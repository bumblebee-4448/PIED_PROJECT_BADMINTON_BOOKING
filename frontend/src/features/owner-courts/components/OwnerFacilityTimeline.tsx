import { useState, useEffect } from "react";
import { useQueries } from "@tanstack/react-query";
import { ownerCourtService } from "../services";
import { 
  Calendar as CalendarIcon,
  ChevronLeft,
  ChevronRight,
  Info,
  Plus,
  Loader2,
  Lock as LockIcon,
  Check as CheckIcon
} from "lucide-react";
import { useBookingDetail } from "../hooks/useOwnerSlots";
import { useUpdateSubCourtInfo } from "../hooks/useOwnerSubCourts";
import { Button } from "@/shared/components/ui/button";
import { 
  Dialog, 
  DialogContent, 
  DialogHeader, 
  DialogTitle,
  DialogTrigger,
  DialogFooter
} from "@/shared/components/ui/dialog";
import { Input } from "@/shared/components/ui/input";
import { Label } from "@/shared/components/ui/label";
import { Checkbox } from "@/shared/components/ui/checkbox";
import { Textarea } from "@/shared/components/ui/textarea";
import { cn } from "@/lib/utils";
import { format, addDays, subDays } from "date-fns";
import { vi } from "date-fns/locale";
import { toast } from "sonner";
import { useCreateOverrideSlot, useCreateExceptionSlot } from "../hooks/useOwnerSlots";
import type { SubCourtListItem } from "../types";
import { SlotActionModal } from "./SlotActionModal";
import { CourtScheduleGrid } from "@/shared/components/CourtScheduleGrid";
import { BookedSlotTooltip } from "./BookedSlotTooltip";

const DAYS_OF_WEEK = [
  { value: 1, label: "Thứ Hai" },
  { value: 2, label: "Thứ Ba" },
  { value: 3, label: "Thứ Tư" },
  { value: 4, label: "Thứ Năm" },
  { value: 5, label: "Thứ Sáu" },
  { value: 6, label: "Thứ Bảy" },
  { value: 0, label: "Chủ Nhật" },
];



function BookingDetailModal({ 
  bookingDetailId, 
  isOpen, 
  onOpenChange 
}: { 
  bookingDetailId: string | null; 
  isOpen: boolean; 
  onOpenChange: (open: boolean) => void;
}) {
  const { data: detail, isLoading } = useBookingDetail(bookingDetailId || "");

  return (
    <Dialog open={isOpen} onOpenChange={onOpenChange}>
      <DialogContent className="sm:max-w-[420px] rounded-2xl p-0 overflow-hidden">
        <DialogHeader className="p-6 pb-2">
          <DialogTitle className="text-lg font-bold text-gray-900">Chi tiết lượt đặt sân</DialogTitle>
        </DialogHeader>

        <div className="px-6 pb-8 space-y-5">
          {isLoading ? (
            <div className="py-10 flex flex-col items-center gap-3">
              <Loader2 className="animate-spin text-emerald-500" size={24} />
              <p className="text-sm text-gray-500">Đang tải thông tin...</p>
            </div>
          ) : detail ? (
            <div className="space-y-4">
              <div className="flex items-center gap-3 p-4 bg-emerald-50/50 rounded-xl border border-emerald-100/50">
                <div className="w-10 h-10 rounded-full bg-emerald-100 flex items-center justify-center text-emerald-700 font-bold">
                  {detail.name?.charAt(0).toUpperCase()}
                </div>
                <div>
                  <p className="text-xs text-emerald-600 font-medium">Khách hàng</p>
                  <p className="text-base font-bold text-gray-900">{detail.name}</p>
                </div>
              </div>

              <div className="grid grid-cols-1 gap-4">
                <div className="space-y-1">
                  <p className="text-xs font-medium text-gray-400">Số điện thoại</p>
                  <p className="text-sm font-semibold text-gray-700">{detail.phoneNumber || "Chưa cung cấp"}</p>
                </div>
                <div className="space-y-1">
                  <p className="text-xs font-medium text-gray-400">Email</p>
                  <p className="text-sm font-semibold text-gray-700">{detail.gmail}</p>
                </div>
              </div>

              <div className="pt-4 border-t border-gray-100">
                <div className="flex items-center justify-between p-3 bg-gray-50 rounded-xl">
                  <div className="space-y-0.5">
                    <p className="text-[10px] font-medium text-gray-400">Sân con</p>
                    <p className="text-sm font-bold text-gray-800">{detail.subCourtName}</p>
                  </div>
                  <div className="text-right space-y-0.5">
                    <p className="text-[10px] font-medium text-gray-400">Khung giờ</p>
                    <p className="text-sm font-bold text-emerald-600">
                      {detail.startTime.substring(0, 5)} - {detail.endTime.substring(0, 5)}
                    </p>
                  </div>
                </div>
              </div>
            </div>
          ) : (
            <div className="py-10 text-center text-gray-400 text-sm">
              Không tìm thấy thông tin chi tiết.
            </div>
          )}

          <Button 
            className="w-full h-11 bg-emerald-600 hover:bg-emerald-700 text-white rounded-xl font-bold shadow-sm"
            onClick={() => onOpenChange(false)}
          >
            Đóng
          </Button>
        </div>
      </DialogContent>
    </Dialog>
  );
}


