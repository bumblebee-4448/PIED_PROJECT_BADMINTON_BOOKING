import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useAuthStore } from "@/features/auth/store";
import { toast } from "sonner";
import { profileService } from "../services";
import { QUERY_KEYS } from "@/shared/constants";
import { useMe } from "./useMe";
import type { ProfileSchema, PasswordChangeSchema, OwnerRegistrationSchema } from "../schema";

export function useProfile() {
  const queryClient = useQueryClient();
  const { logout, user: storeUser } = useAuthStore();
  
  // Sử dụng useMe để lấy dữ liệu đồng bộ
  const { data: user, isLoading } = useMe();

  // 1. Mutation cập nhật Profile
  const updateProfileMutation = useMutation({
    mutationFn: (data: ProfileSchema) => profileService.updateProfile(data),
    onSuccess: async (message) => {
      toast.success(message || "Cập nhật thông tin thành công!");
      // Refresh dữ liệu user
      await queryClient.invalidateQueries({ queryKey: QUERY_KEYS.ME });
    },
    onError: () => {
      toast.error("Cập nhật thất bại. Vui lòng thử lại.");
    },
  });

  // 2. Mutation đổi mật khẩu
  const changePasswordMutation = useMutation({
    mutationFn: (data: PasswordChangeSchema) => profileService.changePassword(data),
    onSuccess: () => {
      toast.success("Đổi mật khẩu thành công!");
    },
    onError: () => {
      toast.error("Đổi mật khẩu thất bại.");
    },
  });

  // 3. Mutation đăng ký chủ sân
  const registerOwnerMutation = useMutation({
    mutationFn: (data: OwnerRegistrationSchema) => profileService.registerOwner(data),
    onSuccess: () => {
      toast.success("Yêu cầu đăng ký đã được gửi!");
    },
    onError: () => {
      toast.error("Gửi yêu cầu thất bại.");
    },
  });

  return {
    user: user || storeUser, // Ưu tiên data từ react-query, fallback về store
    isLoading,
    logout,
    isSaving: updateProfileMutation.isPending,
    isChangingPassword: changePasswordMutation.isPending,
    isRegisteringOwner: registerOwnerMutation.isPending,
    updateProfile: updateProfileMutation.mutateAsync,
    changePassword: changePasswordMutation.mutateAsync,
    registerOwner: registerOwnerMutation.mutateAsync,
  };
}
