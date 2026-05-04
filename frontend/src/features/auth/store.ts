import { create } from 'zustand';
import { persist, createJSONStorage } from 'zustand/middleware';

import type { UserRole } from '@/shared/types';
import type { User } from './types';

interface AuthState {
  accessToken: string | null;
  role: UserRole | null;
  user: User | null;
  isLoginPromptOpen: boolean;
  setAuth: (accessToken: string, role: UserRole, user?: User) => void;
  logout: () => void;
  setLoginPromptOpen: (open: boolean) => void;
}

export const useAuthStore = create<AuthState>()(
  persist(
    (set) => ({
      accessToken: null,
      role: null,
      user: null,
      isLoginPromptOpen: false,
      setAuth: (accessToken, role, user) => set({ accessToken, role, user }),
      logout: () => {
        set({ accessToken: null, role: null, user: null });
        localStorage.removeItem('auth-storage'); // Xóa sạch key khỏi LS
      },
      setLoginPromptOpen: (open) => set({ isLoginPromptOpen: open }),
    }),
    {
      name: 'auth-storage', // Key trong localStorage
      storage: createJSONStorage(() => localStorage),
      // Chỉ lưu các trường cần thiết, không lưu trạng thái UI như dialog
      partialize: (state) => ({
        accessToken: state.accessToken,
        role: state.role,
        user: state.user,
      }),
    }
  )
);
