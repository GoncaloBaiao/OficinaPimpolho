using Microsoft.EntityFrameworkCore;
using OficinaPimpolho.Data;
using OficinaPimpolho.Models;

namespace OficinaPimpolho.Repositorio
{
    public class OficinaRepositorio : IOficinaRepositorio
    {
        private readonly OficinaPimpolhoContext _context; // Contexto da base de dados
        public OficinaRepositorio(OficinaPimpolhoContext pimpolhoContext)
        {
            this._context = pimpolhoContext; // Inicializa o contexto no construtor
        }
        // Implementação do método para adicionar uma oficina
        public Oficina Adicionar(Oficina oficina)
        {

            _context.Oficina.Add(oficina);
            _context.SaveChanges();
            return oficina;
        }
        // Implementação do método para obter todas as oficinas
        public List<Oficina> ObterOficinas()
        {
            return _context.Oficina.ToList();
        }


        // Método para atualizar uma oficina na base de dados
        public void Atualizar(Oficina oficina)
        {    // Obtém a oficina da base de dados com base no ID
            Oficina oficinaDb = ObterOficinasId(oficina.IdOficina);
            // Verifica se a oficina existe
            if (oficinaDb != null)
            {
                // Atualiza os campos da oficina com os valores fornecidos
                oficinaDb.Nome = oficina.Nome;
                oficinaDb.Localidade = oficina.Localidade;
                oficinaDb.Morada = oficina.Morada;
                oficinaDb.CodigoPostal = oficina.CodigoPostal;
                oficinaDb.NumTelemovel = oficina.NumTelemovel;
                // Atualiza a oficina no contexto 
                _context.Oficina.Update(oficinaDb);
                _context.SaveChanges();
            }
                
        }
        // Método para obter uma oficina com base no ID
        public Oficina ObterOficinasId(int Id)
        {
            return _context.Oficina.Find(Id);
        }
        // Método para apagar uma oficina com base no ID
        public bool Apagar(int id)
        {     
            // Obtém a oficina do banco de dados com base no ID
            Oficina oficinaDb = ObterOficinasId(id);
            // Verifica se a oficina existe
            if (oficinaDb == null) throw new System.Exception("Houve um erro");
            _context.Remove(oficinaDb);
            _context.SaveChanges();
            return true;
    

        }
        // Método para adicionar uma marcação na base de dados
        public Marcacao Adicionar(Marcacao marcacao)
        {
            _context.Marcacao.Add(marcacao);
            _context.SaveChanges();
            return marcacao;
        }
        // Método para obter todas as marcações
        public List<Marcacao> ObterMarcacao()
        {
            
            var result = _context.Marcacao.ToList(); 
            return result;
        }
        // Método para obter uma marcação com base no ID
        public Marcacao ObterMarcacaoId(int Id)
        {
            return _context.Marcacao.Find(Id);
        }
        // Método para atualizar uma marcação na base de dados
        public void Atualizar(Marcacao marcacao)
        {
            Marcacao marcacaoDb = ObterMarcacaoId(marcacao.IdMarcacao);
            // Verifica se a marcação existe
            if (marcacaoDb != null)
            {
                // Atualiza os campos da marcação com os valores fornecidos
                marcacaoDb.Nome = marcacao.Nome;
                marcacaoDb.Preco = marcacao.Preco;
                marcacaoDb.DataMarcacao = marcacao.DataMarcacao;
                marcacaoDb.MarcacaoServico = marcacao.MarcacaoServico;
                // Atualiza a marcação 
                _context.Marcacao.Update(marcacaoDb);
                _context.SaveChanges();
            }
        }
        // Método para apagar uma marcação com base no ID
        public bool ApagarMarcacao(int id)
        {
            // Obtém a marcação da base de dados com base no ID
            Marcacao marcacaoDb = ObterMarcacaoId(id);
            // Verifica se a marcação existe
            if (marcacaoDb == null) throw new System.Exception("Houve um erro");
            // Remove a marcação
            _context.Remove(marcacaoDb);
            _context.SaveChanges();
            return true;
        }
        // Método para obter todos os serviços
        public List<Servico> ObterServicos()
        {
            return _context.Servico.ToList();
        }
        // Método para obter um serviço com base no ID
        public Servico ObterServicoId(int Id)
        {
            return _context.Servico.Find(Id);
        }
        // Método para obter um serviço com base no nome
        public Servico ObterServicoNome(string Nome)
        {
            return _context.Servico.Where(o => o.Nome.Equals(Nome)).FirstOrDefault();
        }
        // Método para adicionar uma lista de marcação de serviços
        public List<MarcacaoServico> Adicionar(List<MarcacaoServico> listaMarcacaoServicos)
        {
            return null;
            foreach (var servico in listaMarcacaoServicos)
            {
                
            }
        }
        // Método para salvar as mudanças 
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }



    }
}