using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestOpenApi;
using TestOpenApi;
using web.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IBooksClient _HttpClient;

        public HomeController(ILogger<HomeController> logger, IBooksClient httpClient)
        {
            _logger = logger;
            _HttpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _HttpClient.BooksGetAsync(null, null, null, null, null, null);

            var listBooks = books.Select(b => new BookModelView()
            {
                Author = b.Author, Title = b.Title, Price = b.Price, Id = b.Id
            }).ToList();
            return View(listBooks);
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