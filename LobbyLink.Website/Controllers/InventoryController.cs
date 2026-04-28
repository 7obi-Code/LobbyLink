using LobbyLink.APIClient;
using LobbyLink.DataAccess.Model;
using Microsoft.AspNetCore.Mvc;

namespace LobbyLink.Website.Controllers;

public class InventoryController : Controller
{
    readonly ItemInstanceApiClient _itemInstanceApiClient =
    new("https://localhost:7148/api/v1/iteminstance");

    readonly ListingApiClient _listingApiClient =
        new ListingApiClient("https://localhost:7148/api/v1/listing");

    //shows the inventory with all items
    // Inventory/Account/{id}
    public IActionResult Account(int id)
    {
        var allItemInstancesForAccount = _itemInstanceApiClient.GetAllItemInstancesByAccountId(id);
        return View(allItemInstancesForAccount);
    }

    public IActionResult InventoryInspect(int itemInstanceId)
    {
        var item = _itemInstanceApiClient.GetItemInstanceById(itemInstanceId);
        return View(item);
    }

    // Inventory/Sell/{id}
    [HttpPost]
    public IActionResult Sell(int itemInstanceId, decimal price)
    {
        try
        {
            ItemInstance itemInstance = _itemInstanceApiClient.GetItemInstanceById(itemInstanceId);

            if (itemInstance == null)
            {
                return Content("ItemInstance was not found.");
            }

            if (price <= 0)
                return Content("Price must be a positive number.");

            if (decimal.Round(price, 2) != price)
                return Content("Price can only have two decimal numbers.");

            Listing listing = new Listing
            {
                Price = price,
                StatusId = 1,
                ItemInstanceId = itemInstance.ItemInstanceId,
                SellerAccountId = itemInstance.Account.AccountId,
                CreationTimeStamp = DateTime.Now
            };

            _listingApiClient.ValidateAndInsertListing(listing);

            return Content("Listing created successfully.");
        }
        catch 
        {
            return Content("Listing was not created");
        }
    }
}
