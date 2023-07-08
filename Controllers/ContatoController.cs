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
        public IActionResult Editar(int Id)
        {
            Oficina oficina = contatoRepositorio.ObterOficinasId(Id);

            return View(oficina);
        }

        [HttpPost]
        public IActionResult Edit(Oficina oficina)
        {

            contatoRepositorio.Atualizar(oficina);
            return RedirectToAction("Index");
        }
        


        public IActionResult ApagarConfirmacao(int Id)
        {
            var oficina = contatoRepositorio.ObterOficinasId(Id);
            return View(oficina);
        }
        [HttpPost]
        public IActionResult Criar(Oficina oficina) {
            contatoRepositorio.Adicionar(oficina);
            return RedirectToAction("Index");
        }
        
        public IActionResult Apagar(int Id) {
            contatoRepositorio.Apagar(Id);
            return RedirectToAction("Index");
        }

    }
}
