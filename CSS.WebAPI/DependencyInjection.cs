using CSS.Application.Services;
using CSS.Application.Services.Interfaces;
using CSS.WebAPI.Middlewares;
using CSS.WebAPI.Services;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace CSS.WebAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddWebAPIServices(this IServiceCollection services)
    {
			services.AddHangfire(config => config
			.UseSimpleAssemblyNameTypeSerializer()
			.UseRecommendedSerializerSettings()
			.UseInMemoryStorage());

        services.AddCors(options
                => options.AddDefaultPolicy(policy
                    => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
			services.AddHangfireServer();
        services.AddHttpContextAccessor();
        services.AddScoped<GlobalExceptionMiddleware>();
        services.AddControllers().AddOData(opt => opt.Filter().Select().OrderBy().Count().Filter());
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opt =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
                opt.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Bearer Generated JWT-Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"

                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        }, new string[] { }
                    }
                });
            });
        services.AddScoped<ICurrentTime, CurrentTime>();
        services.AddScoped<IClaimsService, ClaimsService>();
        services.AddRouting(opt => opt.LowercaseUrls = true);
        services.AddSignalR();
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
