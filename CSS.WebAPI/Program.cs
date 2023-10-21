using CSS.Application.Services.Interfaces;
using CSS.Application.Utilities.TokenUtilities;
using CSS.Infrastructure;
using CSS.Infrastructure.Data;
using CSS.WebAPI;
using CSS.WebAPI.Middlewares;
using Hangfire;
using CSS.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using FirebaseAdmin.Auth;
using CSS.Application.Utilities.EmailUtilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("EmailSetting"));
// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("DefaultConnection")!);
builder.Services.AddWebAPIServices();
builder.AddCSSAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
ApplyMigration();
app.UseCors();
app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseAuthorization();
app.MapHangfireDashboard("/HangfireDashBoard");

app.MapControllers();
app.MapHub<ChatHub>("/chatHub");
RecurringJob.AddOrUpdate<IProposalService>("Update Proposal Done", x => x.CheckProposalDone(), Cron.Hourly );
app.Run();

void ApplyMigration()
{
    using (var scope = app!.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}