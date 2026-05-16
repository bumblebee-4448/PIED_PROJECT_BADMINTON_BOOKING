import { useCallback, useMemo, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { toast } from "sonner";
import {
  ArrowLeft,
  CalendarCheck,
  Clock,
  Globe,
  Info,
  Loader2,
  MapPin,
  Phone,
  Star,
} from "lucide-react";

import { Button } from "@/shared/components/ui/button";
import { Badge } from "@/shared/components/ui/badge";
import { useAuthStore } from "@/features/auth/store";
import { FeedbackDialog } from "@/features/bookings/components/FeedbackDialog";
import { useDeleteBookingFeedback } from "@/features/bookings/hooks/useBookingFeedback";
import { useBookings } from "@/features/bookings/hooks/useBookings";
import { useCourtDetail, useCourtFeedbacks } from "../hooks/useCourts";
import { CourtDetailItem } from "../components/CourtDetailItem";
import { CourtFeedbackSection } from "../components/CourtFeedbackSection";
import type { CourtFeedback } from "../types";
import type { GetBookingResponse } from "@/features/bookings/types";

const fallbackCourtImage =
  "https://images.unsplash.com/photo-1626225967045-9c76db7b62dc?w=1200&auto=format&fit=crop";
const FEEDBACK_PAGE_SIZE = 10;

const formatCourtPrice = (price?: number) => {
  if (typeof price !== "number" || price < 0) {
    return "Liên hệ";
  }

  return new Intl.NumberFormat("vi-VN", {
    style: "currency",
    currency: "VND",
    maximumFractionDigits: 0,
  }).format(price);
};

export function CourtDetailPage() {
  const { id: courtId } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const user = useAuthStore((state) => state.user);
  const [feedbackPage, setFeedbackPage] = useState(1);
  const [editingFeedback, setEditingFeedback] = useState<GetBookingResponse | null>(null);
  const deleteFeedback = useDeleteBookingFeedback();
  const { data: bookingsData } = useBookings(1, 1000);
  const { data: court, isLoading, isError } = useCourtDetail(courtId || "");
  const {
    data: feedbacks,
    isLoading: isFeedbackLoading,
    isFetching: isFeedbackFetching,
    isError: isFeedbackError,
  } = useCourtFeedbacks(courtId || "", 1, feedbackPage * FEEDBACK_PAGE_SIZE);

  const loadedFeedbacks = useMemo(() => feedbacks?.items || [], [feedbacks?.items]);

  const canLoadMoreFeedbacks = useMemo(() => {
    const totalItems = feedbacks?.totalItems ?? 0;
    return loadedFeedbacks.length < totalItems;
  }, [feedbacks?.totalItems, loadedFeedbacks.length]);

  const currentCustomerName = useMemo(
    () => [user?.firstName, user?.lastName].filter(Boolean).join(" ").trim(),
    [user?.firstName, user?.lastName],
  );

  const canManageFeedback = useCallback((feedback: CourtFeedback) => {
    if (!currentCustomerName) {
      return false;
    }

    const feedbackName = feedback.nameCustomer.trim().toLowerCase();
    const fullName = currentCustomerName.toLowerCase();
    const firstName = (user?.firstName || "").trim().toLowerCase();

    return feedbackName === fullName || (!!firstName && feedbackName === firstName);
  }, [currentCustomerName, user?.firstName]);

  const getCompletedBookingForCourt = useCallback(() =>
    bookingsData?.items.find(
      (booking) =>
        (booking.status === "Complete" || booking.status === "Completed") &&
        (booking.courtId === courtId ||
          booking.address === court?.address ||
          (booking.courtName === court?.name && booking.address === court?.address)),
    ), [bookingsData?.items, court?.address, court?.name, courtId]);

  const displayFeedbacks = useMemo(
    () =>
      loadedFeedbacks.map((feedback) => {
        if (feedback.bookingId || !canManageFeedback(feedback)) {
          return feedback;
        }

        const completedBooking = getCompletedBookingForCourt();

        return {
          ...feedback,
          bookingId: completedBooking?.bookingId,
          feedbackId: feedback.feedbackId || feedback.id || completedBooking?.feedbackId,
        };
      }),
    [
      canManageFeedback,
      getCompletedBookingForCourt,
      loadedFeedbacks,
    ],
  );

  const handleEditFeedback = (feedback: CourtFeedback) => {
    const bookingId = feedback.bookingId || getCompletedBookingForCourt()?.bookingId;
    if (!bookingId) {
      toast.error("Không tìm thấy đơn hoàn thành để sửa đánh giá.");
      return;
    }

    setEditingFeedback({
      bookingId,
      courtName: court?.name || "Sân cầu lông",
      address: court?.address || "",
      finalPrice: 0,
      status: "Completed",
      slotsResponses: [],
      phoneNumber: court?.phoneNumber || "",
      urlMap: court?.mapUrl || "",
      rating: feedback.rating,
      comment: feedback.comment,
      feedbackId: feedback.feedbackId || feedback.id,
      courtId,
    });
  };

  const handleDeleteFeedback = (feedback: CourtFeedback) => {
    const feedbackId =
      feedback.feedbackId || feedback.id || getCompletedBookingForCourt()?.feedbackId;
    if (!feedbackId) {
      toast.error("Chưa có mã feedback để xóa. API GET /Feedback cần trả thêm id/feedbackId.");
      return;
    }

    deleteFeedback.mutate({ id: feedbackId });
  };

  if (isLoading) {
    return (
      <div className="flex min-h-screen items-center justify-center bg-[#F9FBFA] pt-20">
        <div className="flex flex-col items-center gap-4">
          <Loader2 size={44} className="animate-spin text-emerald-500" />
          <p className="text-xs font-black uppercase tracking-[0.2em] text-gray-400">
            Đang tải thông tin sân...
          </p>
        </div>
      </div>
    );
  }

  if (isError || !court) {
    return (
      <div className="min-h-screen bg-[#F9FBFA] px-4 pb-20 pt-32">
        <div className="mx-auto max-w-3xl rounded-2xl border border-red-100 bg-white p-10 text-center shadow-sm">
          <h1 className="mb-3 text-2xl font-black text-[#0B2421]">
            Không thể tải thông tin sân
          </h1>
          <p className="mb-6 text-sm font-medium text-gray-500">
            Vui lòng thử lại sau hoặc quay về trang tìm kiếm.
          </p>
          <Button
            onClick={() => navigate("/courts")}
            className="h-11 rounded-xl bg-[#00897B] px-6 font-bold text-white hover:bg-[#00796B]"
          >
            Quay lại tìm sân
          </Button>
        </div>
      </div>
    );
  }

  const isActive = court.status === "Active";
  const hasListedPrice =
    typeof court.defaultPrice === "number" && court.defaultPrice >= 0;

  return (
    <div className="min-h-screen bg-[#F9FBFA] pb-20 pt-20">
      <section className="relative min-h-[460px] overflow-hidden bg-[#0B2421]">
        <img
          src={court.pictureUrl || fallbackCourtImage}
          alt={court.name}
          className="absolute inset-0 h-full w-full object-cover"
        />
        <div className="absolute inset-0 bg-gradient-to-t from-[#071714] via-[#071714]/55 to-[#071714]/10" />

        <div className="relative mx-auto flex min-h-[460px] max-w-6xl flex-col justify-between px-4 py-8 sm:px-6">
          <button
            onClick={() => navigate(-1)}
            className="flex w-fit items-center gap-2 rounded-xl bg-white/90 px-3 py-2 text-xs font-black uppercase tracking-wider text-[#0B2421] shadow-sm backdrop-blur transition hover:bg-white"
          >
            <ArrowLeft size={16} />
            Quay lại
          </button>

          <div className="max-w-3xl pb-4">
            <Badge
              className={
                isActive
                  ? "mb-4 border-none bg-emerald-500 px-4 py-1.5 text-xs font-black text-white hover:bg-emerald-500"
                  : "mb-4 border-none bg-red-500 px-4 py-1.5 text-xs font-black text-white hover:bg-red-500"
              }
            >
              {isActive ? "Sẵn sàng" : "Bận"}
            </Badge>
            <h1 className="text-4xl font-black leading-tight text-white sm:text-5xl">
              {court.name}
            </h1>
            <div className="mt-5 flex flex-wrap items-center gap-3">
              <div className="flex items-center gap-2 rounded-2xl bg-white/95 px-4 py-2 text-sm font-bold text-[#0B2421] shadow-sm">
                <MapPin size={16} className="text-emerald-500" />
                <span>{court.address}</span>
              </div>
              <div className="flex items-center gap-2 rounded-2xl bg-white/95 px-4 py-2 text-sm font-bold text-[#0B2421] shadow-sm">
                <Star size={16} className="fill-yellow-500 text-yellow-500" />
                <span>{court.averageRating} / 5.0</span>
              </div>
            </div>
          </div>
        </div>
      </section>

      <section className="mx-auto grid max-w-6xl grid-cols-1 gap-8 px-4 pt-10 sm:px-6 lg:grid-cols-[1fr_340px]">
        <div className="space-y-8">
          <div className="grid grid-cols-1 gap-4 sm:grid-cols-2">
            <CourtDetailItem
              icon={<MapPin size={20} />}
              iconClassName="bg-emerald-50 text-emerald-600"
              label="Địa chỉ"
              value={court.address}
            />
            <CourtDetailItem
              icon={<Phone size={20} />}
              iconClassName="bg-blue-50 text-blue-600"
              label="Số điện thoại"
              value={court.phoneNumber || "Chưa cập nhật"}
            />
            <CourtDetailItem
              icon={<Clock size={20} />}
              iconClassName="bg-orange-50 text-orange-600"
              label="Giờ hoạt động"
              value={`${court.openTime} - ${court.closeTime}`}
            />
            <CourtDetailItem
              icon={<Star size={20} className="fill-yellow-600" />}
              iconClassName="bg-yellow-50 text-yellow-600"
              label="Đánh giá trung bình"
              value={`${court.averageRating} / 5.0`}
            />
          </div>

          {court.description && (
            <div className="rounded-2xl border border-gray-100 bg-white p-6 shadow-sm">
              <div className="mb-4 flex items-center gap-2">
                <Info size={18} className="text-emerald-500" />
                <h2 className="text-xs font-black uppercase tracking-[0.2em] text-gray-400">
                  Mô tả chi tiết
                </h2>
              </div>
              <p className="text-sm font-medium leading-7 text-gray-600">
                {court.description}
              </p>
            </div>
          )}

          <CourtFeedbackSection
            feedbacks={displayFeedbacks}
            totalItems={feedbacks?.totalItems ?? 0}
            isLoading={isFeedbackLoading}
            isLoadingMore={isFeedbackFetching && feedbackPage > 1}
            isError={isFeedbackError}
            canLoadMore={canLoadMoreFeedbacks}
            onLoadMore={() => setFeedbackPage((page) => page + 1)}
            canManageFeedback={canManageFeedback}
            onEditFeedback={handleEditFeedback}
            onDeleteFeedback={handleDeleteFeedback}
          />
        </div>

        <aside className="h-fit rounded-2xl border border-gray-100 bg-white p-5 shadow-sm">
          <div className="mb-5 rounded-2xl bg-emerald-50 p-4">
            <p className="mb-1 text-[10px] font-black uppercase tracking-[0.2em] text-emerald-600">
              Giá từ
            </p>
            <p className="text-2xl font-black text-[#0B2421]">
              {formatCourtPrice(court.defaultPrice)}
            </p>
            {hasListedPrice ? (
              <p className="mt-1 text-xs font-bold text-gray-400">/giờ</p>
            ) : null}
          </div>

          <div className="space-y-3">
            <Button
              onClick={() => navigate(`/courts/${courtId}/booking`)}
              className="h-12 w-full rounded-2xl bg-[#00897B] text-sm font-black text-white shadow-lg shadow-emerald-900/10 transition-all hover:bg-[#00796B] active:scale-[0.98]"
            >
              <CalendarCheck size={18} />
              Đặt sân ngay
            </Button>

            {court.mapUrl && (
              <Button
                variant="outline"
                asChild
                className="h-12 w-full rounded-2xl border-gray-100 text-sm font-black text-purple-600 hover:bg-purple-50 hover:text-purple-700"
              >
                <a href={court.mapUrl} target="_blank" rel="noopener noreferrer">
                  <Globe size={18} />
                  Xem trên Google Maps
                </a>
              </Button>
            )}
          </div>
        </aside>
      </section>

      <FeedbackDialog
        key={editingFeedback?.bookingId || "court-feedback-dialog"}
        isOpen={!!editingFeedback}
        booking={editingFeedback}
        onClose={() => setEditingFeedback(null)}
      />
    </div>
  );
}