function UpdateSubCourtModal({
  subCourt,
  isOpen,
  onOpenChange
}: {
  subCourt: SubCourtListItem | null;
  isOpen: boolean;
  onOpenChange: (open: boolean) => void;
}) {
  const updateMutation = useUpdateSubCourtInfo();
  const [name, setName] = useState(subCourt?.name || "");

  useEffect(() => {
    if (subCourt) setName(subCourt.name);
  }, [subCourt]);

  if (!subCourt) return null;

  const handleUpdate = async () => {
    if (!name) return;
    try {
      await updateMutation.mutateAsync({
        subCourtId: subCourt.subCourtId,
        name: name
      });
      onOpenChange(false);
    } catch (error) {}
  };

  return (
    <Dialog open={isOpen} onOpenChange={onOpenChange}>
      <DialogContent className="sm:max-w-[400px] rounded-3xl p-6">
        <DialogHeader>
          <DialogTitle className="text-xl font-bold">Cập nhật sân con</DialogTitle>
        </DialogHeader>
        <div className="space-y-4 py-4">
          <div className="space-y-2">
            <Label className="text-xs font-bold text-gray-500">Tên sân con</Label>
            <Input 
              value={name} 
              onChange={(e) => setName(e.target.value)}
              className="rounded-xl h-12 font-bold"
            />
          </div>
        </div>
        <DialogFooter>
          <Button variant="ghost" onClick={() => onOpenChange(false)} className="rounded-xl font-bold text-gray-500">Hủy</Button>
          <Button onClick={handleUpdate} disabled={updateMutation.isPending} className="bg-emerald-600 hover:bg-emerald-700 text-white rounded-xl px-8 font-bold">
            {updateMutation.isPending ? <Loader2 className="animate-spin" size={20} /> : "Cập nhật"}
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}

export function OwnerFacilityTimeline({ subCourts, courtName }: { subCourts: SubCourtListItem[]; courtName: string; }) {
  const [selectedDate, setSelectedDate] = useState(new Date());
  const dateStr = format(selectedDate, "yyyy-MM-dd");

  const todayStr = format(new Date(), "yyyy-MM-dd");
  const [selectedSubCourtIds, setSelectedSubCourtIds] = useState<string[]>([]);
  const [isMergeModalOpen, setIsMergeModalOpen] = useState(false);
  const [isBlockModalOpen, setIsBlockModalOpen] = useState(false);
  const [modalDate, setModalDate] = useState(dateStr);
  const [isRecurring, setIsRecurring] = useState(false);
  const [selectedDays, setSelectedDays] = useState<number[]>([]);
  const [startTime, setStartTime] = useState("08:00");
  const [endTime, setEndTime] = useState("12:00");
  const [price, setPrice] = useState("");
  const [blockReason, setBlockReason] = useState("");
  const [isBlockRecurring, setIsBlockRecurring] = useState(false);
  const [selectedBlockDays, setSelectedBlockDays] = useState<number[]>([]);

  const formatVND = (val: string) => {
    const num = val.replace(/\D/g, "");
    if (!num) return "";
    return parseInt(num).toLocaleString("vi-VN");
  };

  const handlePriceChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setPrice(formatVND(e.target.value));
  };

  const [selectedBookingDetailId, setSelectedBookingDetailId] = useState<string | null>(null);
  const [isDetailModalOpen, setIsDetailModalOpen] = useState(false);

  const createOverrideMutation = useCreateOverrideSlot();
  const createExceptionMutation = useCreateExceptionSlot();

  const [selectedSlotForAction, setSelectedSlotForAction] = useState<any>(null);
  const [isActionModalOpen, setIsActionModalOpen] = useState(false);

  const [subCourtToEdit] = useState<SubCourtListItem | null>(null);
  const [isUpdateSubCourtOpen, setIsUpdateSubCourtOpen] = useState(false);

  const subCourtQueries = useQueries({
    queries: subCourts.map((sub) => ({
      queryKey: ["available-slots", { subCourtId: sub.subCourtId, date: dateStr }],
      queryFn: () => ownerCourtService.getAvailableSlots({ subCourtId: sub.subCourtId, date: dateStr }),
      enabled: !!sub.subCourtId && !!dateStr,
    })),
  });

  const isLoading = subCourtQueries.some(q => q.isLoading);

  const handleMergeSlots = async () => {
    if (selectedSubCourtIds.length === 0 || !startTime || !endTime || !price) {
      toast.error("Vui lòng nhập đầy đủ thông tin");
      return;
    }

    const payloadBase = {
      isRecurring,
      startTime: startTime + ":00",
      endTime: endTime + ":00",
      price: Number(price.replace(/\./g, "")),
    };

    try {
      const promises: Promise<any>[] = [];
      
      for (const subCourtId of selectedSubCourtIds) {
        if (isRecurring) {
          if (selectedDays.length === 0) {
            toast.error("Vui lòng chọn ít nhất một thứ trong tuần");
            return;
          }
          for (const day of selectedDays) {
            promises.push(createOverrideMutation.mutateAsync({ ...payloadBase, subCourtId, dayOfWeek: day }));
          }
        } else {
          promises.push(createOverrideMutation.mutateAsync({ ...payloadBase, subCourtId, date: modalDate }));
        }
      }
      
      await Promise.all(promises);
      toast.success(`Đã gộp slot thành công cho ${selectedSubCourtIds.length} sân`);
      setIsMergeModalOpen(false);
      setSelectedSubCourtIds([]);
      setPrice("");
      setSelectedDays([]);
    } catch (error) {
      toast.error("Có lỗi xảy ra khi gộp slot");
    }
  };

  const handleBlockSlots = async () => {
    if (selectedSubCourtIds.length === 0 || !startTime || !endTime || !blockReason) {
      toast.error("Vui lòng nhập đầy đủ thông tin khóa sân");
      return;
    }

    const payloadBase = {
      isRecurring: isBlockRecurring,
      startTime: startTime + ":00",
      endTime: endTime + ":00",
      reason: blockReason,
    };

    try {
      const promises: Promise<any>[] = [];

      for (const subCourtId of selectedSubCourtIds) {
        if (isBlockRecurring) {
          if (selectedBlockDays.length === 0) {
            toast.error("Vui lòng chọn ít nhất một thứ trong tuần");
            return;
          }
          for (const day of selectedBlockDays) {
            promises.push(createExceptionMutation.mutateAsync({
              ...payloadBase,
              subCourtId,
              dayOfWeek: day,
            }));
          }
        } else {
          promises.push(createExceptionMutation.mutateAsync({
            ...payloadBase,
            subCourtId,
            date: modalDate,
          }));
        }
      }

      await Promise.all(promises);
      toast.success(`Đã khóa slot thành công cho ${selectedSubCourtIds.length} sân`);
      setIsBlockModalOpen(false);
      setSelectedSubCourtIds([]);
      setBlockReason("");
      setSelectedBlockDays([]);
    } catch (error) {
      toast.error("Có lỗi xảy ra khi khóa slot");
    }
  };

  const toggleDay = (day: number) => {
    setSelectedDays(prev => 
      prev.includes(day) ? prev.filter(d => d !== day) : [...prev, day]
    );
  };

  const toggleBlockDay = (day: number) => {
    setSelectedBlockDays(prev => 
      prev.includes(day) ? prev.filter(d => d !== day) : [...prev, day]
    );
  };

  const handlePrevDay = () => setSelectedDate(prev => subDays(prev, 1));
  const handleNextDay = () => setSelectedDate(prev => addDays(prev, 1));

  return (
    <>
    <div className="bg-white rounded-xl border border-gray-100 shadow-sm overflow-hidden flex flex-col flex-1">
      <div className="px-6 py-3 flex flex-wrap items-center justify-between gap-4 bg-white sticky top-0 z-[5]">
        <div className="flex items-center gap-3">
          <div className="bg-emerald-50 p-2 rounded-xl text-emerald-600">
            <CalendarIcon size={18} />
          </div>
          <div>
            <h2 className="text-sm font-bold text-gray-900">{courtName} - Lịch tổng quan</h2>
            <p className="text-[10px] text-gray-400 font-medium">
              {format(selectedDate, "EEEE, dd 'tháng' MM, yyyy", { locale: vi })}
            </p>
          </div>
        </div>

        <div className="flex items-center gap-2">
          <Dialog open={isMergeModalOpen} onOpenChange={setIsMergeModalOpen}>
            <DialogTrigger asChild>
              <Button size="sm" className="bg-emerald-600 hover:bg-emerald-700 text-white rounded-lg h-9 px-4 font-bold shadow-sm">
                <Plus size={16} className="mr-2" />
                Gộp slot
              </Button>
            </DialogTrigger>
            <DialogContent className="sm:max-w-[450px] rounded-2xl p-0 overflow-hidden border-none shadow-2xl">
              <div className="bg-emerald-600 p-6 text-white">
                <DialogHeader>
                  <DialogTitle className="text-xl font-bold">Gộp Slot Mới</DialogTitle>
                </DialogHeader>
                <p className="text-emerald-100 text-xs mt-1 font-medium">Tạo khung giờ cố định cho các sân được chọn</p>
              </div>

              <div className="p-5 space-y-4 max-h-[calc(90vh-180px)] overflow-y-auto custom-scrollbar">
                <div className="space-y-3">
                  <Label className="text-xs font-semibold text-gray-400">Chọn sân áp dụng</Label>
                  <div className="grid grid-cols-2 gap-2 p-3 bg-gray-50 rounded-xl border border-gray-100 max-h-40 overflow-y-auto">
                    {subCourts.map(sc => (
                      <div 
                        key={sc.subCourtId} 
                        onClick={() => {
                          setSelectedSubCourtIds(prev => 
                            prev.includes(sc.subCourtId) ? prev.filter(id => id !== sc.subCourtId) : [...prev, sc.subCourtId]
                          );
                        }}
                        className={cn(
                          "flex items-center gap-2 p-2 rounded-lg cursor-pointer transition-all border",
                          selectedSubCourtIds.includes(sc.subCourtId) 
                            ? "bg-emerald-50 border-emerald-200 text-emerald-700" 
                            : "bg-white border-transparent text-gray-600 hover:bg-gray-100"
                        )}
                      >
                        <div className={cn(
                          "w-4 h-4 rounded border flex items-center justify-center transition-all",
                          selectedSubCourtIds.includes(sc.subCourtId) ? "bg-emerald-500 border-emerald-500" : "border-gray-300"
                        )}>
                          {selectedSubCourtIds.includes(sc.subCourtId) && <CheckIcon size={10} className="text-white" />}
                        </div>
                        <span className="text-xs font-bold">{sc.name}</span>
                      </div>
                    ))}
                  </div>
                </div>

                <div className="flex items-center space-x-3 bg-gray-50 p-4 rounded-xl border border-gray-100">
                  <Checkbox 
                    id="recurring" 
                    checked={isRecurring}
                    onCheckedChange={(checked) => setIsRecurring(!!checked)}
                    className="border-emerald-200 data-[state=checked]:bg-emerald-600"
                  />
                  <Label htmlFor="recurring" className="text-sm font-bold text-gray-700 cursor-pointer">
                    Lặp lại hàng tuần
                  </Label>
                </div>

                {isRecurring ? (
                  <div className="space-y-3">
                    <Label className="text-xs font-semibold text-gray-400">Chọn thứ trong tuần</Label>
                    <div className="grid grid-cols-2 gap-2">
                      {DAYS_OF_WEEK.map((day) => (
                        <div 
                          key={day.value}
                          onClick={() => toggleDay(day.value)}
                          className={cn(
                            "flex items-center gap-3 p-3 rounded-xl border transition-all cursor-pointer",
                            selectedDays.includes(day.value) ? "bg-emerald-50 border-emerald-200" : "bg-white border-gray-100 hover:border-gray-200"
                          )}
                        >
                          <Checkbox checked={selectedDays.includes(day.value)} className="pointer-events-none" />
                          <span className={cn("text-xs font-bold", selectedDays.includes(day.value) ? "text-emerald-700" : "text-gray-600")}>
                            {day.label}
                          </span>
                        </div>
                      ))}
                    </div>
                  </div>
                ) : (
                  <div className="space-y-2">
                    <Label className="text-xs font-semibold text-gray-400">Ngày áp dụng</Label>
                    <Input 
                      type="date" 
                      value={modalDate} 
                      min={todayStr}
                      onChange={(e) => setModalDate(e.target.value)}
                      className="h-12 rounded-xl bg-gray-50 border-gray-100 font-bold" 
                    />
                  </div>
                )}

                <div className="grid grid-cols-2 gap-4">
                  <div className="space-y-2">
                    <Label className="text-xs font-semibold text-gray-400">Bắt đầu</Label>
                    <Input type="time" value={startTime} onChange={(e) => setStartTime(e.target.value)} className="h-12 rounded-xl bg-gray-50 border-gray-100 font-bold" />
                  </div>
                  <div className="space-y-2">
                    <Label className="text-xs font-semibold text-gray-400">Kết thúc</Label>
                    <Input type="time" value={endTime} onChange={(e) => setEndTime(e.target.value)} className="h-12 rounded-xl bg-gray-50 border-gray-100 font-bold" />
                  </div>
                </div>

                <div className="space-y-2">
                  <Label className="text-xs font-semibold text-gray-400">Giá tiền (VNĐ)</Label>
                  <Input 
                    type="text" 
                    placeholder="Ví dụ: 100.000" 
                    value={price} 
                    onChange={handlePriceChange} 
                    className="h-12 rounded-xl bg-gray-50 border-gray-100 font-bold" 
                  />
                </div>
              </div>

              <DialogFooter className="p-5 bg-gray-50 border-t border-gray-100 flex-shrink-0">
                <Button variant="ghost" onClick={() => setIsMergeModalOpen(false)} className="rounded-xl font-bold text-gray-500">Hủy</Button>
                <Button onClick={handleMergeSlots} disabled={createOverrideMutation.isPending} className="bg-emerald-600 hover:bg-emerald-700 text-white rounded-xl px-8 font-bold">
                  {createOverrideMutation.isPending ? <Loader2 className="animate-spin" size={20} /> : "Xác nhận"}
                </Button>
              </DialogFooter>
            </DialogContent>
          </Dialog>

          <Dialog open={isBlockModalOpen} onOpenChange={setIsBlockModalOpen}>
            <DialogTrigger asChild>
              <Button variant="outline" size="sm" className="text-rose-600 border-rose-100 hover:bg-rose-50 rounded-lg h-9 px-4 font-bold shadow-sm">
                <LockIcon size={16} className="mr-2" />
                Khóa slot
              </Button>
            </DialogTrigger>
            <DialogContent className="sm:max-w-[450px] rounded-2xl p-0 overflow-hidden border-none shadow-2xl">
              <div className="bg-rose-600 p-6 text-white">
                <DialogHeader>
                  <DialogTitle className="text-xl font-bold">Khóa Slot Sân</DialogTitle>
                </DialogHeader>
                <p className="text-rose-100 text-xs mt-1 font-medium">Chặn đặt sân cho khoảng thời gian cụ thể</p>
              </div>

              <div className="p-5 space-y-4 max-h-[calc(90vh-180px)] overflow-y-auto custom-scrollbar">
                <div className="space-y-3">
                  <Label className="text-xs font-semibold text-gray-400">Chọn sân áp dụng</Label>
                  <div className="grid grid-cols-2 gap-2 p-3 bg-gray-50 rounded-xl border border-gray-100 max-h-40 overflow-y-auto">
                    {subCourts.map(sc => (
                      <div 
                        key={sc.subCourtId} 
                        onClick={() => {
                          setSelectedSubCourtIds(prev => 
                            prev.includes(sc.subCourtId) ? prev.filter(id => id !== sc.subCourtId) : [...prev, sc.subCourtId]
                          );
                        }}
                        className={cn(
                          "flex items-center gap-2 p-2 rounded-lg cursor-pointer transition-all border",
                          selectedSubCourtIds.includes(sc.subCourtId) 
                            ? "bg-rose-50 border-rose-200 text-rose-700" 
                            : "bg-white border-transparent text-gray-600 hover:bg-gray-100"
                        )}
                      >
                        <div className={cn(
                          "w-4 h-4 rounded border flex items-center justify-center transition-all",
                          selectedSubCourtIds.includes(sc.subCourtId) ? "bg-rose-500 border-rose-500" : "border-gray-300"
                        )}>
                          {selectedSubCourtIds.includes(sc.subCourtId) && <CheckIcon size={10} className="text-white" />}
                        </div>
                        <span className="text-xs font-bold">{sc.name}</span>
                      </div>
                    ))}
                  </div>
                </div>

                <div className="flex items-center space-x-3 bg-gray-50 p-4 rounded-xl border border-gray-100">
                  <Checkbox 
                    id="blockRecurring" 
                    checked={isBlockRecurring}
                    onCheckedChange={(checked) => setIsBlockRecurring(!!checked)}
                    className="border-rose-200 data-[state=checked]:bg-rose-600 data-[state=checked]:border-rose-600"
                  />
                  <Label htmlFor="blockRecurring" className="text-sm font-bold text-gray-700 cursor-pointer">
                    Lặp lại hàng tuần
                  </Label>
                </div>

                {isBlockRecurring ? (
                  <div className="space-y-3">
                    <Label className="text-xs font-semibold text-gray-400">Chọn thứ trong tuần</Label>
                    <div className="grid grid-cols-2 gap-2">
                      {DAYS_OF_WEEK.map((day) => (
                        <div 
                          key={day.value}
                          onClick={() => toggleBlockDay(day.value)}
                          className={cn(
                            "flex items-center gap-3 p-3 rounded-xl border transition-all cursor-pointer",
                            selectedBlockDays.includes(day.value) 
                              ? "bg-rose-50 border-rose-200" 
                              : "bg-white border-gray-100 hover:border-gray-200"
                          )}
                        >
                          <Checkbox 
                            checked={selectedBlockDays.includes(day.value)}
                            className="border-rose-200 data-[state=checked]:bg-rose-600 data-[state=checked]:border-rose-600 pointer-events-none"
                          />
                          <span className={cn(
                            "text-xs font-bold",
                            selectedBlockDays.includes(day.value) ? "text-rose-700" : "text-gray-600"
                          )}>
                            {day.label}
                          </span>
                        </div>
                      ))}
                    </div>
                  </div>
                ) : (
                  <div className="space-y-2">
                    <Label className="text-xs font-semibold text-gray-400">Ngày áp dụng</Label>
                    <Input 
                      type="date" 
                      value={modalDate} 
                      min={todayStr}
                      onChange={(e) => setModalDate(e.target.value)}
                      className="h-12 rounded-xl bg-gray-50 border-gray-100 font-bold" 
                    />
                  </div>
                )}

                <div className="grid grid-cols-2 gap-4">
                  <div className="space-y-2">
                    <Label className="text-xs font-semibold text-gray-400">Bắt đầu</Label>
                    <Input type="time" value={startTime} onChange={(e) => setStartTime(e.target.value)} className="h-12 rounded-xl bg-gray-50 border-gray-100 font-bold" />
                  </div>
                  <div className="space-y-2">
                    <Label className="text-xs font-semibold text-gray-400">Kết thúc</Label>
                    <Input type="time" value={endTime} onChange={(e) => setEndTime(e.target.value)} className="h-12 rounded-xl bg-gray-50 border-gray-100 font-bold" />
                  </div>
                </div>

                <div className="space-y-2">
                  <Label className="text-xs font-semibold text-gray-400">Lý do khóa</Label>
                  <Textarea placeholder="VD: Bảo trì định kỳ, Sự kiện địa phương..." value={blockReason} onChange={(e) => setBlockReason(e.target.value)} className="min-h-[100px] rounded-xl bg-gray-50 border-gray-100 font-bold resize-none" />
                </div>
              </div>

              <DialogFooter className="p-5 bg-gray-50 border-t border-gray-100 flex-shrink-0">
                <Button variant="ghost" onClick={() => setIsBlockModalOpen(false)} className="rounded-xl font-bold text-gray-500">Hủy</Button>
                <Button onClick={handleBlockSlots} disabled={createExceptionMutation.isPending} className="bg-rose-600 hover:bg-rose-700 text-white rounded-xl px-8 font-bold shadow-lg shadow-rose-600/20">
                  {createExceptionMutation.isPending ? <Loader2 className="animate-spin" size={20} /> : "Xác nhận khóa"}
                </Button>
              </DialogFooter>
            </DialogContent>
          </Dialog>

        <div className="flex items-center bg-gray-50 rounded-lg p-0.5 border border-gray-200">
          <Button variant="ghost" size="icon" onClick={handlePrevDay} className="h-7 w-7 text-gray-500 hover:text-emerald-600">
            <ChevronLeft size={16} />
          </Button>
          <div className="px-3 text-[10px] font-bold min-w-[100px] text-center text-gray-500">
            {format(selectedDate, "dd/MM/yyyy")}
          </div>
          <Button variant="ghost" size="icon" onClick={handleNextDay} className="h-7 w-7 text-gray-500 hover:text-emerald-600">
            <ChevronRight size={16} />
          </Button>
        </div>
      </div>
    </div>

      <div className="relative px-6 py-2 bg-slate-50/10">
        <CourtScheduleGrid 
          subCourts={subCourts.map((sub, idx) => ({
            id: sub.subCourtId,
            name: sub.name,
            slots: (subCourtQueries[idx].data as any[]) || []
          }))}
          startTime="05:00"
          endTime="23:30"
          selectedDate={selectedDate}
          isLoading={isLoading}
          onSlotClick={(_subId, slot) => {
            if (slot.type === "Booked" && slot.bookingDetailId) {
              setSelectedBookingDetailId(slot.bookingDetailId);
              setIsDetailModalOpen(true);
            } else if (slot.type !== "Booked") {
              setSelectedSlotForAction(slot);
              setIsActionModalOpen(true);
            }
          }}
          renderCellExtra={(_subId, slot) => {
            if (slot.type === "Booked" && slot.bookingDetailId) {
              return <BookedSlotTooltip bookingDetailId={slot.bookingDetailId} />;
            }
            return (
              <div className="flex flex-col items-center gap-1 opacity-0 group-hover:opacity-100 transition-opacity absolute top-1 left-1">
                 {/* Nút sửa nhanh nếu cần */}
              </div>
            );
          }}
        />
      </div>

      {/* Footer Info */}
      <div className="p-3 border-t border-gray-50 bg-gray-50/50 flex items-center gap-4">
        <div className="flex items-center gap-2 text-[10px] text-gray-500">
          <Info size={14} className="text-emerald-600" />
          <span>Gợi ý: Rê chuột vào các ô màu để xem chi tiết lý do khóa hoặc thông tin đặt sân.</span>
        </div>
      </div>
      </div>

      <BookingDetailModal 
        bookingDetailId={selectedBookingDetailId}
        isOpen={isDetailModalOpen}
        onOpenChange={setIsDetailModalOpen}
      />

      <SlotActionModal 
        slot={selectedSlotForAction}
        isOpen={isActionModalOpen}
        onOpenChange={setIsActionModalOpen}
      />

      <UpdateSubCourtModal 
        subCourt={subCourtToEdit}
        isOpen={isUpdateSubCourtOpen}
        onOpenChange={setIsUpdateSubCourtOpen}
      />
    </>
  );
}
