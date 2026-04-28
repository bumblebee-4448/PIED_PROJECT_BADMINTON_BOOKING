import { create } from 'zustand';

interface AuthState {
  accessToken: string | null;
  role: string | null;
  user: any | null;
  isLoginPromptOpen: boolean;
  setAuth: (accessToken: string, role: string, user?: any) => void;
  logout: () => void;
  setLoginPromptOpen: (open: boolean) => void;
}

export const useAuthStore = create<AuthState>((set) => ({
  accessToken: null,
  role: null,
  user: null,
  isLoginPromptOpen: false,
  setAuth: (accessToken, role, user) => set({ accessToken, role, user }),
  logout: () => set({ accessToken: null, role: null, user: null }),
  setLoginPromptOpen: (open) => set({ isLoginPromptOpen: open }),
}));
