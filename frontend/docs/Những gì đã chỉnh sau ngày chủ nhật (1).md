1. BE: khi người dùng gộp slot ví dụ từ 8:00 -> 10:00, mà nếu tạo thêm block slot từ 8:30 - 9:00
	thì BE sẽ tự tách ra: 8:00 -> 8:30: có thể đặt được, từ 9:00 -> 10:00 có thể đặt được, và từ 8:30 - 9:00: bị block
	So với code đợt trước thì nếu gộp từ 8:00 -> 10:00 mà lỡ block slot trong khoảng đó thì khoảng đó sẽ bị mất luôn
2. Khi chủ sân muốn slot đó, mà đã có người dùng đặt slot đó rồi, thì mình ko handle case đó
	- BE: tạo một hàm mới là: GetBookingDetail
		- API: mục đích của hàm này: để owner khi kích vào slot đã đặt đó, thì sẽ lấy được thông tin của người, mà tự liên hệ với nhau
	- API:
	```CSharp
	[HttpPost("GetBookingDetail")]  
public async Task<IActionResult> GetBookingDetail(Guid bookingDetailsId)  
{  
    var result = await _bookingService.GetBookingDetail(bookingDetailsId);  
    return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
, HttpContext.TraceIdentifier));  
}
	```
	- Request:
```CSharp
- Hàm này nhận vào một bookingDetails Guid bookingDetailsId: tức là người đã chuyển khoảng slot đó rồi
```
	- Response: trả ra các thông tin sau của customer đặt slot đó
```CSharp
public class GetBookingDetailResponse  
{  
    public string? Name { get; set; }  
    public string? PhoneNumber { get; set; }  
    public string Gmail { get; set; } = null!;  
    public string SubCourtName { get; set; } = null!;  
    public TimeOnly StartTime { get; set; }  
    public TimeOnly EndTime { get; set; }  
}
```

3. BE: đã xử lí trường hợp ko cho người dùng đặt sân trong quá khứ
4. BE: trả ra giá tiền default của sân khi người dùng tìm kiếm sân bằng 2 hàm: SearchByFilter
	và GetCourtsDetailById
5. BE: đã xử lí trường hợp người dùng search tên không có dấu
6. Phần Trang chủ: 
	FE: ở phần trang chủ, kéo xuống phía dưới có mục: sân cầu lông được yêu thích nhất
	FE có thể design lấy các sân có lượt đánh giá cao và booking cao để bỏ ở đó
	FE cần API nào thì nói lại BE
7. Phần Tìm sân
	Ở hàm SearchByFilter: FE thiếu trả ra số điện của chủ sân
	 BE: cũng đã thêm số lượng feebacks và số lượng booking ở cả 2 hàm (SearchByFilter
	và GetCourtsDetailById) của từng sân
	- SearchByFilter: Thấy được số lượng feedbacks và số lượng sân đã đặt
	- GetCourtsDetailById: sẽ trả ra một vài feebacks(5 cái), gần nhất và khi người dùng ấn, xem tất cả feebacks thì sẽ gọi thêm hàm của Nhuận, lấy tất cả feedbacks của sân đó ra (GetFeedback trong class Service của folder: Feadback)
   Ở phần Map: FE thiếu đi hàm customer search bằng text
 - API:
	```CSharp
	[HttpGet("SeachByText")]  
public async Task<IActionResult> SeachByText(  
    [FromQuery] MapService.Request.SearchByTextRequest request,  
    CancellationToken cancellationToken)  
{  
    var result = await _mapService.SearchByText(request, cancellationToken);  
    return Ok(ApiResponseFactory.SuccessResponse(result,"Success",HttpContext.TraceIdentifier));  
}
	```
	FE: có thể design các marker (cái này làm sau cùng)
8. Phần đặt sân:
	- FE: thanh giờ chưa hợp lí tùy theo giờ sân, có khúc bị dư giờ, ... (desgin lại sau cùng)
	- BE: đã sửa lại ở hàm CreateExceptionSlot: chủ sân có thể setup khóa theo ngày hoặc khóa vào một ngày đó và lặp lại trong tuần với API: 
	```CSharp
	[HttpPost("CreateExceptionSlot")]  public async Task<IActionResult> CreateExceptionSlot([FromBody]Request.CreateExceptionSlotRequest request)  {    
var result = await _ownerService.CreateExceptionSlot(request);   
return Ok(ApiResponseFactory.SuccessResponse( result,"Success"     
, HttpContext.TraceIdentifier));  }
	```
	- BE: ở hàm GetAvailableSlots BE có chỉnh lại phần response đó là: thêm file Type:
		- Slot trống: Default
		- Slot bị đặt: Booked
		- Slot bị khóa: Blocked
		- Slot bị gộp: Override
	- Khi FE gọi hàm này, sẽ trả ra các Type, dựa vào đó mà desgin theo màu sắc
	- Có APi là:
```CSharp
[HttpGet("GetAvailableSlots")]  public async Task<IActionResult> GetAvailableSlots([FromQuery]Request.GetAvailableSlotsRequest request)  {    
var result = await _ownerService.GetAvailableSlots(request);   
return Ok(ApiResponseFactory.SuccessResponse( result,"Success"     
, HttpContext.TraceIdentifier));  }
```
 - BE đã chỉnh, customer có thể đặt nhiều slots trong nhiều sân con trong 1 sân lớn
 9. Phần thanh toán
 - BE: ở hàm CreateBooking với CreateBookingByWallet, BE đã bổ sung thêm các field như: BankName, BankAccount, .. để cho customer biết được thêm nội dung của chủ tài khoản và ngân hàng, để ko sợ chuyển sân
 - API của 2 hàm đó
 ```CSharp
 [HttpPost("CreateBooking")]  
public async Task<IActionResult> CreateBooking([FromBody] Request.CreateBookingRequest request)  
{  
    var result = await _bookingService.CreateBooking(request);  
    return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
, HttpContext.TraceIdentifier));  
}
[HttpPost("CreateBookingByWallet")]  
public async Task<IActionResult> CreateBookingByWallet([FromBody] Request.CreateBookingRequest request)  
{  
    var result = await _bookingService.CreateBookingByWallet(request);  
    return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
, HttpContext.TraceIdentifier));  
}
 ```
 9. Phần lịch sử:
 - FE có thể design cho customer search booking theo ngày: ở hàm GetBooking có thể search theo này
 - Có API là:
 ```CSharp
 [HttpGet("GetBooking")]  
public async Task<IActionResult> GetBooking([FromQuery] Service.Base.Request.PagingDay2 pagingDay2)  
{  
    var result = await _bookingService.GetBooking(pagingDay2);  
    return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
, HttpContext.TraceIdentifier));  
}
 ```
 - BE: anh Hoàng: sửa lỗi job chuyển các đơn bookingDetails thành trạng thái Completed
 - Hình như ở mục này FE đưa ra các thể court mà thiếu đi tên sân
 - BE: anh Hoàng: refundBooking check lại thời gian
 - FE: cấu hình, nếu qua thời gian mà owner có thể cho người dùng Refund được, thì bỏ nút hủy sân đi

# Task đang làm sắp xong ùi
- Owner bổ sung thêm vào hàm, em viết docs sau
- Việc chưa làm của BE:
	- Handle trường hợp khi người dùng tạo sân mới, ko cần nhập kinh độ và vĩ độ
	- Người đặt 2 slot cùng lúc