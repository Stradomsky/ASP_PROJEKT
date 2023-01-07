using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBookApp.Data.Configuration;
using PhoneBookApp.Data.Entities;
using PhoneBookApp.Data.Repositories;
using PhoneBookApp.Logic.Services.PhoneBooks;

namespace PhoneBookWeb
{
    // Apka webowa to tak naprawd� apka consolowa, kt�ra ma biblioteki ASP.NET mi�dzy innymi z przestrzeni nazw  Microsoft.AspNetCore, kt�re ogarniaj� ��dania HTTP i inne web�wkowe rzeczy
    // Podspodem znajduje si� konfiguracja apki, tu mo�na zdefiniowa� wszystkie jej zachowania, mapowanie request� na kontrolery i akcje (MVC), wszelkie wstrzykiwanie zale�no�ci (DI), itp
    // Zycie apki zaczyna si� w metodzie app.Run();

    // MVC - bardzo popularna architektura apek webowych Model View Controller
    // Model - klasy modeli
    // View - Widoki (HTML) zwracane do ��dania
    // Controller - Klasa tworzona automatycznie na podstawie przychodz�cego ��dania, jej zadaniem jest wywo�a� logik� programu i zwr�ci� odpowiedni widok
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // https://localhost/Home/Index
            // 1 "argument" czy tam cz�on uri (po domenie) jest mapowany na controller, a nast�pny na akcj� (metod� kontrolera)

            builder.Services.AddTransient<IPhoneBookService, PhoneBookService>();
            builder.Services.AddTransient<IRepository<PhoneBook>, Repository<PhoneBook>>();
            builder.Services.AddSingleton<PhoneBookAppContext>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=PhoneBook}/{action=Index}/{id?}");

            app.Run();
        }
    }
}