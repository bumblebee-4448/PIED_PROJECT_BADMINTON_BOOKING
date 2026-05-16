import { useState } from "react";
import { usePendingCourts, useApproveCourt, useRejectCourt } from "../hooks/useAdminCourts";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/shared/components/ui/table";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Badge } from "@/shared/components/ui/badge";
import { 
  Search, 
  Loader2, 
  CheckCircle2, 
  Eye, 
  MapPin, 
  Clock, 
  Building2
} from "lucide-react";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogFooter,
  DialogDescription,
} from "@/shared/components/ui/dialog";
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
import type { PendingCourt } from "../types";
import { cn } from "@/lib/utils";
import { DataTablePagination } from "@/shared/components/DataTablePagination";

export default function AdminCourtsPage() {
  const [pageIndex, setPageIndex] = useState(1);
  const [searchTerm, setSearchTerm] = useState("");
  const [viewingCourt, setViewingCourt] = useState<PendingCourt | null>(null);
  const [rejectingCourt, setRejectingCourt] = useState<PendingCourt | null>(null);
  const [approveCourtId, setApproveCourtId] = useState<string | null>(null);
  const [rejectReason, setRejectReason] = useState("");

  const { data, isLoading } = usePendingCourts({
    pageIndex,
    pageSize: 10,
    name: searchTerm,
  });

  const approveMutation = useApproveCourt();
  const rejectMutation = useRejectCourt();

  const handleApprove = () => {
    if (!approveCourtId) return;
    approveMutation.mutate(approveCourtId, {
      onSuccess: () => {
        setViewingCourt(null);
        setApproveCourtId(null);
      }
    });
  };

  const handleReject = () => {
    if (!rejectReason.trim()) return;
    if (rejectingCourt) {
      rejectMutation.mutate({
        courtId: rejectingCourt.courtId,
        data: { reason: rejectReason }
      }, {
        onSuccess: () => {
          setRejectingCourt(null);
          setViewingCourt(null);
          setRejectReason("");
        }
      });
    }
  };

  return (
    <div className="p-6 max-w-7xl mx-auto space-y-6">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-gray-900">Phê duyệt sân</h1>
          <p className="text-sm text-gray-500">Xem xét và quản lý các yêu cầu đăng ký sân mới</p>
        </div>
        {data && data.totalItems > 0 && (
          <Badge className="bg-amber-100 text-amber-700 border-none font-bold py-1 px-3 shadow-none">
            {data.totalItems} yêu cầu đang chờ
          </Badge>
        )}
      </div>

      {/* Filters */}
      <div className="bg-white p-4 rounded-xl border border-gray-100 shadow-sm flex flex-col md:flex-row gap-4">
        <div className="relative flex-1">
          <Search className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={18} />
          <Input 
            placeholder="Tìm theo tên sân..." 
            className="pl-10 h-11 border-gray-200 focus:ring-emerald-500/20"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
        </div>
      </div>

      {/* Table Section */}
      <div className="bg-white rounded-xl border border-gray-100 shadow-sm overflow-hidden">
        {isLoading ? (
          <div className="py-20 flex flex-col items-center justify-center gap-4">
            <Loader2 className="animate-spin text-emerald-600" size={40} />
            <p className="text-sm text-gray-400 font-medium">Đang tải danh sách...</p>
          </div>
        ) : data?.items && data.items.length > 0 ? (
          <Table>
            <TableHeader className="bg-gray-50/50">
              <TableRow>
                <TableHead className="w-[100px]">Hình ảnh</TableHead>
                <TableHead>Thông tin sân</TableHead>
                <TableHead>Chủ sân</TableHead>
                <TableHead>Giờ hoạt động</TableHead>
                <TableHead className="text-right">Thao tác</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {data.items.map((court: PendingCourt) => (
                <TableRow key={court.courtId} className="hover:bg-gray-50/50 transition-colors">
                  <TableCell>
                    <div className="w-16 h-12 rounded-lg overflow-hidden border border-gray-100">
                      <img 
                        src={court.pictureUrl} 
                        alt={court.name} 
                        className="w-full h-full object-cover"
                        onError={(e) => {
                          (e.target as HTMLImageElement).src = "https://placehold.co/400x300?text=Court";
                        }}
                      />
                    </div>
                  </TableCell>
                  <TableCell>
                    <div className="flex flex-col">
                      <span className="font-semibold text-gray-900">{court.name}</span>
                      <span className="text-xs text-gray-500 flex items-center gap-1 mt-0.5">
                        <MapPin size={12} className="text-gray-400" /> {court.address}
                      </span>
                    </div>
                  </TableCell>
                  <TableCell>
                    <div className="flex items-center gap-2">
                      <div className="w-7 h-7 bg-emerald-50 text-emerald-600 rounded-full flex items-center justify-center text-[10px] font-bold">
                        {court.ownerName?.charAt(0) || "O"}
                      </div>
                      <span className="text-sm text-gray-600 font-medium">{court.ownerName}</span>
                    </div>
                  </TableCell>
                  <TableCell>
                    <Badge variant="outline" className="bg-gray-50 text-gray-600 border-gray-200 font-medium text-[10px]">
                      {court.openTime} - {court.closeTime}
                    </Badge>
                  </TableCell>
                  <TableCell className="text-right">
                    <div className="flex items-center justify-end gap-2">
                      <Button 
                        size="icon" 
                        variant="ghost" 
                        className="h-8 w-8 text-gray-400 hover:text-emerald-600"
                        onClick={() => setViewingCourt(court)}
                      >
                        <Eye size={18} />
                      </Button>
                      <Button 
                        size="sm"
                        onClick={() => setApproveCourtId(court.courtId)}
                        disabled={approveMutation.isPending}
                        className="bg-emerald-600 hover:bg-emerald-700 h-8 font-bold text-xs"
                      >
                        Duyệt
                      </Button>
                      <Button 
                        variant="ghost"
                        size="sm"
                        onClick={() => setRejectingCourt(court)}
                        className="text-red-500 hover:text-red-600 hover:bg-red-50 h-8 font-bold text-xs"
                      >
                        Từ chối
                      </Button>
                    </div>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        ) : (
          <div className="py-20 text-center space-y-3">
            <div className="w-16 h-16 bg-gray-50 rounded-full flex items-center justify-center text-gray-200 mx-auto">
              <CheckCircle2 size={32} />
            </div>
            <p className="text-gray-500 font-medium">Hiện không có yêu cầu nào</p>
          </div>
        )}

        {data && data.totalPages > 1 && (
          <div className="p-4 border-t border-gray-50 bg-gray-50/20">
            <DataTablePagination 
              pageIndex={pageIndex}
              totalPages={data.totalPages}
              onPageChange={setPageIndex}
            />
          </div>
        )}
      </div>

      {/* Details Dialog */}
      <Dialog open={!!viewingCourt} onOpenChange={(open) => !open && setViewingCourt(null)}>
        <DialogContent className="sm:max-w-[600px] p-0 overflow-hidden rounded-2xl border-none shadow-2xl">
          {viewingCourt && (
            <div className="flex flex-col">
              <div className="h-48 w-full relative">
                <img 
                  src={viewingCourt.pictureUrl} 
                  alt={viewingCourt.name} 
                  className="w-full h-full object-cover"
                />
                <div className="absolute inset-0 bg-gradient-to-t from-black/60 to-transparent" />
                <div className="absolute bottom-4 left-6">
                  <h2 className="text-xl font-bold text-white">{viewingCourt.name}</h2>
                  <p className="text-white/80 text-xs flex items-center gap-1 mt-1">
                    <MapPin size={12} /> {viewingCourt.address}
                  </p>
                </div>
              </div>

              <div className="p-6 space-y-6">
                <div className="grid grid-cols-2 gap-4">
                  <div className="space-y-1">
                    <Label className="text-[10px] font-bold text-gray-400 uppercase tracking-widest">Thời gian hoạt động</Label>
                    <div className="flex items-center gap-2 text-sm font-medium text-gray-700">
                      <Clock size={14} className="text-emerald-500" />
                      {viewingCourt.openTime} - {viewingCourt.closeTime}
                    </div>
                  </div>
                  <div className="space-y-1">
                    <Label className="text-[10px] font-bold text-gray-400 uppercase tracking-widest">Chủ sở hữu</Label>
                    <div className="flex items-center gap-2 text-sm font-medium text-gray-700">
                      <Building2 size={14} className="text-emerald-500" />
                      {viewingCourt.ownerName}
                    </div>
                  </div>
                </div>

                <div className="pt-4 flex gap-3">
                  <Button 
                    className="flex-1 bg-emerald-600 hover:bg-emerald-700 h-11 font-bold rounded-xl"
                    onClick={() => setApproveCourtId(viewingCourt.courtId)}
                    disabled={approveMutation.isPending}
                  >
                    Phê duyệt sân
                  </Button>
                  <Button 
                    variant="outline" 
                    className="flex-1 border-gray-200 text-red-600 hover:bg-red-50 h-11 font-bold rounded-xl"
                    onClick={() => setRejectingCourt(viewingCourt)}
                  >
                    Từ chối
                  </Button>
                </div>
              </div>
            </div>
          )}
        </DialogContent>
      </Dialog>

      {/* Reject Reason Dialog */}
      <Dialog open={!!rejectingCourt} onOpenChange={(open) => !open && setRejectingCourt(null)}>
        <DialogContent className="sm:max-w-[400px] rounded-2xl p-6">
          <DialogHeader>
            <DialogTitle className="text-lg font-bold">Từ chối yêu cầu</DialogTitle>
            <DialogDescription>
              Vui lòng nhập lý do từ chối để thông báo cho chủ sân.
            </DialogDescription>
          </DialogHeader>
          <div className="py-4">
            <textarea
              className="w-full h-32 p-3 bg-gray-50 border border-gray-100 rounded-xl focus:ring-2 focus:ring-red-500/20 text-sm outline-none resize-none"
              placeholder="VD: Hình ảnh không rõ nét, địa chỉ không chính xác..."
              value={rejectReason}
              onChange={(e) => setRejectReason(e.target.value)}
            />
          </div>
          <DialogFooter className="gap-2">
            <Button 
              variant="ghost" 
              className="font-bold rounded-xl h-10"
              onClick={() => setRejectingCourt(null)}
            >
              Hủy
            </Button>
            <Button 
              className="bg-red-600 hover:bg-red-700 text-white font-bold rounded-xl h-10 px-6"
              onClick={handleReject}
              disabled={rejectMutation.isPending || !rejectReason.trim()}
            >
              Xác nhận từ chối
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>

      {/* Approve Confirmation Dialog */}
      <AlertDialog open={!!approveCourtId} onOpenChange={(open) => !open && setApproveCourtId(null)}>
        <AlertDialogContent className="rounded-3xl p-6">
          <AlertDialogHeader>
            <AlertDialogTitle className="text-xl font-bold text-gray-900">Xác nhận phê duyệt</AlertDialogTitle>
            <AlertDialogDescription className="text-gray-500">
              Bạn có chắc chắn muốn phê duyệt sân này? 
              Sân sẽ được hiển thị công khai trên hệ thống sau khi phê duyệt.
            </AlertDialogDescription>
          </AlertDialogHeader>
          <AlertDialogFooter className="gap-2 pt-4">
            <AlertDialogCancel className="rounded-xl h-11 font-bold border-gray-200">Hủy</AlertDialogCancel>
            <AlertDialogAction 
              onClick={handleApprove}
              className="bg-emerald-600 hover:bg-emerald-700 text-white font-bold rounded-xl h-11 px-6 shadow-none"
            >
              {approveMutation.isPending ? "Đang xử lý..." : "Xác nhận phê duyệt"}
            </AlertDialogAction>
          </AlertDialogFooter>
        </AlertDialogContent>
      </AlertDialog>
    </div>
  );
}

const Label = ({ children, className }: { children: React.ReactNode, className?: string }) => (
  <label className={cn("block", className)}>{children}</label>
);
