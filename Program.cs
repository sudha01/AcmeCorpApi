using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AcmeCorpAPI.Data;
using AcmeCorpAPI.Services;
using System.Configuration;
using AcmeCorpAPI.Data.Models;

namespace AcmeCorpAPI
{
    public class Program
    {    
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection") ?? throw new InvalidOperationException("Connection string 'SqliteConnection' not found.")));

            CreateHostBuilder(args).Build().Run();

            // Add services to the container.
            builder.Services.AddControllers();
            //builder.Services.AddDbContext();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}