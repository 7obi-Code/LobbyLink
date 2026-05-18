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

    public IActionResult Listings(string? game = null, int? minPrice = null, int? maxPrice = null, string? sort = null, string? search = null)
    {
        //Få alle spilnavne ud til dropdown
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

    //Marketplace/MarketInspect/"listingId"
    [Authorize]
    public IActionResult MarketInspect(int listingId)
    {
        Listing? listing = _listingApiClient.GetActiveListingById(listingId);

        return View(listing);
    }


    //Marketplace/Buy
    [HttpPost]
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