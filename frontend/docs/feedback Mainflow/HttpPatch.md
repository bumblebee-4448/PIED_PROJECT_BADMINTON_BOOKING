 trong các booking trong phần lịch sử thì có các feedback của cus thì ấn vào cập nhập thì sẽ cập nhập, điều kiện là trong 30 ngày hoàn thành
 
Authen:
Customer

Request:
```csharp
public class UpdateFeedbackRequest  
{  
    public required Guid Id  { get; set; }  
    public required Guid BookingId  { get; set; }  
    public required int Rating { get; set; }  
    public string? Comment   { get; set; }  
}
```

Response:
ko có