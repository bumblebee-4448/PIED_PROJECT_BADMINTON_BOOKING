import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { walletService } from "../../wallet/services";
import { toast } from "sonner";
import type { PagingParams } from "../../wallet/types";

export const useAdminWallet = () => {
  const queryClient = useQueryClient();

  const useAllWithdrawals = (userId: string | null, params: PagingParams) =>
    useQuery({
      queryKey: ["admin-withdrawals", userId, params],
      queryFn: () => walletService.adminGetWithdrawals(userId, params),
    });

  const useAllTransactions = (userId: string | null, params: PagingParams) =>
    useQuery({
      queryKey: ["admin-transactions", userId, params],
      queryFn: () => walletService.adminGetTransactions(userId, params),
    });

  const approveWithdrawalMutation = useMutation({
    mutationFn: (id: string) => walletService.adminApproveWithdrawal(id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["admin-withdrawals"] });
      toast.success("Đã duyệt yêu cầu rút tiền");
    },
    onError: (error: any) => {
      toast.error(error.response?.data?.message || "Lỗi khi duyệt yêu cầu");
    }
  });

  const rejectWithdrawalMutation = useMutation({
    mutationFn: ({ id, reason, note }: { id: string, reason: string, note?: string }) => 
      walletService.adminRejectWithdrawal(id, reason, note),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["admin-withdrawals"] });
      toast.success("Đã từ chối yêu cầu rút tiền");
    },
    onError: (error: any) => {
      toast.error(error.response?.data?.message || "Lỗi khi từ chối yêu cầu");
    }
  });

  return {
    useAllWithdrawals,
    useAllTransactions,
    approveWithdrawalMutation,
    rejectWithdrawalMutation,
  };
};
