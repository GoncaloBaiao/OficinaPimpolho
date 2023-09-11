using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OficinaPimpolho.Data;
using OficinaPimpolho.Models;
using OficinaPimpolho.Repositorio;
using System.Data;

namespace OficinaPimpolho.Controllers
{
    
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio contatoRepositorio;
        public ContatoController(OficinaPimpolhoContext context)
        {
            contatoRepositorio = new ContatoRepositorio(context);
        }
        [Authorize(Roles = "Cliente,Gestor")]
        public IActionResult Index()
        {
            var Oficinas = contatoRepositorio.ObterOficinas();
            return View(Oficinas);
        }
        [Authorize(Roles = "Gestor")]
        public IActionResult Criar()
        {
            return View();
        }
        [Authorize(Roles = "Gestor")]
        [HttpGet]
        public IActionResult Editar(int Id)
        {
            Oficina oficina = contatoRepositorio.ObterOficinasId(Id);

            return View(oficina);
        }
        [Authorize(Roles = "Gestor")]
        [HttpPost]
        public IActionResult Edit(Oficina oficina)
        {

            contatoRepositorio.Atualizar(oficina);
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Gestor")]
        public IActionResult ApagarConfirmacao(int Id)
        {
            var oficina = contatoRepositorio.ObterOficinasId(Id);
            return View(oficina);
        }


        [HttpPost]
        [Authorize(Roles = "Gestor")]
        public async Task<IActionResult> Criar(Oficina oficina)
        {

            contatoRepositorio.Adicionar(oficina);
            return RedirectToAction("Index");
        }



        [Authorize(Roles = "Gestor")]
        public IActionResult Apagar(int Id) {
            contatoRepositorio.Apagar(Id);
            return RedirectToAction("Index");
        }

    }
}
