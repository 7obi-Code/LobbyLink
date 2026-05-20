using LobbyLink.APIClient;
using LobbyLink.DataAccess.Model;
using LobbyLink.Website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LobbyLink.Website.Controllers;

public class InventoryController : Controller
{
    private readonly ItemInstanceApiClient _itemInstanceApiClient;

    private readonly ListingApiClient _listingApiClient;

    private readonly AccountApiClient _accountApiClient;

    public InventoryController(ItemInstanceApiClient itemInstanceApiClient, ListingApiClient listingApiClient, AccountApiClient accountApiClient)
    {
        _itemInstanceApiClient = itemInstanceApiClient;
        _listingApiClient = listingApiClient;
        _accountApiClient = accountApiClient;
    }

    // */Inventory/Account/
    // Controller Action til at fremvise en bruger som er logget ind (Kræver log ind ved brug af Authorize)
    [Authorize]
    public IActionResult Account()
    {
        var accountEmail = User.FindFirst("email")?.Value;

        if (accountEmail == null)
        {
            throw new Exception("Couldnt find user email");
        }

        var accountId = _accountApiClient.GetAccountIdByEmail(accountEmail);

        var allItemInstancesForAccount = _itemInstanceApiClient.GetAllItemInstancesByAccountId(accountId);

        var model = allItemInstancesForAccount.Select(item => new InventoryItemViewModel
        {
            ItemInstanceId = item.ItemInstanceId,
            ItemName = item.ItemDefinition?.ItemName,
            Description = item.ItemDefinition?.ItemDescription,
            AccountOwner = item.Account?.UserName,
            GameTitle = item.ItemDefinition?.Game?.GameTitle,
            IsListedForSale = _listingApiClient.IsItemInstanceListed(item.ItemInstanceId)
        }).ToList();

        return View(model);
    }

    // */InventoryInspect
    //Controller til at se detaljer om et ItemInstance og indsætte pris hvis det ikke allerede er Listed
    [Authorize]
    [HttpGet("Inventory/InventoryInspect/{itemInstanceId}")]
    public IActionResult InventoryInspect(int itemInstanceId)
    {
        try
        {
            var item = _itemInstanceApiClient.GetItemInstanceById(itemInstanceId);

            if (item == null)
            {
                throw new Exception($"Couldnt find item with id {itemInstanceId}");
            }

            var accountEmail = User.FindFirst("email")?.Value;

            if (accountEmail == null)
            {
                throw new Exception("Couldnt find user email");
            }

            var accountId = _accountApiClient.GetAccountIdByEmail(accountEmail);
            //Tjek at ejeren faktisk er den person der er inde på itemet

            //Hvis de ikke matcher, redirect til Account
            if (item.AccountId != accountId)
            {
                return RedirectToAction("Account");
            }

            var itemModel = new InventoryItemViewModel
            {
                ItemInstanceId = item.ItemInstanceId,
                ItemName = item.ItemDefinition?.ItemName,
                Description = item.ItemDefinition?.ItemDescription,
                AccountOwner = item.Account?.UserName,
                GameTitle = item.ItemDefinition?.Game?.GameTitle,
                IsListedForSale = _listingApiClient.IsItemInstanceListed(item.ItemInstanceId)
            };

            return View(itemModel);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Something went wrong when trying to inspect: {itemInstanceId}! - error was {ex.Message}";
            return RedirectToAction("Account");
        }
    }

    // Inventory/Sell/
    //Action controller der opretter en listing ud fra den indtastede pris
    [HttpPost]
    public IActionResult Sell(int itemInstanceId, decimal price)
    {
        try
        { 
        ItemInstance itemInstance = _itemInstanceApiClient.GetItemInstanceById(itemInstanceId);

            if (itemInstance == null)
            {
                TempData["ErrorMessage"] = "Item was not found";
                return RedirectToAction($"Account");
            }

            if (price < 0.01m)
            {
                TempData["ErrorMessage"] = "Something went wrong when setting the price, try again!.";
                return RedirectToAction($"Account");
            }

            Listing listing = new Listing
            {
                Price = price,
                StatusId = 1,
                ItemInstanceId = itemInstance.ItemInstanceId,
                SellerAccountId = itemInstance.AccountId,
                CreationTimeStamp = DateTime.Now
            };

            _listingApiClient.ValidateAndInsertListing(listing);

            TempData["SuccessMessage"] = "Listing created successfully.";
            return RedirectToAction("Account");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Something went wrong when trying to sell Item with id: {itemInstanceId}! - error was {ex.Message}";
            return RedirectToAction("Account");
        }
    }
}
