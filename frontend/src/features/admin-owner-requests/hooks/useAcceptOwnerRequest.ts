import { useMutation, useQueryClient } from "@tanstack/react-query";
import { toast } from "sonner";
import { apiClient } from "@/lib/axios";

export function useAcceptOwnerRequest() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (ownerRequestId: string) => {
      const response = await apiClient.post("/api/Admin/OwnerRequest/Approve", {
        ownerRequestId,
      });
      return response;
    },
    onSuccess: () => {
      toast.success("Đã phê duyệt đơn đăng ký chủ sân");
      queryClient.invalidateQueries({ queryKey: ["admin", "owner-requests"] });
    },
    onError: (error: any) => {
      const message =
        error.response?.data?.message ||
        error.message ||
        "Phê duyệt thất bại. Vui lòng thử lại.";
      toast.error("Phê duyệt thất bại", {
        description: message,
        duration: 5000,
      });
    },
  });
}
