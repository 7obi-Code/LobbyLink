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

    public IActionResult MarketInspect(int itemInstanceId, string mode)
    {
        var item = _itemInstanceApiClient.GetItemInstanceById(itemInstanceId);

        ViewBag.Mode = mode;
        return View(item);
    }

}