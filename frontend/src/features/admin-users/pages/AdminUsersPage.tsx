import { useState, useEffect } from "react";
import { useAdminUsers, useBanUnbanUser, useUserDetail } from "../hooks/useAdminUsers";
import { useDebounce } from "@/shared/hooks/useDebounce";
import { 
  Table, 
  TableBody, 
  TableCell, 
  TableHead, 
  TableHeader, 
  TableRow 
} from "@/shared/components/ui/table";
import { Input } from "@/shared/components/ui/input";
import { Button } from "@/shared/components/ui/button";
import { 
  Select, 
  SelectContent, 
  SelectItem, 
  SelectTrigger, 
  SelectValue 
} from "@/shared/components/ui/select";
import { 
  Search, 
  User, 
  Ban, 
  Unlock, 
  Eye, 
  Loader2,
  Filter,
  MoreVertical
} from "lucide-react";
import { 
  Dialog, 
  DialogContent, 
} from "@/shared/components/ui/dialog";
import { Separator } from "@/shared/components/ui/separator";
import { Badge } from "@/shared/components/ui/badge";
import { Avatar, AvatarFallback, AvatarImage } from "@/shared/components/ui/avatar";
import { 
  DropdownMenu, 
  DropdownMenuContent, 
  DropdownMenuItem, 
  DropdownMenuTrigger 
} from "@/shared/components/ui/dropdown-menu";
import { cn } from "@/lib/utils";
import { DataTablePagination } from "@/shared/components/DataTablePagination";

const ROLE_OPTIONS = [
  { label: "Tất cả vai trò", value: "all" },
  { label: "Chủ sân", value: "Owner" },
  { label: "Khách hàng", value: "Customer" },
];

const STATUS_OPTIONS = [
  { label: "Tất cả trạng thái", value: "all" },
  { label: "Hoạt động", value: "Active" },
  { label: "Đã khóa", value: "Banned" },
];

