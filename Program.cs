using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OficinaPimpolho.Data;
using OficinaPimpolho.Models;
using OficinaPimpolho.Repositorio;

public class Program
{
    public static async Task Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("OficinaPimpolhoContextConnection") ?? throw new InvalidOperationException("Connection string 'OficinaPimpolhoContextConnection' not found.");
        // Configura��o da base de dados
        builder.Services.AddDbContext<OficinaPimpolhoContext>(options =>
            options.UseSqlServer(connectionString));
        // Configura��o da autentica��o e autoriza��o
        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<OficinaPimpolhoContext>();

        // Adiciona servi�os ao container
        builder.Services.AddControllersWithViews();
        //builder.Services.AddScoped<IOficinaRepositorio, OficinaRepositorio>();
        builder.Services.AddRazorPages();
        var app = builder.Build();

        // Configurar o pipeline de solicita��o HTTP
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication(); ;

        app.UseAuthorization();
        // Mapeamento de rota padr�o
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        using (var scope = app.Services.CreateScope())
        {
            var roleManager =
                scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            // Configura��o inicial dos roles 
            var roles = new[] { "Gestor", "Cliente" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string gestorEmail = "gestor@gestor.com";
            string gestorPassword = "Gestor1234,";

            if (await userManager.FindByEmailAsync(gestorEmail) == null)
            {
                var context = scope.ServiceProvider.GetRequiredService<OficinaPimpolhoContext>();
                var gestorUser = new IdentityUser();
                gestorUser.UserName = gestorEmail;
                gestorUser.Email = gestorEmail;
                // Cria��o de usu�rio e associa��o ao papel "Gestor"
                await userManager.CreateAsync(gestorUser, gestorPassword);

                await userManager.AddToRoleAsync(gestorUser, "Gestor");

                // Cria��o um novo gestor
                var gestor = new Gestor
                {
                    IdGestor = 1,
                    Nome = "Gestor",
                    Email = "gestor@gestor.com",
                    Ntelemovel = "912345678",
                    OficinaId = 1 
                };

                //Adiciona gestor � tabela 
                context.Gestor.Add(gestor);
                await context.SaveChangesAsync();
            }
        }



        app.Run();

    }
}