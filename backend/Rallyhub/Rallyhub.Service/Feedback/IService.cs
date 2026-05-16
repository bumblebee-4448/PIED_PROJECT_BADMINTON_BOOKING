using Org.BouncyCastle.Ocsp;

namespace Rallyhub.Service.Feedback;

public interface IService
{
    public Task CreateFeedback(Request.CreateFeedbackRequest request);
    public Task<Base.Response.PageResult<Response.GetFeedbackResponse>> GetFeedback(Request.GetFeedbackRequest request);
    public Task<Response.GetFeedbackResponse?> FeedbackByBookingId(Guid bookingId);
    public Task DeleteFeedback(Request.DeteteFeedbackRequest request);
    public Task UpdateFeedback(Request.UpdateFeedbackRequest request);
}
