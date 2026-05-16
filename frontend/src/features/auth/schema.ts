import { z } from "zod";

export const loginSchema = z.object({
  email: z
    .string()
    .min(1, { message: "Email không được để trống" })
    .email({ message: "Email không hợp lệ" }),
  password: z
    .string()
    .min(6, { message: "Mật khẩu phải có ít nhất 6 ký tự" })
    .regex(/[A-Z]/, { message: "Mật khẩu phải chứa ít nhất 1 chữ hoa" })
    .regex(/[0-9]/, { message: "Mật khẩu phải chứa ít nhất 1 chữ số" })
    .regex(/[^a-zA-Z0-9]/, { message: "Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt" }),
});

export const registerSchema = z.object({
  fullName: z
    .string()
    .min(1, { message: "Họ và tên không được để trống" }),
  phone: z
    .string()
    .min(10, { message: "Số điện thoại không hợp lệ" })
    .max(11, { message: "Số điện thoại không hợp lệ" }),
  email: z
    .string()
    .min(1, { message: "Email không được để trống" })
    .email({ message: "Email không hợp lệ" }),
  password: z
    .string()
    .min(6, { message: "Mật khẩu phải có ít nhất 6 ký tự" })
    .regex(/[A-Z]/, { message: "Mật khẩu phải chứa ít nhất 1 chữ hoa" })
    .regex(/[0-9]/, { message: "Mật khẩu phải chứa ít nhất 1 chữ số" })
    .regex(/[^a-zA-Z0-9]/, { message: "Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt" }),
});

export const forgotPasswordSchema = z.object({
  email: z
    .string()
    .min(1, { message: "Email không được để trống" })
    .email({ message: "Email không hợp lệ" }),
});

export const resetPasswordSchema = z.object({
  email: z
    .string()
    .min(1, { message: "Email không được để trống" })
    .email({ message: "Email không hợp lệ" }),
  otpCode: z
    .string()
    .min(6, { message: "Mã OTP phải có 6 ký tự" })
    .max(6, { message: "Mã OTP phải có 6 ký tự" }),
  newPassword: z
    .string()
    .min(6, { message: "Mật khẩu mới phải có ít nhất 6 ký tự" })
    .regex(/[A-Z]/, { message: "Mật khẩu mới phải chứa ít nhất 1 chữ hoa" })
    .regex(/[0-9]/, { message: "Mật khẩu mới phải chứa ít nhất 1 chữ số" })
    .regex(/[^a-zA-Z0-9]/, { message: "Mật khẩu mới phải chứa ít nhất 1 ký tự đặc biệt" }),
});
