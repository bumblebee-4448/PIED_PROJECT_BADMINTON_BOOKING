import { AlertCircle } from "lucide-react";
import { cn } from "@/lib/utils";
import { Button } from "@/shared/components/ui/button";

interface ErrorStateProps {
  message?: string;
  onRetry?: () => void;
  className?: string;
}

/**
 * Component hiển thị lỗi với nút retry.
 * Dùng khi query/mutation thất bại.
 */
export function ErrorState({
  message = "Đã có lỗi xảy ra",
  onRetry,
  className,
}: ErrorStateProps) {
  return (
    <div
      className={cn(
        "flex flex-col items-center justify-center p-12 text-center max-w-md mx-auto",
        className,
      )}
    >
      <div className="rounded-full bg-destructive/10 p-4 mb-4">
        <AlertCircle className="h-12 w-12 text-destructive" />
      </div>
      <h3 className="text-2xl font-bold mb-2">System Error</h3>
      <p className="text-muted-foreground mb-6 text-base">{message}</p>
      <Button
        variant="destructive"
        size="lg"
        onClick={onRetry || (() => window.location.reload())}
      >
        Retry Connection
      </Button>
    </div>
  );
}
