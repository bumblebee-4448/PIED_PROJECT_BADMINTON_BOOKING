import { Moon, Sun } from "lucide-react";

import { Button } from "@/shared/components/ui/button";
import { useThemeStore } from "@/app/store";

/**
 * Nút bật/tắt Dark Mode.
 */
export function ThemeToggle() {
  const { theme, toggleTheme } = useThemeStore();

  return (
    <Button
      variant="ghost"
      size="icon"
      onClick={toggleTheme}
      aria-label="Chuyển đổi giao diện sáng/tối"
    >
      {theme === "light" ? (
        <Moon className="h-5 w-5" />
      ) : (
        <Sun className="h-5 w-5" />
      )}
    </Button>
  );
}
