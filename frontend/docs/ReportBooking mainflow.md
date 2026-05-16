
- Khi customer booking sân,và khi đơn chuyển về trạng thái completed, sẽ hiện ra nút report trong đơn booking đó, customer có thể report cái booking đó cho admin biết. Sử dụng trong trường hợp, ví dụ như: chủ sân ngưng hoạt động, nhưng đơn booking không thể hoàn tiền được nữa, lúc này customer gửi một cái report booking lên cho admin nhận, và admin sẽ thấy đơn booking ở trang thái pending, và sẽ gửi thông báo về cho thằng customer và đồn thời chuyển trạng thái của đơn reportBooking đó thành completed.
- Khi customer vào xem mục lịch sử đặt sân ở tag Hoàn thành, sẽ hiện ra các booking đã hoàn thành, bên cạnh cái booking đó sẽ có nút report, khi nó ấn vào nút report của cái booking đó, sẽ truyền vào bookingId đó cho hàm CreateReportBookings luôn và hiện ra cho nó ghi vô lí do

Customer gửi cái reportBooking thông qua API:
```CSharp
[HttpPost("CreateReportBookings")]  
[Authorize(Policy = JwtExtensions.CustomerPolicy)]  
public async Task<IActionResult> CreateReportBookings(Request.CreateReportBookingsRequest request)  
{  
    await _reportService.CreateReportBookings(request);  
    return Ok(Service.Models.ApiResponseFactory.SuccessResponse("Create success", HttpContext.TraceIdentifier));  
}
```
- Request:
```CSharp
public class CreateReportBookingsRequest  
{  
    public required string Reason { get; set; }  
    public Guid BookingId { get; set; }  
}
```
- Response:
```CSharp
return "Báo cáo đơn đặt sân thành công";
```

Admin hoặc Customer xem cái reportBooking
	Admin thì xem hết tất cả cái reportBooking
	 Customer thì chỉ xem hết tất cả cái reportBooking của nó
```CSharp
[HttpGet("GetReportBookings")]  
[Authorize]  
public async Task<IActionResult> GetReportBookings([FromQuery]Request.GetReportBookingsRequest request)  
{  
    var result = await _reportService.GetReportBookings(request);  
    return Ok(Service.Models.ApiResponseFactory.SuccessResponse(result,"Create success", HttpContext.TraceIdentifier));  
}
```
- Response
```CSharp
public class GetReportBookingsRequest  
{  
    public Guid ReportBookingId { get; set; } //id của reportBooking đó  
    public string Reason { get; set; }  //lí do
    public Guid CustomerId { get; set; }  //id của khách hàng report
    public Guid BookingId { get; set; }   //đơn booking
    public Guid CourtId { get; set; }  //id của sân
    public string Status { get; set; } = null!;  //trạng thái
}
```

Vì GetReportBookings có trả ra id của reportBooking, dựa vào đó mà Admin có hàm ConfirmReport nhận vào id đó và trả lời lại cho thằng user
API
```CSharp
[HttpPatch("ConfirmReport")]  
[Authorize(Policy = JwtExtensions.AdminPolicy)]  
public async Task<IActionResult> ConfirmReport(Request.ConfirmReportRequest request)  
{  
    await _reportService.ConfirmReport(request);  
    return Ok(Service.Models.ApiResponseFactory.SuccessResponse("Create success", HttpContext.TraceIdentifier));  
}
```
Request
```CSharp
Nhận vào Id của reportBooking
```
Response
```CSharp
trả ra string: return "Phản hồi thành công";
```