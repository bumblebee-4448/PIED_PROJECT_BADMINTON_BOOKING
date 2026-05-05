using Microsoft.AspNetCore.Http;

namespace Rallyhub.Service.Customer;

public class Request
{
    public class OwnerRequestRequest : User.Request.UserRequest
    {
        public required string BusinessName { get; set; }
        public required string TaxCode { get; set; }
        public required string BusinessAddress { get; set; }
        public required IFormFile BusinessLicenseUrl { get; set; } // Ảnh giấy phép

        public required string IdentityNumber { get; set; } // Số CCCD
        public required IFormFile IdentityCardFrontUrl { get; set; } // Ảnh mặt trước CCCD
        public required IFormFile IdentityCardBackUrl { get; set; } // Ảnh mặt sau CCCD
    }

    public class GetOwnerRequest
    {
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
    }

    public class CancelBooking
    {
        public Guid? BookingDetailId  { get; set; }
    }

    public class AddCourtLikeListRequest
    {
        public Guid CourtId  { get; set; }
        public required string CourtName  { get; set; }
        public required string CourtAddress   { get; set; }
    }
    public class DeteleCourtLikeListRequest
    {
        public Guid CourtId  { get; set; }
    }
    public class LikeListDetailRequest
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class GetAllBookingRequest
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}