import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import type { LoginInput, RegisterInput, AuthResponse } from "./types";

export const authService = {
  login: async (data: LoginInput): Promise<AuthResponse> => {
    return apiClient.post(API_ENDPOINTS.AUTH.LOGIN, data);
  },
  
  register: async (data: RegisterInput): Promise<string> => {
    return apiClient.post(API_ENDPOINTS.AUTH.REGISTER, {
      fullName: data.fullName,
      email: data.email,
      password: data.password,
      phoneNumber: data.phone, // Backend usually uses phoneNumber
    });
  },

  verifyOtp: async (email: string, otpCode: string): Promise<string> => {
    return apiClient.post(API_ENDPOINTS.AUTH.VERIFY_OTP, { email, otpCode });
  },

  logout: async (): Promise<void> => {
    await apiClient.post(API_ENDPOINTS.AUTH.LOGOUT);
  },
};
