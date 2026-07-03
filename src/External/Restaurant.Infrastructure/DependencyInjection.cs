using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Services.Storage;
using Restaurant.Contracts.Settings.Storage;
using Restaurant.Infrastructure.Services.Storage;

namespace Restaurant.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // ── Cloudinary ───────────────────────────────────────────────────
            services.Configure<CloudinarySettings>(
                configuration.GetSection(CloudinarySettings.SectionName));
            services.AddScoped<ICloudinaryService, CloudinaryService>();

            // ── Authentication & Security ────────────────────────────────────
            //services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            //services.AddScoped<IJwtProvider, JwtProvider>();
            //services.AddScoped<IPasswordHasher, PasswordHasher>();
            //services.AddScoped<IEmailService, EmailService>();

            //var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
            //if (jwtSettings != null)
            //{
            //    services.AddAuthentication(options =>
            //    {
            //        options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            //        options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            //    })
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = jwtSettings.Issuer,
            //            ValidAudience = jwtSettings.Audience,
            //            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
            //                System.Text.Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
            //        };
            //    });
            //}

            return services;
        }
    }
}
