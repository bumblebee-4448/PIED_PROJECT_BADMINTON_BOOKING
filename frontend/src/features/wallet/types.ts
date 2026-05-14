export interface WalletInfo {
  id: string;
  firstName: string | null;
  lastName: string | null;
  bankName: string | null;
  bankAccount: string | null;
  bankAccountName: string | null;
  balance: number;
}

export interface AddBankInfoRequest {
  bankName: string;
  bankAccount: string;
  bankAccountName: string;
}

export interface DepositRequest {
  amount: number;
}

export interface DepositResponse {
  id: string;
  transactionId: string;
  amount: number;
  qrCodeUrl: string;
}

export interface WithdrawalRequest {
  amount: number;
}

export interface WithdrawalInfo {
  id: string;
  userId: string;
  email: string | null;
  avatar: string | null;
  firstName: string | null;
  lastName: string | null;
  amount: number;
  bankName: string | null;
  bankAccountNumber: string | null;
  bankAccountName: string | null;
  walletId: string;
  transactionId: string | null;
  createdAt: string;
  status?: string;
  rejectionReason?: string | null;
  adminNote?: string | null;
  processedByAdminId?: string | null;
  updatedAt?: string;
}

export interface TransactionInfo {
  id: string;
  type: string;
  amount: number;
  bankRefCode: string | null;
  bankAccountNumber: string | null;
  status: string;
  bookingId: string | null;
  // Admin fields
  mail?: string | null;
  avatarUrl?: string | null;
  firstName?: string | null;
  lastName?: string | null;
  balanceBefore?: number;
  balanceAfter?: number;
  sePayId?: string | null;
  transferContent?: string | null;
  actionCode?: string | null;
  signature?: string | null;
  walletId?: string;
  createdAt?: string;
  updatedAt?: string;
}

export interface PagingParams {
  pageIndex: number;
  pageSize: number;
  date?: string; // YYYY-MM-DD
  search?: string;
  id?: string;
}

export interface PageResult<T> {
  items: T[];
  pageIndex: number;
  pageSize: number;
  totalItems: number;
}
