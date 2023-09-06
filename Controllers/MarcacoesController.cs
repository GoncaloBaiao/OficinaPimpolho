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
            var marcacoes = contatoRepositorio.ObterMarcacao();
            var viewModel = new MarcacaoViewModel
            {
                MarcacaoList = marcacoes,
                Serviços = contatoRepositorio.ObterServicos()
            };
    

        return View(viewModel);
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
        public async Task<IActionResult> Criar([FromBody] UploadMarcacao marcacao)
        {
            //Servico servico = contatoRepositorio.ObterServicoId(1);//marcacao.MarcacaoServico = marcacaoServicos;

            Marcacao marcacaoRecord = new Marcacao {Nome=marcacao.Name, Preco=160, DataMarcacao= DateTime.Now};//a DateTime.Now tem de ser da marcacao
            List<Servico> lista = new List<Servico>();
            foreach (var Item in marcacao.Servicos) {
                if (contatoRepositorio.ObterServicoNome(Item) != null)
                {
                    lista.Add(contatoRepositorio.ObterServicoNome(Item));
                }
            }

            var m = contatoRepositorio.Adicionar(marcacaoRecord);
            List<MarcacaoServico> marcacaoServicos = new List<MarcacaoServico>();
            foreach (var item in lista) { 
            marcacaoServicos.Add( new MarcacaoServico { MarcacaoId = marcacaoRecord.IdMarcacao, ServicoId = item.IdServico, Marcacao = marcacaoRecord, Servico = item } );
                
            }
            
            m.MarcacaoServico = marcacaoServicos;
            await contatoRepositorio.Salvar();

            var a = "resultou";
            return new JsonResult(a);
        }

        public IActionResult Apagar(int Id)
        {
            contatoRepositorio.Apagar(Id);
            return RedirectToAction("Index");
        }

        public List<Marcacao> ObterMarcacoes()
        {
            
            return contatoRepositorio.ObterMarcacao();
        }



    }
}