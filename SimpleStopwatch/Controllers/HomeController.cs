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
                AddTimeGradation(stringBuilder, interval.Minutes, "минута", "минуты", "минут");
            }
            if (interval.Seconds != 0)
            {
                AddTimeGradation(stringBuilder, interval.Seconds, "секунда", "секунды", "секунд");
            }
            if (interval.Milliseconds != 0)
            {
                AddTimeGradation(stringBuilder, interval.Milliseconds, "миллисекунда", "миллисекунды", "миллисекунд");
            }

            model.TimeToPrint = stringBuilder.ToString();

            return View(model);
        }

        private void AddTimeGradation(StringBuilder sb, int time,
            string fstPostFix, string  secPostFix, string thrdPostFix)
        {
            sb.Append(time.ToString());
            int preLastDigit = time % 10;
            switch (preLastDigit)
            {
                case 1:
                    sb.Append($" {fstPostFix} ");
                    break;
                case 2:
                case 3:
                case 4:
                    if(time > 20) sb.Append($" {secPostFix} ");
                    else sb.Append($" {thrdPostFix} ");                    
                    break;
                default:
                    sb.Append($" {thrdPostFix} ");
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