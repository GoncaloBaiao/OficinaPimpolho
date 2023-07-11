using Microsoft.AspNetCore.Mvc;

namespace OficinaPimpolho.Controllers
{
    public class MarcacoesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}