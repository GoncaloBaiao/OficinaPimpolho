using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OficinaPimpolho.Models
{
    public class Marcacao
    {
        /// <summary>
        /// Identificador da Marcação
        /// </summary>
        [Key]
        public int IdMarcacao { get; set; }

        /// <summary>
        /// Nome do Gestor
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "O nome não pode conter mais que 50 letras.\n Se for necessário abrevie o nome.")]
        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        public double Preco { get; set; }

        [Required]
        public ICollection<MarcacaoServico> MarcacaoServico { get; set; }

    }
}
