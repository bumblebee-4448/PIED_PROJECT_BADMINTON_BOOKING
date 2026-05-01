import { z } from "zod";

export const profileSchema = z.object({
  name: z.string().min(2, "Họ và tên phải có ít nhất 2 ký tự"),
  email: z.string().email("Email không hợp lệ"),
  phone: z.string().regex(/^[0-9]{10}$/, "Số điện thoại phải có 10 chữ số"),
  preferredLocation: z.string().min(1, "Vui lòng chọn khu vực"),
  level: z.string().min(1, "Vui lòng chọn trình độ"),
  avatar: z.string().optional(),
});

export const passwordChangeSchema = z.object({
  otp: z.string().length(6, "Mã OTP phải có 6 chữ số"),
  newPassword: z.string().min(6, "Mật khẩu phải có ít nhất 6 ký tự"),
});

export const ownerRegistrationSchema = z.object({
  bizName: z.string().min(2, "Tên doanh nghiệp/cá nhân không được để trống"),
  bizPhone: z.string().regex(/^[0-9]{10}$/, "Số điện thoại không hợp lệ"),
  idCard: z.string().min(9, "Số CCCD/CMND không hợp lệ"),
});

export type ProfileSchema = z.infer<typeof profileSchema>;
export type PasswordChangeSchema = z.infer<typeof passwordChangeSchema>;
export type OwnerRegistrationSchema = z.infer<typeof ownerRegistrationSchema>;
