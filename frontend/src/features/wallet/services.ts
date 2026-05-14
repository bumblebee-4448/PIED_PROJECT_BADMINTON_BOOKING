import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import type { 
  WalletInfo, 
  AddBankInfoRequest, 
  DepositResponse, 
  WithdrawalRequest, 
  WithdrawalInfo, 
  TransactionInfo, 
  PageResult,
  PagingParams
} from "./types";

export const walletService = {
  // Wallet
  getWalletInfo: async (): Promise<WalletInfo> => {
    return apiClient.get<WalletInfo>(
      API_ENDPOINTS.WALLET.GET_INFO,
    ) as unknown as Promise<WalletInfo>;
  },

  addBankInfo: async (data: AddBankInfoRequest): Promise<string> => {
    return apiClient.patch<string>(
      API_ENDPOINTS.WALLET.ADD_INFO,
      data
    ) as unknown as Promise<string>;
  },

  removeBankInfo: async (): Promise<string> => {
    return apiClient.patch<string>(
      API_ENDPOINTS.WALLET.REMOVE_BANK
    ) as unknown as Promise<string>;
  },

  deposit: async (amount: number): Promise<DepositResponse> => {
    return apiClient.patch<DepositResponse>(
      API_ENDPOINTS.WALLET.ADD_BALANCE,
      amount,
      { headers: { 'Content-Type': 'application/json' } }
    ) as unknown as Promise<DepositResponse>;
  },

  checkDepositStatus: async (transactionId: string): Promise<string> => {
    return apiClient.get<string>(
      API_ENDPOINTS.WALLET.CHECK_STATUS.replace("{transactionId}", transactionId)
    ) as unknown as Promise<string>;
  },

  // Withdrawal
  createWithdrawal: async (data: WithdrawalRequest): Promise<string> => {
    return apiClient.post<string>(
      API_ENDPOINTS.WITHDRAWAL.CREATE,
      data
    ) as unknown as Promise<string>;
  },

  getMyWithdrawals: async (params: PagingParams): Promise<PageResult<WithdrawalInfo>> => {
    return apiClient.get<PageResult<WithdrawalInfo>>(
      API_ENDPOINTS.WITHDRAWAL.GET_MY,
      { params }
    ) as unknown as Promise<PageResult<WithdrawalInfo>>;
  },

  adminGetWithdrawals: async (userId: string | null, params: PagingParams): Promise<PageResult<WithdrawalInfo>> => {
    return apiClient.get<PageResult<WithdrawalInfo>>(
      API_ENDPOINTS.WITHDRAWAL.ADMIN_GET,
      { params: { ...params, userId } }
    ) as unknown as Promise<PageResult<WithdrawalInfo>>;
  },

  adminApproveWithdrawal: async (withdrawalRequestId: string): Promise<string> => {
    return apiClient.post<string>(
      API_ENDPOINTS.WITHDRAWAL.ADMIN_APPROVE,
      withdrawalRequestId,
      { headers: { 'Content-Type': 'application/json' } }
    ) as unknown as Promise<string>;
  },

  adminRejectWithdrawal: async (withdrawalRequestId: string, reason: string, note?: string): Promise<string> => {
    return apiClient.post<string>(
      API_ENDPOINTS.WITHDRAWAL.ADMIN_REJECT,
      { withdrawalRequestId, reason, note }
    ) as unknown as Promise<string>;
  },

  // Transactions
  getMyTransactions: async (params: PagingParams): Promise<PageResult<TransactionInfo>> => {
    return apiClient.get<PageResult<TransactionInfo>>(
      API_ENDPOINTS.TRANSACTION.GET_MY,
      { params }
    ) as unknown as Promise<PageResult<TransactionInfo>>;
  },

  adminGetTransactions: async (userId: string | null, params: PagingParams): Promise<PageResult<TransactionInfo>> => {
    return apiClient.get<PageResult<TransactionInfo>>(
      API_ENDPOINTS.TRANSACTION.ADMIN_GET,
      { params: { ...params, userId } }
    ) as unknown as Promise<PageResult<TransactionInfo>>;
  },
};
