using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Rallyhub.Service.JwtService;

namespace Rallyhub.Api.Extention;

public static class JwtExtensions
{
    public const string AdminPolicy = "AdminPolicy";
    public const string SellerPolicy = "SellerPolicy";
    public const string UserPolicy = "UserPolicy";
    public const string SellerOrAdminPolicy = "SellerOrAdminPolicy";

    public static void AddJwtServices(this IServiceCollection services, IConfiguration configuration)
    {
        JwtOptions jwtOptions = new JwtOptions();
        configuration.GetSection(nameof(JwtOptions)).Bind(jwtOptions);
        var key = Encoding.UTF8.GetBytes(jwtOptions.SecretKey);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true, 
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    NameClaimType = ClaimTypes.NameIdentifier,
                    RoleClaimType = ClaimTypes.Role
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy(AdminPolicy, policy =>
                policy.RequireRole("Admin"));
            // [Authorize(Policy = JwtExtensions.AdminPolicy)]
        
            options.AddPolicy(SellerPolicy, policy =>
                policy.RequireRole("Seller"));
            // [Authorize(Policy = JwtExtensions.SellerPolicy)]
        
            options.AddPolicy(UserPolicy, policy =>
                policy.RequireRole("User"));
        
            options.AddPolicy(SellerOrAdminPolicy, policy =>
                policy.RequireRole("Seller", "Admin"));
        
            // [Authorize(Policy = JwtExtensions.SellerOrAdminPolicy)]
        });
    }
}