using LinkLobby.Web.Models;
using LobbyLink.APIClient;
using LobbyLink.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LinkLobby.Web.Controllers
{
    public class HomeController : Controller
    {

        IFItemInstanceDao _itemInstanceApiClient = new ItemInstanceApiClient("https://localhost:7148/api/v1/itemInstance");

        //shows the inventory with all items
        public IActionResult Index()
        {
            var AllItemInstances = _itemInstanceApiClient.GetAllItemInstance();
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
