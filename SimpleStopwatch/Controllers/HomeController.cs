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

        [HttpGet]
        public IActionResult Index()
        {                         
            return View();
        }

        [HttpPost]
        public IActionResult Index(TimeViewModel model)
        {
            if (model == null)
            {
                RedirectToAction(nameof(Index));
            }

            TimeSpan interval = TimeSpan.FromMilliseconds(model.Milliseconds);

            model.TimeToPrint = $"h={interval.Hours}, m={interval.Minutes}, s={interval.Seconds}, ms={interval.Milliseconds}";

            return View(model);
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