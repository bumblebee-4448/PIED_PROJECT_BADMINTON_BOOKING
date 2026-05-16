import { useState } from "react";
import { useOwnerCourts, useRemoveCourt } from "../hooks/useOwnerCourts";
import { CreateCourtDialog } from "../components/CreateCourtDialog";
import { UpdateCourtDialog } from "../components/UpdateCourtDialog";
import { Input } from "@/shared/components/ui/input";
import { Search, Loader2, MapPin, Clock, Eye, Edit2, Trash2 } from "lucide-react";
import { Button } from "@/shared/components/ui/button";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/shared/components/ui/table";
import { Badge } from "@/shared/components/ui/badge";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
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
import type { MyCourtListItem } from "../types";

import { LayoutGrid } from "lucide-react";

export default function OwnerCourtsPage() {
  const [pageIndex] = useState(1);
  const [searchTerm, setSearchTerm] = useState("");
  const [selectedCourt, setSelectedCourt] = useState<MyCourtListItem | null>(null);
  const [courtToEdit, setCourtToEdit] = useState<MyCourtListItem | null>(null);
  const [isUpdateOpen, setIsUpdateOpen] = useState(false);
  const [isDeleteConfirmOpen, setIsDeleteConfirmOpen] = useState(false);
  const [courtToDelete, setCourtToDelete] = useState<string | null>(null);
  
  const removeCourt = useRemoveCourt();
  
  const { data, isLoading } = useOwnerCourts({
    pageIndex,
    pageSize: 10,
    name: searchTerm,
  });

  const getStatusBadge = (status: string) => {
    switch (status.toLowerCase()) {
      case "pending":
        return <Badge className="bg-amber-50 text-amber-600 hover:bg-amber-50 border-none px-2 py-0.5 rounded-full text-[10px] font-bold uppercase tracking-wider">Đang chờ duyệt</Badge>;
      case "active":
        return <Badge className="bg-emerald-50 text-emerald-600 hover:bg-emerald-50 border-none px-2 py-0.5 rounded-full text-[10px] font-bold uppercase tracking-wider">Đang hoạt động</Badge>;
      case "rejected":
        return <Badge className="bg-rose-50 text-rose-600 hover:bg-rose-50 border-none px-2 py-0.5 rounded-full text-[10px] font-bold uppercase tracking-wider">Bị từ chối</Badge>;
      case "inactive":
        return <Badge className="bg-slate-100 text-slate-600 hover:bg-slate-100 border-none px-2 py-0.5 rounded-full text-[10px] font-bold uppercase tracking-wider">Ngưng hoạt động</Badge>;
      default:
        return <Badge className="bg-slate-100 text-slate-600 hover:bg-slate-100 border-none px-2 py-0.5 rounded-full text-[10px] font-bold uppercase tracking-wider">Ngưng hoạt động</Badge>;
    }
  };

  return (
    <div className="p-5 sm:p-7 max-w-[1400px] mx-auto space-y-6 animate-in fade-in duration-500">
      {/* Header section */}
      <div className="flex flex-col sm:flex-row sm:items-center justify-between gap-4">
        <div>
          <h1 className="text-xl font-bold text-gray-900 tracking-tight flex items-center gap-3">
            <LayoutGrid size={24} className="text-emerald-600" />
            Quản lý cơ sở
          </h1>
          <p className="text-sm text-gray-400 mt-1 font-medium">
            Theo dõi trạng thái và quản lý thông tin các cơ sở bạn đã đăng ký
          </p>
        </div>
        <CreateCourtDialog />
      </div>

      {/* Filters and Search */}
      <div className="flex flex-col sm:flex-row items-center gap-4">
        <div className="relative flex-1 w-full max-w-md">
          <Search className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={18} />
          <Input 
            placeholder="Tìm kiếm theo tên cơ sở..." 
            className="pl-10 rounded-xl border-gray-100 bg-white shadow-sm focus:ring-emerald-500 h-10 font-medium text-sm"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
        </div>
      </div>

      {/* Table content */}
      <div className="bg-white rounded-2xl shadow-sm border border-gray-100 overflow-hidden">
        {isLoading ? (
          <div className="flex flex-col items-center justify-center py-24">
            <Loader2 className="animate-spin text-emerald-600 mb-4" size={40} />
            <p className="text-gray-400 text-sm font-semibold tracking-tight">Đang tải danh sách cơ sở...</p>
          </div>
        ) : data && data.items && data.items.length > 0 ? (
          <div className="overflow-x-auto">
            <Table>
              <TableHeader className="bg-gray-50/50 border-b border-gray-100">
                <TableRow>
                  <TableHead className="py-4 px-6 text-[10px] font-bold text-gray-400 uppercase tracking-widest">Hình ảnh</TableHead>
                  <TableHead className="py-4 px-6 text-[10px] font-bold text-gray-400 uppercase tracking-widest">Tên cơ sở</TableHead>
                  <TableHead className="py-4 px-6 text-[10px] font-bold text-gray-400 uppercase tracking-widest">Địa chỉ</TableHead>
                  <TableHead className="py-4 px-6 text-[10px] font-bold text-gray-400 uppercase tracking-widest">Giờ hoạt động</TableHead>
                  <TableHead className="py-4 px-6 text-[10px] font-bold text-gray-400 uppercase tracking-widest">Trạng thái</TableHead>
                  <TableHead className="py-4 px-6 text-[10px] font-bold text-gray-400 uppercase tracking-widest text-right">Thao tác</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody className="divide-y divide-gray-50">
              {data.items.map((court) => (
                <TableRow 
                  key={court.courtId} 
                  className="cursor-pointer hover:bg-gray-50/50 transition-colors"
                  onClick={() => setSelectedCourt(court)}
                >
                  <TableCell className="py-4 px-6">
                    <div className="w-14 h-10 rounded-lg overflow-hidden border border-gray-100 shadow-sm">
                      <img 
                        src={court.pictureUrl} 
                        alt={court.name} 
                        className="w-full h-full object-cover"
                        onError={(e) => {
                          (e.target as HTMLImageElement).src = "https://placehold.co/400x300?text=Sân+Cầu+Lông";
                        }}
                      />
                    </div>
                  </TableCell>
                  <TableCell className="py-4 px-6">
                    <span className="text-sm font-semibold text-gray-900">{court.name}</span>
                  </TableCell>
                  <TableCell className="py-4 px-6 max-w-[250px] truncate">
                    <span className="text-[13px] text-gray-500 font-medium">{court.address}</span>
                  </TableCell>
                  <TableCell className="py-4 px-6">
                    <span className="text-[11px] font-bold text-gray-500 bg-gray-100 px-2 py-0.5 rounded-md">
                      {court.startTime.substring(0, 5)} - {court.endTime.substring(0, 5)}
                    </span>
                  </TableCell>
                  <TableCell className="py-4 px-6">
                    {getStatusBadge(court.status)}
                  </TableCell>
                  <TableCell className="py-4 px-6 text-right">
                    <div className="flex justify-end gap-1">
                      <Button 
                        variant="ghost" 
                        size="icon" 
                        className="h-8 w-8 text-blue-400 hover:text-blue-600 hover:bg-blue-50 rounded-lg transition-all"
                        onClick={(e) => {
                          e.stopPropagation();
                          setCourtToEdit(court);
                          setIsUpdateOpen(true);
                        }}
                      >
                        <Edit2 size={15} />
                      </Button>
                      <Button 
                        variant="ghost" 
                        size="icon" 
                        className="h-8 w-8 text-rose-400 hover:text-rose-600 hover:bg-rose-50 rounded-lg transition-all"
                        onClick={(e) => {
                          e.stopPropagation();
                          setCourtToDelete(court.courtId);
                          setIsDeleteConfirmOpen(true);
                        }}
                        disabled={removeCourt.isPending}
                      >
                        <Trash2 size={15} />
                      </Button>
                      <Button 
                        variant="ghost" 
                        size="icon" 
                        className="h-8 w-8 text-gray-400 hover:text-emerald-600 hover:bg-emerald-50 rounded-lg transition-all"
                        onClick={(e) => {
                          e.stopPropagation();
                          setSelectedCourt(court);
                        }}
                      >
                        <Eye size={15} />
                      </Button>
                    </div>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </div>
      ) : (
          <div className="text-center py-20">
            <div className="bg-gray-50 w-16 h-16 rounded-2xl shadow-sm flex items-center justify-center mx-auto mb-4">
              <Search className="text-gray-300" size={32} />
            </div>
            <h3 className="text-gray-900 font-bold text-lg">Chưa có sân nào</h3>
            <p className="text-gray-500 text-sm max-w-xs mx-auto mt-2">
              Bạn chưa đăng ký sân nào hoặc không tìm thấy sân phù hợp với tìm kiếm.
            </p>
          </div>
        )}
      </div>

      {/* Detail Dialog */}
      <Dialog open={!!selectedCourt} onOpenChange={(open) => !open && setSelectedCourt(null)}>
        <DialogContent className="sm:max-w-[520px] p-0 overflow-hidden rounded-3xl border-none shadow-2xl">
          {selectedCourt && (
            <>
              <div className="h-56 w-full relative">
                <img 
                  src={selectedCourt.pictureUrl} 
                  alt={selectedCourt.name} 
                  className="w-full h-full object-cover"
                  onError={(e) => {
                    (e.target as HTMLImageElement).src = "https://placehold.co/800x400?text=Sân+Cầu+Lông";
                  }}
                />
                <div className="absolute top-4 right-4">
                  {getStatusBadge(selectedCourt.status)}
                </div>
              </div>
              <div className="p-8">
                <DialogHeader className="mb-6">
                  <DialogTitle className="text-xl font-bold text-gray-900 tracking-tight">{selectedCourt.name}</DialogTitle>
                </DialogHeader>
                
                <div className="space-y-4">
                  <div className="flex items-start gap-4 p-4 bg-gray-50/80 rounded-2xl border border-gray-100/50">
                    <MapPin className="text-emerald-600 mt-0.5 shrink-0" size={18} />
                    <div>
                      <p className="text-[11px] font-bold text-gray-400 uppercase tracking-widest mb-1">Địa chỉ</p>
                      <p className="text-sm text-gray-600 font-medium leading-relaxed">{selectedCourt.address}</p>
                    </div>
                  </div>

                  <div className="flex items-center gap-4 p-4 bg-gray-50/80 rounded-2xl border border-gray-100/50">
                    <Clock className="text-emerald-600 shrink-0" size={18} />
                    <div>
                      <p className="text-[11px] font-bold text-gray-400 uppercase tracking-widest mb-1">Giờ hoạt động</p>
                      <p className="text-sm text-gray-600 font-medium">{selectedCourt.startTime} - {selectedCourt.endTime}</p>
                    </div>
                  </div>

                  {selectedCourt.mapUrl && (
                    <div className="flex items-center gap-4 p-4 bg-gray-50/80 rounded-2xl border border-gray-100/50">
                      <MapPin className="text-emerald-600 shrink-0" size={18} />
                      <div className="flex-1 overflow-hidden">
                        <p className="text-[11px] font-bold text-gray-400 uppercase tracking-widest mb-1">Google Maps</p>
                        <a 
                          href={selectedCourt.mapUrl} 
                          target="_blank" 
                          rel="noopener noreferrer"
                          className="text-sm text-emerald-600 hover:text-emerald-700 font-semibold truncate block"
                        >
                          {selectedCourt.mapUrl}
                        </a>
                      </div>
                    </div>
                  )}
                </div>

                <div className="mt-8 flex gap-3">
                  <Button 
                    className="flex-1 bg-emerald-600 hover:bg-emerald-700 text-white rounded-xl h-12 font-bold shadow-lg shadow-emerald-600/10 transition-all hover:scale-[1.02]"
                    onClick={() => {
                      setCourtToEdit(selectedCourt);
                      setIsUpdateOpen(true);
                      setSelectedCourt(null);
                    }}
                  >
                    Cập nhật thông tin
                  </Button>
                  <Button 
                    variant="ghost" 
                    className="flex-1 rounded-xl h-12 font-bold text-gray-400 hover:text-gray-600 hover:bg-gray-50"
                    onClick={() => setSelectedCourt(null)}
                  >
                    Đóng
                  </Button>
                </div>
              </div>
            </>
          )}
        </DialogContent>
      </Dialog>
      {/* Update Dialog */}
      <UpdateCourtDialog 
        court={courtToEdit}
        open={isUpdateOpen}
        onOpenChange={setIsUpdateOpen}
      />
      {/* Delete Confirmation */}
      <AlertDialog open={isDeleteConfirmOpen} onOpenChange={setIsDeleteConfirmOpen}>
        <AlertDialogContent className="rounded-2xl">
          <AlertDialogHeader>
            <AlertDialogTitle className="flex items-center gap-2 text-red-600">
              <Trash2 size={20} />
              Xác nhận xóa sân
            </AlertDialogTitle>
            <AlertDialogDescription>
              Bạn có chắc chắn muốn xóa sân này? Hành động này sẽ gỡ bỏ toàn bộ dữ liệu liên quan và không thể hoàn tác.
            </AlertDialogDescription>
          </AlertDialogHeader>
          <AlertDialogFooter>
            <AlertDialogCancel className="rounded-xl">Hủy bỏ</AlertDialogCancel>
            <AlertDialogAction 
              className="bg-red-600 hover:bg-red-700 text-white rounded-xl"
              onClick={() => {
                if (courtToDelete) {
                  removeCourt.mutate(courtToDelete);
                }
              }}
            >
              {removeCourt.isPending ? <Loader2 className="animate-spin" size={18} /> : "Xác nhận xóa"}
            </AlertDialogAction>
          </AlertDialogFooter>
        </AlertDialogContent>
      </AlertDialog>
    </div>
  );
}
