import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import type { WalletInfo } from "./types";

export const walletService = {
  getWalletInfo: async (): Promise<WalletInfo> => {
    /**
     * TẠI SAO PHẢI DÙNG: as unknown as Promise<...>
     * Xem giải thích chi tiết trong src/shared/services/BaseService.ts
     */
    return apiClient.get<WalletInfo>(
      API_ENDPOINTS.WALLET.GET_INFO,
    ) as unknown as Promise<WalletInfo>;
  },
};
