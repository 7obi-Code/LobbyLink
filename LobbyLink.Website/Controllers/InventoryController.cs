using LobbyLink.APIClient;
using Microsoft.AspNetCore.Mvc;

namespace LobbyLink.Website.Controllers;

public class InventoryController : Controller
{
    readonly ItemInstanceApiClient _itemInstanceApiClient =
    new("https://localhost:7094/api/v1/iteminstance");

    //shows the inventory with all items
    public IActionResult Index(int accountId)
    {
        var allItemInstances = _itemInstanceApiClient.GetAllItemInstances();
        return View(allItemInstances);
    }

    //ItemInstance/Account
    public IActionResult Account(int accountId)
    {
        var allItemInstancesForAccount = _itemInstanceApiClient.GetAllItemInstancesByAccountId(accountId);
        return View(allItemInstancesForAccount);
    }
}
