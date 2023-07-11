namespace OficinaPimpolho.Models
{
    public class MarcacaoViewModel
    {

        public Marcacao Marcacao { get; set; } = null;

        public List<Marcacao> MarcacaoList { get; set; } 

        public List<Servico> Serviços { get; set; }
    }
}
