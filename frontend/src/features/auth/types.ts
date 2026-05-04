import { z } from "zod";
import { loginSchema, registerSchema } from "./schema";

export type LoginInput = z.infer<typeof loginSchema>;
export type RegisterInput = z.infer<typeof registerSchema>;

export interface User {
  id: string;
  email: string;
  firstName: string;
  lastName: string;
  fullName?: string;
  role: string;
  avartarUrl?: string | null;
  phoneNumber?: string;
  isOwner?: boolean;
}

export interface AuthResponse {
  accessToken: string;
  role: string;
  user: User;
}
