using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OficinaPimpolho.Models
{
    public class Cliente
    {
        /// <summary>
        /// Identificador do Cliente
        /// </summary>
        [Key] 
        public int IdClientes { get; set; }

        /// <summary>
        /// Nome Próprio do Cliente
        /// </summary>
        [Required(ErrorMessage = "O Nome é de preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "O primeiro nome não pode conter mais que 50 letras.\n Se for necessário abrevie o seu nome.")]
        [Column("PrimeiroNome")]
        [Display(Name = "Primeiro Nome")]
        public String PrimeiroNome { get; set; }

        /// <summary>
        /// Apelido do Cliente
        /// </summary>
        [Required(ErrorMessage = "O Apelido é de preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "O primeiro nome não pode conter mais que 50 letras.\n Se for necessário abrevie o seu nome.")]
        [Column("Apelido")]
        [Display(Name = "Apelido")]
        public String Apelido { get; set; }

        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public String NomeCliente
        {
            get { return PrimeiroNome + " " + Apelido; }
        }

        /// <summary>
        /// Data de Nascimento do Cliente
        /// </summary>
        [Required(ErrorMessage = "Data de Nascimento obrigatória")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        /// <summary>
        /// Email do Cliente
        /// </summary>
        [StringLength(50, ErrorMessage = "O email não pode ter mais de 50 caracteres.")]
        [EmailAddress(ErrorMessage = "O email introduzido não é válido.")]
        [Required(ErrorMessage = "Deve escrever o seu email.")]
        [Display(Name = "Email")]
        public String Email { get; set; }

        /// <summary>
        /// Morada do Cliente
        /// </summary>
        [Required(ErrorMessage = "A Morada é de preenchimento obrigatório")]
        [StringLength(60, ErrorMessage = "A morada não pode ter mais de 60 caracteres.")]
        [Display(Name = "Morada")]
        public String Morada { get; set; }

        /// <summary>
        /// Código Postal do Cliente
        /// </summary>
        [Required(ErrorMessage = "Deve escrever o código postal")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "O código postal deve ter entre 30 e 8 caracteres.")]
        [Display(Name = "Código Postal")]
        public String CodPostal { get; set; }

        /// <summary>
        /// Número de Telemóvel do Cliente
        /// </summary>
        [Required(ErrorMessage = "Deve escrever o Número de telemóvel")]
        [StringLength(14, MinimumLength = 9, ErrorMessage = "O número deve ter entre 9 e 14 caracteres.")]
        [Display(Name = "Número de telemóvel")]
        [RegularExpression("(00)?([0-9]{2,3})?[1-9][0-9]{8}", ErrorMessage = "Escreva, por favor, um nº de telemóvel com 9 algarismos. Se quiser, pode acrescentar o indicativo nacional e o internacional.")]
        public String Ntelemovel { get; set; }


        public Marcacao? Marcacao { get; set; }

    }
}
