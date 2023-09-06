// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using OficinaPimpolho.Data;
using OficinaPimpolho.Models;

namespace OficinaPimpolho.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly OficinaPimpolhoContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            OficinaPimpolhoContext context
,
            RoleManager<IdentityRole> roleManager

            )
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Model usado para 'transportar' os dados para a interface de'Registar'
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        /// serve para redirecionar o utilizador para o 'local' de origem
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [StringLength(50, ErrorMessage = "O email não pode ter mais de 50 caracteres.")]
            [EmailAddress(ErrorMessage = "O email introduzido não é válido.")]
            [Required(ErrorMessage = "Deve escrever o seu email.")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "A sua password deve ter um mínimo de 6 caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "A password e a sua confirmação não correspondem.")]
            public string ConfirmPassword { get; set; }

            /// <summary>
            /// Ao anexar um objeto deste tipo ao 'InpuModel' estamos a 
            /// permitir a recolha dos dados do Cliente
            /// </summary>
            public Cliente Cliente { get; set; }
        }

        /// <summary>
        /// método a ser executado pela página, quando o HTTP é invocado em GET
        /// </summary>
        /// <param name="returnUrl">link para redirecionar o utilizador, se fornecido</param>
        /// <returns></returns>
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }
        /// <summary>
        /// método a ser executado pela página, quando o HTTP é invocado em POST
        ///    - criar um novo Utilizador
        ///    - registar os dados pessoais do cliente
        /// </summary>
        /// <param name="returnUrl">link para redirecionar o utilizador, se fornecido</param>
        /// <returns></returns>
        /// 

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            // não preciso de especificar uma variável de adição de dados da 'view'
            // a este método, pq essa variável já está previamente definida no
            // atributo 'Input'
            //   public InputModel Input { get; set; }

            // se o 'returnUrl' for null, é-lhe atribuído um URL
            // se não for Null, nada é feito
            //returnUrl ??= Url.Content("~/");

            // ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            // validar se se pode criar um USER
            // Se os dados forem validados pela classe 'InputModel'
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            
                // criar um objeto do tipo 'ApplicationUser'
                var user = new IdentityUser
                {
                    UserName = Input.Email, // username
                    Email = Input.Email,
                    PhoneNumber = Input.Cliente.Ntelemovel,// email do utilizador
                    EmailConfirmed = true, // o email não está formalmente confirmado
                    LockoutEnabled = true,  // o utilizador pode ser bloqueado
                    LockoutEnd = new DateTime(DateTime.Now.Day, 1, 1),  // data em que termina o bloqueio,
                                                                        // se não for anulado antes 
                };





                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    Input.Cliente.Email = Input.Email;

                    // estamos em condições de guardar os dados na BD
                    try
                    {
                        _context.Add(Input.Cliente); // adicionar o Cliente
                        await _context.SaveChangesAsync(); // 'commit' da adição
                                                           // Enviar para o utilizador para a página de confirmação da criaçao de Registo
                                                           // Verifica se o papel "Cliente" existe, se não existir, cria-o
                    if (!await _roleManager.RoleExistsAsync("Cliente"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Cliente"));
                    }

                    // Adiciona o usuário ao papel "Cliente"
                    await _userManager.AddToRoleAsync(user, "Cliente");

                    // Resto do código



                    return RedirectToPage("RegisterConfirmation");
                    }
                    catch (Exception)
                    {
                        // houve um erro na criação dos dados do Cliente
                        // Mas, o USER já foi criado na BD
                        // vou efetuar o Roolback da ação
                        await _userManager.DeleteAsync(user);

                        // avisar que houve um erro
                        ModelState.AddModelError("", "Ocorreu um erro na criação de dados");
                    }


                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            

            // If we got this far, something failed, redisplay form
            return Page();
        }



        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
    }
}
