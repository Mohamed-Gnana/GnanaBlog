using Blog.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Blog.Application.Artichles.Query.GetArtichlesList;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetArtichlesListQuery _artichlesListQuery;

        public HomeController(
            ILogger<HomeController> logger,
            IGetArtichlesListQuery getArtichlesListQuery)
        {
            _logger = logger;
            _artichlesListQuery = getArtichlesListQuery;
        }

        public async Task<IActionResult> Index()
        {
            var artichles = await _artichlesListQuery.Execute();
            return View(artichles);
        }

        [Authorize]
        public async Task<IActionResult> Privacy()
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