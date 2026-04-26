using Microsoft.EntityFrameworkCore;
using Quartz;
using Rallyhub.Api.Extention;
using Rallyhub.Api.Middleware;
using Rallyhub.Repository;
using JwtService = Rallyhub.Service.JwtService;
using MailService = Rallyhub.Service.MailService;
using IdentityService = Rallyhub.Service.IdentityService;
using UserService = Rallyhub.Service.User;
// using DiscordService = Rallyhub.Service.DiscordService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//đăng kí DI cho AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddJwtServices(builder.Configuration);

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<JwtService.IService, JwtService.Service>();
builder.Services.AddScoped<MailService.IService, MailService.Service>();
builder.Services.AddScoped<IdentityService.IService, IdentityService.Service>();
// builder.Services.AddScoped<DiscordService.IService, DiscordService.Service>();
builder.Services.AddScoped<UserService.IService, UserService.Service>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "RallyHub";
});

builder.Services.AddQuartz();

builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

builder.Services.AddQuartzHostedService(opt => opt.WaitForJobsToComplete = true);

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();