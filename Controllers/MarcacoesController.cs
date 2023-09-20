using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OficinaPimpolho.Data;
using OficinaPimpolho.Models;
using OficinaPimpolho.Repositorio;

namespace OficinaPimpolho.Controllers
{
    
    public class MarcacoesController : Controller
    {
        private readonly IOficinaRepositorio oficinaRepositorio;
        public MarcacoesController(OficinaPimpolhoContext context)
        {
            oficinaRepositorio = new OficinaRepositorio(context);
            
        }
        [Authorize(Roles = "Cliente,Gestor")]
        public IActionResult Index()
        {
            var marcacoes = oficinaRepositorio.ObterMarcacao();
            var viewModel = new MarcacaoViewModel
            {
                MarcacaoList = marcacoes,
                Serviços = oficinaRepositorio.ObterServicos()
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
            Marcacao marcacao = oficinaRepositorio.ObterMarcacaoId(Id);

            return View(marcacao);
        }   

        [Authorize(Roles = "Gestor")]
        [HttpPost]
        public IActionResult Edit(Marcacao marcacao)
        {

            oficinaRepositorio.Atualizar(marcacao);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Gestor")]
        public IActionResult ApagarConfirmacao(int Id)
        {
            var marcacao = oficinaRepositorio.ObterMarcacaoId(Id);
            return View(marcacao);
        }


        [HttpPost]
[Authorize(Roles = "Gestor")]
public async Task<IActionResult> Criar([FromBody] UploadMarcacao marcacao)
{
            // Create a new Marcacao
            Marcacao marcacaoRecord = new Marcacao
            {
                Nome = marcacao.Name,
                Preco = 160,
                DataMarcacao = DateTime.Now,
                MarcacaoServico = new List<MarcacaoServico>() // Initialize the collection
            };

            foreach (var item in marcacao.Servicos)
            {
                var servico = oficinaRepositorio.ObterServicoNome(item);
                if (servico != null)
                {
                    marcacaoRecord.MarcacaoServico.Add(new MarcacaoServico
                    {
                        Servico = servico
                    });
                }
            }

            var m = oficinaRepositorio.Adicionar(marcacaoRecord);
            await oficinaRepositorio.Salvar();


            var a = "resultou";
    return new JsonResult(a);
}



        [Authorize(Roles = "Gestor")]
        public IActionResult Apagar(int Id)
        {
            oficinaRepositorio.Apagar(Id);
            return RedirectToAction("Index");
        }

        public List<Marcacao> ObterMarcacoes()
        {
            
            return oficinaRepositorio.ObterMarcacao();
        }




    }
}