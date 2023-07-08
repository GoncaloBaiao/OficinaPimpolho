using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace OficinaPimpolho.Models
{
    public class HomeModel
    {
        /// <summary>
        /// Nome do HomeModel
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "O nome não pode conter mais que 50 letras.\n Se for necessário abrevie o nome.")]
        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Email do HomeModel
        /// </summary>
        [StringLength(50, ErrorMessage = "O email não pode ter mais de 50 caracteres.")]
        [EmailAddress(ErrorMessage = "O email introduzido não é válido.")]
        [Required(ErrorMessage = "Deve escrever o seu email.")]
        public String Email { get; set; }
    }
}
