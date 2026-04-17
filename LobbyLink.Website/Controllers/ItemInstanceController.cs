using LobbyLink.Website.Models;
using LobbyLink.APIClient;
using LobbyLink.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LobbyLink.Website.Controllers
{
    public class ItemInstanceController : Controller
    {

        IFItemInstanceDao _itemInstanceApiClient = new ItemInstanceApiClient("https://localhost:7148/api/v1/iteminstances");

        //shows the inventory with all items
        public IActionResult Index()
        {
            var AllItemInstances = _itemInstanceApiClient.GetAllItemInstances();
            return View(AllItemInstances);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
