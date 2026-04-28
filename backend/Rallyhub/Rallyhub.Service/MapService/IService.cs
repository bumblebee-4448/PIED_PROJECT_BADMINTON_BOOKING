namespace Rallyhub.Service.MapService;
 
public interface IService
{
    public Task<Response.MapSearchResponse> SearchByBoundingBox(
        BoundingBoxRequest request, CancellationToken cancellationToken);
    
    public Task<Response.MapSearchResponse> SearchByRadius(
        RadiusRequest request, CancellationToken cancellationToken);
}