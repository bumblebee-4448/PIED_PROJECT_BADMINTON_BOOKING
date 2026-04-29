import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import type { LoginInput, RegisterInput, AuthResponse } from "./types";

export const authService = {
  login: async (data: LoginInput): Promise<AuthResponse> => {
    return apiClient.post(API_ENDPOINTS.AUTH.LOGIN, {
      email: data.email,
      rawPassword: data.password, // Backend expects RawPassword
    });
  },
  
  register: async (data: RegisterInput): Promise<string> => {
    // Split fullName into FirstName and LastName for backend compatibility
    const names = data.fullName.trim().split(" ");
    const firstName = names.pop() || "";
    const lastName = names.join(" ") || firstName;

    return apiClient.post(API_ENDPOINTS.AUTH.REGISTER, {
      email: data.email,
      rawPassword: data.password, // Backend expects RawPassword
      firstName: firstName,
      lastName: lastName,
      phoneNumber: data.phone,
    });
  },

  verifyOtp: async (email: string, otpCode: string): Promise<string> => {
    return apiClient.post(API_ENDPOINTS.AUTH.VERIFY_OTP, { email, otpCode });
  },

  logout: async (): Promise<void> => {
    await apiClient.post(API_ENDPOINTS.AUTH.LOGOUT);
  },
};
