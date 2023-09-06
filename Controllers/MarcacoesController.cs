using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Cliente,Gestor")]
        public IActionResult Index()
        {
            var marcacoes = contatoRepositorio.ObterMarcacao();
            var viewModel = new MarcacaoViewModel
            {
                MarcacaoList = marcacoes,
                Serviços = contatoRepositorio.ObterServicos()
            };
    

        return View(viewModel);
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
            Marcacao marcacao = contatoRepositorio.ObterMarcacaoId(Id);

            return View(marcacao);
        }

        [Authorize(Roles = "Gestor")]
        [HttpPost]
        public IActionResult Edit(Marcacao marcacao)
        {

            contatoRepositorio.Atualizar(marcacao);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Gestor")]
        public IActionResult ApagarConfirmacao(int Id)
        {
            var marcacao = contatoRepositorio.ObterMarcacaoId(Id);
            return View(marcacao);
        }

        [Authorize(Roles = "Gestor")]
        [HttpPost]
        public IActionResult Criar( Marcacao marcacao)
        {
            Servico servico = contatoRepositorio.ObterServicoId(1);
            List<MarcacaoServico> marcacaoServicos = new List<MarcacaoServico> { new MarcacaoServico { MarcacaoId = 1, ServicoId = 1, Marcacao = marcacao, Servico = servico } };
            marcacao.MarcacaoServico = marcacaoServicos;

            Marcacao marcacaoRecord = contatoRepositorio.Adicionar(marcacao);
            
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Gestor")]
        public IActionResult Apagar(int Id)
        {
            contatoRepositorio.Apagar(Id);
            return RedirectToAction("Index");
        }

    }
}