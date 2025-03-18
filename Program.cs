using Microsoft.EntityFrameworkCore;
using System;

using Microsoft.EntityFrameworkCore;

using Npgsql;
using BackForFrontVue2.Services;

namespace BackForFrontVue2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            builder.Services.AddControllers();
            builder.Services.AddScoped<DatabaseService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowVueApp", policy =>
                    policy.WithOrigins("http://localhost:8080")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
            });
            // Add services to the container.

            builder.Services.AddAuthorization();


            var app = builder.Build();

            app.UseCors("AllowVueApp");

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}