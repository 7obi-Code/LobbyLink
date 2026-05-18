using LobbyLink.APIClient;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.Website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LobbyLink.Website.Controllers
{
    public class HomeController : Controller
    {
        //Controller action som returnere vores Landing Page view (Index)
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Claims()
        {
            var claims = User.Claims
                .Select(c => $"{c.Type}: {c.Value}");

            return Content(string.Join("\n", claims));
        }
    }
}
