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
            // Retorna a view "Index" com a lista de oficinas
            var Oficinas = oficinaRepositorio.ObterOficinas();
            return View(Oficinas);
        }
        [Authorize(Roles = "Gestor")]
        public IActionResult Criar()
        {
            // Retorna a view para criar uma nova oficina
            return View();
        }
        [Authorize(Roles = "Gestor")]
        [HttpGet]
        public IActionResult Editar(int Id)
        {
            // Retorna a view para editar uma oficina com o ID especificado
            Oficina oficina = oficinaRepositorio.ObterOficinasId(Id);

            return View(oficina);
        }
        [Authorize(Roles = "Gestor")]
        [HttpPost]
        public IActionResult Edit(Oficina oficina)
        {
            // Atualiza os detalhes de uma oficina
            oficinaRepositorio.Atualizar(oficina);
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Gestor")]
        public IActionResult ApagarConfirmacao(int Id)
        {
            // Retorna a view para confirmar a exclusão de uma oficina com o ID especificado
            var oficina = oficinaRepositorio.ObterOficinasId(Id);
            return View(oficina);
        }


        [HttpPost]
        [Authorize(Roles = "Gestor")]
        public async Task<IActionResult> Criar(Oficina oficina, IFormFile upload)
        {
            // Cria uma nova oficina e faz o upload de uma imagem associada
            if (upload != null && upload.Length > 0) {
                var fileName = Path.GetFileName(upload.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                oficina.Image = fileName;
                oficinaRepositorio.Adicionar(oficina);
                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await upload.CopyToAsync(fileSrteam);
                }
                
            }return RedirectToAction("Index");
        }



        [Authorize(Roles = "Gestor")]
        public IActionResult Apagar(int Id) {
            // Remove uma oficina com o ID especificado
            oficinaRepositorio.Apagar(Id);
            return RedirectToAction("Index");
        }

    }
}
