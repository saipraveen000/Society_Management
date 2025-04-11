
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Society.Services.MaintenanceAPI.Data;
using Society.Services.MaintenanceAPI.ExceptionHandling;
using Society.Services.MaintenanceAPI.Repository;
using Society.Services.MaintenanceAPI.Services;

namespace Society.Services.MaintenanceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddCors();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
            builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();

            //builder.Services.AddAuthentication("MockScheme")
             //   .AddScheme<AuthenticationSchemeOptions, MockAuthHandler>("MockScheme", null);
            //builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStaticFiles();
            app.UseCors(policy =>
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());

            //app.UseAuthentication();
            //app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
