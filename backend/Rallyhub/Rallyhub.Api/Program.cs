using Microsoft.EntityFrameworkCore;
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
// using DiscordService = Rallyhub.Service.DiscordService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
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
// builder.Services.AddScoped<DiscordService.IService, DiscordService.Service>();
builder.Services.AddScoped<UserService.IService, UserService.Service>();
builder.Services.AddScoped<OtpService.IService, OtpService.Service>();
builder.Services.AddScoped<CourtService.IService, CourtService.Service>();
builder.Services.AddScoped<MapService.IService, MapService.Service>();
builder.Services.AddScoped<MediaService.IService, CloudinaryService.Service>();
builder.Services.AddScoped<AdminService.IService, AdminService.Service>();
builder.Services.AddScoped<CustomerService.IService, CustomerService.Service>();
builder.Services.AddScoped<OwnerService.IService, OwnerService.Service>();





builder.Services.AddHttpClient("VietMap", client =>
{
    client.Timeout = TimeSpan.FromSeconds(10);
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "RallyHub";
});

// 1. xây dựng trạm và đăng ký công nhân
builder.Services.AddQuartz(q =>
{
    // tạo một mã định danh cho công việc
    var jobkey = new JobKey("SendOtpJob");

    // đưa công nhân vào trạm
    q.AddJob<SendOtpJob>(opts => opts.WithIdentity(jobkey));

    // dán bảng giờ chạy cho công nhân này
    q.AddTrigger(opts => opts
        .ForJob(jobkey)
        .WithIdentity("SendOtpJobTrigger")
        // thiết lập chu kỳ: ví dụ 10 giây một lần
        .WithSimpleSchedule(x => x.WithIntervalInSeconds(10).RepeatForever()));
});

// 2. kích hoạt người quản lý trạm để quartz chạy cùng ứng dụng
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseCors("AllowAll");

app.UseSwaggerAPI();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();