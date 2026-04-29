namespace Rallyhub.Service.MapService;
 
public interface IService
{
    public Task<Response.MapSearchResponse> SearchByBoundingBox(
        Request.BoundingBoxRequest request, CancellationToken cancellationToken);
    
    public Task<Response.MapSearchResponse> SearchByRadius(
        Request.RadiusRequest request, CancellationToken cancellationToken);

    public Task<Response.MapSearchResponse> SearchByText(
        Request.SearchByTextRequest request, CancellationToken cancellationToken
    );
}