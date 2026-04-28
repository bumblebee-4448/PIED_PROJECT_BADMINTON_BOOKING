/**
 * Environment variables validation & export
 *
 * ⚠️ Fail-fast principle: Nếu thiếu env variables → App crash ngay lúc start
 * Tốt hơn là runtime error khi user đang dùng!
 */

const VITE_API_URL = import.meta.env.VITE_API_URL;

if (!VITE_API_URL) {
  throw new Error(
    "❌ MISSING ENVIRONMENT VARIABLE: VITE_API_URL\n" +
      "Please create .env file with: VITE_API_URL=https://rallyhub.onrender.com",
  );
}

export const env = {
  VITE_API_URL,
} as const;
