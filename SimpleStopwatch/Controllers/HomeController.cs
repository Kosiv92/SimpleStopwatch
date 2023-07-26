using Microsoft.AspNetCore.Mvc;
using SimpleStopwatch.Models;
using System.Diagnostics;
using System.Text;

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

            StringBuilder stringBuilder = new StringBuilder();

            if (interval.Minutes != 0)
            {
                AddTimeGradation(stringBuilder, interval.Minutes, "минут");
            }
            if (interval.Seconds != 0)
            {
                AddTimeGradation(stringBuilder, interval.Seconds, "секунд");
            }
            if (interval.Milliseconds != 0)
            {
                AddTimeGradation(stringBuilder, interval.Milliseconds, "миллисекунд");
            }

            model.TimeToPrint = stringBuilder.ToString();

            return View(model);
        }

        private void AddTimeGradation(StringBuilder sb, int time, string gradation)
        {
            sb.Append(time.ToString());
            int preLastDigit = time % 10;
            if(time>9 && time < 21) sb.Append($" {gradation}а ");
            switch (preLastDigit)
            {
                case 1:
                    sb.Append($" {gradation}а ");
                    break;
                case 2:
                case 3:
                case 4:
                    if(time > 20) sb.Append($" {gradation}ы ");
                    else sb.Append($" {gradation} ");                    
                    break;
                default:
                    sb.Append($" {gradation} ");
                    break;
            }
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