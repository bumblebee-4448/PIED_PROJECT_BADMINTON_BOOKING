namespace Rallyhub.Service.Booking;

public interface IService
{
    public Task<List<Response.SlotResponse>> GetAvailableSlots(Request.GetAvailableSlotsRequest request);
    public Task<Response.HoldBookingResponse> HoodBooking(Request.HoldBookingRequest request);
    public Task<Response.GetBookingResponse> GetBookingById(Guid bookingId);
}