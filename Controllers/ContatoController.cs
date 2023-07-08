using Microsoft.AspNetCore.Mvc;
using OficinaPimpolho.Data;
using OficinaPimpolho.Models;
using OficinaPimpolho.Repositorio;

namespace OficinaPimpolho.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio contatoRepositorio;
        public ContatoController(OficinaPimpolhoContext context)
        {
            contatoRepositorio = new ContatoRepositorio(context);
        }

        public IActionResult Index()
        {
            var Oficinas = contatoRepositorio.ObterOficinas();
            return View(Oficinas);
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Editar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit()
        {

            return RedirectToAction("Index");
        }

        public IActionResult Apagar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Oficina oficina) {
            contatoRepositorio.Adicionar(oficina);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Apagar(int Id) {
            Oficina oficina = contatoRepositorio.ObterOficinasId(Id);
            contatoRepositorio.Apagar(oficina);
            return RedirectToAction("Index");
        }

    }
}
