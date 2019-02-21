using System.Diagnostics;
using Demo.IBLL;
using Microsoft.AspNetCore.Mvc;
using Demo.Web.MVC.Models;

namespace Demo.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IDemoBLL _demoBll;
        public HomeController(IDemoBLL demoBll)
        {
            _demoBll = demoBll;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = $"Your application description page. {_demoBll.GetHello("方")}";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
