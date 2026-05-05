import { useState } from "react";
import {
  Search,
  CheckCircle,
  XCircle,
  Eye,
  FileText,
  Loader2,
  User,
  Building2,
  Phone,
  MapPin,
} from "lucide-react";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Badge } from "@/shared/components/ui/badge";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/shared/components/ui/table";
import { useOwnerRequests } from "../hooks/useOwnerRequests";
import { useAcceptOwnerRequest } from "../hooks/useAcceptOwnerRequest";
import { useRejectOwnerRequest } from "../hooks/useRejectOwnerRequest";
import type { OwnerRequest } from "../types";

const statusConfig: Record<
  OwnerRequest["status"],
  { label: string; className: string }
> = {
  Pending: {
    label: "Chờ duyệt",
    className: "bg-amber-50 text-amber-700 border-amber-200 hover:bg-amber-100",
  },
  Approved: {
    label: "Đã duyệt",
    className: "bg-green-50 text-green-700 border-green-200 hover:bg-green-100",
  },
  Rejected: {
    label: "Đã từ chối",
    className: "bg-red-50 text-red-700 border-red-200 hover:bg-red-100",
  },
};

export function OwnerRequestsPage() {
  const [search, setSearch] = useState("");
  const [pageIndex, setPageIndex] = useState(1);
  const [pageSize] = useState(10);
  const [selectedRequest, setSelectedRequest] = useState<OwnerRequest | null>(
    null,
  );
  const [isDetailOpen, setIsDetailOpen] = useState(false);
  const [isRejectOpen, setIsRejectOpen] = useState(false);
  const [rejectReason, setRejectReason] = useState("");
  const [rejectingId, setRejectingId] = useState<string | null>(null);

  const { data, isLoading } = useOwnerRequests({
    search: search || undefined,
    pageSize,
    pageIndex,
  });

  const acceptMutation = useAcceptOwnerRequest();
  const rejectMutation = useRejectOwnerRequest();

  const handleAccept = (id: string) => {
    if (confirm("Bạn có chắc muốn phê duyệt đơn đăng ký này?")) {
      acceptMutation.mutate(id);
    }
  };

  const handleReject = (id: string) => {
    setRejectingId(id);
    setRejectReason("");
    setIsRejectOpen(true);
  };

  const submitReject = () => {
    if (!rejectReason.trim()) {
      alert("Vui lòng nhập lý do từ chối");
      return;
    }
    if (rejectingId) {
      rejectMutation.mutate(
        { ownerRequestId: rejectingId, rejectReason: rejectReason.trim() },
        {
          onSuccess: () => {
            setIsRejectOpen(false);
            setRejectingId(null);
            setRejectReason("");
          },
        },
      );
    }
  };

  const handleViewDetail = (request: OwnerRequest) => {
    setSelectedRequest(request);
    setIsDetailOpen(true);
  };

  const requests = data?.items || [];
  const totalCount = data?.totalCount || 0;
  const totalPages = Math.ceil(totalCount / pageSize);

  return (
    <div className="space-y-6">
      {/* Header */}
      <div className="flex items-center justify-between">
        <div>
          <h1 className="text-2xl font-bold text-[#0B2421]">
            Đơn đăng ký chủ sân
          </h1>
          <p className="text-sm text-gray-500 mt-1">
            Quản lý và phê duyệt các đơn đăng ký trở thành chủ sân
          </p>
        </div>
      </div>

      {/* Search */}
      <div className="flex items-center gap-4">
        <div className="relative flex-1 max-w-md">
          <Search
            size={16}
            className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400"
          />
          <Input
            placeholder="Tìm kiếm theo tên, email, mã số thuế..."
            value={search}
            onChange={(e) => {
              setSearch(e.target.value);
              setPageIndex(1);
            }}
            className="pl-10"
          />
        </div>
      </div>

      {/* Table */}
      <div className="bg-white rounded-2xl border border-gray-100 shadow-sm overflow-hidden">
        <Table>
          <TableHeader>
            <TableRow className="bg-gray-50/50 hover:bg-gray-50/50">
              <TableHead className="font-semibold text-gray-700">
                Thông tin
              </TableHead>
              <TableHead className="font-semibold text-gray-700">
                Doanh nghiệp
              </TableHead>
              <TableHead className="font-semibold text-gray-700">
                Trạng thái
              </TableHead>
              <TableHead className="font-semibold text-gray-700">
                Ngày gửi
              </TableHead>
              <TableHead className="font-semibold text-gray-700 text-right">
                Thao tác
              </TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {isLoading ? (
              <TableRow>
                <TableCell colSpan={5} className="text-center py-12">
                  <Loader2
                    className="animate-spin mx-auto text-emerald-500"
                    size={28}
                  />
                  <p className="text-sm text-gray-400 mt-2">
                    Đang tải dữ liệu...
                  </p>
                </TableCell>
              </TableRow>
            ) : requests.length === 0 ? (
              <TableRow>
                <TableCell colSpan={5} className="text-center py-12">
                  <FileText className="mx-auto text-gray-300" size={40} />
                  <p className="text-sm text-gray-400 mt-2">
                    {search
                      ? "Không tìm thấy đơn đăng ký nào"
                      : "Chưa có đơn đăng ký nào"}
                  </p>
                </TableCell>
              </TableRow>
            ) : (
              requests.map((request) => (
                <TableRow key={request.id} className="hover:bg-gray-50/50">
                  <TableCell>
                    <div className="flex items-center gap-3">
                      <div className="w-9 h-9 rounded-full bg-emerald-50 flex items-center justify-center">
                        <User size={16} className="text-emerald-600" />
                      </div>
                      <div>
                        <p className="font-medium text-gray-900 text-sm">
                          {request.firstName ||
                          request.customer?.firstName ||
                          request.lastName ||
                          request.customer?.lastName
                            ? `${request.firstName || request.customer?.firstName || ""} ${request.lastName || request.customer?.lastName || ""}`
                            : request.businessName}
                        </p>
                        <p className="text-xs text-gray-500">
                          {request.customerEmail ||
                            request.customer?.email ||
                            request.customerId}
                        </p>
                      </div>
                    </div>
                  </TableCell>
                  <TableCell>
                    <div className="space-y-1">
                      <p className="font-medium text-gray-900 text-sm flex items-center gap-1.5">
                        <Building2 size={13} className="text-emerald-500" />
                        {request.businessName}
                      </p>
                      <p className="text-xs text-gray-500 flex items-center gap-1.5">
                        <MapPin size={12} className="text-gray-400" />
                        {request.businessAddress}
                      </p>
                    </div>
                  </TableCell>
                  <TableCell>
                    <Badge
                      variant="outline"
                      className={`text-xs font-medium ${statusConfig[request.status].className}`}
                    >
                      {statusConfig[request.status].label}
                    </Badge>
                  </TableCell>
                  <TableCell className="text-sm text-gray-600">
                    {new Date(request.createdAt).toLocaleDateString("vi-VN")}
                  </TableCell>
                  <TableCell className="text-right">
                    <Button
                      variant="outline"
                      size="sm"
                      onClick={() => handleViewDetail(request)}
                      className="text-xs text-emerald-700 border-emerald-200 hover:bg-emerald-50 hover:text-emerald-800"
                    >
                      <Eye size={14} className="mr-1.5" />
                      Xem chi tiết
                    </Button>
                  </TableCell>
                </TableRow>
              ))
            )}
          </TableBody>
        </Table>

        {/* Pagination */}
        {totalPages > 1 && (
          <div className="flex items-center justify-between px-6 py-4 border-t border-gray-100">
            <p className="text-sm text-gray-500">
              Hiển thị {requests.length} / {totalCount} đơn
            </p>
            <div className="flex items-center gap-2">
              <Button
                variant="outline"
                size="sm"
                onClick={() => setPageIndex((p) => Math.max(1, p - 1))}
                disabled={pageIndex <= 1}
              >
                Trước
              </Button>
              <span className="text-sm text-gray-600 px-2">
                Trang {pageIndex} / {totalPages}
              </span>
              <Button
                variant="outline"
                size="sm"
                onClick={() => setPageIndex((p) => Math.min(totalPages, p + 1))}
                disabled={pageIndex >= totalPages}
              >
                Sau
              </Button>
            </div>
          </div>
        )}
      </div>

      {/* Detail Dialog */}
      <Dialog open={isDetailOpen} onOpenChange={setIsDetailOpen}>
        <DialogContent className="max-w-2xl max-h-[90vh] overflow-y-auto">
          <DialogHeader>
            <DialogTitle className="flex items-center gap-3 text-xl font-bold">
              <div className="w-10 h-10 rounded-xl flex items-center justify-center bg-emerald-50">
                <FileText className="text-emerald-600" size={20} />
              </div>
              Chi tiết đơn đăng ký
            </DialogTitle>
          </DialogHeader>

          {selectedRequest && (
            <div className="space-y-6">
              {/* Status */}
              <div className="flex items-center gap-3">
                <span className="text-sm text-gray-500">Trạng thái:</span>
                <Badge
                  variant="outline"
                  className={`text-xs font-medium ${statusConfig[selectedRequest.status].className}`}
                >
                  {statusConfig[selectedRequest.status].label}
                </Badge>
              </div>

              {/* Personal Info */}
              <div className="space-y-3">
                <h3 className="font-semibold text-gray-900 flex items-center gap-2">
                  <User size={16} className="text-emerald-600" />
                  Thông tin cá nhân
                </h3>
                <div className="grid grid-cols-2 gap-4 bg-gray-50 rounded-xl p-4">
                  <div>
                    <p className="text-xs text-gray-500">Họ và tên</p>
                    <p className="text-sm font-medium text-gray-900">
                      {selectedRequest.firstName ||
                        selectedRequest.customer?.firstName ||
                        ""}{" "}
                      {selectedRequest.lastName ||
                        selectedRequest.customer?.lastName ||
                        ""}
                      {!selectedRequest.firstName &&
                        !selectedRequest.customer?.firstName &&
                        !selectedRequest.lastName &&
                        !selectedRequest.customer?.lastName && (
                          <span className="text-gray-400 font-normal">
                            Chưa cung cấp
                          </span>
                        )}
                    </p>
                  </div>
                  <div>
                    <p className="text-xs text-gray-500">Số điện thoại</p>
                    <p className="text-sm font-medium text-gray-900 flex items-center gap-1">
                      <Phone size={12} className="text-emerald-500" />
                      {selectedRequest.phoneNumber ||
                        selectedRequest.customer?.phoneNumber || (
                          <span className="text-gray-400 font-normal">
                            Chưa cung cấp
                          </span>
                        )}
                    </p>
                  </div>
                  <div>
                    <p className="text-xs text-gray-500">CCCD/CMND</p>
                    <p className="text-sm font-medium text-gray-900">
                      {selectedRequest.identityNumber || (
                        <span className="text-gray-400 font-normal">
                          Chưa cung cấp
                        </span>
                      )}
                    </p>
                  </div>
                  <div>
                    <p className="text-xs text-gray-500">Email</p>
                    <p className="text-sm font-medium text-gray-900">
                      {selectedRequest.customerEmail ||
                        selectedRequest.customer?.email || (
                          <span className="text-gray-400 font-normal">
                            Chưa cung cấp
                          </span>
                        )}
                    </p>
                  </div>
                </div>
              </div>

              {/* Business Info */}
              <div className="space-y-3">
                <h3 className="font-semibold text-gray-900 flex items-center gap-2">
                  <Building2 size={16} className="text-emerald-600" />
                  Thông tin doanh nghiệp
                </h3>
                <div className="grid grid-cols-2 gap-4 bg-gray-50 rounded-xl p-4">
                  <div>
                    <p className="text-xs text-gray-500">Tên doanh nghiệp</p>
                    <p className="text-sm font-medium text-gray-900">
                      {selectedRequest.businessName}
                    </p>
                  </div>
                  <div>
                    <p className="text-xs text-gray-500">Mã số thuế</p>
                    <p className="text-sm font-medium text-gray-900">
                      {selectedRequest.taxCode}
                    </p>
                  </div>
                  <div className="col-span-2">
                    <p className="text-xs text-gray-500">Địa chỉ kinh doanh</p>
                    <p className="text-sm font-medium text-gray-900">
                      {selectedRequest.businessAddress}
                    </p>
                  </div>
                </div>
              </div>

              {/* Documents */}
              <div className="space-y-3">
                <h3 className="font-semibold text-gray-900 flex items-center gap-2">
                  <FileText size={16} className="text-emerald-600" />
                  Tài liệu đính kèm
                </h3>
                <div className="grid grid-cols-3 gap-3">
                  {[
                    {
                      label: "Giấy phép KD",
                      url: selectedRequest.businessLicenseUrl,
                    },
                    {
                      label: "CCCD trước",
                      url: selectedRequest.identityCardFrontUrl,
                    },
                    {
                      label: "CCCD sau",
                      url: selectedRequest.identityCardBackUrl,
                    },
                  ].map((doc) => (
                    <a
                      key={doc.label}
                      href={doc.url}
                      target="_blank"
                      rel="noopener noreferrer"
                      className="flex flex-col items-center gap-2 p-4 rounded-xl border border-gray-200 hover:border-emerald-400 hover:bg-emerald-50 transition-all"
                    >
                      <FileText size={24} className="text-emerald-600" />
                      <span className="text-xs font-medium text-gray-700 text-center">
                        {doc.label}
                      </span>
                      <span className="text-[10px] text-emerald-600">
                        Xem file
                      </span>
                    </a>
                  ))}
                </div>
              </div>

              {/* Actions for pending */}
              {selectedRequest.status === "Pending" && (
                <div className="flex gap-3 pt-2">
                  <Button
                    variant="outline"
                    className="flex-1"
                    onClick={() => setIsDetailOpen(false)}
                  >
                    Đóng
                  </Button>
                  <Button
                    variant="outline"
                    className="flex-1 text-red-600 border-red-200 hover:bg-red-50"
                    onClick={() => {
                      setIsDetailOpen(false);
                      handleReject(selectedRequest.id);
                    }}
                    disabled={rejectMutation.isPending}
                  >
                    <XCircle size={16} className="mr-2" />
                    Từ chối
                  </Button>
                  <Button
                    className="flex-1 bg-emerald-600 hover:bg-emerald-700 text-white"
                    onClick={() => {
                      setIsDetailOpen(false);
                      handleAccept(selectedRequest.id);
                    }}
                    disabled={acceptMutation.isPending}
                  >
                    <CheckCircle size={16} className="mr-2" />
                    Phê duyệt
                  </Button>
                </div>
              )}
            </div>
          )}
        </DialogContent>
      </Dialog>

      {/* Reject Dialog */}
      <Dialog open={isRejectOpen} onOpenChange={setIsRejectOpen}>
        <DialogContent className="max-w-md">
          <DialogHeader>
            <DialogTitle className="text-lg font-bold text-red-600 flex items-center gap-2">
              <XCircle size={20} />
              Từ chối đơn đăng ký
            </DialogTitle>
          </DialogHeader>

          <div className="space-y-4">
            <div>
              <label className="text-sm font-medium text-gray-700 mb-1.5 block">
                Lý do từ chối *
              </label>
              <textarea
                value={rejectReason}
                onChange={(e) => setRejectReason(e.target.value)}
                placeholder="Nhập lý do từ chối đơn đăng ký..."
                rows={4}
                className="w-full rounded-xl border border-gray-200 px-4 py-3 text-sm focus:border-red-400 focus:ring-2 focus:ring-red-100 outline-none resize-none"
              />
            </div>

            <div className="flex gap-3">
              <Button
                variant="outline"
                className="flex-1"
                onClick={() => setIsRejectOpen(false)}
              >
                Hủy
              </Button>
              <Button
                variant="destructive"
                className="flex-1"
                onClick={submitReject}
                disabled={rejectMutation.isPending || !rejectReason.trim()}
              >
                {rejectMutation.isPending ? (
                  <Loader2 size={16} className="animate-spin mr-2" />
                ) : (
                  <XCircle size={16} className="mr-2" />
                )}
                Xác nhận từ chối
              </Button>
            </div>
          </div>
        </DialogContent>
      </Dialog>
    </div>
  );
}
