import { Link } from "react-router-dom";
import { ShieldAlert } from "lucide-react";

import { Button } from "@/shared/components/ui/button";

/**
 * Page 403 - Không có quyền truy cập.
 * Hiển thị khi user cố truy cập route không đủ role.
 */
export function UnauthorizedPage() {
  return (
    <div className="flex min-h-[60vh] items-center justify-center">
      <div className="text-center">
        <ShieldAlert className="mx-auto h-16 w-16 text-destructive" />
        <h1 className="mt-4 text-4xl font-bold text-destructive">403</h1>
        <p className="mt-2 text-lg text-muted-foreground">
          Bạn không có quyền truy cập trang này.
        </p>
        <Button variant="link" asChild className="mt-4">
          <Link to="/">Về trang chủ</Link>
        </Button>
      </div>
    </div>
  );
}
