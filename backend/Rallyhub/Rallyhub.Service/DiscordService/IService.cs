using Microsoft.AspNetCore.Http;

namespace Rallyhub.Service.DiscordService;

public interface IService
{
    Task SendExceptionAlertAsync(
        HttpContext context,
        Exception exception,
        int statusCode,
        CancellationToken cancellationToken = default);
}