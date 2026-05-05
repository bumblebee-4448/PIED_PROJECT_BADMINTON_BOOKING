import { useQuery } from "@tanstack/react-query";
import { bookingsService } from "../services";

/**
 * Kiểm tra điều kiện hủy sân — dùng `useQuery` với `enabled` flag
 * thay vì `useMutation` + `useEffect`, vì đây là read operation
 * chạy tự động khi dialog mở + có bookingDetailId.
 */
export function useCheckCancel(bookingDetailId: string | null) {
  return useQuery({
    queryKey: ["checkCancel", bookingDetailId],
    queryFn: () => bookingsService.checkCancel(bookingDetailId!),
    enabled: !!bookingDetailId,
    staleTime: 0, // Luôn fetch mới khi dialog mở
    gcTime: 0,    // Không cache kết quả
  });
}
