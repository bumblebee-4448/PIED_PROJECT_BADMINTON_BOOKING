import { Edit3, Loader2, MessageSquare, Star, Trash2, UserRound } from "lucide-react";

import { Button } from "@/shared/components/ui/button";
import type { Feedback } from "../types";

interface CourtFeedbackSectionProps {
  feedbacks: Feedback[];
  totalItems: number;
  isLoading: boolean;
  isLoadingMore: boolean;
  isError: boolean;
  canLoadMore: boolean;
  onLoadMore: () => void;
  canManageFeedback?: (feedback: Feedback) => boolean;
  onEditFeedback?: (feedback: Feedback) => void;
  onDeleteFeedback?: (feedback: Feedback) => void;
}

export function CourtFeedbackSection({
  feedbacks,
  totalItems,
  isLoading,
  isLoadingMore,
  isError,
  canLoadMore,
  onLoadMore,
  canManageFeedback,
  onEditFeedback,
  onDeleteFeedback,
}: CourtFeedbackSectionProps) {
  return (
    <div className="rounded-2xl border border-gray-100 bg-white p-6 shadow-sm">
      <div className="mb-6 flex flex-wrap items-center justify-between gap-3">
        <div className="flex items-center gap-2">
          <MessageSquare size={18} className="text-emerald-500" />
          <h2 className="text-xs font-black uppercase tracking-[0.2em] text-gray-400">
            Đánh giá từ khách hàng
          </h2>
        </div>
        <span className="rounded-full bg-emerald-50 px-3 py-1 text-[10px] font-black uppercase tracking-wider text-emerald-600">
          {totalItems} đánh giá
        </span>
      </div>

      {isLoading && feedbacks.length === 0 ? (
        <div className="space-y-4">
          {[1, 2].map((item) => (
            <div key={item} className="animate-pulse rounded-2xl bg-gray-50 p-4">
              <div className="mb-3 h-4 w-1/3 rounded bg-gray-100" />
              <div className="h-3 w-full rounded bg-gray-100" />
            </div>
          ))}
        </div>
      ) : isError ? (
        <div className="rounded-2xl bg-red-50 p-5 text-sm font-bold text-red-600">
          Không thể tải đánh giá của sân. Vui lòng thử lại sau.
        </div>
      ) : feedbacks.length === 0 ? (
        <div className="rounded-2xl bg-gray-50 p-8 text-center">
          <div className="mx-auto mb-3 flex h-12 w-12 items-center justify-center rounded-2xl bg-white text-gray-300 shadow-sm">
            <MessageSquare size={22} />
          </div>
          <p className="text-sm font-black text-[#0B2421]">Chưa có đánh giá nào</p>
          <p className="mt-1 text-xs font-medium text-gray-400">
            Các đánh giá sau khi khách đặt sân sẽ hiển thị tại đây.
          </p>
        </div>
      ) : (
        <div className="space-y-5">
          <div className="space-y-4">
            {feedbacks.map((feedback, index) => (
              <FeedbackCard
                key={`${feedback.feedbackId || feedback.id || feedback.createdAt}-${index}`}
                feedback={feedback}
                canManage={canManageFeedback?.(feedback) ?? false}
                onEdit={onEditFeedback}
                onDelete={onDeleteFeedback}
              />
            ))}
          </div>

          {canLoadMore && (
            <Button
              variant="outline"
              onClick={onLoadMore}
              disabled={isLoadingMore}
              className="h-11 w-full rounded-2xl border-gray-100 text-xs font-black uppercase tracking-wider text-emerald-600 hover:bg-emerald-50 hover:text-emerald-700"
            >
              {isLoadingMore ? (
                <>
                  <Loader2 size={16} className="animate-spin" />
                  Đang tải thêm...
                </>
              ) : (
                "Xem thêm đánh giá"
              )}
            </Button>
          )}
        </div>
      )}
    </div>
  );
}

function FeedbackCard({
  feedback,
  canManage,
  onEdit,
  onDelete,
}: {
  feedback: Feedback;
  canManage: boolean;
  onEdit?: (feedback: Feedback) => void;
  onDelete?: (feedback: Feedback) => void;
}) {
  return (
    <div className="rounded-2xl border border-gray-100 bg-gray-50/60 p-5">
      <div className="mb-3 flex flex-wrap items-start justify-between gap-3">
        <div className="flex items-center gap-3">
          <div className="flex h-10 w-10 items-center justify-center rounded-2xl bg-white text-emerald-600 shadow-sm">
            <UserRound size={18} />
          </div>
          <div>
            <p className="text-sm font-black text-[#0B2421]">
              {feedback.nameCustomer}
            </p>
            <p className="text-[11px] font-bold text-gray-400">
              {formatFeedbackDate(feedback.createdAt)}
            </p>
          </div>
        </div>
        <div className="flex flex-wrap items-center justify-end gap-2">
          <StarRating rating={feedback.rating} />
          {canManage && (
            <div className="flex items-center gap-1 rounded-full bg-white p-1 shadow-sm">
              <button
                type="button"
                onClick={() => onEdit?.(feedback)}
                className="flex h-8 w-8 items-center justify-center rounded-full text-emerald-600 transition-colors hover:bg-emerald-50"
                aria-label="Sửa đánh giá"
                title="Sửa đánh giá"
              >
                <Edit3 size={15} />
              </button>
              <button
                type="button"
                onClick={() => onDelete?.(feedback)}
                className="flex h-8 w-8 items-center justify-center rounded-full text-red-500 transition-colors hover:bg-red-50"
                aria-label="Xóa đánh giá"
                title="Xóa đánh giá"
              >
                <Trash2 size={15} />
              </button>
            </div>
          )}
        </div>
      </div>

      <p className="text-sm font-medium leading-6 text-gray-600">
        {feedback.comment || "Khách hàng chưa để lại bình luận."}
      </p>
    </div>
  );
}

function StarRating({ rating }: { rating: number }) {
  return (
    <div className="flex items-center gap-1 rounded-full bg-white px-3 py-1.5 shadow-sm">
      {Array.from({ length: 5 }).map((_, index) => (
        <Star
          key={index}
          size={14}
          className={
            index < rating
              ? "fill-yellow-500 text-yellow-500"
              : "fill-gray-100 text-gray-200"
          }
        />
      ))}
      <span className="ml-1 text-xs font-black text-[#0B2421]">{rating}/5</span>
    </div>
  );
}

function formatFeedbackDate(value?: string) {
  if (!value) {
    return "Vừa cập nhật";
  }

  return new Intl.DateTimeFormat("vi-VN", {
    day: "2-digit",
    month: "2-digit",
    year: "numeric",
  }).format(new Date(value));
}
