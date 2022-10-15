using Microsoft.AspNetCore.Mvc;
using Senfoni.Satis.Webui.Models;

namespace Senfoni.Satis.Webui.Controllers
{
    public class HomeController:Controller
    {

        public HomeController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}