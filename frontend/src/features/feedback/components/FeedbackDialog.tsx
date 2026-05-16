import * as React from "react";
import { Loader2, Star, Trash2 } from "lucide-react";
import { toast } from "sonner";

import { cn } from "@/lib/utils";
import { Button } from "@/shared/components/ui/button";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
} from "@/shared/components/ui/dialog";
import { Textarea } from "@/shared/components/ui/textarea";
import { useDeleteFeedback, useUpsertFeedback } from "../hooks/useFeedback";

interface FeedbackDialogProps {
  booking: {
    bookingId: string;
    courtName: string;
    rating?: number;
    comment?: string | null;
    feedbackId?: string;
  } | null;
  isOpen: boolean;
  onClose: () => void;
}

export function FeedbackDialog({
  booking,
  isOpen,
  onClose,
}: FeedbackDialogProps) {
  const [rating, setRating] = React.useState(booking?.rating || 5);
  const [comment, setComment] = React.useState(booking?.comment || "");
  const upsertFeedback = useUpsertFeedback();
  const deleteFeedback = useDeleteFeedback();

  // Update local state when booking changes (e.g. when lookup finishes)
  React.useEffect(() => {
    if (booking) {
      setRating(booking.rating || 5);
      setComment(booking.comment || "");
    }
  }, [booking]);

  const feedbackId = booking?.feedbackId;
  const isSubmitting = upsertFeedback.isPending || deleteFeedback.isPending;

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    if (!booking?.bookingId) {
      return;
    }

    const payload = feedbackId 
      ? { id: feedbackId, bookingId: booking.bookingId, rating, comment: comment.trim() || null }
      : { bookingId: booking.bookingId, rating, comment: comment.trim() || null };

    upsertFeedback.mutate(payload, {
      onSuccess: onClose,
    });
  };

  const handleDelete = () => {
    if (!feedbackId) {
      toast.error("Không tìm thấy mã đánh giá để xóa.");
      return;
    }

    deleteFeedback.mutate(
      { id: feedbackId },
      {
        onSuccess: onClose,
      },
    );
  };

  return (
    <Dialog open={isOpen} onOpenChange={(open) => !open && onClose()}>
      <DialogContent className="max-w-md rounded-3xl border-0 p-0 shadow-2xl">
        <form onSubmit={handleSubmit} className="overflow-hidden rounded-3xl bg-white">
          <DialogHeader className="bg-emerald-50 px-6 py-5 text-left">
            <DialogTitle className="text-xl font-black text-[#0B2421]">
              Đánh giá sân
            </DialogTitle>
            <DialogDescription className="font-medium text-emerald-700">
              {booking?.courtName || "Sân cầu lông"}
            </DialogDescription>
          </DialogHeader>

          <div className="space-y-6 px-6 py-6">
            <div>
              <p className="mb-3 text-[10px] font-black uppercase tracking-widest text-gray-400">
                Mức độ hài lòng
              </p>
              <div className="flex items-center gap-2">
                {Array.from({ length: 5 }).map((_, index) => {
                  const value = index + 1;
                  const isActive = value <= rating;

                  return (
                    <button
                      key={value}
                      type="button"
                      onClick={() => setRating(value)}
                      disabled={isSubmitting}
                      aria-label={`${value} sao`}
                      className={cn(
                        "flex h-11 w-11 items-center justify-center rounded-2xl border transition-colors",
                        isActive
                          ? "border-yellow-100 bg-yellow-50 text-yellow-500"
                          : "border-gray-100 bg-gray-50 text-gray-300 hover:bg-yellow-50 hover:text-yellow-400",
                      )}
                    >
                      <Star
                        size={22}
                        className={isActive ? "fill-yellow-500" : "fill-transparent"}
                      />
                    </button>
                  );
                })}
              </div>
            </div>

            <div>
              <p className="mb-3 text-[10px] font-black uppercase tracking-widest text-gray-400">
                Nội dung review
              </p>
              <Textarea
                value={comment}
                onChange={(event) => setComment(event.target.value)}
                disabled={isSubmitting}
                maxLength={500}
                placeholder="Chia sẻ cảm nhận của bạn về sân..."
                className="min-h-32 resize-none rounded-2xl border-gray-100 bg-gray-50/60 text-sm font-medium focus-visible:ring-emerald-500"
              />
              <p className="mt-2 text-right text-[11px] font-bold text-gray-300">
                {comment.length}/500
              </p>
            </div>
          </div>

          <DialogFooter className="gap-3 border-t border-gray-50 px-6 py-5 sm:space-x-0">
            {feedbackId && (
              <Button
                type="button"
                variant="ghost"
                onClick={handleDelete}
                disabled={isSubmitting}
                className="rounded-2xl text-red-500 hover:bg-red-50 hover:text-red-600"
              >
                {deleteFeedback.isPending ? (
                  <Loader2 size={16} className="animate-spin" />
                ) : (
                  <Trash2 size={16} />
                )}
                Xóa
              </Button>
            )}

            <Button
              type="submit"
              disabled={isSubmitting}
              className="h-11 rounded-2xl bg-[#00897B] px-6 font-black text-white hover:bg-[#00796B]"
            >
              {upsertFeedback.isPending && (
                <Loader2 size={16} className="animate-spin" />
              )}
              Lưu đánh giá
            </Button>
          </DialogFooter>
        </form>
      </DialogContent>
    </Dialog>
  );
}
