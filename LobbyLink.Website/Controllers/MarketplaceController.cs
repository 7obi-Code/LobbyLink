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
        new("https://localhost:7094/api/v1/listing");

    readonly ItemInstanceApiClient _itemInstanceApiClient =
        new("https://localhost:7094/api/v1/iteminstance");

    public IActionResult Listings()
    {
        var allListings = _listingApiClient.GetAllActiveListings();

        Console.WriteLine($"Listings count: {allListings.Count()}");

        return View(allListings);
    }

    public IActionResult MarketInspect(int listingId)
    {
        var listing = _listingApiClient.GetListingById(listingId);

        return View(listing);
    }

    public IActionResult Buy(int buyerAccountId, int listingId)
    {
        try
        {
            //apiClient.GetListingById();
            //Account account = accountApiClient.GetAccountById(buyerAccountId);
            if (buyerAccountId <= 0) //Tilføj || account != NULL (MIDLERTIDIG LØSNING)
            {
                return Content("not valid buyerAccountId.");
            }

            if (listing == null)
            {
                return Content("listing was null.");
            }

            listing.BuyerAccountId = buyerAccountId;

            _listingApiClient.BuyListing(listing);

            return Content("Item Was Bought.");
        }
        catch
        {
            return Content("Item was not bought");
        }
    }
}