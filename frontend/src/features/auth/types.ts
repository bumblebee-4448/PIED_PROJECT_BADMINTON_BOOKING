import { z } from "zod";
import { loginSchema, registerSchema } from "./schema";

export type LoginInput = z.infer<typeof loginSchema>;
export type RegisterInput = z.infer<typeof registerSchema>;

export interface User {
  id: string;
  email: string;
  fullName: string;
  role: string;
  avatar?: string;
  phone?: string;
  isOwner?: boolean;
}

export interface AuthResponse {
  accessToken: string;
  role: string;
  user: User;
}
