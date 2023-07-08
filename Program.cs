using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OficinaPimpolho.Data;
using OficinaPimpolho.Repositorio;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("OficinaPimpolhoContextConnection") ?? throw new InvalidOperationException("Connection string 'OficinaPimpolhoContextConnection' not found.");

builder.Services.AddDbContext<OficinaPimpolhoContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<OficinaPimpolhoContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
