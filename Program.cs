using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OficinaPimpolho.Data;
using OficinaPimpolho.Repositorio;

public class Program
{
    public static async Task Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("OficinaPimpolhoContextConnection") ?? throw new InvalidOperationException("Connection string 'OficinaPimpolhoContextConnection' not found.");

        builder.Services.AddDbContext<OficinaPimpolhoContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<OficinaPimpolhoContext>();

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        //builder.Services.AddScoped<IOficinaRepositorio, OficinaRepositorio>();
        builder.Services.AddRazorPages();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
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

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        using (var scope = app.Services.CreateScope())
        {
            var roleManager =
                scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

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
                var gestorUser = new IdentityUser();
                gestorUser.UserName = gestorEmail;
                gestorUser.Email = gestorEmail;

                await userManager.CreateAsync(gestorUser, gestorPassword);

                await userManager.AddToRoleAsync(gestorUser, "Gestor");
            }
        }



        app.Run();

    }
}