using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OficinaPimpolho.Models
{
    public class Gestor
    {
        /// <summary>
        /// Identificador do Gestor
        /// </summary>
        [Required]
        [Key]
        public int IdGestor { get; set; }

        /// <summary>
        /// Nome do Gestor
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "O nome não pode conter mais que 50 letras.\n Se for necessário abrevie o nome.")]
        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Email do Gestor
        /// </summary>
        [StringLength(50, ErrorMessage = "O email não pode ter mais de 50 caracteres.")]
        [EmailAddress(ErrorMessage = "O email introduzido não é válido.")]
        [Required(ErrorMessage = "Deve escrever o seu email.")]
        public String Email { get; set; }

        /// <summary>
        /// Número de Telemóvel do Gestor
        /// </summary>
        [StringLength(14, MinimumLength = 9, ErrorMessage = "O número deve ter entre 9 e 14 caracteres.")]
        [RegularExpression("(00)?([0-9]{2,3})?[1-9][0-9]{8}", ErrorMessage = "Escreva, por favor, um nº de telemóvel com 9 algarismos. Se quiser, pode acrescentar o indicativo nacional e o internacional.")]
        public String Ntelemovel { get; set; }

        /// <summary>
        /// Id da Oficina
        /// </summary>
        [Required]
        public int OficinaId { get; set; }
    }
}
