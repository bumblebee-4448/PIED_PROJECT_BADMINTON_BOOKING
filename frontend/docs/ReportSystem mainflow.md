- Flow tổng quát: khi user kích vào mục báo cáo hệ thống, hệ thống sẽ trả ra title và reason để cho người dùng nhập vào, lúc này cái systemreport được tạo ra và ở trạng thái pending(đang xử lí), đồng thời nếu user kích vào xem các systemreport sẽ thấy đơn systemreport ở trạng thái pending(đang xử lí). Admin vào check phần systemreport, thấy có một report đang ở trạng thái pending, sẽ gửi thông báo cho thằng user đó rằng là hệ thống đã xác nhận báo cáo, và chuyển status của đơn systemreport đó về comfirmed, và  user sẽ nhận được thông báo rằng là admin  đã xác nhận báo cáo của nó, đồng thời nó có thể vào check các systemreport của nó là thấy được trạng thái là confirmed (tức đã duyệt)

Owner hoặc Customer có thể tạo SystemReport qua API
```CSharp
[HttpPost("CreateSystemReport")]  
[Authorize(Policy = JwtExtensions.CustomerOrOwnerPolicy)]  
public async Task<IActionResult> CreateSystemReport(Request.CreateSystemReportRequest request)  
{  
    await _systemReportService.CreateSystemReport(request);  
    return Ok(ApiResponseFactory.SuccessResponse("Create success", HttpContext.TraceIdentifier));  
}
```
- Request
```CSharp
public class CreateSystemReportRequest  
{  
    public required string Title { get; set; }  //tiêu đề
    public required string Reason { get; set; }  //Lí do
}
```
- Response
```
return "Tạo report thành công";
```

Admin hoặc Customer xem cái SystemReport 
	Admin thì xem hết tất cả các SystemReport và sắp xếp cái chưa xử lí lên đầu
	 Customer thì xem hết tất cả các SystemReport của nó và sắp xếp cái xử lí rồi lên đầu
```CSharp
[HttpGet("GetSystemReport")]  
[Authorize]  
public async Task<IActionResult> GetSystemReport ([FromQuery]Request.GetSystemReportRequest request)  
{  
    var result = await _systemReportService.GetSystemReport(request);  
    return Ok(ApiResponseFactory.SuccessResponse  
        (result, "Success you!", HttpContext.TraceIdentifier));  
}
```
Response
```CSharp
public class GetSystemReportResponse  
{  
    public required Guid Id  { get; set; }  
    public required string Title { get; set; }  
    public required string Reason { get; set; }  
    public required string Status { get; set; } }
```

Vì GetSystemReport: có trả ra Id, dựa vào đó mà Admin có hàm SubmitReportReply nhận vào id đó trả lời cho user đó
API
```CSharp
[HttpPatch("SubmitReportReply")]  
[Authorize(Policy = JwtExtensions.AdminPolicy)]  
public async Task<IActionResult> SubmitReportReply(Request.SubmitReportReplyRequest request)  
{  
    await _systemReportService.SubmitReportReply(request);  
    return Ok(ApiResponseFactory.SuccessResponse("success", HttpContext.TraceIdentifier));  
}
```
- Request
```HTML
nhận vào Id của report
```