export default function AdminUsersPage() {
  const [search, setSearch] = useState("");
  const [role, setRole] = useState<string>("all");
  const [status, setStatus] = useState<string>("all");
  const debouncedSearch = useDebounce(search, 500);
  const [pageIndex, setPageIndex] = useState(1);
  const [selectedUserId, setSelectedUserId] = useState<string | null>(null);

  const { data, isLoading } = useAdminUsers({
    search: debouncedSearch || undefined,
    role: role === "all" ? undefined : role,
    status: status === "all" ? undefined : status,
    pageIndex,
    pageSize: 10,
  });

  // Reset to first page when filters change
  useEffect(() => {
    setPageIndex(1);
  }, [debouncedSearch, role, status]);


  const banUnbanMutation = useBanUnbanUser();
  const { data: userDetail } = useUserDetail(selectedUserId || "");

  const handleToggleStatus = (userId: string, currentStatus: string) => {
    const newStatus = currentStatus === "Active" ? "Banned" : "Active";
    banUnbanMutation.mutate({ id: userId, status: newStatus });
  };

  const getRoleLabel = (role: string) => {
    switch (role) {
      case "Admin": return { label: "Admin", class: "bg-blue-50 text-blue-600" };
      case "Owner": return { label: "Chủ sân", class: "bg-purple-50 text-purple-600" };
      case "Customer": return { label: "Khách hàng", class: "bg-emerald-50 text-emerald-600" };
      default: return { label: role || "Người dùng", class: "bg-gray-50 text-gray-600" };
    }
  };

  const getStatusLabel = (status: string) => {
    switch (status) {
      case "Active": return { label: "Hoạt động", class: "bg-emerald-100 text-emerald-700" };
      case "Banned": return { label: "Đã khóa", class: "bg-red-100 text-red-700" };
      default: return { label: status || "Không xác định", class: "bg-gray-100 text-gray-700" };
    }
  };

  return (
    <div className="p-6 max-w-7xl mx-auto space-y-6">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-gray-900">Quản lý người dùng</h1>
          <p className="text-sm text-gray-500">Tìm kiếm và quản lý tài khoản người dùng trong hệ thống</p>
        </div>
      </div>

      {/* Filters */}
      <div className="bg-white p-4 rounded-xl border border-gray-100 shadow-sm flex flex-col md:flex-row gap-4">
        <div className="relative flex-1">
          <Search className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={18} />
          <Input 
            placeholder="Tìm theo tên, email, số điện thoại..." 
            className="pl-10 h-11 border-gray-200 focus:ring-emerald-500/20"
            value={search}
            onChange={(e) => setSearch(e.target.value)}
          />
        </div>
        
        <div className="flex flex-wrap gap-3">
          <Select value={role} onValueChange={setRole}>
            <SelectTrigger className="w-[160px] h-11 border-gray-200">
              <div className="flex items-center gap-2">
                <Filter size={14} className="text-gray-400" />
                <SelectValue placeholder="Vai trò" />
              </div>
            </SelectTrigger>
            <SelectContent>
              {ROLE_OPTIONS.map(opt => (
                <SelectItem key={opt.value} value={opt.value}>{opt.label}</SelectItem>
              ))}
            </SelectContent>
          </Select>

          <Select value={status} onValueChange={setStatus}>
            <SelectTrigger className="w-[160px] h-11 border-gray-200">
              <SelectValue placeholder="Trạng thái" />
            </SelectTrigger>
            <SelectContent>
              {STATUS_OPTIONS.map(opt => (
                <SelectItem key={opt.value} value={opt.value}>{opt.label}</SelectItem>
              ))}
            </SelectContent>
          </Select>
        </div>
      </div>

      {/* Table */}
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
                <TableHead className="w-[300px]">Người dùng</TableHead>
                <TableHead>Vai trò</TableHead>
                <TableHead>Trạng thái</TableHead>
                <TableHead>Số điện thoại</TableHead>
                <TableHead className="text-right">Thao tác</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {data.items.map((user) => {
                const roleInfo = getRoleLabel(user.role);
                const statusInfo = getStatusLabel(user.status);
                
                return (
                  <TableRow key={user.id} className="hover:bg-gray-50/50 transition-colors">
                    <TableCell>
                      <div className="flex items-center gap-3">
                        <Avatar className="h-10 w-10 border border-gray-100">
                          <AvatarImage src={user.avatarUrl} alt={`${user.firstName} ${user.lastName}`} />
                          <AvatarFallback className="bg-emerald-50 text-emerald-600">
                            {user.firstName ? user.firstName.charAt(0) : <User size={16} />}
                          </AvatarFallback>
                        </Avatar>
                        <div className="min-w-0">
                          <p className="font-semibold text-gray-900 truncate">{user.firstName} {user.lastName}</p>
                          <p className="text-xs text-gray-500 truncate">{user.email || "Không có email"}</p>
                        </div>
                      </div>
                    </TableCell>
                    <TableCell>
                      <Badge className={cn("border-none font-medium pointer-events-none shadow-none", roleInfo.class)}>
                        {roleInfo.label}
                      </Badge>
                    </TableCell>
                    <TableCell>
                      <Badge className={cn("border-none font-bold pointer-events-none shadow-none", statusInfo.class)}>
                        {statusInfo.label}
                      </Badge>
                    </TableCell>
                    <TableCell className="text-sm text-gray-600">
                      {user.phoneNumber || "---"}
                    </TableCell>
                    <TableCell className="text-right">
                      <DropdownMenu>
                        <DropdownMenuTrigger asChild>
                          <Button variant="ghost" size="icon" className="h-8 w-8 text-gray-400">
                            <MoreVertical size={16} />
                          </Button>
                        </DropdownMenuTrigger>
                        <DropdownMenuContent align="end" className="w-48 p-1">
                          <DropdownMenuItem 
                            className="flex items-center gap-2 cursor-pointer py-2"
                            onClick={() => setSelectedUserId(user.id)}
                          >
                            <Eye size={16} className="text-blue-500" />
                            <span>Xem chi tiết</span>
                          </DropdownMenuItem>
                          
                          <DropdownMenuItem 
                            className={cn(
                              "flex items-center gap-2 cursor-pointer py-2",
                              user.status === "Active" ? "text-red-600 focus:text-red-600" : "text-emerald-600 focus:text-emerald-600"
                            )}
                            onClick={() => handleToggleStatus(user.id, user.status)}
                            disabled={banUnbanMutation.isPending}
                          >
                            {user.status === "Active" ? (
                              <><Ban size={16} /> <span>Khóa tài khoản</span></>
                            ) : (
                              <><Unlock size={16} /> <span>Mở khóa tài khoản</span></>
                            )}
                          </DropdownMenuItem>
                        </DropdownMenuContent>
                      </DropdownMenu>
                    </TableCell>
                  </TableRow>
                );
              })}
            </TableBody>
          </Table>
        ) : (
          <div className="py-20 text-center space-y-3">
            <div className="w-16 h-16 bg-gray-50 rounded-full flex items-center justify-center text-gray-200 mx-auto">
              <User size={32} />
            </div>
            <p className="text-gray-500 font-medium">Không tìm thấy người dùng nào</p>
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

      {/* User Detail Modal */}
      <Dialog open={!!selectedUserId} onOpenChange={(open) => !open && setSelectedUserId(null)}>
        <DialogContent className="sm:max-w-[500px] rounded-3xl p-0 overflow-hidden border-none shadow-2xl">
          <div className="bg-emerald-600 h-32 relative">
             <div className="absolute -bottom-12 left-8 p-1 bg-white rounded-full">
                <Avatar className="h-24 w-24 border-4 border-white">
                  <AvatarImage src={userDetail?.avatarUrl} />
                  <AvatarFallback className="text-2xl bg-emerald-50 text-emerald-600">
                    {userDetail?.firstName ? userDetail.firstName.charAt(0) : <User size={32} />}
                  </AvatarFallback>
                </Avatar>
             </div>
          </div>

          <div className="pt-16 pb-8 px-8 space-y-6">
            <div>
              <div className="flex items-center justify-between mb-1">
                <h2 className="text-2xl font-black text-gray-900">{userDetail?.firstName} {userDetail?.lastName}</h2>
                {userDetail && (
                  <Badge className={cn("border-none pointer-events-none shadow-none", getStatusLabel(userDetail.status).class)}>
                    {getStatusLabel(userDetail.status).label}
                  </Badge>
                )}
              </div>
              <p className="text-sm text-gray-400 font-medium">{userDetail?.email}</p>
            </div>

            <Separator className="bg-gray-50" />

            <div className="grid grid-cols-2 gap-6">
              <div className="space-y-1">
                <p className="text-[10px] font-black text-gray-400 uppercase tracking-widest">Số điện thoại</p>
                <p className="text-sm font-bold text-gray-700">{userDetail?.phoneNumber || "---"}</p>
              </div>
              <div className="space-y-1">
                <p className="text-[10px] font-black text-gray-400 uppercase tracking-widest">Vai trò</p>
                {userDetail && (
                  <Badge className={cn("border-none mt-1 pointer-events-none shadow-none", getRoleLabel(userDetail.role).class)}>
                    {getRoleLabel(userDetail.role).label}
                  </Badge>
                )}
              </div>
              <div className="space-y-1">
                <p className="text-[10px] font-black text-gray-400 uppercase tracking-widest">Mã định danh</p>
                <p className="text-[10px] font-mono text-gray-400 bg-gray-50 px-2 py-1 rounded mt-1">
                  {userDetail?.id}
                </p>
              </div>
            </div>

            <div className="pt-4">
              <Button 
                variant="outline" 
                className="w-full h-12 rounded-2xl font-bold border-gray-100 hover:bg-gray-50"
                onClick={() => setSelectedUserId(null)}
              >
                Đóng
              </Button>
            </div>
          </div>
        </DialogContent>
      </Dialog>
    </div>
  );
}
