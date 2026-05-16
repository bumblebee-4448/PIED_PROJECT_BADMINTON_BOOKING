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
  X,
  CheckCircle2
} from "lucide-react";
import { format } from "date-fns";
import { Avatar, AvatarFallback, AvatarImage } from "@/shared/components/ui/avatar";
import { DataTablePagination } from "@/shared/components/DataTablePagination";

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
          <Badge className="bg-emerald-100 text-emerald-700 border-none font-bold text-[10px] shadow-none h-5 px-2">
            THÀNH CÔNG
          </Badge>
        );
      case "Rejected": 
        return (
          <Badge className="bg-red-100 text-red-700 border-none font-bold text-[10px] shadow-none h-5 px-2">
            ĐÃ TỪ CHỐI
          </Badge>
        );
      case "Pending": 
        return (
          <Badge className="bg-amber-100 text-amber-700 border-none font-bold text-[10px] shadow-none flex items-center gap-1 w-fit h-5 px-2">
            <Clock className="w-3 h-3" /> ĐANG CHỜ
          </Badge>
        );
      default: 
        return (
          <Badge className="bg-gray-100 text-gray-700 border-none font-bold text-[10px] shadow-none h-5 px-2">
            {status?.toUpperCase() || "KHÔNG RÕ"}
          </Badge>
        );
    }
  };

  return (
    <div className="p-6 max-w-7xl mx-auto space-y-6">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-gray-900">Phê duyệt rút tiền</h1>
          <p className="text-sm text-gray-500">Xử lý các yêu cầu rút tiền từ Khách hàng và Chủ sân</p>
        </div>
      </div>

      {/* Filters */}
      <div className="bg-white p-4 rounded-xl border border-gray-100 shadow-sm flex flex-col md:flex-row gap-4">
        <div className="relative flex-1">
          <Search className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={18} />
          <Input 
            placeholder="Tìm theo email..." 
            className="pl-10 h-11 border-gray-200 focus:ring-emerald-500/20"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
        </div>
        
        <div className="flex flex-wrap gap-3">
          <div className="relative w-[180px]">
            <User className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={16} />
            <Input 
              placeholder="User ID..." 
              className="pl-9 h-11 border-gray-200"
              value={filterUserId}
              onChange={(e) => setFilterUserId(e.target.value)}
            />
          </div>
          <div className="relative w-[180px]">
            <CalendarIcon className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={16} />
            <Input 
              type="date"
              className="pl-9 h-11 border-gray-200"
              value={filterDate}
              onChange={(e) => setFilterDate(e.target.value)}
            />
          </div>
          <Button 
            variant="outline" 
            onClick={clearFilters}
            className="h-11 px-4 text-xs font-bold text-gray-500 gap-2 border-gray-200 rounded-lg"
          >
            <X size={14} /> Làm mới
          </Button>
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
              <TableRow className="hover:bg-transparent">
                <TableHead className="w-[280px] font-semibold text-xs text-gray-400 uppercase tracking-wider">Người yêu cầu</TableHead>
                <TableHead className="font-semibold text-xs text-gray-400 uppercase tracking-wider">Ngân hàng</TableHead>
                <TableHead className="font-semibold text-xs text-gray-400 uppercase tracking-wider text-right">Số tiền</TableHead>
                <TableHead className="font-semibold text-xs text-gray-400 uppercase tracking-wider">Thời gian</TableHead>
                <TableHead className="font-semibold text-xs text-gray-400 uppercase tracking-wider text-center">Trạng thái</TableHead>
                <TableHead className="text-right font-semibold text-xs text-gray-400 uppercase tracking-wider">Thao tác</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {data.items.map((w) => (
                <TableRow key={w.id} className="hover:bg-gray-50/50 transition-colors border-b border-gray-50 last:border-0">
                  <TableCell>
                    <div className="flex items-center gap-3">
                      <Avatar className="h-9 w-9 border border-gray-100">
                        <AvatarImage src={w.avatar || ""} alt={`${w.firstName} ${w.lastName}`} />
                        <AvatarFallback className="bg-gray-50 text-gray-500 text-xs font-semibold">
                          {w.firstName ? w.firstName.charAt(0) : <User size={14} />}
                        </AvatarFallback>
                      </Avatar>
                      <div className="min-w-0 flex flex-col">
                        <p className="font-semibold text-gray-900 truncate text-sm">
                          {w.lastName} {w.firstName}
                        </p>
                        <p className="text-[10px] text-gray-400 truncate flex items-center gap-1 font-medium">
                          <Mail size={10} />
                          {w.email || "---"}
                        </p>
                      </div>
                    </div>
                  </TableCell>
                  <TableCell>
                    <div className="flex flex-col gap-0.5">
                      <div className="flex items-center gap-2">
                         <span className="text-xs font-bold text-emerald-600 bg-emerald-50 px-1.5 rounded">
                           {w.bankName?.toUpperCase()}
                         </span>
                         <span className="text-xs font-mono font-bold text-gray-700">
                           {w.bankAccountNumber}
                         </span>
                      </div>
                      <p className="text-[10px] font-medium text-gray-400 uppercase tracking-wide">{w.bankAccountName}</p>
                    </div>
                  </TableCell>
                  <TableCell className="text-right">
                    <p className="font-bold text-gray-900 text-sm">
                      {w.amount.toLocaleString()}đ
                    </p>
                  </TableCell>
                  <TableCell className="text-xs text-gray-400 font-medium">
                    {w.createdAt ? format(new Date(w.createdAt), "dd/MM HH:mm") : "---"}
                  </TableCell>
                  <TableCell className="text-center">
                    {getStatusBadge(w.status)}
                  </TableCell>
                  <TableCell className="text-right">
                    {w.status === "Pending" ? (
                      <div className="flex items-center justify-end gap-2">
                        <Button 
                          size="sm"
                          onClick={() => openApproveDialog(w.id)}
                          disabled={approveWithdrawalMutation.isPending}
                          className="bg-emerald-600 hover:bg-emerald-700 text-white h-8 px-3 font-bold text-xs rounded-lg"
                        >
                          Duyệt
                        </Button>
                        <Button 
                          variant="ghost"
                          size="sm"
                          onClick={() => openRejectDialog(w.id)}
                          className="text-red-500 hover:text-red-600 hover:bg-red-50 h-8 px-3 font-bold text-xs rounded-lg"
                        >
                          Từ chối
                        </Button>
                      </div>
                    ) : (
                      <span className="text-xs font-medium text-gray-300 uppercase tracking-wider">---</span>
                    )}
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        ) : (
          <div className="py-20 text-center space-y-4 bg-gray-50/20">
            <div className="w-16 h-16 bg-white rounded-2xl flex items-center justify-center text-gray-200 mx-auto border border-gray-100 shadow-sm">
              <Wallet size={32} />
            </div>
            <div className="space-y-1">
              <p className="text-gray-500 font-bold text-sm uppercase tracking-wider">Trống</p>
              <p className="text-gray-400 text-xs">Hiện tại không có yêu cầu nào cần xử lý</p>
            </div>
          </div>
        )}

        {/* Pagination */}
        {data && Math.ceil(data.totalItems / data.pageSize) > 1 && (
          <div className="p-4 border-t border-gray-50 bg-gray-50/20">
            <DataTablePagination 
              pageIndex={pageParams.pageIndex}
              totalPages={Math.ceil(data.totalItems / data.pageSize)}
              onPageChange={(page) => setPageParams(prev => ({ ...prev, pageIndex: page }))}
            />
          </div>
        )}
      </div>

      {/* Reject Dialog */}
      <Dialog open={isRejectDialogOpen} onOpenChange={setIsRejectDialogOpen}>
        <DialogContent className="sm:max-w-[420px] rounded-3xl p-0 overflow-hidden border-none shadow-2xl">
          <div className="bg-rose-500 p-6 text-white">
            <DialogHeader>
              <DialogTitle className="text-xl font-black tracking-tight">Từ chối rút tiền</DialogTitle>
              <DialogDescription className="text-rose-100 font-medium">
                Vui lòng cung cấp lý do chính xác để phản hồi người dùng.
              </DialogDescription>
            </DialogHeader>
          </div>
          <div className="p-6 space-y-5 bg-white">
            <div className="space-y-2">
              <Label className="text-[10px] font-black text-slate-400 uppercase tracking-widest">Lý do chính</Label>
              <Input 
                placeholder="VD: Sai thông tin tài khoản ngân hàng" 
                value={rejectReason}
                onChange={(e) => setRejectReason(e.target.value)}
                className="h-12 rounded-xl border-slate-200 focus:ring-rose-500/20 font-bold"
              />
            </div>
            <div className="space-y-2">
              <Label className="text-[10px] font-black text-slate-400 uppercase tracking-widest">Ghi chú chi tiết</Label>
              <Textarea 
                placeholder="Nhập thêm hướng dẫn cho người dùng..." 
                value={rejectNote}
                onChange={(e) => setRejectNote(e.target.value)}
                className="rounded-xl border-slate-200 focus:ring-rose-500/20 min-h-[120px] font-medium"
              />
            </div>
          </div>
          <div className="p-6 bg-slate-50 flex gap-3">
            <Button variant="ghost" onClick={() => setIsRejectDialogOpen(false)} className="flex-1 rounded-xl h-12 font-black text-slate-500">HỦY BỎ</Button>
            <Button 
              onClick={handleReject}
              disabled={!rejectReason || rejectWithdrawalMutation.isPending}
              className="flex-1 bg-rose-500 hover:bg-rose-600 text-white font-black rounded-xl h-12 shadow-lg shadow-rose-100"
            >
              {rejectWithdrawalMutation.isPending ? "ĐANG XỬ LÝ..." : "XÁC NHẬN TỪ CHỐI"}
            </Button>
          </div>
        </DialogContent>
      </Dialog>

      {/* Approve Confirmation Dialog */}
      <AlertDialog open={isApproveDialogOpen} onOpenChange={setIsApproveDialogOpen}>
        <AlertDialogContent className="rounded-3xl p-8 border-none shadow-2xl">
          <div className="flex flex-col items-center text-center space-y-4">
            <div className="w-16 h-16 bg-emerald-50 rounded-full flex items-center justify-center text-emerald-500">
              <CheckCircle2 className="w-10 h-10" />
            </div>
            <AlertDialogHeader>
              <AlertDialogTitle className="text-2xl font-black text-slate-900 tracking-tight">Xác nhận phê duyệt</AlertDialogTitle>
              <AlertDialogDescription className="text-slate-500 font-medium">
                Bạn đang chuẩn bị duyệt lệnh rút tiền này. Hãy đảm bảo bạn đã thực hiện chuyển khoản thực tế cho người dùng trước khi xác nhận trên hệ thống.
              </AlertDialogDescription>
            </AlertDialogHeader>
          </div>
          <AlertDialogFooter className="gap-3 pt-6 w-full flex sm:justify-center">
            <AlertDialogCancel className="flex-1 rounded-xl h-12 font-black text-slate-500 border-slate-200">KIỂM TRA LẠI</AlertDialogCancel>
            <AlertDialogAction 
              onClick={handleApprove}
              className="flex-1 bg-emerald-600 hover:bg-emerald-700 text-white font-black rounded-xl h-12 shadow-lg shadow-emerald-100"
            >
              {approveWithdrawalMutation.isPending ? "ĐANG XỬ LÝ..." : "TÔI ĐÃ CHUYỂN TIỀN"}
            </AlertDialogAction>
          </AlertDialogFooter>
        </AlertDialogContent>
      </AlertDialog>
    </div>
  );
};
