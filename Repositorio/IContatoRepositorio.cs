using OficinaPimpolho.Models;

namespace OficinaPimpolho.Repositorio
{
    public interface IContatoRepositorio
    {
        Oficina Adicionar(Oficina oficina);
        List<Oficina> ObterOficinas();
        bool Apagar (int id);
        Oficina ObterOficinasId (int Id);
        void Atualizar(Oficina oficina);
        Marcacao Adicionar(Marcacao marcacao);
        List<Marcacao> ObterMarcacao();
        Marcacao ObterMarcacaoId (int Id);
        void Atualizar(Marcacao marcacao);
        bool ApagarMarcacao (int id);
            }

}
