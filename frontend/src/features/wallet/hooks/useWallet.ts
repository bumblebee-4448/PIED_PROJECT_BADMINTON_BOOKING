import { useQuery } from "@tanstack/react-query";
import { QUERY_KEYS } from "@/shared/constants";
import { useAuthStore } from "@/features/auth";
import { walletService } from "../services";
import type { WalletInfo } from "../types";

export function useWallet() {
  const { role, accessToken } = useAuthStore();

  return useQuery({
    queryKey: QUERY_KEYS.WALLET_INFO,
    queryFn: async () => {
      const response = await walletService.getWalletInfo();
      
      // Normalize response from BE (handle PascalCase if necessary)
      // Based on the provided example, it's camelCase, but we handle potential PascalCase just in case
      return {
        id: response.id || (response as any).Id,
        firstName: response.firstName || (response as any).FirstName,
        lastName: response.lastName || (response as any).LastName,
        bankName: response.bankName ?? (response as any).BankName,
        bankAccount: response.bankAccount ?? (response as any).BankAccount,
        bankAccountName: response.bankAccountName ?? (response as any).BankAccountName,
        balance: response.balance ?? (response as any).Balance ?? 0,
      } as WalletInfo;
    },
    enabled: !!accessToken && role !== "Admin",
    staleTime: 2 * 60 * 1000, // 2 minutes
  });
}
