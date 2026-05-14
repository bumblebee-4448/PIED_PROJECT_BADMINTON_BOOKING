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
  Search, 
  ArrowUpRight, 
  ArrowDownLeft, 
  ShoppingBag,
  Undo2,
  RefreshCcw,
  User,
  Loader2,
  History,
  Calendar as CalendarIcon,
  X
} from "lucide-react";
import { format } from "date-fns";
import { Avatar, AvatarFallback, AvatarImage } from "@/shared/components/ui/avatar";
import { cn } from "@/lib/utils";

export const AdminTransactionsPage: React.FC = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [filterUserId, setFilterUserId] = useState("");
  const [filterDate, setFilterDate] = useState("");
  const [pageParams, setPageParams] = useState({ pageIndex: 1, pageSize: 10 });

  const { useAllTransactions } = useAdminWallet();
  const { data, isLoading } = useAllTransactions(
    filterUserId || null, 
    { ...pageParams, search: searchTerm, date: filterDate }
  );

  const getTransactionTypeInfo = (type: string) => {
    switch (type) {
      case "Deposit":
        return {
          icon: <ArrowUpRight className="w-3 h-3" />,
          label: "NẠP TIỀN",
          className: "bg-emerald-50 text-emerald-600",
        };
      case "Withdrawal":
        return {
          icon: <ArrowDownLeft className="w-3 h-3" />,
          label: "RÚT TIỀN",
          className: "bg-red-50 text-red-600",
        };
      case "BookingPayment":
        return {
          icon: <ShoppingBag className="w-3 h-3" />,
          label: "THANH TOÁN",
          className: "bg-blue-50 text-blue-600",
        };
      case "Refund":
        return {
          icon: <Undo2 className="w-3 h-3" />,
          label: "HOÀN TIỀN",
          className: "bg-amber-50 text-amber-600",
        };
      default:
        return {
          icon: <RefreshCcw className="w-3 h-3" />,
          label: "GIAO DỊCH",
          className: "bg-gray-50 text-gray-600",
        };
    }
  };

  const clearFilters = () => {
    setSearchTerm("");
    setFilterUserId("");
    setFilterDate("");
    setPageParams({ pageIndex: 1, pageSize: 10 });
  };

  return (
    <div className="p-6 max-w-7xl mx-auto space-y-6">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-gray-900">Lịch sử giao dịch</h1>
          <p className="text-sm text-gray-500">Theo dõi toàn bộ biến động số dư trong hệ thống</p>
        </div>
      </div>

      {/* Filters */}
      <div className="bg-white p-4 rounded-xl border border-gray-100 shadow-sm space-y-4">
        <div className="grid grid-cols-1 md:grid-cols-3 lg:grid-cols-4 gap-4">
          <div className="relative">
            <Search className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={16} />
            <Input 
              placeholder="Tìm theo Email..." 
              className="pl-9 h-10 border-gray-200 focus:ring-blue-500/20 text-sm"
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
            />
          </div>
          <div className="relative">
            <User className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={16} />
            <Input 
              placeholder="Lọc theo User ID..." 
              className="pl-9 h-10 border-gray-200 focus:ring-blue-500/20 text-sm"
              value={filterUserId}
              onChange={(e) => setFilterUserId(e.target.value)}
            />
          </div>
          <div className="relative">
            <CalendarIcon className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={16} />
            <Input 
              type="date"
              className="pl-9 h-10 border-gray-200 focus:ring-blue-500/20 text-sm"
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
            <Loader2 className="animate-spin text-blue-600" size={40} />
            <p className="text-sm text-gray-400 font-medium">Đang tải giao dịch...</p>
          </div>
        ) : data?.items && data.items.length > 0 ? (
          <Table>
            <TableHeader className="bg-gray-50/50">
              <TableRow>
                <TableHead className="w-[280px]">Người dùng</TableHead>
                <TableHead>Loại giao dịch</TableHead>
                <TableHead>Số tiền</TableHead>
                <TableHead>Nội dung</TableHead>
                <TableHead>Thời gian</TableHead>
                <TableHead className="text-right">Trạng thái</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {data.items.map((tx) => {
                const typeInfo = getTransactionTypeInfo(tx.type);
                const isPositive = ["Deposit", "Refund"].includes(tx.type);
                
                return (
                  <TableRow key={tx.id} className="hover:bg-gray-50/50 transition-colors">
                    <TableCell>
                      <div className="flex items-center gap-3">
                        <Avatar className="h-10 w-10 border border-gray-100">
                          <AvatarImage src={tx.avatarUrl || ""} alt={`${tx.firstName} ${tx.lastName}`} />
                          <AvatarFallback className="bg-blue-50 text-blue-600">
                            {tx.firstName ? tx.firstName.charAt(0) : <User size={16} />}
                          </AvatarFallback>
                        </Avatar>
                        <div className="min-w-0">
                          <p className="font-semibold text-gray-900 truncate">
                            {tx.lastName} {tx.firstName}
                          </p>
                          <p className="text-[10px] text-gray-400 font-mono font-bold truncate">
                            ID: {tx.walletId ? tx.walletId.substring(0, 8) : "N/A"}...
                          </p>
                        </div>
                      </div>
                    </TableCell>
                    <TableCell>
                      <Badge className={cn("border-none font-bold shadow-none flex items-center gap-1.5 w-fit", typeInfo.className)}>
                        {typeInfo.icon} {typeInfo.label}
                      </Badge>
                    </TableCell>
                    <TableCell>
                      <span className={cn("font-bold", isPositive ? "text-emerald-600" : "text-gray-900")}>
                        {isPositive ? '+' : '-'}{Math.abs(tx.amount).toLocaleString()}đ
                      </span>
                    </TableCell>
                    <TableCell>
                      <div className="flex flex-col gap-0.5 max-w-[250px]">
                         <p className="text-xs font-medium text-gray-700 truncate">{tx.transferContent || "Không có nội dung"}</p>
                         {tx.bankRefCode && (
                           <span className="text-[9px] font-mono text-gray-400 uppercase tracking-tighter">
                             REF: {tx.bankRefCode}
                           </span>
                         )}
                      </div>
                    </TableCell>
                    <TableCell className="text-xs text-gray-500 font-medium">
                      {tx.createdAt ? format(new Date(tx.createdAt), "dd/MM/yyyy HH:mm") : "N/A"}
                    </TableCell>
                    <TableCell className="text-right">
                      <Badge className="bg-emerald-100 text-emerald-700 border-none font-bold shadow-none">
                        HOÀN TẤT
                      </Badge>
                    </TableCell>
                  </TableRow>
                );
              })}
            </TableBody>
          </Table>
        ) : (
          <div className="py-20 text-center space-y-3">
            <div className="w-16 h-16 bg-gray-50 rounded-full flex items-center justify-center text-gray-200 mx-auto">
              <History size={32} />
            </div>
            <p className="text-gray-500 font-medium">Không tìm thấy giao dịch nào</p>
          </div>
        )}

        {/* Pagination */}
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
    </div>
  );
};

