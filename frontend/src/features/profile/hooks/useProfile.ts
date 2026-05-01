import { useState, useEffect } from "react";
import { useAuthStore } from "@/features/auth/store";
import { toast } from "sonner";
import { profileService } from "../services";
import type { ProfileSchema, PasswordChangeSchema, OwnerRegistrationSchema } from "../schema";
import type { User } from "@/features/auth/types";

export function useProfile() {
  const { logout, setAuth, user: storeUser, role, accessToken } = useAuthStore();
  const [user, setUser] = useState<User | null>(storeUser);
  const [isLoading, setIsLoading] = useState(false);
  const [isSaving, setIsSaving] = useState(false);
  const [isChangingPassword, setIsChangingPassword] = useState(false);
  const [isRegisteringOwner, setIsRegisteringOwner] = useState(false);

  // Lấy thông tin user thực tế từ backend khi mount
  useEffect(() => {
    const fetchProfile = async () => {
      if (!accessToken) return;
      setIsLoading(true);
      try {
        const profileData = await profileService.getMe();
        setUser(profileData);
        // Cập nhật store nếu có thay đổi
        if (accessToken && role) {
          setAuth(accessToken, role, profileData);
        }
      } catch (error) {
        console.error("Failed to fetch profile:", error);
        // Nếu lỗi 401 thì có thể logout tùy theo policy
      } finally {
        setIsLoading(false);
      }
    };

    fetchProfile();
  }, [accessToken, role, setAuth]);

  const updateProfile = async (data: ProfileSchema) => {
    setIsSaving(true);
    try {
      const updatedUser = await profileService.updateProfile(data);
      setUser(updatedUser);
      if (accessToken && role) {
        setAuth(accessToken, role, updatedUser);
      }
      toast.success("Cập nhật thông tin thành công!");
    } catch (error) {
      toast.error("Cập nhật thất bại. Vui lòng thử lại.");
    } finally {
      setIsSaving(false);
    }
  };

  const changePassword = async (data: PasswordChangeSchema) => {
    setIsChangingPassword(true);
    try {
      await profileService.changePassword(data);
      toast.success("Đổi mật khẩu thành công!");
    } catch (error) {
      toast.error("Đổi mật khẩu thất bại.");
    } finally {
      setIsChangingPassword(false);
    }
  };

  const registerOwner = async (data: OwnerRegistrationSchema) => {
    setIsRegisteringOwner(true);
    try {
      await profileService.registerOwner(data);
      toast.success("Yêu cầu đăng ký đã được gửi!");
    } catch (error) {
      toast.error("Gửi yêu cầu thất bại.");
    } finally {
      setIsRegisteringOwner(false);
    }
  };

  return {
    user,
    isLoading,
    logout,
    isSaving,
    isChangingPassword,
    isRegisteringOwner,
    updateProfile,
    changePassword,
    registerOwner,
  };
}
