using System.ComponentModel.DataAnnotations;

namespace Rallyhub.Service.MapService;

public class MapOptions
{
   [Required] public string ApiKey { get; set; } = null!;
   [Required] public string BaseUrl { get; set; } = null!;
   [Required] public int VietMapConcurrency = 7;
}