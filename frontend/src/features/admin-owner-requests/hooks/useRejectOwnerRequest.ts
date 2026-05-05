import { useMutation, useQueryClient } from "@tanstack/react-query";
import { toast } from "sonner";
import { apiClient } from "@/lib/axios";
import type { RejectOwnerRequestParams } from "../types";

export function useRejectOwnerRequest() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async ({
      ownerRequestId,
      rejectReason,
    }: RejectOwnerRequestParams) => {
      const response = await apiClient.get("/api/Admin/RejectCreateOwner", {
        params: { ownerRequestId, rejectReason },
      });
      return response;
    },
    onSuccess: () => {
      toast.success("Đã từ chối đơn đăng ký chủ sân");
      queryClient.invalidateQueries({ queryKey: ["admin", "owner-requests"] });
    },
    onError: (error: any) => {
      const message =
        error.response?.data?.message ||
        error.message ||
        "Từ chối thất bại. Vui lòng thử lại.";
      toast.error("Từ chối thất bại", {
        description: message,
        duration: 5000,
      });
    },
  });
}
