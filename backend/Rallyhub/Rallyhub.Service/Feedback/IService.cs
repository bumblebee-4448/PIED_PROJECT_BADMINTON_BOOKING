using Org.BouncyCastle.Ocsp;

namespace Rallyhub.Service.Feedback;

public interface IService
{
    public Task CreateFeedback(Request.CreateFeedbackRequest request);
    public Task<Base.Response.PageResult<Response.GetFeedbackResponse>> GetFeedback(Request.GetFeedbackRequest request);
    public Task DeteteFeedback(Request.DeteteFeedbackRequest request);
    public Task UpdateFeeback(Request.UpdateFeedbackRequest request);
}