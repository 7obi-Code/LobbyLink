using LobbyLink.Website.Models;
using LobbyLink.APIClient;
using LobbyLink.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LobbyLink.Website.Controllers
{
    public class HomeController : Controller
    {

        readonly ItemInstanceApiClient _itemInstanceApiClient =
            new("https://localhost:7094/api/v1/iteminstance");

        //shows the inventory with all items
        public IActionResult Index()
        {
            var allItemInstances = _itemInstanceApiClient.GetAllItemInstances();
            return View(allItemInstances);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
