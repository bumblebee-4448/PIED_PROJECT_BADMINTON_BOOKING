import { useState } from "react";
import { useAuthStore } from "@/features/auth/store";
import { toast } from "sonner";
import type { ProfileSchema, PasswordChangeSchema, OwnerRegistrationSchema } from "../schema";

const MOCK_USER = {
  id: "1",
  name: "Nguyễn Văn A",
  email: "nguyenvana@example.com",
  phone: "0987654321",
  preferredLocation: "Quận 1",
  level: "intermediate",
  avatar: "",
  isOwner: false,
};

export function useProfile() {
  const { logout } = useAuthStore();
  
  // Ép buộc sử dụng mock data theo yêu cầu của bạn để tránh lỗi API
  const user = MOCK_USER;

  const [isSaving, setIsSaving] = useState(false);
  const [isChangingPassword, setIsChangingPassword] = useState(false);
  const [isRegisteringOwner, setIsRegisteringOwner] = useState(false);

  const updateProfile = async (data: ProfileSchema) => {
    setIsSaving(true);
    try {
      // Logic gọi API update profile ở đây
      console.log("Updating profile...", data);
      await new Promise((resolve) => setTimeout(resolve, 1000));
      toast.success("Cập nhật thông tin thành công!");
    } catch {
      toast.error("Cập nhật thất bại. Vui lòng thử lại.");
    } finally {
      setIsSaving(false);
    }
  };

  const changePassword = async (data: PasswordChangeSchema) => {
    setIsChangingPassword(true);
    try {
      // Logic gọi API đổi mật khẩu ở đây
      console.log("Changing password...", data);
      await new Promise((resolve) => setTimeout(resolve, 1000));
      toast.success("Đổi mật khẩu thành công!");
    } catch {
      toast.error("Đổi mật khẩu thất bại.");
    } finally {
      setIsChangingPassword(false);
    }
  };

  const registerOwner = async (data: OwnerRegistrationSchema) => {
    setIsRegisteringOwner(true);
    try {
      // Logic gọi API đăng ký chủ sân ở đây
      console.log("Registering as owner...", data);
      await new Promise((resolve) => setTimeout(resolve, 1000));
      toast.success("Yêu cầu đăng ký đã được gửi!");
    } catch {
      toast.error("Gửi yêu cầu thất bại.");
    } finally {
      setIsRegisteringOwner(false);
    }
  };

  return {
    user,
    logout,
    isSaving,
    isChangingPassword,
    isRegisteringOwner,
    updateProfile,
    changePassword,
    registerOwner,
  };
}
