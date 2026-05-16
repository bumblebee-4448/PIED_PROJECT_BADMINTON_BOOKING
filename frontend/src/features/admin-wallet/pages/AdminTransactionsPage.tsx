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
import { DataTablePagination } from "@/shared/components/DataTablePagination";

import { 
  Tabs, 
  TabsList, 
  TabsTrigger
} from "@/shared/components/ui/tabs";

export const AdminTransactionsPage: React.FC = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [filterUserId, setFilterUserId] = useState("");
  const [filterDate, setFilterDate] = useState("");
  const [activeTab, setActiveTab] = useState<string>("all");
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
          category: "SYSTEM",
          roleColor: "bg-gray-50 text-gray-600",
          className: "bg-emerald-50 text-emerald-600",
        };
      case "Withdrawal":
        return {
          icon: <ArrowDownLeft className="w-3 h-3" />,
          label: "RÚT TIỀN",
          category: "OWNER",
          roleColor: "bg-purple-50 text-purple-600",
          className: "bg-rose-50 text-rose-600",
        };
      case "BookingPayment":
        return {
          icon: <ShoppingBag className="w-3 h-3" />,
          label: "THANH TOÁN",
          category: "CUSTOMER",
          roleColor: "bg-emerald-50 text-emerald-600",
          className: "bg-blue-50 text-blue-600",
        };
      case "Refund":
        return {
          icon: <Undo2 className="w-3 h-3" />,
          label: "HOÀN TIỀN",
          category: "CUSTOMER",
          roleColor: "bg-emerald-50 text-emerald-600",
          className: "bg-indigo-50 text-indigo-600",
        };
      case "Receive":
        return {
          icon: <ArrowDownLeft className="w-3 h-3" />,
          label: "NHẬN DOANH THU",
          category: "OWNER",
          roleColor: "bg-purple-50 text-purple-600",
          className: "bg-emerald-50 text-emerald-600",
        };
      default:
        return {
          icon: <RefreshCcw className="w-3 h-3" />,
          label: "GIAO DỊCH",
          category: "SYSTEM",
          roleColor: "bg-gray-50 text-gray-500",
          className: "bg-gray-50 text-gray-600",
        };
    }
  };

  const clearFilters = () => {
    setSearchTerm("");
    setFilterUserId("");
    setFilterDate("");
    setActiveTab("all");
    setPageParams({ pageIndex: 1, pageSize: 10 });
  };

  const filteredItems = data?.items.filter(tx => {
    const typeInfo = getTransactionTypeInfo(tx.type);
    if (activeTab === "customer") return typeInfo.category === "CUSTOMER";
    if (activeTab === "owner") return typeInfo.category === "OWNER";
    return true;
  }) || [];

  return (
    <div className="p-6 max-w-7xl mx-auto space-y-6">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-gray-900">Lịch sử giao dịch</h1>
          <p className="text-sm text-gray-500">Theo dõi toàn bộ luồng tiền của Khách hàng và Chủ sân</p>
        </div>
      </div>

      <div className="space-y-4">
        <div className="flex flex-col md:flex-row items-center justify-between gap-4">
          <Tabs value={activeTab} onValueChange={setActiveTab} className="w-full md:w-auto">
            <TabsList className="bg-gray-100 p-1 rounded-lg">
              <TabsTrigger value="all" className="rounded-md px-6 text-xs font-semibold uppercase tracking-wider data-[state=active]:bg-white data-[state=active]:shadow-sm">
                Tất cả
              </TabsTrigger>
              <TabsTrigger value="customer" className="rounded-md px-6 text-xs font-semibold uppercase tracking-wider data-[state=active]:bg-white data-[state=active]:shadow-sm">
                Khách hàng
              </TabsTrigger>
              <TabsTrigger value="owner" className="rounded-md px-6 text-xs font-semibold uppercase tracking-wider data-[state=active]:bg-white data-[state=active]:shadow-sm">
                Chủ sân
              </TabsTrigger>
            </TabsList>
          </Tabs>

          <div className="flex flex-wrap items-center gap-3 w-full md:w-auto">
            <div className="relative flex-1 md:w-64">
              <Search className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={16} />
              <Input 
                placeholder="Email hoặc Tên..." 
                className="pl-9 h-10 border-gray-200 focus:ring-emerald-500/20 text-sm"
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
              />
            </div>
            <Button 
              variant="outline" 
              size="sm"
              onClick={clearFilters}
              className="h-10 px-4 text-xs font-semibold text-gray-500 gap-2 border-gray-200"
            >
              <X size={14} /> Làm mới
            </Button>
          </div>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
           <div className="relative">
              <User className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={16} />
              <Input 
                placeholder="Tìm theo User ID..." 
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
        </div>
      </div>

      {/* Table Section */}
      <div className="bg-white rounded-xl border border-gray-100 shadow-sm overflow-hidden">
        {isLoading ? (
          <div className="py-20 flex flex-col items-center justify-center gap-4">
            <Loader2 className="animate-spin text-emerald-600" size={40} />
            <p className="text-sm text-gray-400 font-medium tracking-wide">Đang tải dữ liệu...</p>
          </div>
        ) : filteredItems.length > 0 ? (
          <Table>
            <TableHeader className="bg-gray-50/50">
              <TableRow className="hover:bg-transparent">
                <TableHead className="w-[220px] font-semibold text-xs text-gray-400 uppercase tracking-wider">Người thực hiện</TableHead>
                <TableHead className="font-semibold text-xs text-gray-400 uppercase tracking-wider">Loại giao dịch</TableHead>
                <TableHead className="font-semibold text-xs text-gray-400 uppercase tracking-wider text-right">Số tiền</TableHead>
                <TableHead className="font-semibold text-xs text-gray-400 uppercase tracking-wider">Nội dung</TableHead>
                <TableHead className="font-semibold text-xs text-gray-400 uppercase tracking-wider">Thời gian</TableHead>
                <TableHead className="text-right font-semibold text-xs text-gray-400 uppercase tracking-wider">Trạng thái</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {filteredItems.map((tx) => {
                const typeInfo = getTransactionTypeInfo(tx.type);
                const isPositive = ["Deposit", "Refund", "Receive"].includes(tx.type);
                
                return (
                  <TableRow key={tx.id} className="hover:bg-gray-50/50 transition-colors border-b border-gray-50 last:border-0">
                    <TableCell>
                      <div className="flex items-center gap-3">
                        <Avatar className="h-9 w-9 border border-gray-100 shadow-sm">
                          <AvatarImage src={tx.avatarUrl || ""} alt={`${tx.firstName} ${tx.lastName}`} />
                          <AvatarFallback className="bg-gray-50 text-gray-500 text-xs font-semibold">
                            {tx.firstName ? tx.firstName.charAt(0) : <User size={14} />}
                          </AvatarFallback>
                        </Avatar>
                        <div className="min-w-0 flex flex-col">
                          <p className="font-semibold text-gray-900 truncate text-sm">
                            {tx.lastName} {tx.firstName}
                          </p>
                          <p className="text-[10px] text-gray-400 font-mono truncate">
                            ID: {tx.walletId ? tx.walletId.substring(0, 8) : "---"}
                          </p>
                        </div>
                      </div>
                    </TableCell>
                    <TableCell>
                      <div className="flex flex-col gap-1">
                        <Badge className={cn("border-none font-medium text-[10px] shadow-none w-fit h-5 uppercase", typeInfo.roleColor)}>
                          {typeInfo.category === "CUSTOMER" ? "Khách hàng" : 
                           typeInfo.category === "OWNER" ? "Chủ sân" : "Hệ thống"}
                        </Badge>
                        <div className="flex items-center gap-1.5 text-[11px] font-semibold text-gray-600">
                          <span className={cn("p-0.5 rounded", typeInfo.className.replace("bg-", "text-").replace("text-", "bg-").replace("600", "50"))}>
                            {typeInfo.icon}
                          </span>
                          {typeInfo.label}
                        </div>
                      </div>
                    </TableCell>
                    <TableCell className="text-right">
                      <span className={cn("font-bold text-sm", isPositive ? "text-emerald-600" : "text-rose-500")}>
                        {isPositive ? '+' : '-'}{Math.abs(tx.amount).toLocaleString()}đ
                      </span>
                    </TableCell>
                    <TableCell>
                      <div className="flex flex-col gap-1 max-w-[180px]">
                         <p className="text-xs text-gray-600 truncate font-medium">{tx.transferContent || "---"}</p>
                         <div className="flex items-center gap-2">
                           {tx.bankRefCode && (
                             <span className="text-[10px] font-mono text-gray-400 bg-gray-50 px-1.5 py-0.5 rounded border border-gray-100">
                               {tx.bankRefCode}
                             </span>
                           )}
                         </div>
                      </div>
                    </TableCell>
                    <TableCell className="text-xs text-gray-400 font-medium">
                      {tx.createdAt ? format(new Date(tx.createdAt), "dd/MM HH:mm") : "---"}
                    </TableCell>
                    <TableCell className="text-right">
                      <Badge className="bg-emerald-100 text-emerald-700 border-none font-bold text-[10px] shadow-none h-5">
                        HOÀN TẤT
                      </Badge>
                    </TableCell>
                  </TableRow>
                );
              })}
            </TableBody>
          </Table>
        ) : (
          <div className="py-20 text-center space-y-4 bg-gray-50/20">
            <div className="w-16 h-16 bg-white rounded-2xl flex items-center justify-center text-gray-200 mx-auto shadow-sm border border-gray-50">
              <History size={32} />
            </div>
            <div className="space-y-1">
              <p className="text-gray-500 font-bold text-sm uppercase tracking-wider">Không có dữ liệu</p>
              <p className="text-gray-400 text-xs">Hãy thử thay đổi bộ lọc để tìm kiếm kết quả khác</p>
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
    </div>
  );
};

