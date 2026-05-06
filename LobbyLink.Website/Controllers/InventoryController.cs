using LobbyLink.APIClient;
using LobbyLink.DataAccess.Model;
using LobbyLink.Website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LobbyLink.Website.Controllers;

public class InventoryController : Controller
{
    readonly ItemInstanceApiClient _itemInstanceApiClient =
    new("https://localhost:8888/api/v1/iteminstances");

    readonly ListingApiClient _listingApiClient =
        new ListingApiClient("https://localhost:8888/api/v1/listings");

    readonly AccountApiClient _accountApiClient =
        new AccountApiClient("https://localhost:8888/api/v1/accounts");

    //shows the inventory with all items
    // Inventory/Account/
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

    public IActionResult InventoryInspect(int itemInstanceId)
    {
        var item = _itemInstanceApiClient.GetItemInstanceById(itemInstanceId);

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

    // Inventory/Sell/
    [HttpPost]
    public IActionResult Sell(int itemInstanceId, decimal price)
    {
        try
        { 
        ItemInstance itemInstance = _itemInstanceApiClient.GetItemInstanceById(itemInstanceId);

            //Pris skal være positiv og mindst 0.01 dollars! 
            if (price < 0.01m)
            {
                TempData["ErrorMessage"] = "Something went wrong when setting the price, try again!.";
                return RedirectToAction($"Account", new { id = itemInstance.AccountId });
            }

            Listing listing = new Listing
            {
                Price = price,
                StatusId = 1,
                ItemInstanceId = itemInstance.ItemInstanceId,
                SellerAccountId = itemInstance.Account.AccountId,
                CreationTimeStamp = DateTime.Now
            };

            _listingApiClient.ValidateAndInsertListing(listing);

            TempData["SuccessMessage"] = "Listing created successfully.";
            return RedirectToAction("Account", new { id = listing.SellerAccountId });
        }
        catch
        {
            TempData["ErrorMessage"] = $"Something went wrong when trying to sell Item with id: {itemInstanceId}!";
            return RedirectToAction("Account");
        }
    }
}
