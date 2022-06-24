using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SwaggerGenOpenApi;
using web.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IClient _HttpClient;

        public HomeController(ILogger<HomeController> logger, IClient httpClient)
        {
            _logger = logger;
            _HttpClient = httpClient;
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}