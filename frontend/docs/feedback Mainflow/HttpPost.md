khi ấn vào 1 booking trong lịch sử có trạng thái completed thì sẽ có thể feedback đc. chỉ tạo đc trong vòng 30 ngày kể từ khi cái feedback đó completed

Authen:
Customer

Request:
```csharp
public class CreateFeedbackRequest  
{  
    public required Guid BookingId  { get; set; }  
    public required int Rating { get; set; }  
    public string? Comment   { get; set; }  
}
```

Response:
ko có