using Microsoft.AspNetCore.Mvc;
using SimpleStopwatch.Models;
using System.Diagnostics;

namespace SimpleStopwatch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string? time)
        {
           if(time != null)
            {                
                ViewBag.Time = time;
            }
            
            return View(time);
        }

        [HttpPost]
        public IActionResult Time(string? ms)
        {
            if(ms == null || ms == "")
            {
                RedirectToAction(nameof(Index));
            }

            return View(ms);

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