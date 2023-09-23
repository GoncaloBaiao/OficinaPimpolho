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
            // Obtém as marcações e os serviços e os passa para a view
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
            // Retorna a view para criar uma nova marcação
            return View();
        }

        [Authorize(Roles = "Gestor")]
        [HttpGet]
        public IActionResult Editar(int Id)
        {
            // Retorna a view para editar uma marcação com o ID especificado
            Marcacao marcacao = oficinaRepositorio.ObterMarcacaoId(Id);

            return View(marcacao);
        }   

        [Authorize(Roles = "Gestor")]
        [HttpPost]
        public IActionResult Edit(Marcacao marcacao)
        {
            // Atualiza os detalhes de uma marcação com base nos dados fornecidos
            oficinaRepositorio.Atualizar(marcacao);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Gestor")]
        public IActionResult ApagarConfirmacao(int Id)
        {
            // Retorna a view para confirmar a exclusão de uma marcação com o ID especificado
            var marcacao = oficinaRepositorio.ObterMarcacaoId(Id);
            return View(marcacao);
        }


        [HttpPost]
        [Authorize(Roles = "Gestor")]
        public async Task<IActionResult> Criar([FromBody] UploadMarcacao marcacao)
        {
            // Cria uma nova marcação com os dados fornecidos
            // Adiciona serviços associados à marcação
            Marcacao marcacaoRecord = new Marcacao
            {
                Nome = marcacao.Name,
                Preco = 160,
                DataMarcacao = DateTime.Now,
                MarcacaoServico = new List<MarcacaoServico>() // Inicializa a coleção
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
            // Remove uma marcação com o ID especificado
            oficinaRepositorio.Apagar(Id);
            return RedirectToAction("Index");
        }

        public List<Marcacao> ObterMarcacoes()
        {
            // Obtém a lista de marcações
            return oficinaRepositorio.ObterMarcacao();
        }




    }
}