import { useEffect, useMemo, useState } from "react";
import {
  AlertTriangle,
  CheckCircle2,
  Clock,
  Loader2,
  MessageSquare,
  Search,
  ShieldCheck,
  X,
} from "lucide-react";

import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Badge } from "@/shared/components/ui/badge";
import {
  Tabs,
  TabsContent,
  TabsList,
  TabsTrigger,
} from "@/shared/components/ui/tabs";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/shared/components/ui/table";
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
import { DataTablePagination } from "@/shared/components/DataTablePagination";
import { useDebounce } from "@/shared/hooks/useDebounce";
import { cn } from "@/lib/utils";
import {
  useBookingReports,
  useConfirmBookingReport,
  useSubmitSystemReportReply,
  useSystemReports,
} from "../hooks/useReports";
import type {
  ReportBookingResponse,
  ReportStatus,
  SystemReportResponse,
} from "../types";

type ReportTab = "booking" | "system";

const STATUS_OPTIONS = [
  { label: "Tất cả", value: "all" },
  { label: "Đang chờ", value: "Pending" },
  { label: "Đã xử lý", value: "resolved" },
];

const getStatusConfig = (status: ReportStatus | string) => {
  if (status === "Pending") {
    return {
      label: "Đang chờ",
      icon: Clock,
      className: "bg-amber-100 text-amber-700 border-amber-100",
    };
  }

  return {
    label: "Đã xử lý",
    icon: CheckCircle2,
    className: "bg-emerald-100 text-emerald-700 border-emerald-100",
  };
};

const isResolvedStatus = (status: string) =>
  status === "Confirmed" || status === "Completed";

const matchesStatus = (status: string, filter: string) => {
  if (filter === "all") return true;
  if (filter === "resolved") return isResolvedStatus(status);
  return status === filter;
};

const matchesSearch = (values: Array<string | undefined>, search: string) => {
  if (!search) return true;
  const normalizedSearch = search.toLowerCase().trim();
  return values.some((value) => value?.toLowerCase().includes(normalizedSearch));
};

