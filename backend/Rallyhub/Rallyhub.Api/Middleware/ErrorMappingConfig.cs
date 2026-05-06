using Microsoft.AspNetCore.Http;

namespace Rallyhub.Api.Middleware;

public static class ErrorMappingConfig
{
    /// <summary>
    /// Từ điển map các thông báo lỗi Tiếng Việt (mà bạn đang throw trong code) 
    /// sang Tiếng Anh và gán HTTP Status chuẩn.
    /// Bạn có thể thêm, sửa, xóa các lỗi ở đây một cách tập trung.
    /// </summary>
    public static readonly Dictionary<string, (int StatusCode, string EnglishMessage)> BusinessErrors = new(StringComparer.OrdinalIgnoreCase)
    {
        // User & Wallet
        { "người dùng không tồn tại.", (StatusCodes.Status404NotFound, "User does not exist.") },
        { "không tìm thấy user", (StatusCodes.Status404NotFound, "User not found.") },
        { "Mật khẩu hiện tại không chính xác.", (StatusCodes.Status400BadRequest, "Current password is incorrect.") },
        { "Mật khẩu mới không được trùng với mật khẩu cũ.", (StatusCodes.Status400BadRequest, "New password cannot be the same as the old password.") },
        { "Ví đã tồn tại", (StatusCodes.Status409Conflict, "Wallet already exists.") },
        { "Ví chưa được tạo", (StatusCodes.Status404NotFound, "Wallet has not been created yet.") },
        { "Wallet not found", (StatusCodes.Status404NotFound, "Wallet not found.") },
        { "Balance is less than 0!!!waring", (StatusCodes.Status400BadRequest, "Balance is insufficient.") },
        { "Total amount of transaction is less than 0!!!waring", (StatusCodes.Status400BadRequest, "Total transaction amount cannot be less than 0.") },
        { "!!!Waring, các giao dịch ko khớp với số dư ví", (StatusCodes.Status400BadRequest, "Transactions do not match the wallet balance.") },
        
        // Owner / Court
        { "Owner không tồn tại", (StatusCodes.Status404NotFound, "Owner does not exist.") },
        { "Tân sân không được bỏ trống", (StatusCodes.Status400BadRequest, "Court name cannot be empty.") },
        { "Giờ mở phải nhỏ hơn giờ đóng", (StatusCodes.Status400BadRequest, "Opening time must be before closing time.") },
        { "Chủ sân không tồn tại trên hệ thống", (StatusCodes.Status404NotFound, "Court owner does not exist in the system.") },
        { "Sân này đã tồn tại trên hệ thống của bạn", (StatusCodes.Status409Conflict, "This court already exists in your system.") },
        { "Không tìm thấy sân", (StatusCodes.Status404NotFound, "Court not found.") },
        { "Sân đó không phải của bạn", (StatusCodes.Status403Forbidden, "That court does not belong to you.") },
        { "Bạn không có quyền", (StatusCodes.Status403Forbidden, "You do not have permission.") },
        { "Sân con đó đã tồn tại!", (StatusCodes.Status409Conflict, "That sub-court already exists.") },
        { "Sân con không tồn tại!", (StatusCodes.Status404NotFound, "Sub-court does not exist.") },
        { "Sân con không tồn tại", (StatusCodes.Status404NotFound, "Sub-court does not exist.") },
        
        // Slot
        { "Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc của khung giờ đó!", (StatusCodes.Status400BadRequest, "Start time must be before end time for this slot.") },
        { "Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc", (StatusCodes.Status400BadRequest, "Start time must be before end time.") },
        { "Slot bị trùng thời gian", (StatusCodes.Status409Conflict, "Slot times conflict.") },
        { "Mỗi slot phải đúng 30 phút", (StatusCodes.Status400BadRequest, "Each slot must be exactly 30 minutes.") },
        { "Slot phải align 30 phút", (StatusCodes.Status400BadRequest, "Slot must align to 30 minutes.") },
        { "Thiếu DateOfWeek", (StatusCodes.Status400BadRequest, "Missing DateOfWeek.") },
        { "Recurring không được có Date", (StatusCodes.Status400BadRequest, "Recurring slots cannot have a specific Date.") },
        { "Thiếu Date", (StatusCodes.Status400BadRequest, "Missing Date.") },
        { "Override bị trùng thời ", (StatusCodes.Status409Conflict, "Override times conflict.") },
        { "SubCourt chưa có ConfigSlot", (StatusCodes.Status404NotFound, "SubCourt does not have a ConfigSlot.") },
        { "Override phải align với ConfigSlot", (StatusCodes.Status400BadRequest, "Override must align with ConfigSlot.") },
        { "Override không cover full ConfigSlot", (StatusCodes.Status400BadRequest, "Override does not fully cover ConfigSlot.") }
    };
}
