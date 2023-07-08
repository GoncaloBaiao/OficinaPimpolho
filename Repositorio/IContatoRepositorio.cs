using OficinaPimpolho.Models;

namespace OficinaPimpolho.Repositorio
{
    public interface IContatoRepositorio
    {
        Oficina Adicionar(Oficina oficina);
        List<Oficina> ObterOficinas();
        Oficina Apagar (Oficina oficina);
        Oficina ObterOficinasId (int Id);
    }

}
