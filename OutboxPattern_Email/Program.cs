using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OutboxPattern_Email.EmailOutboxService;
using OutboxPattern_Email.EmailOutboxService.BackgroundServices;
using OutboxPattern_Email.EmailOutboxService.Service;
using OutboxPattern_Email.EmailService;
using OutboxPattern_Email.Models;
using OutboxPattern_Email.OrderService;
using System;

var builder = WebApplication.CreateBuilder(args);



// Register AppDbContext
var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(connectionString));


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IEmailOutbox, EmailOutboxes>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddSingleton<IEmailBackgroundServices,EmailBackgroundServices>();
builder.Services.AddHostedService<EmailBackgroundService>();
#region Email Configuration
// Email Configuration

var emailSettings = new EmailSettings();
builder.Configuration.Bind(EmailSettings.SectionName, emailSettings);
builder.Services.AddSingleton(Options.Create(emailSettings));
builder.Services.AddSingleton<IMailService, EmailService>();
#endregion
var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
