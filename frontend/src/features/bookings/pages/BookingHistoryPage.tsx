import React from "react";
import { BookingFilters } from "../components/BookingFilters";
import { BookingCard } from "../components/BookingCard";
import { CancelBookingDialog } from "../components/CancelBookingDialog";
import { useBookings } from "../hooks/useBookings";
import { useFilteredBookings } from "../hooks/useFilteredBookings";
import { Loader2, ClipboardList } from "lucide-react";
import { 
  Pagination, 
  PaginationContent, 
  PaginationItem, 
  PaginationLink, 
  PaginationNext, 
  PaginationPrevious 
} from "@/shared/components/ui/pagination";
import { cn } from "@/lib/utils";
import { DEFAULT_PAGE_SIZE, type FilterStatus } from "../types";

export function BookingHistoryPage() {
  const [pageIndex, setPageIndex] = React.useState(1);
  const [activeStatus, setActiveStatus] = React.useState<FilterStatus>("all");
  const [cancellingId, setCancellingId] = React.useState<string | null>(null);

  const { data, isLoading, isError } = useBookings(pageIndex, DEFAULT_PAGE_SIZE);
  const { filteredItems, counts } = useFilteredBookings(data, activeStatus);

  const handleStatusChange = (status: FilterStatus) => {
    setActiveStatus(status);
    setPageIndex(1); // Reset to first page on filter change
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
            filteredItems.map((booking) => (
              <BookingCard 
                key={booking.id} 
                booking={booking} 
                onCancelClick={(id) => setCancellingId(id)}
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
                  <PaginationItem key={i}>
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
        isOpen={!!cancellingId} 
        bookingId={cancellingId} 
        onClose={() => setCancellingId(null)} 
      />
    </div>
  );
}
