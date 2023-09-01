using FreeTimeSpenderWeb.Services;
using Microsoft.EntityFrameworkCore;
using FreeTimeSpenderWeb.Data;
using FreeTimeSpenderWeb.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FreeTimeSpenderWeb.Hubs;
using Npgsql;

namespace FreeTimeSpenderWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("FreeTimeSpenderSecretKey"))),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero,
                };
            });

            builder.Services.AddHttpClient();


            var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
            var databaseUrl = new Uri(connectionString!);
            var userInfo = databaseUrl.UserInfo.Split(':');

            var db = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUrl.Host,
                Port = databaseUrl.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUrl.LocalPath.TrimStart('/'),
                //SslMode = SslMode.Require,
                //TrustServerCertificate = true
            };


            builder.Services.AddDbContext<FreeTimeSpenderContext>(options => options.UseNpgsql(db.ToString()));

            /*builder.Services.AddDbContext<FreeTimeSpenderContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ?.Replace("{SQLPassword}", Environment.GetEnvironmentVariable("SQLPassword"))
            ));*/
            builder.Services.AddTransient<INewsService, NewsService>();
            builder.Services.AddTransient<IBotService, BotService>();
            builder.Services.AddTransient<IFlickrService, FlickrService>();
            builder.Services.AddTransient<IWeatherService, WeatherService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IOpinionService, OpinionService>();
            builder.Services.AddSingleton<IShooterGameService, ShooterGameService>();
            builder.Services.AddTransient<ISortingGameService, SortingGameService>();

            var port = Environment.GetEnvironmentVariable("PORT");
            if (!string.IsNullOrEmpty(port))
            {
                builder.WebHost.UseUrls($"http://*:{port}");
            }

            builder.Services.AddSignalR();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(policy => policy
                .WithOrigins("https://www.digitalisjatszoter.hu", "http://localhost:4200")
                //.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthorization();
            
            app.MapControllers();

            app.MapHub<GameHub>("/gamehub");

            app.Run();
        }
    }
}