using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OficinaPimpolho.Data;
using OficinaPimpolho.Models;
using OficinaPimpolho.Repositorio;
using System.Data;

namespace OficinaPimpolho.Controllers
{
    
    public class OficinasController : Controller
    {
        private readonly IOficinaRepositorio oficinaRepositorio;
        public OficinasController(OficinaPimpolhoContext context)
        {
            oficinaRepositorio = new OficinaRepositorio(context);
        }
        [Authorize(Roles = "Cliente,Gestor")]
        public IActionResult Index()
        {
            var Oficinas = oficinaRepositorio.ObterOficinas();
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
            Oficina oficina = oficinaRepositorio.ObterOficinasId(Id);

            return View(oficina);
        }
        [Authorize(Roles = "Gestor")]
        [HttpPost]
        public IActionResult Edit(Oficina oficina)
        {

            oficinaRepositorio.Atualizar(oficina);
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Gestor")]
        public IActionResult ApagarConfirmacao(int Id)
        {
            var oficina = oficinaRepositorio.ObterOficinasId(Id);
            return View(oficina);
        }


        [HttpPost]
        [Authorize(Roles = "Gestor")]
        public async Task<IActionResult> Criar(Oficina oficina)
        {
            oficinaRepositorio.Adicionar(oficina);
            return RedirectToAction("Index");
        }



        [Authorize(Roles = "Gestor")]
        public IActionResult Apagar(int Id) {
            oficinaRepositorio.Apagar(Id);
            return RedirectToAction("Index");
        }

    }
}
