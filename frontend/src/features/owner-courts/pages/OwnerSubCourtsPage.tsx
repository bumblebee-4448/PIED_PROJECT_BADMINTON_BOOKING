import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useOwnerCourts } from "../hooks/useOwnerCourts";
import {
  useOwnerSubCourts,
  useCreateSubCourt,
} from "../hooks/useOwnerSubCourts";

import { Input } from "@/shared/components/ui/input";
import { Button } from "@/shared/components/ui/button";
import { Label } from "@/shared/components/ui/label";
import {
  Loader2,
  Plus,
  Building2,
  ArrowLeft,
  ChevronRight,
} from "lucide-react";
import { useLocation } from "react-router-dom";
import { OwnerFacilityTimeline } from "../components/OwnerFacilityTimeline";
import { cn } from "@/lib/utils";

const COURT_STATUS_MAP: Record<string, string> = {
  active: "Hoạt động",
  pending: "Chờ duyệt",
  rejected: "Bị từ chối",
};

const COURT_DOT_COLOR_MAP: Record<string, string> = {
  active: "bg-emerald-500",
  pending: "bg-amber-500",
  rejected: "bg-rose-500",
};

export default function OwnerSubCourtsPage() {
  const navigate = useNavigate();
  const location = useLocation();
  const isScheduleMode = location.pathname.includes("/owner/schedules");
  const [view, setView] = useState<"list" | "create">("list");
  const [selectedCourtId, setSelectedCourtId] = useState<string>("");
  const [subCourtName, setSubCourtName] = useState("");
  const [defaultPrice, setDefaultPrice] = useState("");

  // Fetch all main courts
  const { data: courtsData, isLoading: isLoadingCourts } = useOwnerCourts({
    pageIndex: 1,
    pageSize: 100,
  });

  // Fetch sub-courts for selected court
  const { data: subCourtsData } = useOwnerSubCourts({
    courtId: selectedCourtId,
    pageIndex: 1,
    pageSize: 100,
  });

  const createSubCourtMutation = useCreateSubCourt();

  const handleCreate = async () => {
    if (!selectedCourtId || !subCourtName || !defaultPrice) return;

    createSubCourtMutation.mutate(
      {
        courtId: selectedCourtId,
        name: subCourtName,
        defaultPrice: Number(defaultPrice),
      },
      {
        onSuccess: () => {
          setSubCourtName("");
          setDefaultPrice("");
          setView("list");
        },
      },
    );
  };

  const selectedCourt = courtsData?.items.find(
    (c) => c.courtId === selectedCourtId,
  );

  return (
    <div className="p-6 max-w-7xl mx-auto space-y-6">
      {/* Page Header */}
      <div className="flex flex-col sm:flex-row sm:items-center justify-between gap-4">
        <div className="flex items-center gap-4">
          {selectedCourtId && (
            <Button
              variant="outline"
              size="icon"
              onClick={() => setSelectedCourtId("")}
              className="rounded-full h-10 w-10 border-gray-200 hover:bg-gray-50"
            >
              <ArrowLeft size={20} className="text-gray-600" />
            </Button>
          )}
          <div>
            <h1 className="text-2xl font-bold text-gray-900">
              {isScheduleMode
                ? "Quản lý lịch sân"
                : view === "list"
                  ? "Quản lý sân con"
                  : "Thêm sân con mới"}
            </h1>
            <p className="text-sm text-gray-500 mt-0.5">
              {!selectedCourtId
                ? "Chọn cơ sở bạn muốn quản lý"
                : isScheduleMode
                  ? `Lịch chi tiết cơ sở: ${selectedCourt?.name}`
                  : `Danh sách sân con: ${selectedCourt?.name}`}
            </p>
          </div>
        </div>

        <div className="flex items-center gap-3">
          {selectedCourtId &&
            !isScheduleMode &&
            (view === "list" ? (
              <Button
                className="bg-emerald-600 hover:bg-emerald-700 text-white rounded-xl px-5 h-10 font-bold"
                onClick={() => setView("create")}
              >
                <Plus className="mr-2" size={18} />
                Thêm sân con
              </Button>
            ) : (
              <Button
                variant="outline"
                className="rounded-xl h-10 px-5 font-bold"
                onClick={() => setView("list")}
              >
                <ArrowLeft className="mr-2" size={18} />
                Quay lại danh sách
              </Button>
            ))}
        </div>
      </div>

      {!selectedCourtId ? (
        /* STEP 1: SELECT COURT GRID */
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6 animate-in fade-in slide-in-from-bottom-4 duration-500">
          {isLoadingCourts ? (
            Array.from({ length: 3 }).map((_, i) => (
              <div
                key={i}
                className="bg-white rounded-2xl border border-gray-100 p-6 h-48 animate-pulse flex flex-col gap-4"
              >
                <div className="w-12 h-12 bg-gray-50 rounded-xl" />
                <div className="space-y-2">
                  <div className="h-4 bg-gray-50 rounded w-2/3" />
                  <div className="h-3 bg-gray-50 rounded w-full" />
                </div>
              </div>
            ))
          ) : courtsData?.items && courtsData.items.length > 0 ? (
            courtsData.items.map((court) => (
              <button
                key={court.courtId}
                onClick={() => setSelectedCourtId(court.courtId)}
                className="group relative bg-white rounded-2xl border border-gray-100 p-6 text-left hover:border-emerald-500 hover:shadow-xl hover:shadow-emerald-500/5 transition-all duration-300"
              >
                <div className="flex flex-col h-full">
                  <div className="mb-4">
                    <div className="w-14 h-14 bg-emerald-50 rounded-2xl flex items-center justify-center text-emerald-600 group-hover:bg-emerald-500 group-hover:text-white transition-colors duration-300">
                      <Building2 size={28} />
                    </div>
                  </div>
                  <div className="flex-1">
                    <h3 className="text-lg font-bold text-gray-900 mb-1 group-hover:text-emerald-700 transition-colors">
                      {court.name}
                    </h3>
                    <p className="text-xs text-gray-400 line-clamp-2 leading-relaxed">
                      {court.address}
                    </p>
                  </div>
                  <div className="mt-6 flex items-center justify-between">
                    <div className="flex items-center gap-2">
                      <div
                        className={cn(
                          "h-2 w-2 rounded-full",
                          COURT_DOT_COLOR_MAP[court.status.toLowerCase()] || "bg-slate-400",
                        )}
                      />
                      <span className="text-[10px] font-bold text-gray-500 uppercase tracking-wider">
                        {COURT_STATUS_MAP[court.status.toLowerCase()] || court.status}
                      </span>
                    </div>
                    <div className="h-8 w-8 rounded-full bg-gray-50 flex items-center justify-center text-gray-400 group-hover:bg-emerald-50 group-hover:text-emerald-600 transition-colors">
                      <ChevronRight size={18} />
                    </div>
                  </div>
                </div>
              </button>
            ))
          ) : (
            <div className="col-span-full py-20 flex flex-col items-center justify-center bg-white rounded-3xl border border-gray-100 border-dashed">
              <Building2 className="text-gray-100 mb-4" size={64} />
              <p className="text-gray-400 font-medium">
                Bạn chưa có cơ sở nào được đăng ký
              </p>
              <Button
                variant="link"
                className="text-emerald-600 mt-2"
                onClick={() => navigate("/owner/courts")}
              >
                Đi tới quản lý cơ sở
              </Button>
            </div>
          )}
        </div>
      ) : (
        /* STEP 2: SHOW FULL-WIDTH CONTENT */
        <div className="animate-in fade-in slide-in-from-bottom-2 duration-300">
          <div className="space-y-4">
            {view === "list" ? (
              <OwnerFacilityTimeline
                courtName={selectedCourt?.name || ""}
                subCourts={subCourtsData?.items || []}
              />
            ) : (
              /* CREATE VIEW */
              <div className="bg-white rounded-2xl border border-gray-100 shadow-sm p-10 max-w-4xl mx-auto space-y-10">
                <div className="space-y-2">
                  <h2 className="text-xl font-bold text-gray-900">
                    Thông tin sân con mới
                  </h2>
                  <p className="text-sm text-gray-400">
                    Vị trí:{" "}
                    <span className="text-emerald-600 font-semibold">
                      {selectedCourt?.name}
                    </span>
                  </p>
                </div>

                <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
                  <div className="space-y-3">
                    <Label className="text-xs font-bold text-gray-500 tracking-widest">
                      Tên sân con
                    </Label>
                    <Input
                      placeholder="VD: Sân 1, Sân A..."
                      className="h-12 rounded-xl border-gray-200 focus:ring-emerald-500/20 text-base"
                      value={subCourtName}
                      onChange={(e) => setSubCourtName(e.target.value)}
                    />
                  </div>
                  <div className="space-y-3">
                    <Label className="text-xs font-bold text-gray-500 tracking-widest">
                      Giá niêm yết (VNĐ/Giờ)
                    </Label>
                    <Input
                      type="text"
                      placeholder="VD: 150,000"
                      className="h-12 rounded-xl border-gray-200 focus:ring-emerald-500/20 text-base font-mono"
                      value={defaultPrice ? Number(defaultPrice).toLocaleString("en-US") : ""}
                      onChange={(e) => {
                        const rawValue = e.target.value.replace(/,/g, "");
                        if (/^\d*$/.test(rawValue)) {
                          setDefaultPrice(rawValue);
                        }
                      }}
                    />
                  </div>
                </div>

                <div className="pt-6 border-t border-gray-50">
                  <Button
                    className="w-full h-14 bg-emerald-600 hover:bg-emerald-700 text-white font-bold text-lg rounded-2xl shadow-xl shadow-emerald-600/20 transition-all hover:scale-[1.01] active:scale-[0.99]"
                    onClick={handleCreate}
                    disabled={
                      !subCourtName ||
                      !defaultPrice ||
                      createSubCourtMutation.isPending
                    }
                  >
                    {createSubCourtMutation.isPending ? (
                      <Loader2 className="animate-spin mr-3" size={24} />
                    ) : (
                      <Plus className="mr-3" size={24} />
                    )}
                    Xác nhận tạo sân con
                  </Button>
                </div>
              </div>
            )}
          </div>
        </div>
      )}
    </div>
  );
}
