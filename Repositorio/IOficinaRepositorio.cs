using OficinaPimpolho.Models;

namespace OficinaPimpolho.Repositorio
{
    public interface IOficinaRepositorio
    {
        // Métodos para adicionar, obter, atualizar e apagar informações sobre oficinas
        Oficina Adicionar(Oficina oficina);
        List<Oficina> ObterOficinas();
        bool Apagar (int id);
        Oficina ObterOficinasId (int Id);
        void Atualizar(Oficina oficina);
        // Métodos para adicionar, obter, atualizar e apagar informações sobre marcações
        Marcacao Adicionar(Marcacao marcacao);
        List<Marcacao> ObterMarcacao();
        Marcacao ObterMarcacaoId (int Id);
        void Atualizar(Marcacao marcacao);
        bool ApagarMarcacao (int id);
        // Métodos para obter informações sobre serviços
        List<Servico> ObterServicos();

        Servico ObterServicoId(int Id);

        Servico ObterServicoNome(string Nome);
        // Método para adicionar uma lista de marcação de serviços 
        List<MarcacaoServico> Adicionar(List<MarcacaoServico> listaMarcacaoServicos);
        Task Salvar();
    }



}
