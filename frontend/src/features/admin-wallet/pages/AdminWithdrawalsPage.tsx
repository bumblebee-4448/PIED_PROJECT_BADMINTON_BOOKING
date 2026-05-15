import React, { useState } from "react";
import { useAdminWallet } from "../hooks/useAdminWallet";
import { 
  Table, 
  TableBody, 
  TableCell, 
  TableHead, 
  TableHeader, 
  TableRow 
} from "@/shared/components/ui/table";
import { Button } from "@/shared/components/ui/button";
import { Badge } from "@/shared/components/ui/badge";
import { Input } from "@/shared/components/ui/input";
import { 
  Dialog, 
  DialogContent, 
  DialogHeader, 
  DialogTitle, 
  DialogFooter,
  DialogDescription 
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
import { Label } from "@/shared/components/ui/label";
import { Textarea } from "@/shared/components/ui/textarea";
import { 
  Search, 
  Clock, 
  User, 
  Mail, 
  Loader2,
  Wallet,
  Calendar as CalendarIcon,
  X
} from "lucide-react";
import { format } from "date-fns";
import { Avatar, AvatarFallback, AvatarImage } from "@/shared/components/ui/avatar";

export const AdminWithdrawalsPage: React.FC = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [filterUserId, setFilterUserId] = useState("");
  const [filterDate, setFilterDate] = useState("");
  const [pageParams, setPageParams] = useState({ pageIndex: 1, pageSize: 10 });

  const { 
    useAllWithdrawals, 
    approveWithdrawalMutation, 
    rejectWithdrawalMutation 
  } = useAdminWallet();

  const { data, isLoading } = useAllWithdrawals(
    filterUserId || null, 
    { ...pageParams, search: searchTerm, date: filterDate }
  );

  // Dialog States
  const [isRejectDialogOpen, setIsRejectDialogOpen] = useState(false);
  const [isApproveDialogOpen, setIsApproveDialogOpen] = useState(false);
  const [selectedId, setSelectedId] = useState<string | null>(null);
  
  const [rejectReason, setRejectReason] = useState("");
  const [rejectNote, setRejectNote] = useState("");

  const handleApprove = () => {
    if (!selectedId) return;
    approveWithdrawalMutation.mutate(selectedId, {
      onSuccess: () => {
        setIsApproveDialogOpen(false);
        setSelectedId(null);
      }
    });
  };

  const openApproveDialog = (id: string) => {
    setSelectedId(id);
    setIsApproveDialogOpen(true);
  };

  const openRejectDialog = (id: string) => {
    setSelectedId(id);
    setIsRejectDialogOpen(true);
  };

  const handleReject = () => {
    if (!selectedId || !rejectReason) return;
    rejectWithdrawalMutation.mutate({ 
      id: selectedId, 
      reason: rejectReason, 
      note: rejectNote 
    }, {
      onSuccess: () => {
        setIsRejectDialogOpen(false);
        setRejectReason("");
        setRejectNote("");
        setSelectedId(null);
      }
    });
  };

  const clearFilters = () => {
    setSearchTerm("");
    setFilterUserId("");
    setFilterDate("");
    setPageParams({ pageIndex: 1, pageSize: 10 });
  };

  const getStatusBadge = (status?: string) => {
    switch (status) {
      case "Approved": 
        return (
          <Badge className="bg-emerald-100 text-emerald-700 border-none font-bold shadow-none">
            Thành công
          </Badge>
        );
      case "Rejected": 
        return (
          <Badge className="bg-red-100 text-red-700 border-none font-bold shadow-none">
            Đã từ chối
          </Badge>
        );
      case "Pending": 
        return (
          <Badge className="bg-amber-100 text-amber-700 border-none font-bold shadow-none flex items-center gap-1.5 w-fit">
            <Clock className="w-3 h-3" /> Đang chờ
          </Badge>
        );
      default: 
        return (
          <Badge className="bg-gray-100 text-gray-700 border-none font-bold shadow-none">
            {status || "Không rõ"}
          </Badge>
        );
    }
  };

  return (
    <div className="p-6 max-w-7xl mx-auto space-y-6">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-gray-900">Quản lý rút tiền</h1>
          <p className="text-sm text-gray-500">Duyệt và theo dõi các yêu cầu rút tiền của người dùng</p>
        </div>
      </div>

      {/* Filters */}
      <div className="bg-white p-4 rounded-xl border border-gray-100 shadow-sm space-y-4">
        <div className="grid grid-cols-1 md:grid-cols-3 lg:grid-cols-4 gap-4">
          <div className="relative">
            <Search className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={16} />
            <Input 
              placeholder="Tìm theo Email..." 
              className="pl-9 h-10 border-gray-200 focus:ring-emerald-500/20 text-sm"
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
            />
          </div>
          <div className="relative">
            <User className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={16} />
            <Input 
              placeholder="Lọc theo User ID..." 
              className="pl-9 h-10 border-gray-200 focus:ring-emerald-500/20 text-sm"
              value={filterUserId}
              onChange={(e) => setFilterUserId(e.target.value)}
            />
          </div>
          <div className="relative">
            <CalendarIcon className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={16} />
            <Input 
              type="date"
              className="pl-9 h-10 border-gray-200 focus:ring-emerald-500/20 text-sm"
              value={filterDate}
              onChange={(e) => setFilterDate(e.target.value)}
            />
          </div>
          <div className="flex items-center gap-2">
            <Button 
              variant="outline" 
              size="sm" 
              onClick={clearFilters}
              className="h-10 px-4 text-xs font-bold text-gray-500 gap-2 border-gray-200"
            >
              <X size={14} /> Xóa lọc
            </Button>
          </div>
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
                <TableHead className="w-[280px]">Người yêu cầu</TableHead>
                <TableHead>Thông tin ngân hàng</TableHead>
                <TableHead>Số tiền</TableHead>
                <TableHead>Thời gian</TableHead>
                <TableHead>Trạng thái</TableHead>
                <TableHead className="text-right">Thao tác</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {data.items.map((w) => (
                <TableRow key={w.id} className="hover:bg-gray-50/50 transition-colors">
                  <TableCell>
                    <div className="flex items-center gap-3">
                      <Avatar className="h-10 w-10 border border-gray-100">
                        <AvatarImage src={w.avatar || ""} alt={`${w.firstName} ${w.lastName}`} />
                        <AvatarFallback className="bg-emerald-50 text-emerald-600">
                          {w.firstName ? w.firstName.charAt(0) : <User size={16} />}
                        </AvatarFallback>
                      </Avatar>
                      <div className="min-w-0">
                        <p className="font-semibold text-gray-900 truncate">
                          {w.lastName} {w.firstName}
                        </p>
                        <p className="text-xs text-gray-500 truncate flex items-center gap-1">
                          <Mail size={10} />
                          {w.email || "Không có email"}
                        </p>
                      </div>
                    </div>
                  </TableCell>
                  <TableCell>
                    <div className="flex flex-col">
                      <div className="flex items-center gap-2 mb-1">
                         <Badge variant="outline" className="bg-gray-50 text-gray-600 border-gray-200 text-[10px] px-1.5 py-0">
                           {w.bankName}
                         </Badge>
                         <span className="text-xs font-mono font-bold text-gray-700">
                           {w.bankAccountNumber}
                         </span>
                      </div>
                      <p className="text-[10px] font-medium text-gray-400 uppercase">{w.bankAccountName}</p>
                    </div>
                  </TableCell>
                  <TableCell>
                    <p className="font-bold text-gray-900">
                      {w.amount.toLocaleString()}đ
                    </p>
                  </TableCell>
                  <TableCell className="text-xs text-gray-500 font-medium">
                    {w.createdAt ? format(new Date(w.createdAt), "dd/MM/yyyy HH:mm") : "N/A"}
                  </TableCell>
                  <TableCell>
                    {getStatusBadge(w.status)}
                  </TableCell>
                  <TableCell className="text-right">
                    {w.status === "Pending" && (
                      <div className="flex items-center justify-end gap-2">
                        <Button 
                          size="sm"
                          onClick={() => openApproveDialog(w.id)}
                          disabled={approveWithdrawalMutation.isPending}
                          className="bg-emerald-600 hover:bg-emerald-700 h-8 font-bold text-xs"
                        >
                          Duyệt
                        </Button>
                        <Button 
                          variant="ghost"
                          size="sm"
                          onClick={() => openRejectDialog(w.id)}
                          className="text-red-500 hover:text-red-600 hover:bg-red-50 h-8 font-bold text-xs"
                        >
                          Từ chối
                        </Button>
                      </div>
                    )}
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        ) : (
          <div className="py-20 text-center space-y-3">
            <div className="w-16 h-16 bg-gray-50 rounded-full flex items-center justify-center text-gray-200 mx-auto">
              <Wallet size={32} />
            </div>
            <p className="text-gray-500 font-medium">Không tìm thấy yêu cầu nào</p>
          </div>
        )}

        {/* Pagination placeholder */}
        {data && data.totalItems > pageParams.pageSize && (
          <div className="p-4 border-t border-gray-50 flex items-center justify-center gap-2">
            <Button 
              variant="outline" 
              size="sm" 
              disabled={pageParams.pageIndex === 1}
              onClick={() => setPageParams(prev => ({ ...prev, pageIndex: prev.pageIndex - 1 }))}
            >
              Trước
            </Button>
            <span className="text-xs font-bold text-gray-500 px-4">
              Trang {pageParams.pageIndex} / {Math.ceil(data.totalItems / pageParams.pageSize)}
            </span>
            <Button 
              variant="outline" 
              size="sm"
              disabled={pageParams.pageIndex >= Math.ceil(data.totalItems / pageParams.pageSize)}
              onClick={() => setPageParams(prev => ({ ...prev, pageIndex: prev.pageIndex + 1 }))}
            >
              Sau
            </Button>
          </div>
        )}
      </div>

      {/* Reject Dialog */}
      <Dialog open={isRejectDialogOpen} onOpenChange={setIsRejectDialogOpen}>
        <DialogContent className="sm:max-w-[420px] rounded-3xl p-6">
          <DialogHeader>
            <DialogTitle className="text-xl font-bold">Từ chối rút tiền</DialogTitle>
            <DialogDescription>
              Vui lòng cung cấp lý do từ chối để thông báo cho người dùng.
            </DialogDescription>
          </DialogHeader>
          <div className="space-y-4 py-4">
            <div className="space-y-2">
              <Label className="text-xs font-bold text-gray-500 uppercase tracking-wider">Lý do chính</Label>
              <Input 
                placeholder="VD: Thông tin ngân hàng không chính xác" 
                value={rejectReason}
                onChange={(e) => setRejectReason(e.target.value)}
                className="h-11 rounded-xl border-gray-200 focus:ring-red-500/20"
              />
            </div>
            <div className="space-y-2">
              <Label className="text-xs font-bold text-gray-500 uppercase tracking-wider">Ghi chú thêm</Label>
              <Textarea 
                placeholder="VD: Vui lòng cập nhật lại số tài khoản..." 
                value={rejectNote}
                onChange={(e) => setRejectNote(e.target.value)}
                className="rounded-xl border-gray-200 focus:ring-red-500/20 min-h-[100px]"
              />
            </div>
          </div>
          <DialogFooter className="gap-2">
            <Button variant="ghost" onClick={() => setIsRejectDialogOpen(false)} className="rounded-xl h-11 font-bold">Hủy</Button>
            <Button 
              onClick={handleReject}
              disabled={!rejectReason || rejectWithdrawalMutation.isPending}
              className="bg-red-600 hover:bg-red-700 text-white font-bold rounded-xl h-11 px-6 shadow-none"
            >
              {rejectWithdrawalMutation.isPending ? "Đang xử lý..." : "Xác nhận từ chối"}
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>

      {/* Approve Confirmation Dialog */}
      <AlertDialog open={isApproveDialogOpen} onOpenChange={setIsApproveDialogOpen}>
        <AlertDialogContent className="rounded-3xl p-6">
          <AlertDialogHeader>
            <AlertDialogTitle className="text-xl font-bold text-gray-900">Xác nhận duyệt yêu cầu</AlertDialogTitle>
            <AlertDialogDescription className="text-gray-500">
              Bạn có chắc chắn duyệt yêu cầu rút tiền từ người dùng này?
              Hành động này không thể hoàn tác sau khi đã xác nhận.
            </AlertDialogDescription>
          </AlertDialogHeader>
          <AlertDialogFooter className="gap-2 pt-4">
            <AlertDialogCancel className="rounded-xl h-11 font-bold border-gray-200">Hủy</AlertDialogCancel>
            <AlertDialogAction 
              onClick={handleApprove}
              className="bg-emerald-600 hover:bg-emerald-700 text-white font-bold rounded-xl h-11 px-6 shadow-none"
            >
              {approveWithdrawalMutation.isPending ? "Đang xử lý..." : "Xác nhận"}
            </AlertDialogAction>
          </AlertDialogFooter>
        </AlertDialogContent>
      </AlertDialog>
    </div>
  );
};
