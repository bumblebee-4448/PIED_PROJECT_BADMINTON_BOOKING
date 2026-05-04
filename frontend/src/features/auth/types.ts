import { z } from "zod";
import { loginSchema, registerSchema, forgotPasswordSchema, resetPasswordSchema } from "./schema";

export type LoginInput = z.infer<typeof loginSchema>;
export type RegisterInput = z.infer<typeof registerSchema>;
export type ForgotPasswordInput = z.infer<typeof forgotPasswordSchema>;
export type ResetPasswordInput = z.infer<typeof resetPasswordSchema>;

export interface User {
  id?: string;
  email: string;
  firstName: string;
  lastName: string;
  role?: string;
  avartarUrl?: string | null;
  phoneNumber?: string;
  isOwner?: boolean;
}

export interface AuthResponse {
  accessToken: string;
  role: string;
  user: User;
}
