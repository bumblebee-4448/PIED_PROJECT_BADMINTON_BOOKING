import { 
  AlertTriangle, 
  MessageSquare, 
  Clock, 
  CheckCircle2, 
  ChevronRight
} from "lucide-react";
import { cn } from "@/lib/utils";
import { useBookingReports, useSystemReports } from "../hooks/useReports";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/shared/components/ui/tabs";
import { Card, CardContent } from "@/shared/components/ui/card";
import { Badge } from "@/shared/components/ui/badge";
import { LoadingSpinner } from "@/shared/components/common/LoadingSpinner";
import { EmptyState } from "@/shared/components/common/EmptyState";
import type { ReportBookingResponse, ReportStatus, SystemReportResponse } from "../types";

type ReportListResponse<T> = T[] | { items?: T[] };

function getReportItems<T>(data: ReportListResponse<T> | undefined): T[] {
  return Array.isArray(data) ? data : data?.items ?? [];
}

export function ReportsPage() {
  const {
    data: bookingReportsData,
    isLoading: isLoadingBooking,
    isFetching: isFetchingBooking,
  } = useBookingReports({ pageIndex: 1, pageSize: 50 });
  const {
    data: systemReportsData,
    isLoading: isLoadingSystem,
    isFetching: isFetchingSystem,
  } = useSystemReports({ pageIndex: 1, pageSize: 50 });

  const bookingReports = getReportItems<ReportBookingResponse>(bookingReportsData);
  const systemReports = getReportItems<SystemReportResponse>(systemReportsData);
  const isSyncing =
    (isFetchingBooking && !isLoadingBooking) ||
    (isFetchingSystem && !isLoadingSystem);

  const getStatusConfig = (status: ReportStatus) => {
    switch (status) {
      case "Pending":
        return {
          label: "Đang xử lý",
          icon: <Clock size={12} />,
          className: "bg-amber-50 text-amber-600 border-amber-100",
        };
      case "Confirmed":
      case "Completed":
        return {
          label: "Đã xử lý",
          icon: <CheckCircle2 size={12} />,
          className: "bg-emerald-50 text-emerald-600 border-emerald-100",
        };
      default:
        return {
          label: status,
          icon: <Clock size={12} />,
          className: "bg-gray-50 text-gray-600 border-gray-100",
        };
    }
  };

  return (
    <div className="max-w-7xl mx-auto px-6 py-12">
      <div className="flex flex-col md:flex-row justify-between items-start md:items-center gap-6 mb-12">
        <div>
          <h1 className="text-4xl font-black text-gray-900 tracking-tight mb-2">
            Lịch sử báo cáo
          </h1>
          <p className="text-gray-500 font-medium">
            Theo dõi trạng thái và phản hồi các báo cáo của bạn
          </p>
        </div>
        <div className="min-h-8">
          {isSyncing && (
            <Badge className="rounded-full border border-emerald-100 bg-emerald-50 px-3 py-1.5 text-xs font-bold text-emerald-600 shadow-none">
              Đang đồng bộ phản hồi...
            </Badge>
          )}
        </div>
      </div>

      <Tabs defaultValue="booking" className="space-y-8">
        <TabsList className="bg-gray-100/50 p-1.5 rounded-2xl border border-gray-200/50">
          <TabsTrigger 
            value="booking" 
            className="rounded-xl px-8 py-2.5 font-bold data-[state=active]:bg-white data-[state=active]:shadow-sm data-[state=active]:text-[#00897B]"
          >
            <AlertTriangle size={16} className="mr-2" />
            Báo cáo đặt sân
          </TabsTrigger>
          <TabsTrigger 
            value="system" 
            className="rounded-xl px-8 py-2.5 font-bold data-[state=active]:bg-white data-[state=active]:shadow-sm data-[state=active]:text-[#00897B]"
          >
            <MessageSquare size={16} className="mr-2" />
            Báo cáo hệ thống
          </TabsTrigger>
        </TabsList>

        <TabsContent value="booking" className="space-y-4">
          {isLoadingBooking ? (
            <div className="py-20 flex justify-center">
              <LoadingSpinner />
            </div>
          ) : bookingReports.length === 0 ? (
            <EmptyState 
              title="Chưa có báo cáo nào" 
              description="Bạn chưa gửi báo cáo nào cho các đơn đặt sân."
            />
          ) : (
            <div className="grid gap-4">
              {bookingReports.map((report) => {
                const statusConfig = getStatusConfig(report.status);
                return (
                  <Card key={report.reportBookingId} className="group hover:shadow-md transition-all duration-300 border-gray-100 rounded-3xl overflow-hidden">
                    <CardContent className="p-6">
                      <div className="flex flex-col md:flex-row justify-between gap-6">
                        <div className="flex-1 space-y-3">
                          <div className="flex items-center gap-3">
                            <Badge className={cn("rounded-full px-3 py-1 font-bold border", statusConfig.className)}>
                              <span className="mr-1.5">{statusConfig.icon}</span>
                              {statusConfig.label}
                            </Badge>
                            <span className="text-xs text-gray-400 font-bold uppercase tracking-widest">
                              Mã đơn: {report.bookingId.substring(0, 8)}
                            </span>
                          </div>
                          <p className="text-gray-700 font-medium leading-relaxed">
                            {report.reason}
                          </p>
                        </div>
                        <div className="flex flex-col items-end justify-center min-w-[120px]">
                          <div className="p-2 rounded-2xl bg-gray-50 group-hover:bg-[#00897B]/10 transition-colors">
                            <ChevronRight className="text-gray-300 group-hover:text-[#00897B] transition-colors" />
                          </div>
                        </div>
                      </div>
                    </CardContent>
                  </Card>
                );
              })}
            </div>
          )}
        </TabsContent>

        <TabsContent value="system" className="space-y-4">
          {isLoadingSystem ? (
            <div className="py-20 flex justify-center">
              <LoadingSpinner />
            </div>
          ) : systemReports.length === 0 ? (
            <EmptyState 
              title="Chưa có báo cáo hệ thống" 
              description="Hệ thống đang hoạt động ổn định. Cảm ơn bạn!"
            />
          ) : (
            <div className="grid gap-4">
              {systemReports.map((report) => {
                const statusConfig = getStatusConfig(report.status);
                return (
                  <Card key={report.id} className="group hover:shadow-md transition-all duration-300 border-gray-100 rounded-3xl overflow-hidden">
                    <CardContent className="p-6">
                      <div className="flex flex-col md:flex-row justify-between gap-6">
                        <div className="flex-1 space-y-3">
                          <div className="flex items-center gap-3">
                            <Badge className={cn("rounded-full px-3 py-1 font-bold border", statusConfig.className)}>
                              <span className="mr-1.5">{statusConfig.icon}</span>
                              {statusConfig.label}
                            </Badge>
                          </div>
                          <h3 className="text-lg font-black text-gray-900 group-hover:text-[#00897B] transition-colors">
                            {report.title}
                          </h3>
                          <p className="text-gray-600 font-medium leading-relaxed">
                            {report.reason}
                          </p>
                        </div>
                        <div className="flex flex-col items-end justify-center min-w-[120px]">
                          <div className="p-2 rounded-2xl bg-gray-50 group-hover:bg-[#00897B]/10 transition-colors">
                            <ChevronRight className="text-gray-300 group-hover:text-[#00897B] transition-colors" />
                          </div>
                        </div>
                      </div>
                    </CardContent>
                  </Card>
                );
              })}
            </div>
          )}
        </TabsContent>
      </Tabs>
    </div>
  );
}
