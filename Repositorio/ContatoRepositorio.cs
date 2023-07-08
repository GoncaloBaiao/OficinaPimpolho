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
    }
}