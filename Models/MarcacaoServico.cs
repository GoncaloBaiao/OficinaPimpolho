namespace OficinaPimpolho.Models
{
    public class MarcacaoServico
    {
        public int MarcacaoId { get; set; }
        public Marcacao Marcacao { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}
