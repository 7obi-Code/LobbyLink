using LobbyLink.APIClient;
using LobbyLink.DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using LobbyLink.Website.Models;

namespace LobbyLink.Website.Controllers;

public class InventoryController : Controller
{
    readonly ItemInstancesApiClient _itemInstanceApiClient =
    new("https://localhost:7148/api/v1/iteminstances");

    readonly ListingApiClient _listingApiClient =
        new ListingApiClient("https://localhost:7148/api/v1/listings");

    //shows the inventory with all items
    // Inventory/Account/{id}
    public IActionResult Account(int id)
    {
        var allItemInstancesForAccount = _itemInstanceApiClient.GetAllItemInstancesByAccountId(id);

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
        return View(item);
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
