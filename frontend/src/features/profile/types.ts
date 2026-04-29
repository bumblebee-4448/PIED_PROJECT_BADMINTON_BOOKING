import type { UserRole } from "@/shared/types";

export interface User {
  id: string;
  email: string;
  name: string;
  phone: string;
  avatar?: string;
  role: UserRole;
  preferredLocation?: string;
  level?: string;
  isOwner?: boolean;
}

export interface ProfileUpdateInput {
  name: string;
  email: string;
  phone: string;
  preferredLocation: string;
  level: string;
  avatar?: string;
}

export interface PasswordChangeInput {
  otp: string;
  newPassword: string;
}

export interface OwnerRegistrationInput {
  bizName: string;
  bizPhone: string;
  idCard: string;
  verificationDocs: string[]; // URLs or base64
}
