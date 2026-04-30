using Microsoft.AspNetCore.Http;

namespace Rallyhub.Service.Owner;

public class Request
{
    public class CreateOwnerRequest
    {
        public required string BusinessName  { get; set; }
        public required string TaxCode { get; set; }
        public required string BusinessAddress { get; set; }
        public string? BusinessLicenseUrl { get; set; } // Ảnh giấy phép

        public string? IdentityNumber { get; set; } // Số CCCD
        public string? IdentityCardFrontUrl { get; set; } // Ảnh mặt trước CCCD
        public string? IdentityCardBackUrl { get; set; }
    }
    
    public class CreateCourtRequest  
    {  
        public required string Name { get; set; }   
        public required TimeOnly OpenTime  { get; set; }  
        public required TimeOnly CloseTime { get; set; }  
        public required string Address { get; set; }  
        public required decimal Latitude { get; set; }   
        public required decimal Longitude { get; set; }  
        public required string MapUrl  { get; set; }   
        public required IFormFile PictureUrl { get; set; }  
    }  
  
    public class GetMyCourtsRequest  
    {  
        public string? Name { get; set; }  
        public int PageIndex { get; set; } = 1;   
        public int PageSize { get; set; } = 10;  
    }
}