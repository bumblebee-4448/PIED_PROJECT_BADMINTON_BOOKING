using Microsoft.AspNetCore.Http;

namespace Rallyhub.Service.MediaService;

public interface IService
{
    public Task<string> UploadImageAsync(IFormFile file);
}