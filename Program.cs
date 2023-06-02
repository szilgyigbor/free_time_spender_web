using FreeTimeSpenderWeb.Services;
using Microsoft.EntityFrameworkCore;
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
            builder.Services.AddControllers();
            builder.Services.AddHttpClient();

            builder.Services.AddDbContext<FreeTimeSpenderContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
            ));
            builder.Services.AddTransient<INewsService, NewsService>();
            builder.Services.AddTransient<IBotService, BotService>();
            builder.Services.AddTransient<IFlickrService, FlickrService>();
            builder.Services.AddTransient<IWeatherService, WeatherService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}