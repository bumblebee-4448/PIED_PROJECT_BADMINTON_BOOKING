import { apiClient } from "@/lib/axios";

export interface AdminDashboardResponse {
  totalUsers: number;
  totalCourtActive: number;
  totalAmount: number;
}

export const adminDashboardService = {
  getAdminStats: async (): Promise<AdminDashboardResponse> => {
    const response = await apiClient.get("/Dashboard/DashboardAdmin");
    return response.data.data;
  }
};
