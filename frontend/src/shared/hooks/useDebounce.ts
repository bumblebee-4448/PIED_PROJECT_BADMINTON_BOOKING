import { useEffect, useState } from "react";

/**
 * Custom Hook: useDebounce
 * Debounce pattern: Trì hoãn xử lý cho đến khi user NGỪNG typing.
 *
 * Use case: Ô search
 * - User gõ: "r" → "re" → "rea" → "reac" → "react"
 * - Không debounce: Gọi API 5 lần (mỗi ký tự 1 lần) ❌
 * - Có debounce: Chỉ gọi API 1 lần sau khi user ngừng gõ 500ms ✅
 *
 * Generic type <T>: Hook này hoạt động với BẤT KỲ type nào.
 * VD: useDebounce<string>("abc") → T = string
 *     useDebounce<number>(123) → T = number
 *
 * Default parameter: delay = 500
 * → Nếu không truyền param thứ 2, mặc định = 500ms.
 * VD: useDebounce(searchText) = useDebounce(searchText, 500)
 */
export function useDebounce<T>(value: T, delay = 500): T {
  const [debounced, setDebounced] = useState(value);

  useEffect(() => {
    const timer = setTimeout(() => setDebounced(value), delay);

    return () => clearTimeout(timer);
  }, [value, delay]); // Dependencies: Effect chạy lại khi value hoặc delay thay đổi

  return debounced;
}
