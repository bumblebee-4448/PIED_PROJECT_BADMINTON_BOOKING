import { create } from "zustand";
import { persist, createJSONStorage } from "zustand/middleware";

type Theme = "light" | "dark";

interface ThemeState {
  theme: Theme;
  toggleTheme: () => void;
  setTheme: (theme: Theme) => void;
}

/**
 * Zustand store cho theme – persist vào localStorage.
 * Tailwind v4 dùng CSS color-scheme property.
 */
export const useThemeStore = create<ThemeState>()(
  persist(
    (set, get) => ({
      theme: "light",

      toggleTheme: () => {
        const next = get().theme === "light" ? "dark" : "light";

        // Apply both: class for Tailwind + color-scheme for browser
        document.documentElement.classList.remove("light", "dark");
        document.documentElement.classList.add(next);
        document.documentElement.style.colorScheme = next;

        set({ theme: next });
      },

      setTheme: (theme) => {
        // Apply both: class for Tailwind + color-scheme for browser
        document.documentElement.classList.remove("light", "dark");
        document.documentElement.classList.add(theme);
        document.documentElement.style.colorScheme = theme;

        set({ theme });
      },
    }),
    {
      name: "theme-storage",
      storage: createJSONStorage(() => localStorage),
      onRehydrateStorage: () => (state) => {
        // Khi rehydrate (reload page), apply lại theme
        if (state?.theme) {
          document.documentElement.classList.remove("light", "dark");
          document.documentElement.classList.add(state.theme);
          document.documentElement.style.colorScheme = state.theme;
        }
      },
    },
  ),
);
