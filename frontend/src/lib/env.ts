/**
 * Environment variables validation & export
 *
 * ⚠️ Fail-fast principle: Nếu thiếu env variables → App crash ngay lúc start
 * Tốt hơn là runtime error khi user đang dùng!
 */

const VITE_API_URL = import.meta.env.VITE_API_URL || "https://rallyhub.onrender.com";

if (!import.meta.env.VITE_API_URL && import.meta.env.DEV) {
  console.warn(
    "⚠️ MISSING ENVIRONMENT VARIABLE: VITE_API_URL\n" +
      "Using default: https://rallyhub.onrender.com"
  );
}

export const env = {
  VITE_API_URL,
} as const;
