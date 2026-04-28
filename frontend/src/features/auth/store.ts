import { create } from 'zustand';
import { persist, createJSONStorage } from 'zustand/middleware';

interface AuthState {
  accessToken: string | null;
  role: string | null;
  user: any | null;
  isLoginPromptOpen: boolean;
  setAuth: (accessToken: string, role: string, user?: any) => void;
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
      logout: () => set({ accessToken: null, role: null, user: null }),
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
