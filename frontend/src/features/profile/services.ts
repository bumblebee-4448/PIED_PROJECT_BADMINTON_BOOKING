import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import type { User } from "@/features/auth/types";
import type { ProfileSchema, PasswordChangeSchema, OwnerRegistrationSchema } from "./schema";

export const profileService = {
  getMe: async (): Promise<User> => {
    return apiClient.get(API_ENDPOINTS.USER.ME);
  },

  updateProfile: async (data: ProfileSchema): Promise<User> => {
    return apiClient.put(API_ENDPOINTS.USER.PROFILE, data);
  },

  changePassword: async (data: PasswordChangeSchema): Promise<void> => {
    return apiClient.post("/User/ChangePassword", data);
  },

  registerOwner: async (data: OwnerRegistrationSchema): Promise<void> => {
    return apiClient.post("/User/RegisterOwner", data);
  },

  uploadAvatar: async (file: File): Promise<{ url: string }> => {
    const formData = new FormData();
    formData.append("file", file);
    return apiClient.post("/User/UploadAvatar", formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
  },
};
