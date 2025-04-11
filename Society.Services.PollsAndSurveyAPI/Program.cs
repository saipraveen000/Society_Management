
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Society.Services.PollsAndSurveyAPI.Data;
using Society.Services.PollsAndSurveyAPI.Repository;
using Society.Services.PollsAndSurveyAPI.Services;
using System.Text;

namespace Society.Services.PollsAndSurveyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("PollDb"));

            builder.Services.AddScoped<IPollRepository, PollRepository>();
            builder.Services.AddScoped<IPollService, PollService>();

            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKeyHere"))
                    };
                });

            builder.Services.AddAuthorization();

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
