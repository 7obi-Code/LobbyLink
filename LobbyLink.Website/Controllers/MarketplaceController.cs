 using LobbyLink.APIClient;
using LobbyLink.DataAccess.Model;
using LobbyLink.Website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LobbyLink.Website.Controllers;

public class MarketplaceController : Controller
{
    private readonly ListingApiClient _listingApiClient;

    private readonly AccountApiClient _accountApiClient;

    private readonly GameApiClient _gameApiClient;

    public MarketplaceController(ListingApiClient listingApiClient, AccountApiClient accountApiClient, GameApiClient gameApiClient)
    {
        _listingApiClient = listingApiClient;
        _accountApiClient = accountApiClient;
        _gameApiClient = gameApiClient;
    }

    //Action controller der finder tilgængelige listings ud fra ønskede filtre. Hvis ingen filtre er angivet, læser den alle ind.
    public IActionResult Listings(string? game = null, int? minPrice = null, int? maxPrice = null, string? sort = null, string? search = null)
    {
        //Guardrails til at sikre at søgningen er mindst 3 tegn og at minPrice ikke er højere end maxPrice
        if (search != null && search.Length < 3)
        {
            TempData["ErrorMessage"] = "Search must be at least 3 characters long";
            return RedirectToAction("Listings");
        }

        if (minPrice != null && maxPrice != null && minPrice > maxPrice)
        {
            TempData["ErrorMessage"] = "Min price cannot be higher than max price";
            return RedirectToAction("Listings");
        }

        //Få alle spilnavne ud til dropdown ved brug ad LINQ
        List<String> gameTitles = _gameApiClient.GetAllGames().Select(g => g.GameTitle).ToList();

        var marketPlaceViewModel = new MarketPlaceViewModel
        {
            Game = game,
            MinPrice = minPrice,
            MaxPrice = maxPrice,
            Sort = sort,
            Search = search,
            Listings = _listingApiClient.GetFilteredListings(game, minPrice, maxPrice, sort, search),

            //bruger listen af dropdown
            GamesTitles = gameTitles
        };

        return View(marketPlaceViewModel);
    }

    //Marketplace/MarketInspect?"listingId"
    //Action Controller til at se detaljer om et ItemInstance og en knap til at kalde Buy actionen
    [Authorize]
    [HttpGet("MarketPlace/MarketInspect/{listingId}")]
    public IActionResult MarketInspect(int listingId)
    {
        Listing? listing = _listingApiClient.GetActiveListingById(listingId);

        return View(listing);
    }


    //Marketplace/Buy?"listingId"
    [HttpPost]
    //Action Controller til at kalde Api klientens GetAccountIdByEmail og BuyListing metoder
    public IActionResult Buy(int listingId)
    {
        try
        {
            var accountEmail = User.FindFirst("email")?.Value;

            if (accountEmail == null)
            {
                throw new Exception("Couldnt find user email");
            }

            var buyerAccountId = _accountApiClient.GetAccountIdByEmail(accountEmail);

            _listingApiClient.BuyListing(buyerAccountId, listingId);

            TempData["SuccessMessage"] = "Item was purchased successfully!"; 
            return RedirectToAction("Listings");
        }
        catch (ArgumentException aex)
        {
            TempData["ErrorMessage"] = aex.Message; 
            return RedirectToAction("Listings");
        }
        catch (Exception ex) 
        {
            TempData["ErrorMessage"] = "Der skete en uventet fejl, prøv igen";
            Console.WriteLine(ex.Message);
            return RedirectToAction("Listings");
        }
    }
}