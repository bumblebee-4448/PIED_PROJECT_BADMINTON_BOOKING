import { QueryClient } from "@tanstack/react-query";

export const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      refetchOnWindowFocus: false, // Không fetch lại khi focus vào tab
      retry: false, // Không tự động thử lại khi lỗi (tránh nhảy nhiều toast)
      staleTime: 30 * 1000, // Dữ liệu được coi là mới trong 30 giây
    },
  },
});
