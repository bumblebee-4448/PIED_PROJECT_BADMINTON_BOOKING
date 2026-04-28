import { z } from "zod";

export const loginSchema = z.object({
  email: z
    .string()
    .min(1, { message: "Email không được để trống" })
    .email({ message: "Email không hợp lệ" }),
  password: z
    .string()
    .min(6, { message: "Mật khẩu phải có ít nhất 6 ký tự" }),
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
    .min(6, { message: "Mật khẩu phải có ít nhất 6 ký tự" }),
});
