using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OficinaPimpolho.Data;
using OficinaPimpolho.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace OficinaPimpolho.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class API : Controller
    {

        private readonly OficinaPimpolhoContext _baseDados;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="baseDados"></param>
        /// <param name="signInManager"></param>
        /// <param name="userManager"></param>
        public API(
            OficinaPimpolhoContext baseDados,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _baseDados = baseDados;
            _signInManager = signInManager;
            _userManager = userManager;
        }


        /// <summary>
        /// Retorna uma lista de oficinas.
        /// </summary>
        /// <returns>Lista de oficinas</returns>
        //[HttpGet("Oficinas/Lista")]
        //public async Task<ActionResult<IEnumerable<OficinaViewModel>>> GetProfessores()
        //{
        //    return await _baseDados.Oficina.OrderBy(p => p.Nome).Select(p => new OficinaViewModel
        //    {
        //        Id = p.IdOficina,
        //        Nome = p.Nome
        //    }).ToListAsync();
        //}

        /// <summary>
        /// Valida se o utilizador existe.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>True: existe; False: não existe</returns>
        private async Task<bool> IsValidUser(string username, string password)
        {

            var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }



        /// <summary>
        /// Gera um token para o utilizador.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Token gerado.</returns>
        private string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Gerar uma chave secreta aleatória com 32 bytes de comprimento
            byte[] keyBytes = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyBytes);
            }

            // Converter a chave em uma string base64 para uso posterior
            string secretKey = Convert.ToBase64String(keyBytes);
            var key = Encoding.ASCII.GetBytes(secretKey); // Substitua pela sua chave secreta

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username)
                }),

                Expires = DateTime.UtcNow.AddDays(7), // Define a expiração do token.
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



        /// <summary>
        /// Efetua o login e verifica se existe na base de dados.
        /// POST: Api/Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Login autorizado ou não autorizado.</returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel.LoginViewModels model)
        {
            // Validar as credenciais do usuário
            if (await IsValidUser(model.Username, model.Password))
            {
                // Crie um token de autenticação para o usuário
                var token = GenerateToken(model.Username);

                // Retorne o token como resposta
                return Ok(token);
            }

            // Se as credenciais forem inválidas, retorne uma resposta de erro
            return BadRequest("Credenciais inválidas.");
        }




    }
}
