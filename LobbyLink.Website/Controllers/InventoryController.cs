using LobbyLink.APIClient;
using LobbyLink.DataAccess.Model;
using Microsoft.AspNetCore.Mvc;

namespace LobbyLink.Website.Controllers;

public class InventoryController : Controller
{
    readonly ItemInstanceApiClient _itemInstanceApiClient =
    new("https://localhost:7094/api/v1/iteminstance");

    readonly ListingApiClient _listingApiClient =
        new ListingApiClient("https://localhost:7094/api/v1/listing");

    //shows the inventory with all items
    // Inventory/Account/{id}
    public IActionResult Account(int id)
    {
        var allItemInstancesForAccount = _itemInstanceApiClient.GetAllItemInstancesByAccountId(id);
        return View(allItemInstancesForAccount);
    }
<<<<<<< Updated upstream
    public IActionResult InventoryInspect(int itemInstanceId)
    {
        var item = _itemInstanceApiClient.GetItemInstanceById(itemInstanceId);
        return View(item);
=======

    // Inventory/Sell/{id}
    public IActionResult Sell(int id)
    {
        /*bool alreadyListed = _listingApiClient.HasActiveListingForItemInstance(id);

        if (alreadyListed)
        {
            return Content("Item is already listed.");
        }*/

        ItemInstance itemInstance = _itemInstanceApiClient.GetItemInstanceById(id);

        Listing listing = new Listing
        {
            Price = 100.00m,
            Status = ListingStatus.ACTIVE,
            ItemInstanceId = id,
            SellerAccountId = itemInstance.AccountId,
            CreationTimeStamp = DateTime.Now
        };

        _listingApiClient.InsertListing(listing);

        return Content("Listing created successfully.");
>>>>>>> Stashed changes
    }
}
