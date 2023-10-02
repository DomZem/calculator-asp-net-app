using calculator_asp_net_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace calculator_asp_net_app.Controllers
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

        public IActionResult Calculator(Calculator calculator)
        {

            switch(calculator.Operation)
            {
                case "+": 
                    ViewBag.Result = calculator.FirstNumber + calculator.SecondNumber;
                    break;
                case "-":
                    ViewBag.Result = calculator.FirstNumber - calculator.SecondNumber;
                    break;
                case "*":
                    ViewBag.Result = calculator.FirstNumber * calculator.SecondNumber;
                    break;
                case "/":
                    if (calculator.SecondNumber == 0)
                        ViewBag.Result = "You cannot divide by zero!!!";
                    else 
                        ViewBag.Result = calculator.FirstNumber / calculator.SecondNumber;
                    break;
                default:
                    ViewBag.Result = "Unexpected error. Try maybe later!";
                    break;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}