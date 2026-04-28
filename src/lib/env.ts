/**
 * Environment variables validation & export
 *
 * ⚠️ Fail-fast principle: Nếu thiếu env variables → App crash ngay lúc start
 * Tốt hơn là runtime error khi user đang dùng!
 */

const API_URL = import.meta.env.VITE_API_URL;

if (!API_URL) {
  throw new Error(
    "❌ MISSING ENVIRONMENT VARIABLE: VITE_API_URL\n" +
      "Please create .env file with: VITE_API_URL=http://localhost:3000",
  );
}

export const env = {
  API_URL,
} as const;
