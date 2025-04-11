
using Society.Services.NotificationAPI.Data;
using Society.Services.NotificationAPI.ExceptionHandling;
using Society.Services.NotificationAPI.Repository;
using Society.Services.NotificationAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Society.Services.NotificationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Add services
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("AlertsDB")); // Use SQL Server in prod

            /*builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
            {
                options.Audience = "api1";
                options.Authority = "https://your-auth-provider.com"; // IdentityServer4 / Auth0 / etc.
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("ResidentOnly", policy => policy.RequireRole("Resident"));
            });*/

            builder.Services.AddScoped<IAlertRepository, AlertRepository>();
            builder.Services.AddScoped<IAlertService, AlertService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();



            // Middleware
            app.UseMiddleware<ExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
