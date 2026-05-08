using LobbyLink.APIClient;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using LobbyLink.Website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace LobbyLink.Website.Controllers;

public class MarketplaceController : Controller
{
    readonly ListingApiClient _listingApiClient =
        new("https://localhost:8888/api/v1/listings");

    readonly ItemInstanceApiClient _itemInstanceApiClient =
        new("https://localhost:8888/api/v1/iteminstances");

    readonly AccountApiClient _accountApiClient =
        new AccountApiClient("https://localhost:8888/api/v1/accounts");

    readonly GameApiClient _gameApiClient = 
        new GameApiClient("https://localhost:8888/api/v1/games");

    public IActionResult Listings(string? game, int? minPrice, int? maxPrice, string? sort, string? search)
    {
        var listings = _listingApiClient.GetFilteredListings(game, minPrice, maxPrice, sort, search);

        ViewBag.Games = _gameApiClient.GetAllGames()
            .Select(g => g.GameTitle)
            .ToList();

        return View(listings);
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
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message; 
            return RedirectToAction("Listings");
        }
    }
}