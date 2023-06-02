using FreeTimeSpenderWeb.Services;
using Microsoft.EntityFrameworkCore;
using FreeTimeSpenderWeb.Models;
using FreeTimeSpenderWeb.Data;
using FreeTimeSpenderWeb.Services.Interfaces;

namespace FreeTimeSpenderWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();

            builder.Services.AddDbContext<FreeTimeSpenderContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
            ));
            builder.Services.AddTransient<INewsService, NewsService>();
            builder.Services.AddTransient<IBotService, BotService>();
            builder.Services.AddTransient<IFlickrService, FlickrService>();
            builder.Services.AddTransient<IWeatherService, WeatherService>();

            /*builder.Services.AddTransient<NewsService>();
            builder.Services.AddTransient<BotService>();
            builder.Services.AddTransient<WeatherService>();
            builder.Services.AddTransient<FlickrService>();*/

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
                pattern: "{controller=Home}/{action=Main}/{id?}");

            app.Run();
        }
    }
}