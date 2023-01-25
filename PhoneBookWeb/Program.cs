using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBookApp.Data.Configuration;
using PhoneBookApp.Data.Entities;
using PhoneBookApp.Data.Repositories;
using PhoneBookApp.Logic.Services.PhoneBooks;
using PhoneBookApp.Logic.Services.Users;

namespace PhoneBookWeb
{
    // Apka webowa to tak naprawdê apka consolowa, która ma biblioteki ASP.NET miêdzy innymi z przestrzeni nazw  Microsoft.AspNetCore, które ogarniaj¹ ¿¹dania HTTP i inne webówkowe rzeczy
    // Podspodem znajduje siê konfiguracja apki, tu mo¿na zdefiniowaæ wszystkie jej zachowania, mapowanie requestów na kontrolery i akcje (MVC), wszelkie wstrzykiwanie zale¿noœci (DI), itp
    // Zycie apki zaczyna siê w metodzie app.Run();

    // MVC - bardzo popularna architektura apek webowych Model View Controller
    // Model - klasy modeli
    // View - Widoki (HTML) zwracane do ¿¹dania
    // Controller - Klasa tworzona automatycznie na podstawie przychodz¹cego ¿¹dania, jej zadaniem jest wywo³aæ logikê programu i zwróciæ odpowiedni widok
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // https://localhost/Home/Index
            // 1 "argument" czy tam cz³on uri (po domenie) jest mapowany na controller, a nastêpny na akcjê (metodê kontrolera)

            builder.Services.AddSingleton<PhoneBookAppContext>();

            builder.Services.AddSingleton<IPhoneBookService, PhoneBookService>();
            builder.Services.AddSingleton<IUserService, UserService>();

            builder.Services.AddTransient<IRepository<PhoneBook>, Repository<PhoneBook>>();
            builder.Services.AddTransient<IRepository<User>, Repository<User>>();

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

            // Widok od którego zacznie siê apka
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=SignIn}");

            app.Run();
        }
    }
}