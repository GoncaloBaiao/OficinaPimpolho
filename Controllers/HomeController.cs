using Microsoft.AspNetCore.Mvc;
using MVC_oficinas.Models;
using OficinaPimpolho.Models;
using System.Diagnostics;

namespace OficinaPimpolho.Controllers
{
    public class HomeController : Controller
    {
/*        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
*/
        public IActionResult Index()
        {
            // Método para a página inicial
            return View();
        }

        public IActionResult Privacy()
        {
            // Método para a página de privacy
            return View();
        }
        // Método para a página "about"
        // Aceita um modelo AboutViewModel como parâmetro e retorna a view correspondente
        public IActionResult About(AboutViewModel aboutViewModel)
        {
            return View(aboutViewModel);
        }

        // Método para lidar com erros
        // Retorna uma view de erro com informações sobre o erro ocorrido
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Retorna a view de erro com um objeto ErrorViewModel que contém informações sobre o erro
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}