using Microsoft.AspNetCore.Mvc;
using OficinaPimpolho.Data;
using OficinaPimpolho.Models;
using OficinaPimpolho.Repositorio;

namespace OficinaPimpolho.Controllers
{
    public class MarcacoesController : Controller 
    { 
    private readonly IContatoRepositorio contatoRepositorio;
    public MarcacoesController(OficinaPimpolhoContext context)
    {
        contatoRepositorio = new ContatoRepositorio(context);
    }

    public IActionResult Index()
    {
        var marcacao = contatoRepositorio.ObterMarcacao();
        return View(marcacao);
    }

    public IActionResult Criar()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Editar(int Id)
    {
        Marcacao marcacao = contatoRepositorio.ObterMarcacaoId(Id);

        return View(marcacao);
    }

    [HttpPost]
    public IActionResult Edit(Marcacao marcacao)
    {

        contatoRepositorio.Atualizar(marcacao);
        return RedirectToAction("Index");
    }



    public IActionResult ApagarConfirmacao(int Id)
    {
        var marcacao = contatoRepositorio.ObterMarcacaoId(Id);
        return View(marcacao);
    }
    [HttpPost]
    public IActionResult Criar(Marcacao marcacao)
    {
        contatoRepositorio.Adicionar(marcacao);
        return RedirectToAction("Index");
    }

    public IActionResult Apagar(int Id)
    {
        contatoRepositorio.Apagar(Id);
        return RedirectToAction("Index");
    }

}
}