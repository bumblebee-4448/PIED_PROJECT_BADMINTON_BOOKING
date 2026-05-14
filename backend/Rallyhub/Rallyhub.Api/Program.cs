using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Quartz;
using Rallyhub.Api.Extention;
using Rallyhub.Api.Middleware;
using Rallyhub.Repository;
using Rallyhub.Service.BackgroundJobService;
using TetPee.Api.Extention;
using JwtService = Rallyhub.Service.JwtService;
using MailService = Rallyhub.Service.MailService;
using IdentityService = Rallyhub.Service.IdentityService;
using UserService = Rallyhub.Service.User;
using OtpService = Rallyhub.Service.OtpService;
using CourtService = Rallyhub.Service.Court;
using MediaService = Rallyhub.Service.MediaService;
using CloudinaryService = Rallyhub.Service.CloudinaryService;
using AdminService = Rallyhub.Service.Admin;
using CustomerService = Rallyhub.Service.Customer;
using OwnerService = Rallyhub.Service.Owner;
using MapService = Rallyhub.Service.MapService;
using TransactionService = Rallyhub.Service.Transaction;
using WalletService = Rallyhub.Service.Wallet;
using BookingService = Rallyhub.Service.Booking;
using WithdrawalService = Rallyhub.Service.Withdrawal;
using NotificationService = Rallyhub.Service.Notification;
using SepayService = Rallyhub.Service.SepayService;
using FeedbackService = Rallyhub.Service.Feadback;
using ValidationService = Rallyhub.Service.Validation;
using FeadbackService = Rallyhub.Service.Feadback;
using CampaignService = Rallyhub.Service.Campaign;
using DashboardService = Rallyhub.Service.Dashboard;
// using DiscordService = Rallyhub.Service.DiscordService;

var builder = WebApplication.CreateBuilder(args);

// Set default culture to InvariantCulture (dot as decimal separator)
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

// Add services to the container.



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddJwtServices(builder.Configuration);
builder.Services.AddSwaggerServices();

builder.Services.AddScoped<JwtService.IService, JwtService.Service>();
builder.Services.AddScoped<MailService.IService, MailService.Service>();
builder.Services.AddScoped<IdentityService.IService, IdentityService.Service>();
// builder.Services.AddHttpClient<DiscordService.IService, DiscordService.Service>();
builder.Services.AddScoped<UserService.IService, UserService.Service>();
builder.Services.AddScoped<OtpService.IService, OtpService.Service>();
builder.Services.AddScoped<CourtService.IService, CourtService.Service>();
builder.Services.AddScoped<MapService.IService, MapService.Service>();
builder.Services.AddScoped<MediaService.IService, CloudinaryService.Service>();
builder.Services.AddScoped<AdminService.IService, AdminService.Service>();
builder.Services.AddScoped<CustomerService.IService, CustomerService.Service>();
builder.Services.AddScoped<OwnerService.IService, OwnerService.Service>();
builder.Services.AddScoped<TransactionService.IService, TransactionService.Service>();
builder.Services.AddScoped<WalletService.IService, WalletService.Service>();
builder.Services.AddScoped<BookingService.IService, BookingService.Service>();
builder.Services.AddScoped<WithdrawalService.IService, WithdrawalService.Service>();
builder.Services.AddScoped<SepayService.IService, SepayService.Service>();
builder.Services.AddScoped<NotificationService.IService, NotificationService.Service>();
builder.Services.AddScoped<FeedbackService.IService, FeedbackService.Service>();
builder.Services.AddScoped<ValidationService.IService, ValidationService.Service>();
builder.Services.AddScoped<CampaignService.IService, CampaignService.Service>();
builder.Services.AddScoped<FeadbackService.IService, FeadbackService.Service>();
builder.Services.AddScoped<DashboardService.IService, DashboardService.Service>();



builder.Services.AddHttpClient("VietMap", client =>
{
    client.Timeout = TimeSpan.FromSeconds(10);
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "RallyHub";
});

builder.Services.AddQuartz(options =>
{
    var bookingJobKey = new JobKey(nameof(BookingTimeoutJob));
    var bookingDetailJobKey = new JobKey(nameof(BookingDetailTimeJob));
    options.AddJob<BookingTimeoutJob>(bookingJobKey)
        .AddTrigger(trigger => trigger
            .ForJob(bookingJobKey)
            .WithSimpleSchedule(schedule => schedule
                .WithIntervalInSeconds(10)
                .RepeatForever()
            ));

    options.AddJob<BookingDetailTimeJob>(bookingDetailJobKey)
        .AddTrigger(trigger => trigger
            .ForJob(bookingDetailJobKey)
            .WithSimpleSchedule(schedule => schedule
                .WithIntervalInSeconds(10)
                .RepeatForever()
            ));
});
builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true; 
});

builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

builder.Services.AddQuartzHostedService(opt => opt.WaitForJobsToComplete = true);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.SetIsOriginAllowed(origin => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();



app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseCors("AllowAll");

app.UseSwaggerAPI();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();