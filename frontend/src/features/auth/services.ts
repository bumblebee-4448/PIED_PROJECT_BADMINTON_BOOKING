import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import type { LoginInput, RegisterInput, AuthResponse, ForgotPasswordInput, ResetPasswordInput } from "./types";

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

  forgotPassword: async (data: ForgotPasswordInput): Promise<void> => {
    return apiClient.post(API_ENDPOINTS.AUTH.FORGOT_PASSWORD, data);
  },

  resetPassword: async (data: ResetPasswordInput): Promise<void> => {
    return apiClient.post(API_ENDPOINTS.AUTH.RESET_PASSWORD, data);
  },

  logout: async (): Promise<void> => {
    // Local logout only
  },
};
