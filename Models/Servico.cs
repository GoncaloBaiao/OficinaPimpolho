using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaPimpolho.Models
{
    public class Servico
    {
        /// <summary>
        /// Identificador do Serviço
        /// </summary>
        [Key]
        public int IdServico { get; set; }

        /// <summary>
        /// Nome do Servico
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "O nome do serviço não pode conter mais que 50 letras.\n Se for necessário abrevie o nome.")]
        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        public double Preco { get; set; }

        /// <summary>
        /// Lista de Serviços
        /// </summary>
        public ICollection<OficinaServico> OficinaServico { get; set; }

        /// <summary>
        /// Lista de Marcações
        /// </summary>
        public ICollection<MarcacaoServico> MarcacaoServico { get; set; }
    }
}
