import { create } from 'zustand';

interface AuthState {
  accessToken: string | null;
  role: string | null;
  user: any | null;
  setAuth: (accessToken: string, role: string, user?: any) => void;
  logout: () => void;
}

export const useAuthStore = create<AuthState>((set) => ({
  accessToken: null,
  role: null,
  user: null,
  setAuth: (accessToken, role, user) => set({ accessToken, role, user }),
  logout: () => set({ accessToken: null, role: null, user: null }),
}));
