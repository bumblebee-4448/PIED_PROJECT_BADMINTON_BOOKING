using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Rallyhub.Service.JwtService;

namespace Rallyhub.Api.Extention;

public static class JwtExtensions
{
    public const string AdminPolicy = "AdminPolicy";
    public const string CustomerPolicy = "CustomerPolicy";
    public const string OwnerPolicy = "OwnerPolicy";
    public const string OwnerOrAdminPolicy = "OwnerOrAdminPolicy";
    public const string CustomerOrOwnerPolicy = "CustomerOrOwnerPolicy";
    public const string CustomerOrOwnerOrAdminPolicy = "CustomerOrOwnerOrAdminPolicy";

    
    public static void AddJwtServices(this IServiceCollection services, IConfiguration configuration)
    {
        JwtOptions jwtOption = new JwtOptions();
        configuration.GetSection(nameof(JwtOptions)).Bind(jwtOption);
        var key = Encoding.UTF8.GetBytes(jwtOption.SecretKey);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {//config validate cái token này có hợp lệ hay ko
                ValidateIssuer = true,//đc kí đúng người
                ValidateAudience = true,//
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOption.Issuer,
                ValidAudience = jwtOption.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                NameClaimType = ClaimTypes.NameIdentifier,
                RoleClaimType = ClaimTypes.Role,
            };
        });
        services.AddAuthorization(options =>
        {
            options.AddPolicy(AdminPolicy, policy =>
                policy.RequireRole("Admin"));
            // [Authorize(Policy = JwtExtensions.AdminPolicy)]
        
            options.AddPolicy(CustomerPolicy, policy =>
                policy.RequireRole("Customer"));
            // [Authorize(Policy = JwtExtensions.SellerPolicy)]
        
            options.AddPolicy(OwnerPolicy, policy =>
                policy.RequireRole("Owner"));
        
            options.AddPolicy(OwnerOrAdminPolicy, policy =>
                policy.RequireRole("Owner", "Admin"));
            options.AddPolicy(CustomerOrOwnerPolicy, policy => 
                policy.RequireRole("Customer", "Owner"));
            options.AddPolicy(CustomerOrOwnerOrAdminPolicy, policy =>
                policy.RequireRole("Customer", "Owner", "Admin"));
            // [Authorize(Policy = JwtExtensions.SellerOrAdminPolicy)]
        }); 
    }
}