namespace OficinaPimpolho.Models
{
    public class LoginViewModel
    {

        /// <summary>
        /// Esta class contém os dados de login do React para o MVC.
        /// </summary>
        public class LoginViewModels
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        /// <summary>
        /// Esta classe colecta os dados dos Alunos para a API.
        /// </summary>
        public class Gestor
        {
            public int IdGestor { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public int Ntelemovel { get; set; }
            public string OficinaId { get; set; }
        }
    }
}
