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

        public Oficina Apagar(Oficina oficina)
        {
            _context.Oficina.Remove(oficina);
            _context.SaveChanges();
            return oficina;
        }

        public Oficina ObterOficinasId(int Id)
        {
            return _context.Oficina.Find(Id);
        }
    }
}