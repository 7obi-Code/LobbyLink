using LobbyLink.APIClient;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using LobbyLink.Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

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
                TempData["ErrorMessage"] = "Not a valid BuyerAccountId!.";
                return RedirectToAction("MarketInspect", new { id = listingId});
            }

            bool result = _listingApiClient.BuyListing(buyerAccountId, listingId);
            
            if (!result)
            {
                TempData["ErrorMessage"] = "Something went wrong when buying the Item!."; //Dette problem skal vi have løst så det er mere specifikt
                return RedirectToAction("Listings");
            }

            TempData["SuccessMessage"] = "Item was purchased successfully!"; 
            return RedirectToAction("Listings");
        }
        catch
        {
            TempData["ErrorMessage"] = "Something went wrong when buying the Item!."; //Dette problem skal vi have løst så det er mere specifikt
            return RedirectToAction("Listings");
        }
    }
}