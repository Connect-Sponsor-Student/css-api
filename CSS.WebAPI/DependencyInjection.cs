using System.Text;
using CSS.Application.Services;
using CSS.Application.Services.Interfaces;
using CSS.Application.Utilities.TokenUtilities;
using CSS.WebAPI.Middlewares;
using CSS.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace CSS.WebAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddWebAPIServices(this IServiceCollection services)
    {
        
        services.AddHttpContextAccessor();
        services.AddScoped<GlobalExceptionMiddleware>();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddScoped<ICurrentTime, CurrentTime>();
        services.AddScoped<IClaimsService, ClaimsService>();
        services.AddRouting(opt => opt.LowercaseUrls = true);
        return services;
    }
    public static WebApplicationBuilder AddCSSAuthentication(this WebApplicationBuilder builder)
		{
			var settingsSection = builder.Configuration.GetSection("JwtOptions");
			var secret = settingsSection.GetValue<string>("Secret");
			var issuer = settingsSection.GetValue<string>("Issuer");
			var audience = settingsSection.GetValue<string>("Audience");
			var key = Encoding.ASCII.GetBytes(secret!);
			builder.Services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(x =>
			{
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = true,
					ValidIssuer = issuer,
					ValidAudience = audience,
					ValidateAudience = true
				};
			});
			builder.Services.AddAuthentication();
			return builder;
		}
}
