using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       
        
        // use it i not in dev env (to appear error occured with out deteals )
        // there is view called (error) in shared folder means any controllerr can use it not related to specific controller 
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
