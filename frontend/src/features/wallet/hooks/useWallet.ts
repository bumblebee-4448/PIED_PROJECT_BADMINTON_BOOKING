import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { walletService } from "../services";
import { QUERY_KEYS } from "@/shared/constants";
import { toast } from "sonner";
import type { AddBankInfoRequest, WithdrawalRequest, PagingParams } from "../types";

export const useWallet = () => {
  const queryClient = useQueryClient();

  // Queries
  const useWalletInfo = (enabled: boolean = true) => 
    useQuery({
      queryKey: QUERY_KEYS.WALLET_INFO,
      queryFn: () => walletService.getWalletInfo(),
      enabled,
    });

  const useMyTransactions = (params: PagingParams) =>
    useQuery({
      queryKey: ["my-transactions", params],
      queryFn: () => walletService.getMyTransactions(params),
    });

  const useMyWithdrawals = (params: PagingParams) =>
    useQuery({
      queryKey: ["my-withdrawals", params],
      queryFn: () => walletService.getMyWithdrawals(params),
    });

  // Mutations
  const addBankMutation = useMutation({
    mutationFn: (data: AddBankInfoRequest) => walletService.addBankInfo(data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.WALLET_INFO });
      toast.success("Liên kết ngân hàng thành công");
    },
    onError: (error: any) => {
      toast.error(error.response?.data?.message || "Lỗi khi liên kết ngân hàng");
    }
  });

  const removeBankMutation = useMutation({
    mutationFn: () => walletService.removeBankInfo(),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.WALLET_INFO });
      toast.success("Đã xóa liên kết ngân hàng");
    },
    onError: (error: any) => {
      toast.error(error.response?.data?.message || "Lỗi khi xóa liên kết");
    }
  });

  const depositMutation = useMutation({
    mutationFn: (amount: number) => walletService.deposit(amount),
    onError: (error: any) => {
      toast.error(error.response?.data?.message || "Lỗi khi tạo yêu cầu nạp tiền");
    }
  });

  const withdrawalMutation = useMutation({
    mutationFn: (data: WithdrawalRequest) => walletService.createWithdrawal(data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: QUERY_KEYS.WALLET_INFO });
      queryClient.invalidateQueries({ queryKey: ["my-withdrawals"] });
      toast.success("Đã gửi yêu cầu rút tiền thành công");
    },
    onError: (error: any) => {
      toast.error(error.response?.data?.message || "Lỗi khi tạo yêu cầu rút tiền");
    }
  });

  const checkDepositStatusMutation = useMutation({
    mutationFn: (transactionId: string) => walletService.checkDepositStatus(transactionId),
    onSuccess: (status) => {
      if (status === "Success") {
        queryClient.invalidateQueries({ queryKey: QUERY_KEYS.WALLET_INFO });
        queryClient.invalidateQueries({ queryKey: ["my-transactions"] });
      }
    },
    onError: (error: any) => {
      toast.error(error.response?.data?.message || "Lỗi khi kiểm tra trạng thái");
    }
  });

  return {
    useWalletInfo,
    useMyTransactions,
    useMyWithdrawals,
    addBankMutation,
    removeBankMutation,
    depositMutation,
    withdrawalMutation,
    checkDepositStatusMutation,
  };
};
