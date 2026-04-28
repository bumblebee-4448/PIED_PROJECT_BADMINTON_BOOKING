import { Link } from "react-router-dom";
import { FileQuestion } from "lucide-react";

import { Button } from "@/shared/components/ui/button";

/**
 * Page 404 - Không tìm thấy.
 * Hiển thị khi user truy cập URL không tồn tại.
 */
export function NotFoundPage() {
  return (
    <div className="flex min-h-[60vh] items-center justify-center">
      <div className="text-center">
        <FileQuestion className="mx-auto h-16 w-16 text-muted-foreground" />
        <h1 className="mt-4 text-4xl font-bold text-muted-foreground">404</h1>
        <p className="mt-2 text-lg text-muted-foreground">
          Trang bạn tìm không tồn tại.
        </p>
        <Button variant="link" asChild className="mt-4">
          <Link to="/">Về trang chủ</Link>
        </Button>
      </div>
    </div>
  );
}
