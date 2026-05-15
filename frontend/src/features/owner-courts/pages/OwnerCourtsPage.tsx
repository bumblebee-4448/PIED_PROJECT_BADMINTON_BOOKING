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
import type { MyCourtListItem } from "../types";

export default function OwnerCourtsPage() {
  const [pageIndex] = useState(1);
  const [searchTerm, setSearchTerm] = useState("");
  const [selectedCourt, setSelectedCourt] = useState<MyCourtListItem | null>(null);
  const [courtToEdit, setCourtToEdit] = useState<MyCourtListItem | null>(null);
  const [isUpdateOpen, setIsUpdateOpen] = useState(false);
  
  const removeCourt = useRemoveCourt();
  
  const { data, isLoading } = useOwnerCourts({
    pageIndex,
    pageSize: 10,
    name: searchTerm,
  });

  const getStatusBadge = (status: string) => {
    switch (status.toLowerCase()) {
      case "pending":
        return <Badge className="bg-amber-100 text-amber-700 hover:bg-amber-100 border-none px-3 py-1 rounded-full">Đang chờ duyệt</Badge>;
      case "active":
        return <Badge className="bg-emerald-100 text-emerald-700 hover:bg-emerald-100 border-none px-3 py-1 rounded-full">Đang hoạt động</Badge>;
      case "rejected":
        return <Badge className="bg-red-100 text-red-700 hover:bg-red-100 border-none px-3 py-1 rounded-full">Bị từ chối</Badge>;
      default:
        return <Badge variant="outline">{status}</Badge>;
    }
  };

  return (
    <div className="p-4 sm:p-6 max-w-7xl mx-auto">
      {/* Header section */}
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4 mb-8">
        <div>
          <h1 className="text-2xl font-extrabold text-gray-900 tracking-tight">
            Quản lý sân của tôi 🏸
          </h1>
          <p className="text-gray-500 text-sm mt-1">
            Theo dõi trạng thái và quản lý thông tin các sân bạn đã đăng ký
          </p>
        </div>
        <CreateCourtDialog />
      </div>

      {/* Filters and Search */}
      <div className="flex flex-col sm:flex-row items-center gap-4 mb-6">
        <div className="relative flex-1 w-full">
          <Search className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={18} />
          <Input 
            placeholder="Tìm kiếm theo tên sân..." 
            className="pl-10 rounded-xl border-gray-200 focus:ring-emerald-500 h-11"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
        </div>
      </div>

      {/* Table content */}
      <div className="bg-white rounded-2xl shadow-sm border border-gray-100 overflow-hidden">
        {isLoading ? (
          <div className="flex flex-col items-center justify-center py-20">
            <Loader2 className="animate-spin text-emerald-600 mb-4" size={40} />
            <p className="text-gray-500 font-medium">Đang tải danh sách sân...</p>
          </div>
        ) : data && data.items && data.items.length > 0 ? (
          <Table>
            <TableHeader className="bg-gray-50/50">
              <TableRow>
                <TableHead className="w-[100px] font-bold">Hình ảnh</TableHead>
                <TableHead className="font-bold">Tên sân</TableHead>
                <TableHead className="font-bold">Địa chỉ</TableHead>
                <TableHead className="font-bold">Giờ hoạt động</TableHead>
                <TableHead className="font-bold">Trạng thái</TableHead>
                <TableHead className="w-[100px] text-right font-bold">Thao tác</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {data.items.map((court) => (
                <TableRow 
                  key={court.courtId} 
                  className="cursor-pointer hover:bg-gray-50/50 transition-colors"
                  onClick={() => setSelectedCourt(court)}
                >
                  <TableCell>
                    <div className="w-16 h-12 rounded-lg overflow-hidden border border-gray-100 shadow-sm">
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
                  <TableCell className="font-bold text-gray-900">{court.name}</TableCell>
                  <TableCell className="max-w-[300px] truncate text-gray-500">{court.address}</TableCell>
                  <TableCell className="text-gray-600 font-medium">
                    {court.startTime} - {court.endTime}
                  </TableCell>
                  <TableCell>{getStatusBadge(court.status)}</TableCell>
                  <TableCell className="text-right">
                    <div className="flex justify-end gap-2">
                      <Button 
                        variant="ghost" 
                        size="icon" 
                        className="rounded-full h-8 w-8 text-blue-400 hover:text-blue-600 hover:bg-blue-50"
                        onClick={(e) => {
                          e.stopPropagation();
                          setCourtToEdit(court);
                          setIsUpdateOpen(true);
                        }}
                      >
                        <Edit2 size={16} />
                      </Button>
                      <Button 
                        variant="ghost" 
                        size="icon" 
                        className="rounded-full h-8 w-8 text-red-400 hover:text-red-600 hover:bg-red-50"
                        onClick={(e) => {
                          e.stopPropagation();
                          if (window.confirm("Bạn có chắc chắn muốn xóa sân này? Hành động này không thể hoàn tác.")) {
                            removeCourt.mutate(court.courtId);
                          }
                        }}
                        disabled={removeCourt.isPending}
                      >
                        <Trash2 size={16} />
                      </Button>
                      <Button 
                        variant="ghost" 
                        size="icon" 
                        className="rounded-full h-8 w-8 text-gray-400 hover:text-emerald-600 hover:bg-emerald-50"
                        onClick={(e) => {
                          e.stopPropagation();
                          setSelectedCourt(court);
                        }}
                      >
                        <Eye size={16} />
                      </Button>
                    </div>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
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
        <DialogContent className="sm:max-w-[600px] p-0 overflow-hidden rounded-2xl border-none shadow-2xl">
          {selectedCourt && (
            <>
              <div className="h-64 w-full relative">
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
              <div className="p-6">
                <DialogHeader className="mb-6">
                  <DialogTitle className="text-2xl font-black text-gray-900">{selectedCourt.name}</DialogTitle>
                </DialogHeader>
                
                <div className="space-y-4">
                  <div className="flex items-start gap-3 p-4 bg-gray-50 rounded-2xl">
                    <MapPin className="text-emerald-600 mt-1 shrink-0" size={20} />
                    <div>
                      <p className="text-sm font-bold text-gray-900 mb-1">Địa chỉ</p>
                      <p className="text-sm text-gray-500 leading-relaxed">{selectedCourt.address}</p>
                    </div>
                  </div>

                  <div className="flex items-center gap-3 p-4 bg-gray-50 rounded-2xl">
                    <Clock className="text-emerald-600 shrink-0" size={20} />
                    <div>
                      <p className="text-sm font-bold text-gray-900 mb-1">Giờ hoạt động</p>
                      <p className="text-sm text-gray-500">{selectedCourt.startTime} - {selectedCourt.endTime}</p>
                    </div>
                  </div>

                  {selectedCourt.mapUrl && (
                    <div className="flex items-center gap-3 p-4 bg-gray-50 rounded-2xl">
                      <MapPin className="text-emerald-600 shrink-0" size={20} />
                      <div className="flex-1 overflow-hidden">
                        <p className="text-sm font-bold text-gray-900 mb-1">Google Maps</p>
                        <a 
                          href={selectedCourt.mapUrl} 
                          target="_blank" 
                          rel="noopener noreferrer"
                          className="text-sm text-emerald-600 hover:underline truncate block"
                        >
                          {selectedCourt.mapUrl}
                        </a>
                      </div>
                    </div>
                  )}
                </div>

                <div className="mt-8 flex gap-3">
                  <Button className="flex-1 bg-emerald-600 hover:bg-emerald-700 text-white rounded-xl h-12 font-bold">
                    Cập nhật thông tin
                  </Button>
                  <Button 
                    variant="outline" 
                    className="flex-1 rounded-xl h-12 font-bold border-gray-200"
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
    </div>
  );
}
