import type { UserRole } from "@/shared/types";

export interface User {
  id: string;
  email: string;
  firstName: string;
  lastName: string;
  fullName?: string;
  phoneNumber: string;
  avartarUrl?: string | null;
  role: UserRole;
  preferredLocation?: string;
  level?: string;
  isOwner?: boolean;
}

export interface ProfileUpdateInput {
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  preferredLocation: string;
  level: string;
  avartarUrl?: string | null;
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
