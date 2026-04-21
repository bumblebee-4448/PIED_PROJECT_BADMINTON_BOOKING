import { Toaster } from "@/shared/components/ui/sonner";

import { QueryProvider, RouterProvider } from "@/app/providers";

/**
 * App root – kết nối tất cả providers.
 */
export default function App() {
  return (
    <QueryProvider>
      <RouterProvider />
      <Toaster position="top-right" richColors closeButton />
    </QueryProvider>
  );
}
