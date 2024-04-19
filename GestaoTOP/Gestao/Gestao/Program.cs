using Gestao.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BuscaCEP.Service;

var builder = WebApplication.CreateBuilder(args);
//APONTAMENTO DO BANCO
//APOS O "AddDbContext" INDICAR ONDE ESTA O METODO CONTRUTOR DO BANCO (NomeProjeto.Pasta.Classe)
builder.Services.AddDbContext<Gestao.Data.IESContext>(options =>
{
    options.UseSqlServer(builder
        .Configuration
        .GetConnectionString("Gestao")); /*MESMO NOME QUE NO APPSETTINGS*/
});


// INJEÇÃO DE DEPENDÊNCIA E SINGLETON
builder.Services.AddHttpClient();
builder.Services.AddSingleton<CorreiosService>();

//builder.Services.AddDefaultIdentity<IdentityUser>()
//    .AddDefaultTokenProviders()
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<IESContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
     .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IESContext>();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<IESContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

AppDBInicializer.Seed(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
