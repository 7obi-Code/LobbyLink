using LobbyLink.APIClient;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using LobbyLink.Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LobbyLink.Website.Controllers;

public class MarketplaceController : Controller
{
    readonly ListingApiClient _listingApiClient =
        new("https://localhost:7094/api/v1/listings");

    readonly ItemInstancesApiClient _itemInstanceApiClient =
        new("https://localhost:7094/api/v1/iteminstances");

    public IActionResult Listings()
    {
        var allListings = _listingApiClient.GetAllActiveListings();

        Console.WriteLine($"Listings count: {allListings.Count()}");

        return View(allListings);
    }

    //Marketplace/MarketInspect/"listingId"
    public IActionResult MarketInspect(int listingId)
    {
        Listing? listing = _listingApiClient.GetActiveListingById(listingId);

        return View(listing);
    }


    //Marketplace/Buy
    [HttpPost]
    public IActionResult Buy(int buyerAccountId, int listingId)
    {
        try
        {
            if (buyerAccountId <= 0) 
            {
                return Content("not valid buyerAccountId.");
            }

            bool result = _listingApiClient.BuyListing(buyerAccountId, listingId);
            
            if (!result)
            {
                return Content("Item was not bought");
            }

            return Content("Item Was Bought.");
        }
        catch
        {
            return Content("Item was not bought");
        }
    }
}