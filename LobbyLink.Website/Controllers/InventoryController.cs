using LobbyLink.APIClient;
using Microsoft.AspNetCore.Mvc;

namespace LobbyLink.Website.Controllers;

public class InventoryController : Controller
{
    readonly ItemInstanceApiClient _itemInstanceApiClient =
    new("https://localhost:7094/api/v1/iteminstance");

    //shows the inventory with all items
    // Inventory/Account/{id}
    public IActionResult Account(int id)
    {
        var allItemInstancesForAccount = _itemInstanceApiClient.GetAllItemInstancesByAccountId(id);
        return View(allItemInstancesForAccount);
    }
}
