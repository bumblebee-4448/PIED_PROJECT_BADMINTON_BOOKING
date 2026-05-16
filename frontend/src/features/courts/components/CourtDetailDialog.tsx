import { MapPin, Phone, Clock, Star, Info, Globe } from "lucide-react";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";
import { useAuthStore } from "@/features/auth/store";
import { 
  FeedbackDialog, 
  CourtFeedbackSection, 
  useDeleteFeedback,
  useCourtFeedbacks,
  type Feedback 
} from "@/features/feedback";
import { useBookings } from "@/features/bookings/hooks/useBookings";
import { useCourtDetail } from "../hooks/useCourts";
import { useCallback, useState, useMemo } from "react";
import type { GetBookingResponse } from "@/features/bookings/types";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
} from "@/shared/components/ui/dialog";
import { Badge } from "@/shared/components/ui/badge";
import { Button } from "@/shared/components/ui/button";
import { Skeleton } from "@/shared/components/ui/skeleton";

interface CourtDetailDialogProps {
  courtId: string | null;
  isOpen: boolean;
  onClose: () => void;
}

export function CourtDetailDialog({ courtId, isOpen, onClose }: CourtDetailDialogProps) {
  const navigate = useNavigate();
  const user = useAuthStore((state) => state.user);
  const [feedbackPage, setFeedbackPage] = useState(1);
  const [editingFeedback, setEditingFeedback] = useState<GetBookingResponse | null>(null);
  const deleteFeedback = useDeleteFeedback();
  const { data: bookingsData } = useBookings(1, 1000);
  
  const { data: court, isLoading, isError } = useCourtDetail(courtId || "");
  const {
    data: feedbacks,
    isLoading: isFeedbackLoading,
    isFetching: isFeedbackFetching,
    isError: isFeedbackError,
  } = useCourtFeedbacks(courtId || "", 1, feedbackPage * 5);

  const loadedFeedbacks = useMemo(() => feedbacks?.items || [], [feedbacks?.items]);

  const canLoadMoreFeedbacks = useMemo(() => {
    const totalItems = feedbacks?.totalItems ?? 0;
    return loadedFeedbacks.length < totalItems;
  }, [feedbacks?.totalItems, loadedFeedbacks.length]);

  const currentCustomerName = useMemo(
    () => [user?.firstName, user?.lastName].filter(Boolean).join(" ").trim(),
    [user?.firstName, user?.lastName],
  );

  const canManageFeedback = useCallback((feedback: Feedback) => {
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
          bookingId: completedBooking?.bookingId || feedback.bookingId || "",
          feedbackId: feedback.feedbackId || feedback.id || completedBooking?.feedbackId,
        };
      }),
    [
      canManageFeedback,
      getCompletedBookingForCourt,
      loadedFeedbacks,
    ],
  );

  const handleEditFeedback = (feedback: Feedback) => {
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
      courtId: courtId || undefined,
    });
  };

  const handleDeleteFeedback = (feedback: Feedback) => {
    const feedbackId =
      feedback.feedbackId || feedback.id || getCompletedBookingForCourt()?.feedbackId;
    if (!feedbackId) {
      toast.error("Chưa có mã feedback để xóa. API GET /Feedback cần trả thêm id/feedbackId.");
      return;
    }

    deleteFeedback.mutate({ id: feedbackId });
  };

  return (
    <Dialog open={isOpen} onOpenChange={(open) => !open && onClose()}>
      <DialogContent className="max-w-2xl p-0 overflow-hidden bg-white rounded-3xl border-none shadow-2xl max-h-[90vh] flex flex-col">
        {/* Accessibility requirement: Title and Description must always exist */}
        <div className="sr-only">
          <DialogHeader>
            <DialogTitle>{court?.name || "Chi tiết sân"}</DialogTitle>
            <DialogDescription>
              {court?.address || "Thông tin địa chỉ và các dịch vụ của sân cầu lông"}
            </DialogDescription>
          </DialogHeader>
        </div>

        {isLoading ? (
          <div className="p-8 space-y-4">
            <Skeleton className="h-64 w-full rounded-2xl" />
            <Skeleton className="h-8 w-1/2" />
            <Skeleton className="h-4 w-full" />
            <Skeleton className="h-4 w-3/4" />
          </div>
        ) : isError || !court ? (
          <div className="p-12 text-center">
            <p className="text-red-500 font-bold">Không thể tải thông tin sân. Vui lòng thử lại sau.</p>
          </div>
        ) : (
          <div className="flex flex-col overflow-y-auto custom-scrollbar">
            {/* Cover Image */}
            <div className="relative h-64 w-full group">
              <img 
                src={court.pictureUrl || "https://images.unsplash.com/photo-1626225967045-9c76db7b62dc?w=800&auto=format&fit=crop"} 
                alt={court.name}
                className="w-full h-full object-cover"
              />
              <div className="absolute inset-0 bg-gradient-to-t from-black/60 to-transparent" />
              <div className="absolute bottom-6 left-6 right-6">
                <Badge className="mb-3 bg-emerald-500 hover:bg-emerald-600 text-white border-none px-3 py-1 text-xs font-bold">
                  {court.status === "Active" ? "SẴN SÀNG" : "BẬN"}
                </Badge>
                <DialogTitle className="text-3xl font-black text-white leading-tight">
                  {court.name}
                </DialogTitle>
              </div>
            </div>

            {/* Content */}
            <div className="p-8 space-y-6">
              <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                <div className="space-y-4">
                  <div className="flex items-start gap-3">
                    <div className="mt-1 p-2 bg-emerald-50 rounded-xl text-emerald-600">
                      <MapPin size={18} />
                    </div>
                    <div>
                      <p className="text-[10px] font-bold text-gray-400 uppercase tracking-wider mb-0.5">Địa chỉ</p>
                      <p className="text-sm font-bold text-[#0B2421]">{court.address}</p>
                    </div>
                  </div>

                  <div className="flex items-start gap-3">
                    <div className="mt-1 p-2 bg-blue-50 rounded-xl text-blue-600">
                      <Phone size={18} />
                    </div>
                    <div>
                      <p className="text-[10px] font-bold text-gray-400 uppercase tracking-wider mb-0.5">Số điện thoại</p>
                      <p className="text-sm font-bold text-[#0B2421]">{court.phoneNumber}</p>
                    </div>
                  </div>

                  <div className="flex items-start gap-3">
                    <div className="mt-1 p-2 bg-orange-50 rounded-xl text-orange-600">
                      <Clock size={18} />
                    </div>
                    <div>
                      <p className="text-[10px] font-bold text-gray-400 uppercase tracking-wider mb-0.5">Giờ hoạt động</p>
                      <p className="text-sm font-bold text-[#0B2421]">
                        {court.openTime} - {court.closeTime}
                      </p>
                    </div>
                  </div>
                </div>

                <div className="space-y-4">
                  <div className="flex items-start gap-3">
                    <div className="mt-1 p-2 bg-yellow-50 rounded-xl text-yellow-600">
                      <Star size={18} className="fill-yellow-600" />
                    </div>
                    <div>
                      <p className="text-[10px] font-bold text-gray-400 uppercase tracking-wider mb-0.5">Đánh giá trung bình</p>
                      <div className="flex items-center gap-2">
                        <span className="text-lg font-black text-[#0B2421]">{court.averageRating}</span>
                        <span className="text-xs font-bold text-gray-300">/ 5.0</span>
                      </div>
                    </div>
                  </div>

                  {court.mapUrl && (
                    <a 
                      href={court.mapUrl} 
                      target="_blank" 
                      rel="noopener noreferrer"
                      className="flex items-start gap-3 group/link"
                    >
                      <div className="mt-1 p-2 bg-purple-50 rounded-xl text-purple-600 group-hover/link:bg-purple-600 group-hover/link:text-white transition-colors">
                        <Globe size={18} />
                      </div>
                      <div>
                        <p className="text-[10px] font-bold text-gray-400 uppercase tracking-wider mb-0.5">Bản đồ</p>
                        <p className="text-sm font-bold text-purple-600 group-hover/link:underline">Xem trên Google Maps</p>
                      </div>
                    </a>
                  )}
                </div>
              </div>

              {court.description && (
                <div className="pt-6 border-t border-gray-100">
                  <div className="flex items-center gap-2 mb-3">
                    <Info size={16} className="text-emerald-500" />
                    <h4 className="text-[10px] font-black text-gray-400 uppercase tracking-[0.2em]">Mô tả chi tiết</h4>
                  </div>
                  <p className="text-sm font-medium text-gray-600 leading-relaxed italic">
                    "{court.description}"
                  </p>
                </div>
              )}

              <div className="pt-4 pb-8">
                <Button 
                  onClick={() => {
                    onClose();
                    navigate(`/courts/${courtId}/booking`);
                  }}
                  className="w-full h-12 bg-[#00897B] hover:bg-[#00796B] text-white rounded-2xl font-black text-sm transition-all shadow-lg shadow-emerald-900/10 active:scale-[0.98]"
                >
                  ĐẶT SÂN NGAY
                </Button>
              </div>

              {/* Feedback Section */}
              <div className="pt-6 border-t border-gray-100">
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
            </div>
          </div>
        )}
      </DialogContent>
      <style>{`
        .custom-scrollbar::-webkit-scrollbar {
          width: 6px;
        }
        .custom-scrollbar::-webkit-scrollbar-track {
          background: transparent;
        }
        .custom-scrollbar::-webkit-scrollbar-thumb {
          background: #e2e8f0;
          border-radius: 10px;
        }
        .custom-scrollbar::-webkit-scrollbar-thumb:hover {
          background: #cbd5e1;
        }
      `}</style>
      <FeedbackDialog
        key={editingFeedback?.bookingId || "court-dialog-feedback"}
        isOpen={!!editingFeedback}
        booking={editingFeedback}
        onClose={() => setEditingFeedback(null)}
      />
    </Dialog>
  );
}