export function AdminReportsPage() {
  const [activeTab, setActiveTab] = useState<ReportTab>("booking");
  const [search, setSearch] = useState("");
  const [status, setStatus] = useState("Pending");
  const [pageIndex, setPageIndex] = useState(1);
  const [confirmTarget, setConfirmTarget] = useState<{
    id: string;
    type: ReportTab;
    title: string;
  } | null>(null);

  const debouncedSearch = useDebounce(search, 300);

  const bookingReportsQuery = useBookingReports({
    pageIndex: activeTab === "booking" ? pageIndex : 1,
    pageSize: 10,
  });
  const systemReportsQuery = useSystemReports({
    pageIndex: activeTab === "system" ? pageIndex : 1,
    pageSize: 10,
  });
  const confirmBookingReport = useConfirmBookingReport();
  const submitSystemReportReply = useSubmitSystemReportReply();

  useEffect(() => {
    setPageIndex(1);
  }, [activeTab, debouncedSearch, status]);

  const bookingReports = useMemo(() => {
    const items = bookingReportsQuery.data?.items ?? [];
    return items.filter(
      (report) =>
        matchesStatus(report.status, status) &&
        matchesSearch(
          [
            report.reason,
            report.reportBookingId,
            report.bookingId,
            report.customerId,
            report.courtId,
          ],
          debouncedSearch,
        ),
    );
  }, [bookingReportsQuery.data?.items, debouncedSearch, status]);

  const systemReports = useMemo(() => {
    const items = systemReportsQuery.data?.items ?? [];
    return items.filter(
      (report) =>
        matchesStatus(report.status, status) &&
        matchesSearch([report.title, report.reason, report.id], debouncedSearch),
    );
  }, [systemReportsQuery.data?.items, debouncedSearch, status]);

  const currentData =
    activeTab === "booking" ? bookingReportsQuery.data : systemReportsQuery.data;
  const currentTotalPages =
    currentData?.totalPages ?? Math.ceil((currentData?.totalItems ?? 0) / 10);
  const isConfirming =
    confirmBookingReport.isPending || submitSystemReportReply.isPending;

  const openConfirmDialog = (
    report: ReportBookingResponse | SystemReportResponse,
    type: ReportTab,
  ) => {
    const reportId =
      type === "booking"
        ? (report as ReportBookingResponse).reportBookingId
        : (report as SystemReportResponse).id;
    const reportTitle =
      type === "booking"
        ? `Báo cáo đặt sân ${(report as ReportBookingResponse).bookingId.slice(0, 8)}`
        : (report as SystemReportResponse).title;

    setConfirmTarget({
      id: reportId,
      type,
      title: reportTitle,
    });
  };

  const handleConfirm = () => {
    if (!confirmTarget) return;

    if (confirmTarget.type === "booking") {
      confirmBookingReport.mutate(confirmTarget.id, {
        onSuccess: () => setConfirmTarget(null),
      });
      return;
    }

    submitSystemReportReply.mutate(confirmTarget.id, {
      onSuccess: () => setConfirmTarget(null),
    });
  };

  const clearFilters = () => {
    setSearch("");
    setStatus("Pending");
    setPageIndex(1);
  };

  const renderStatusBadge = (reportStatus: string) => {
    const config = getStatusConfig(reportStatus);
    const Icon = config.icon;

    return (
      <Badge
        className={cn(
          "w-fit gap-1.5 border px-2.5 py-1 text-[11px] font-bold shadow-none",
          config.className,
        )}
      >
        <Icon size={13} />
        {config.label}
      </Badge>
    );
  };

  const renderEmptyState = () => (
    <div className="py-20 text-center space-y-4 bg-gray-50/20">
      <div className="mx-auto flex h-16 w-16 items-center justify-center rounded-2xl border border-gray-100 bg-white text-gray-200 shadow-sm">
        <MessageSquare size={32} />
      </div>
      <div className="space-y-1">
        <p className="text-sm font-bold uppercase tracking-wider text-gray-500">
          Không có báo cáo
        </p>
        <p className="text-xs text-gray-400">
          Không tìm thấy báo cáo phù hợp với bộ lọc hiện tại.
        </p>
      </div>
    </div>
  );

  return (
    <div className="p-6 max-w-7xl mx-auto space-y-6">
      <div className="flex flex-col gap-4 md:flex-row md:items-center md:justify-between">
        <div>
          <h1 className="text-2xl font-bold text-gray-900">
            Xử lý báo cáo người dùng
          </h1>
          <p className="text-sm text-gray-500">
            Kiểm tra khiếu nại đặt sân và phản hồi các báo cáo hệ thống từ người dùng.
          </p>
        </div>

        <div className="grid grid-cols-3 gap-3 md:min-w-[360px]">
          <div className="rounded-xl border border-gray-100 bg-white p-3 shadow-sm">
            <p className="text-[10px] font-black uppercase tracking-widest text-gray-400">
              Đặt sân
            </p>
            <p className="mt-1 text-xl font-black text-gray-900">
              {bookingReportsQuery.data?.totalItems ?? 0}
            </p>
          </div>
          <div className="rounded-xl border border-gray-100 bg-white p-3 shadow-sm">
            <p className="text-[10px] font-black uppercase tracking-widest text-gray-400">
              Hệ thống
            </p>
            <p className="mt-1 text-xl font-black text-gray-900">
              {systemReportsQuery.data?.totalItems ?? 0}
            </p>
          </div>
          <div className="rounded-xl border border-emerald-100 bg-emerald-50 p-3 shadow-sm">
            <p className="text-[10px] font-black uppercase tracking-widest text-emerald-600">
              Đang xem
            </p>
            <p className="mt-1 text-xl font-black text-emerald-700">
              {activeTab === "booking" ? bookingReports.length : systemReports.length}
            </p>
          </div>
        </div>
      </div>

      <div className="flex flex-col gap-4 rounded-xl border border-gray-100 bg-white p-4 shadow-sm md:flex-row">
        <div className="relative flex-1">
          <Search
            className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400"
            size={18}
          />
          <Input
            placeholder="Tìm theo nội dung, mã báo cáo, mã đơn..."
            className="h-11 border-gray-200 pl-10 focus:ring-emerald-500/20"
            value={search}
            onChange={(event) => setSearch(event.target.value)}
          />
        </div>

        <div className="flex flex-wrap gap-2">
          {STATUS_OPTIONS.map((option) => (
            <Button
              key={option.value}
              type="button"
              variant={status === option.value ? "default" : "outline"}
              onClick={() => setStatus(option.value)}
              className={cn(
                "h-11 rounded-lg px-4 text-xs font-bold",
                status === option.value
                  ? "bg-[#00897B] text-white hover:bg-[#00796B]"
                  : "border-gray-200 text-gray-500 hover:bg-gray-50",
              )}
            >
              {option.label}
            </Button>
          ))}
          <Button
            type="button"
            variant="outline"
            onClick={clearFilters}
            className="h-11 rounded-lg border-gray-200 px-4 text-xs font-bold text-gray-500"
          >
            <X size={14} />
            Làm mới
          </Button>
        </div>
      </div>

      <Tabs
        value={activeTab}
        onValueChange={(value) => setActiveTab(value as ReportTab)}
        className="space-y-4"
      >
        <TabsList className="rounded-xl border border-gray-200/70 bg-white p-1 shadow-sm">
          <TabsTrigger
            value="booking"
            className="rounded-lg px-5 py-2.5 text-xs font-bold data-[state=active]:bg-emerald-50 data-[state=active]:text-[#00897B]"
          >
            <AlertTriangle size={15} className="mr-2" />
            Khiếu nại đặt sân
          </TabsTrigger>
          <TabsTrigger
            value="system"
            className="rounded-lg px-5 py-2.5 text-xs font-bold data-[state=active]:bg-emerald-50 data-[state=active]:text-[#00897B]"
          >
            <MessageSquare size={15} className="mr-2" />
            Báo cáo hệ thống
          </TabsTrigger>
        </TabsList>

        <TabsContent value="booking">
          <div className="overflow-hidden rounded-xl border border-gray-100 bg-white shadow-sm">
            {bookingReportsQuery.isLoading ? (
              <div className="flex flex-col items-center justify-center gap-4 py-20">
                <Loader2 className="animate-spin text-emerald-600" size={40} />
                <p className="text-sm font-medium text-gray-400">
                  Đang tải báo cáo đặt sân...
                </p>
              </div>
            ) : bookingReports.length > 0 ? (
              <Table>
                <TableHeader className="bg-gray-50/60">
                  <TableRow className="hover:bg-transparent">
                    <TableHead className="w-[42%] text-xs font-bold uppercase tracking-wider text-gray-400">
                      Nội dung
                    </TableHead>
                    <TableHead className="text-xs font-bold uppercase tracking-wider text-gray-400">
                      Mã liên quan
                    </TableHead>
                    <TableHead className="text-xs font-bold uppercase tracking-wider text-gray-400">
                      Trạng thái
                    </TableHead>
                    <TableHead className="text-right text-xs font-bold uppercase tracking-wider text-gray-400">
                      Thao tác
                    </TableHead>
                  </TableRow>
                </TableHeader>
                <TableBody>
                  {bookingReports.map((report) => (
                    <TableRow
                      key={report.reportBookingId}
                      className="border-b border-gray-50 transition-colors hover:bg-gray-50/50 last:border-0"
                    >
                      <TableCell>
                        <div className="space-y-1">
                          <p className="text-sm font-semibold leading-6 text-gray-800">
                            {report.reason}
                          </p>
                          <p className="text-[11px] font-mono text-gray-400">
                            #{report.reportBookingId}
                          </p>
                        </div>
                      </TableCell>
                      <TableCell>
                        <div className="space-y-1 text-xs">
                          <p className="font-semibold text-gray-700">
                            Booking: {report.bookingId.slice(0, 8)}
                          </p>
                          <p className="text-gray-400">
                            Court: {report.courtId.slice(0, 8)}
                          </p>
                          <p className="text-gray-400">
                            Customer: {report.customerId.slice(0, 8)}
                          </p>
                        </div>
                      </TableCell>
                      <TableCell>{renderStatusBadge(report.status)}</TableCell>
                      <TableCell className="text-right">
                        {report.status === "Pending" ? (
                          <Button
                            size="sm"
                            onClick={() => openConfirmDialog(report, "booking")}
                            className="h-8 rounded-lg bg-emerald-600 px-3 text-xs font-bold text-white hover:bg-emerald-700"
                          >
                            <ShieldCheck size={14} />
                            Xử lý
                          </Button>
                        ) : (
                          <span className="text-xs font-medium uppercase tracking-wider text-gray-300">
                            ---
                          </span>
                        )}
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            ) : (
              renderEmptyState()
            )}
          </div>
        </TabsContent>

        <TabsContent value="system">
          <div className="overflow-hidden rounded-xl border border-gray-100 bg-white shadow-sm">
            {systemReportsQuery.isLoading ? (
              <div className="flex flex-col items-center justify-center gap-4 py-20">
                <Loader2 className="animate-spin text-emerald-600" size={40} />
                <p className="text-sm font-medium text-gray-400">
                  Đang tải báo cáo hệ thống...
                </p>
              </div>
            ) : systemReports.length > 0 ? (
              <Table>
                <TableHeader className="bg-gray-50/60">
                  <TableRow className="hover:bg-transparent">
                    <TableHead className="w-[34%] text-xs font-bold uppercase tracking-wider text-gray-400">
                      Tiêu đề
                    </TableHead>
                    <TableHead className="text-xs font-bold uppercase tracking-wider text-gray-400">
                      Nội dung
                    </TableHead>
                    <TableHead className="text-xs font-bold uppercase tracking-wider text-gray-400">
                      Trạng thái
                    </TableHead>
                    <TableHead className="text-right text-xs font-bold uppercase tracking-wider text-gray-400">
                      Thao tác
                    </TableHead>
                  </TableRow>
                </TableHeader>
                <TableBody>
                  {systemReports.map((report) => (
                    <TableRow
                      key={report.id}
                      className="border-b border-gray-50 transition-colors hover:bg-gray-50/50 last:border-0"
                    >
                      <TableCell>
                        <div className="space-y-1">
                          <p className="text-sm font-bold text-gray-900">
                            {report.title}
                          </p>
                          <p className="text-[11px] font-mono text-gray-400">
                            #{report.id}
                          </p>
                        </div>
                      </TableCell>
                      <TableCell>
                        <p className="max-w-xl text-sm font-medium leading-6 text-gray-600">
                          {report.reason}
                        </p>
                      </TableCell>
                      <TableCell>{renderStatusBadge(report.status)}</TableCell>
                      <TableCell className="text-right">
                        {report.status === "Pending" ? (
                          <Button
                            size="sm"
                            onClick={() => openConfirmDialog(report, "system")}
                            className="h-8 rounded-lg bg-emerald-600 px-3 text-xs font-bold text-white hover:bg-emerald-700"
                          >
                            <ShieldCheck size={14} />
                            Phản hồi
                          </Button>
                        ) : (
                          <span className="text-xs font-medium uppercase tracking-wider text-gray-300">
                            ---
                          </span>
                        )}
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            ) : (
              renderEmptyState()
            )}
          </div>
        </TabsContent>
      </Tabs>

      {currentData && currentTotalPages > 1 && (
        <div className="rounded-xl border border-gray-100 bg-white p-4 shadow-sm">
          <DataTablePagination
            pageIndex={pageIndex}
            totalPages={currentTotalPages}
            onPageChange={setPageIndex}
          />
        </div>
      )}

      <AlertDialog
        open={!!confirmTarget}
        onOpenChange={(open) => !open && setConfirmTarget(null)}
      >
        <AlertDialogContent className="rounded-3xl border-none p-8 shadow-2xl">
          <div className="flex flex-col items-center space-y-4 text-center">
            <div className="flex h-16 w-16 items-center justify-center rounded-full bg-emerald-50 text-emerald-500">
              <ShieldCheck className="h-10 w-10" />
            </div>
            <AlertDialogHeader>
              <AlertDialogTitle className="text-2xl font-black tracking-tight text-slate-900">
                Xác nhận xử lý báo cáo
              </AlertDialogTitle>
              <AlertDialogDescription className="font-medium text-slate-500">
                Báo cáo "{confirmTarget?.title}" sẽ được đánh dấu là đã xử lý và
                người gửi sẽ nhận được thông báo phản hồi.
              </AlertDialogDescription>
            </AlertDialogHeader>
          </div>
          <AlertDialogFooter className="gap-3 pt-6 sm:justify-center">
            <AlertDialogCancel
              className="h-12 flex-1 rounded-xl border-slate-200 font-black text-slate-500"
              disabled={isConfirming}
            >
              Kiểm tra lại
            </AlertDialogCancel>
            <AlertDialogAction
              onClick={handleConfirm}
              className="h-12 flex-1 rounded-xl bg-emerald-600 font-black text-white shadow-lg shadow-emerald-100 hover:bg-emerald-700"
              disabled={isConfirming}
            >
              {isConfirming ? "Đang xử lý..." : "Xác nhận"}
            </AlertDialogAction>
          </AlertDialogFooter>
        </AlertDialogContent>
      </AlertDialog>
    </div>
  );
}
