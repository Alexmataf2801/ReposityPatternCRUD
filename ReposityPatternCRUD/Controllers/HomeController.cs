using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models.Models;
using ReposityPattern.Repository;
using ReposityPatternCRUD.Models;
using System.Diagnostics;

namespace ReposityPatternCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository<Beer> _repository; 

        public HomeController(ILogger<HomeController> logger, IRepository<Beer> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var t = _repository.GetAll();
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