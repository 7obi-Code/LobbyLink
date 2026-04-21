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

    public IActionResult Listings()
    {
        var allListings = _listingApiClient.GetAllActiveListings();
        return View(allListings);
    }
}