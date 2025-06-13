using ControleContatos.Data;
using ControleContatos.Helper;
using ControleContatos.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpenTelemetry;

namespace ControleContatos;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
        builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        builder.Services.AddScoped<ISessao, Sessao>();

        builder.Services.AddSession(o =>
            {o.Cookie.HttpOnly = true;
            o.Cookie.IsEssential = true; 
        });


        //Add services to the container.
        builder.Services.AddControllersWithViews();

       


        builder.Services.AddDbContext<BancoContext>
        (options => options.UseSqlServer
        ("Data Source=DESKTOP-P4CONE2;Initial Catalog=DB_SistemaContatos ;Integrated Security=True;TrustServerCertificate=True"));
        
        

        var app = builder.Build();

       app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseSession();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Login}/{action=Index}/{id?}")
            .WithStaticAssets();
            app.Run();

    }
}

internal class Contexto
{
}