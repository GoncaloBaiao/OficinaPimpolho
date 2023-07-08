namespace OficinaPimpolho.Models
{
    public class OficinaServico
    {
        public int OficinaId { get; set; }
        public Oficina Oficina { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}
