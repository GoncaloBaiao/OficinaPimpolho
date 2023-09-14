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


        [Authorize(Roles = "Gestor")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] UploadMarcacao marcacao)
        {
            //Servico servico = oficinaRepositorio.ObterServicoId(1);//marcacao.MarcacaoServico = marcacaoServicos;

            Marcacao marcacaoRecord = new Marcacao {Nome=marcacao.Name, Preco=160, DataMarcacao= DateTime.Now};//a DateTime.Now tem de ser da marcacao
            List<Servico> lista = new List<Servico>();
            foreach (var Item in marcacao.Servicos) {
                if (oficinaRepositorio.ObterServicoNome(Item) != null)
                {
                    lista.Add(oficinaRepositorio.ObterServicoNome(Item));
                }
            }

            var m = oficinaRepositorio.Adicionar(marcacaoRecord);
            List<MarcacaoServico> marcacaoServicos = new List<MarcacaoServico>();
            foreach (var item in lista) { 
            marcacaoServicos.Add( new MarcacaoServico { MarcacaoId = marcacaoRecord.IdMarcacao, ServicoId = item.IdServico, Marcacao = marcacaoRecord, Servico = item } );
                
            }
            
            m.MarcacaoServico = marcacaoServicos;
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