import { apiClient } from "@/lib/axios";
import { API_ENDPOINTS } from "@/shared/constants";
import type { User } from "@/features/auth/types";
import type { ProfileSchema, OwnerRegistrationSchema, ChangePasswordSchema } from "./schema";

export const profileService = {
  getMe: async (): Promise<User> => {
    return apiClient.get(API_ENDPOINTS.USER.ME);
  },

  updateProfile: async (data: ProfileSchema): Promise<string> => {
    return apiClient.patch(API_ENDPOINTS.USER.PROFILE, {
      FirstName: data.firstName,
      LastName: data.lastName,
      PhoneNumber: data.phoneNumber,
      AvatarUrl: data.avatarUrl,
    });
  },

  registerOwner: async (data: OwnerRegistrationSchema): Promise<void> => {
    return apiClient.post("/User/RegisterOwner", data);
  },
  changePassword: async (data: ChangePasswordSchema): Promise<string> => {
    return apiClient.put(API_ENDPOINTS.USER.CHANGE_PASSWORD, {
      oldPassword: data.oldPassword,
      newPassword: data.newPassword,
    });
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
