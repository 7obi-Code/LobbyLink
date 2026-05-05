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

    public IActionResult Listings(string? game, int? minPrice, int? maxPrice, string? sort, string? search)
    {
        var listings = _listingApiClient.GetFilteredListings(game, minPrice, maxPrice, sort, search);

        var allListingsForGames = _listingApiClient.GetAllActiveListings();

        ViewBag.Games = allListingsForGames
            .Where(l => l.ItemInstance.ItemDefinition.Game != null)
            .Select(l => l.ItemInstance.ItemDefinition.Game.GameTitle)
            .Distinct()
            .ToList();

        return View(listings);
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

    //Marketplace/Searchbar
    [HttpGet]
    public IActionResult Search(string query)
    {
        var listings = _listingApiClient.GetAllActiveListings();

        var results = listings
            .Where(l => l.ItemInstance.ItemDefinition.ItemName
                .Contains(query, StringComparison.OrdinalIgnoreCase))
            .Select(l => new {
                itemName = l.ItemInstance.ItemDefinition.ItemName
            })
            .Distinct()
            .OrderBy(x => x.itemName)
            .ToList();

        return Json(results);
    }


}