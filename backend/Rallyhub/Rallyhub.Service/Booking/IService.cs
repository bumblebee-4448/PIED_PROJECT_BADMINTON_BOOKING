namespace Rallyhub.Service.Booking;

public interface IService
{
    public Task<Response.CreateBookingResponse> CreateBooking(Request.CreateBookingRequest request);
    public Task<Response.CreateBookingResponse> CreateBookingByWallet(Request.CreateBookingRequest request);
    public Task<Response.GetBookingDetailResponse> GetBookingDetail(Guid bookingDetailsId);
    public Task<Response.BookingRefundResponse> BookingRefund(Guid bookingId);
    public Task<string> CanCelBooking(Guid bookingId);
    public Task<Base.Response.PageResult<Response.GetBookingResponse>> GetBooking(Base.Request.PagingDay2 pagingDay2);
    
    
    
}