import React from "react";
import { BookingFilters } from "../components/BookingFilters";
import { BookingCard } from "../components/BookingCard";
import { CancelBookingDialog } from "../components/CancelBookingDialog";
import { useBookings } from "../hooks/useBookings";
import { useFilteredBookings } from "../hooks/useFilteredBookings";
import { useRefundBooking } from "../hooks/useRefundBooking";
import { Loader2, ClipboardList, AlertCircle } from "lucide-react";
import { 
  Pagination, 
  PaginationContent, 
  PaginationItem, 
  PaginationLink, 
  PaginationNext, 
  PaginationPrevious 
} from "@/shared/components/ui/pagination";
import {
  AlertDialog,
  AlertDialogAction,
  AlertDialogCancel,
  AlertDialogContent,
  AlertDialogDescription,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogTitle,
} from "@/shared/components/ui/alert-dialog";
import { cn } from "@/lib/utils";
import { DEFAULT_PAGE_SIZE, type FilterStatus } from "../types";
import { toast } from "sonner";

export function BookingHistoryPage() {
  const [pageIndex, setPageIndex] = React.useState(1);
  const [activeStatus, setActiveStatus] = React.useState<FilterStatus>("all");
  const [cancellingBooking, setCancellingBooking] = React.useState<{id: string, status: string} | null>(null);
  const [refundingId, setRefundingId] = React.useState<string | null>(null);

  const { data, isLoading, isError } = useBookings(pageIndex, DEFAULT_PAGE_SIZE);
  const { filteredItems, counts } = useFilteredBookings(data, activeStatus);
  const refundMutation = useRefundBooking();

  const handleStatusChange = (status: FilterStatus) => {
    setActiveStatus(status);
    setPageIndex(1); // Reset to first page on filter change
  };

  const handleRefund = () => {
    if (!refundingId) return;
    
    refundMutation.mutate(refundingId, {
      onSuccess: () => {
        toast.success("Đã gửi yêu cầu hoàn tiền thành công!");
        setRefundingId(null);
      },
      onError: () => {
        toast.error("Không thể hoàn tiền. Vui lòng thử lại sau.");
      }
    });
  };

  const totalPages = data ? Math.ceil(data.totalItems / DEFAULT_PAGE_SIZE) : 0;

  if (isLoading) {
    return (
      <div className="min-h-[60vh] flex flex-col items-center justify-center gap-4">
        <Loader2 className="w-12 h-12 text-[#00897B] animate-spin" />
        <span className="text-sm font-bold text-gray-400 uppercase tracking-widest">Đang tải lịch sử...</span>
      </div>
    );
  }

  if (isError) {
    return (
      <div className="min-h-[60vh] flex flex-col items-center justify-center text-center p-6">
        <div className="w-20 h-20 rounded-full bg-red-50 flex items-center justify-center text-red-500 mb-6">
          <ClipboardList size={40} />
        </div>
        <h2 className="text-2xl font-black text-gray-900 mb-2">Oops! Có lỗi xảy ra</h2>
        <p className="text-gray-500 max-w-md mx-auto mb-8 font-medium">
          Không thể tải được lịch sử đặt sân của bạn vào lúc này. Vui lòng thử lại sau.
        </p>
      </div>
    );
  }

  return (
    <div className="bg-[#F8FAFB] min-h-screen pt-28 pb-20">
      <div className="max-w-4xl mx-auto px-6">
        {/* Header */}
        <div className="mb-10">
          <div className="flex items-center gap-3 mb-2">
            <h1 className="text-4xl font-black text-gray-900 tracking-tight">
              Lịch sử đặt sân
            </h1>
            <span className="text-3xl">📋</span>
          </div>
          <p className="text-gray-400 font-bold">
            {data?.totalItems || 0} đơn đặt sân
          </p>
        </div>

        {/* Filters */}
        <BookingFilters 
          activeStatus={activeStatus} 
          onStatusChange={handleStatusChange}
          counts={counts}
        />

        {/* Booking List */}
        <div className="space-y-6">
          {filteredItems.length > 0 ? (
            filteredItems.map((booking, index) => (
              <BookingCard 
                key={booking.bookingId || (booking as any).BookingId || (booking as any).Id || `booking-${index}`} 
                booking={booking} 
                onCancelClick={(id) => setCancellingBooking({ id, status: booking.status })}
                onRefundClick={(id) => setRefundingId(id)}
              />
            ))
          ) : (
            <div className="bg-white rounded-[40px] p-16 text-center border border-dashed border-gray-200">
              <div className="w-24 h-24 rounded-full bg-gray-50 flex items-center justify-center text-gray-300 mx-auto mb-8">
                <ClipboardList size={48} />
              </div>
              <h3 className="text-xl font-black text-gray-900 mb-2">Chưa có dữ liệu</h3>
              <p className="text-gray-400 font-medium max-w-xs mx-auto">
                Bạn chưa có đơn đặt sân nào trong mục này.
              </p>
            </div>
          )}
        </div>

        {/* Pagination */}
        {totalPages > 1 && (
          <div className="mt-12">
            <Pagination>
              <PaginationContent>
                <PaginationItem>
                  <PaginationPrevious 
                    onClick={() => setPageIndex(p => Math.max(1, p - 1))}
                    className={cn("cursor-pointer", pageIndex === 1 && "pointer-events-none opacity-50")}
                  />
                </PaginationItem>
                
                {Array.from({ length: totalPages }).map((_, i) => (
                  <PaginationItem key={`page-${i}`}>
                    <PaginationLink 
                      isActive={pageIndex === i + 1}
                      onClick={() => setPageIndex(i + 1)}
                      className="cursor-pointer rounded-xl font-bold"
                    >
                      {i + 1}
                    </PaginationLink>
                  </PaginationItem>
                ))}

                <PaginationItem>
                  <PaginationNext 
                    onClick={() => setPageIndex(p => p + 1)}
                    className={cn("cursor-pointer", pageIndex >= totalPages && "pointer-events-none opacity-50")}
                  />
                </PaginationItem>
              </PaginationContent>
            </Pagination>
          </div>
        )}
      </div>

      {/* Dialogs */}
      <CancelBookingDialog 
        isOpen={!!cancellingBooking} 
        bookingId={cancellingBooking?.id || null} 
        status={cancellingBooking?.status || null}
        onClose={() => setCancellingBooking(null)} 
      />

      {/* Refund Confirmation */}
      <AlertDialog open={!!refundingId} onOpenChange={(open) => !open && setRefundingId(null)}>
        <AlertDialogContent className="rounded-3xl p-6">
          <AlertDialogHeader>
            <div className="w-12 h-12 rounded-2xl bg-orange-50 flex items-center justify-center text-orange-500 mb-4">
              <AlertCircle size={24} />
            </div>
            <AlertDialogTitle className="text-xl font-black text-gray-900">Xác nhận hoàn tiền</AlertDialogTitle>
            <AlertDialogDescription className="text-gray-500 font-medium">
              Bạn có chắc chắn muốn hoàn tiền cho đơn đặt sân này? 
              Tiền sẽ được cộng lại vào ví của bạn sau khi hệ thống xử lý.
            </AlertDialogDescription>
          </AlertDialogHeader>
          <AlertDialogFooter className="gap-3 mt-6">
            <AlertDialogCancel className="rounded-xl h-11 border-gray-100 font-bold text-gray-500">Hủy</AlertDialogCancel>
            <AlertDialogAction 
              onClick={handleRefund}
              className="rounded-xl h-11 bg-orange-500 hover:bg-orange-600 font-bold text-white shadow-lg shadow-orange-200"
            >
              {refundMutation.isPending ? "Đang xử lý..." : "Xác nhận hoàn tiền"}
            </AlertDialogAction>
          </AlertDialogFooter>
        </AlertDialogContent>
      </AlertDialog>
    </div>
  );
}
