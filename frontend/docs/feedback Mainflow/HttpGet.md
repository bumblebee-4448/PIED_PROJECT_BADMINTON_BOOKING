ấn vào 1 court thì thì hiện ra các feedback của 1 sân đó.

Authen:
Customer & owner

Request:
```csharp
public class GetFeedbackRequest: Base.Request.PagingRequest  
{  
    public required Guid CourtId  { get; set; }  
}
```

Response:
```csharp
phân trang
public class GetFeedbackResponse  
{  
    public Guid Id { get; set; }  
    public string NameCustomer { get; set; }  
    public string? Comment {get; set;}  
    public int Rating {get; set;}  
    public DateTimeOffset CreatedAt {get; set;}  
}
```