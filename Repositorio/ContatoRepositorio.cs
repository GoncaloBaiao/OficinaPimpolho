using Microsoft.EntityFrameworkCore;
using OficinaPimpolho.Data;
using OficinaPimpolho.Models;

namespace OficinaPimpolho.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly OficinaPimpolhoContext _context;
        public ContatoRepositorio(OficinaPimpolhoContext pimpolhoContext)
        {
            this._context = pimpolhoContext;
        }
        public Oficina Adicionar(Oficina oficina)
        {
            _context.Oficina.Add(oficina);
            _context.SaveChanges();
            return oficina;
        }

        public List<Oficina> ObterOficinas()
        {
            return _context.Oficina.ToList();
        }



        public void Atualizar(Oficina oficina)
        {
            Oficina oficinaDb = ObterOficinasId(oficina.IdOficina);
            if (oficinaDb != null)
            {
                oficinaDb.Nome = oficina.Nome;
                oficinaDb.Localidade = oficina.Localidade;
                oficinaDb.CodigoPostal = oficina.CodigoPostal;
                oficinaDb.NumTelemovel = oficina.NumTelemovel;

                _context.Oficina.Update(oficinaDb);
                _context.SaveChanges();
            }
                
        }
        public Oficina ObterOficinasId(int Id)
        {
            return _context.Oficina.Find(Id);
        }

        public bool Apagar(int id)
        {
            Oficina oficinaDb = ObterOficinasId(id);
            if (oficinaDb == null) throw new System.Exception("Houve um erro");
            _context.Remove(oficinaDb);
            _context.SaveChanges();
            return true;
    

        }

        public Marcacao Adicionar(Marcacao marcacao)
        {
            _context.Marcacao.Add(marcacao);
            _context.SaveChanges();
            return marcacao;
        }

        public List<Marcacao> ObterMarcacao()
        {
            return _context.Marcacao.ToList();
        }

        public Marcacao ObterMarcacaoId(int Id)
        {
            return _context.Marcacao.Find(Id);
        }

        public void Atualizar(Marcacao marcacao)
        {
            Marcacao marcacaoDb = ObterMarcacaoId(marcacao.IdMarcacao);
            if (marcacaoDb != null)
            {
                marcacaoDb.Nome = marcacao.Nome;
                marcacaoDb.Preco = marcacao.Preco;
                marcacaoDb.DataMarcacao = marcacao.DataMarcacao;
                marcacaoDb.MarcacaoServico = marcacao.MarcacaoServico;

                _context.Marcacao.Update(marcacaoDb);
                _context.SaveChanges();
            }
        }

        public bool ApagarMarcacao(int id)
        {
            Marcacao marcacaoDb = ObterMarcacaoId(id);
            if (marcacaoDb == null) throw new System.Exception("Houve um erro");
            _context.Remove(marcacaoDb);
            _context.SaveChanges();
            return true;
        }

        public List<Servico> ObterServicos()
        {
            return _context.Servico.ToList();
        }

        public Servico ObterServicoId(int Id)
        {
            return _context.Servico.Find(Id);
        }
    }
}