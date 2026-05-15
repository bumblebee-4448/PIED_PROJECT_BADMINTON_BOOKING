import { useState } from "react";
import { useQueries } from "@tanstack/react-query";
import { ownerCourtService } from "../services";
import { 
  Calendar as CalendarIcon, 
  Clock, 
  ChevronLeft, 
  ChevronRight,
  Info,
  Plus,
  Loader2,
  Lock,
  CalendarCheck
} from "lucide-react";
import { useBookingDetail } from "../hooks/useOwnerSlots";
import { Button } from "@/shared/components/ui/button";
import { Badge } from "@/shared/components/ui/badge";
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
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/shared/components/ui/select";
import { cn } from "@/lib/utils";
import { format, addDays, subDays } from "date-fns";
import { vi } from "date-fns/locale";
import { toast } from "sonner";
import { useCreateOverrideSlot, useCreateExceptionSlot } from "../hooks/useOwnerSlots";
import type { SubCourtListItem } from "../types";

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
      <DialogContent className="sm:max-w-[400px] rounded-3xl p-0 overflow-hidden border-none shadow-2xl">
        <div className="bg-[#0B2421] p-6 text-white relative">
          <DialogHeader>
            <DialogTitle className="text-xl font-black">Thông tin người đặt</DialogTitle>
          </DialogHeader>
          <div className="absolute -bottom-6 right-6 w-12 h-12 bg-emerald-500 rounded-2xl flex items-center justify-center shadow-lg">
            <CalendarCheck size={24} className="text-white" />
          </div>
        </div>

        <div className="p-6 pt-10 space-y-6">
          {isLoading ? (
            <div className="py-12 flex flex-col items-center gap-3">
              <Loader2 className="animate-spin text-emerald-500" size={32} />
              <p className="text-xs font-bold text-gray-400 uppercase tracking-widest">Đang tải thông tin...</p>
            </div>
          ) : detail ? (
            <div className="space-y-4">
              <div className="flex items-center gap-4 p-4 bg-gray-50 rounded-2xl border border-gray-100">
                <div className="w-10 h-10 rounded-xl bg-white border border-gray-100 flex items-center justify-center text-lg font-black text-emerald-600">
                  {detail.name?.charAt(0).toUpperCase()}
                </div>
                <div>
                  <p className="text-[10px] font-black text-gray-400 uppercase tracking-widest">Khách hàng</p>
                  <p className="text-base font-black text-[#0B2421]">{detail.name}</p>
                </div>
              </div>

              <div className="grid grid-cols-1 gap-3">
                <div className="p-4 bg-gray-50 rounded-2xl border border-gray-100">
                  <p className="text-[10px] font-black text-gray-400 uppercase tracking-widest mb-1">Số điện thoại</p>
                  <p className="text-sm font-bold text-[#0B2421]">{detail.phoneNumber || "N/A"}</p>
                </div>
                <div className="p-4 bg-gray-50 rounded-2xl border border-gray-100">
                  <p className="text-[10px] font-black text-gray-400 uppercase tracking-widest mb-1">Email</p>
                  <p className="text-sm font-bold text-[#0B2421]">{detail.gmail}</p>
                </div>
              </div>

              <div className="p-4 bg-emerald-50 rounded-2xl border border-emerald-100">
                <p className="text-[10px] font-black text-emerald-600/60 uppercase tracking-widest mb-1">Khung giờ đặt</p>
                <div className="flex items-center justify-between">
                  <span className="text-sm font-black text-emerald-700">{detail.subCourtName}</span>
                  <span className="text-sm font-black text-[#0B2421]">
                    {detail.startTime.substring(0, 5)} - {detail.endTime.substring(0, 5)}
                  </span>
                </div>
              </div>
            </div>
          ) : (
            <div className="py-12 text-center text-gray-400 font-bold">
              Không tìm thấy thông tin chi tiết.
            </div>
          )}
        </div>

        <DialogFooter className="p-6 bg-gray-50 border-t border-gray-100">
          <Button 
            className="w-full h-12 bg-[#0B2421] hover:bg-[#1a3a36] text-white rounded-2xl font-black text-xs uppercase tracking-widest"
            onClick={() => onOpenChange(false)}
          >
            Đóng cửa sổ
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}

interface OwnerFacilityTimelineProps {
  subCourts: SubCourtListItem[];
  courtName: string;
}

// Generate time slots from 05:00 to 23:00 with 30min intervals
const TIME_SLOTS = Array.from({ length: 37 }, (_, i) => {
  const hour = Math.floor(i / 2) + 5;
  const minute = i % 2 === 0 ? "00" : "30";
  return `${hour.toString().padStart(2, "0")}:${minute}`;
});

export function OwnerFacilityTimeline({ subCourts, courtName }: OwnerFacilityTimelineProps) {
  const [selectedDate, setSelectedDate] = useState(new Date());
  const dateStr = format(selectedDate, "yyyy-MM-dd");

  const todayStr = format(new Date(), "yyyy-MM-dd");
  const [targetSubCourtId, setTargetSubCourtId] = useState<string>(subCourts[0]?.subCourtId || "");
  const [isMergeModalOpen, setIsMergeModalOpen] = useState(false);
  const [isBlockModalOpen, setIsBlockModalOpen] = useState(false);
  const [modalDate, setModalDate] = useState(dateStr);
  const [isRecurring, setIsRecurring] = useState(false);
  const [selectedDays, setSelectedDays] = useState<number[]>([]);
  const [startTime, setStartTime] = useState("05:00");
  const [endTime, setEndTime] = useState("06:00");
  const [price, setPrice] = useState("");
  const [blockReason, setBlockReason] = useState("");
  const [isBlockRecurring, setIsBlockRecurring] = useState(false);
  const [selectedBlockDays, setSelectedBlockDays] = useState<number[]>([]);

  const [selectedBookingDetailId, setSelectedBookingDetailId] = useState<string | null>(null);
  const [isDetailModalOpen, setIsDetailModalOpen] = useState(false);

  const createOverrideMutation = useCreateOverrideSlot();
  const createExceptionMutation = useCreateExceptionSlot();

  // Fetch all slots for all sub-courts in parallel
  const subCourtQueries = useQueries({
    queries: subCourts.map((sub) => ({
      queryKey: ["available-slots", { subCourtId: sub.subCourtId, date: dateStr }],
      queryFn: () => ownerCourtService.getAvailableSlots({ subCourtId: sub.subCourtId, date: dateStr }),
      enabled: !!sub.subCourtId && !!dateStr,
    })),
  });

  const handleMergeSlots = async () => {
    if (!targetSubCourtId || !startTime || !endTime || !price) {
      toast.error("Vui lòng nhập đầy đủ thông tin");
      return;
    }

    const payloadBase = {
      subCourtId: targetSubCourtId,
      isRecurring,
      startTime: startTime + ":00",
      endTime: endTime + ":00",
      price: Number(price),
    };

    try {
      if (isRecurring) {
        if (selectedDays.length === 0) {
          toast.error("Vui lòng chọn ít nhất một thứ trong tuần");
          return;
        }
        for (const day of selectedDays) {
          await createOverrideMutation.mutateAsync({ ...payloadBase, dayOfWeek: day });
        }
      } else {
        await createOverrideMutation.mutateAsync({ ...payloadBase, date: modalDate });
      }
      setIsMergeModalOpen(false);
      setPrice("");
      setSelectedDays([]);
    } catch (error) {}
  };

  const handleBlockSlots = async () => {
    if (!targetSubCourtId || !startTime || !endTime || !blockReason) {
      toast.error("Vui lòng nhập đầy đủ thông tin khóa sân");
      return;
    }

    const payloadBase = {
      subCourtId: targetSubCourtId,
      isRecurring: isBlockRecurring,
      startTime: startTime + ":00",
      endTime: endTime + ":00",
      reason: blockReason,
    };

    try {
      if (isBlockRecurring) {
        if (selectedBlockDays.length === 0) {
          toast.error("Vui lòng chọn ít nhất một thứ trong tuần");
          return;
        }
        for (const day of selectedBlockDays) {
          await createExceptionMutation.mutateAsync({
            ...payloadBase,
            dayOfWeek: day,
          });
        }
      } else {
        await createExceptionMutation.mutateAsync({
          ...payloadBase,
          date: modalDate,
        });
      }
      setIsBlockModalOpen(false);
      setBlockReason("");
      setSelectedBlockDays([]);
    } catch (error) {}
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
  const handleToday = () => setSelectedDate(new Date());

  const isLoading = subCourtQueries.some(q => q.isLoading);

  return (
    <>
      <div className="bg-white rounded-xl border border-gray-100 shadow-sm overflow-hidden flex flex-col h-[calc(100vh-220px)]">
      {/* Header with Date Navigation */}
      <div className="p-4 border-b border-gray-50 flex flex-wrap items-center justify-between gap-4 bg-white sticky top-0 z-10">
        <div className="flex items-center gap-4">
          <div className="bg-emerald-50 p-2 rounded-lg text-emerald-600">
            <CalendarIcon size={20} />
          </div>
          <div>
            <h2 className="text-sm font-bold text-gray-900">{courtName} - Lịch tổng quan</h2>
            <p className="text-[10px] text-gray-500">
              {format(selectedDate, "EEEE, dd 'tháng' MM, yyyy", { locale: vi })}
            </p>
          </div>
        </div>

        <div className="flex items-center gap-2">
          {/* Merge Modal */}
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
                  <DialogTitle className="text-xl font-black">Gộp Slot Mới</DialogTitle>
                </DialogHeader>
                <p className="text-emerald-100 text-xs mt-1 font-medium">Tạo khung giờ cố định cho sân được chọn</p>
              </div>

              <div className="p-6 space-y-5">
                <div className="space-y-2">
                  <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Chọn sân áp dụng</Label>
                  <Select value={targetSubCourtId} onValueChange={setTargetSubCourtId}>
                    <SelectTrigger className="h-12 rounded-xl bg-gray-50 border-gray-100 font-bold">
                      <SelectValue placeholder="Chọn sân con" />
                    </SelectTrigger>
                    <SelectContent>
                      {subCourts.map(sub => (
                        <SelectItem key={sub.subCourtId} value={sub.subCourtId}>{sub.name}</SelectItem>
                      ))}
                    </SelectContent>
                  </Select>
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
                    <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Chọn thứ trong tuần</Label>
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
                    <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Ngày áp dụng</Label>
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
                    <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Bắt đầu</Label>
                    <Input type="time" value={startTime} onChange={(e) => setStartTime(e.target.value)} className="h-12 rounded-xl bg-gray-50 border-gray-100 font-bold" />
                  </div>
                  <div className="space-y-2">
                    <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Kết thúc</Label>
                    <Input type="time" value={endTime} onChange={(e) => setEndTime(e.target.value)} className="h-12 rounded-xl bg-gray-50 border-gray-100 font-bold" />
                  </div>
                </div>

                <div className="space-y-2">
                  <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Giá tiền (VNĐ)</Label>
                  <Input type="number" placeholder="Ví dụ: 100000" value={price} onChange={(e) => setPrice(e.target.value)} className="h-12 rounded-xl bg-gray-50 border-gray-100 font-bold" />
                </div>
              </div>

              <DialogFooter className="p-6 bg-gray-50 border-t border-gray-100">
                <Button variant="ghost" onClick={() => setIsMergeModalOpen(false)} className="rounded-xl font-bold text-gray-500">Hủy</Button>
                <Button onClick={handleMergeSlots} disabled={createOverrideMutation.isPending} className="bg-emerald-600 hover:bg-emerald-700 text-white rounded-xl px-8 font-black">
                  {createOverrideMutation.isPending ? <Loader2 className="animate-spin" size={20} /> : "XÁC NHẬN"}
                </Button>
              </DialogFooter>
            </DialogContent>
          </Dialog>

          {/* Block Modal */}
          <Dialog open={isBlockModalOpen} onOpenChange={setIsBlockModalOpen}>
            <DialogTrigger asChild>
              <Button variant="outline" size="sm" className="text-rose-600 border-rose-100 hover:bg-rose-50 rounded-lg h-9 px-4 font-bold shadow-sm">
                <Lock size={16} className="mr-2" />
                Khóa slot
              </Button>
            </DialogTrigger>
            <DialogContent className="sm:max-w-[450px] rounded-2xl p-0 overflow-hidden border-none shadow-2xl">
              <div className="bg-rose-600 p-6 text-white">
                <DialogHeader>
                  <DialogTitle className="text-xl font-black">Khóa Slot Sân</DialogTitle>
                </DialogHeader>
                <p className="text-rose-100 text-xs mt-1 font-medium">Chặn đặt sân cho khoảng thời gian cụ thể</p>
              </div>

              <div className="p-6 space-y-5">
                <div className="space-y-2">
                  <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Chọn sân áp dụng</Label>
                  <Select value={targetSubCourtId} onValueChange={setTargetSubCourtId}>
                    <SelectTrigger className="h-12 rounded-xl bg-gray-50 border-gray-100 font-bold">
                      <SelectValue placeholder="Chọn sân con" />
                    </SelectTrigger>
                    <SelectContent>
                      {subCourts.map(sub => (
                        <SelectItem key={sub.subCourtId} value={sub.subCourtId}>{sub.name}</SelectItem>
                      ))}
                    </SelectContent>
                  </Select>
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
                    <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Chọn thứ trong tuần</Label>
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
                    <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Ngày áp dụng</Label>
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
                    <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Bắt đầu</Label>
                    <Input type="time" value={startTime} onChange={(e) => setStartTime(e.target.value)} className="h-12 rounded-xl bg-gray-50 border-gray-100 font-bold" />
                  </div>
                  <div className="space-y-2">
                    <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Kết thúc</Label>
                    <Input type="time" value={endTime} onChange={(e) => setEndTime(e.target.value)} className="h-12 rounded-xl bg-gray-50 border-gray-100 font-bold" />
                  </div>
                </div>

                <div className="space-y-2">
                  <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Lý do khóa</Label>
                  <Textarea placeholder="VD: Bảo trì định kỳ, Sự kiện địa phương..." value={blockReason} onChange={(e) => setBlockReason(e.target.value)} className="min-h-[100px] rounded-xl bg-gray-50 border-gray-100 font-bold resize-none" />
                </div>
              </div>

              <DialogFooter className="p-6 bg-gray-50 border-t border-gray-100">
                <Button variant="ghost" onClick={() => setIsBlockModalOpen(false)} className="rounded-xl font-bold text-gray-500">Hủy</Button>
                <Button onClick={handleBlockSlots} disabled={createExceptionMutation.isPending} className="bg-rose-600 hover:bg-rose-700 text-white rounded-xl px-8 font-black shadow-lg shadow-rose-600/20">
                  {createExceptionMutation.isPending ? <Loader2 className="animate-spin" size={20} /> : "XÁC NHẬN KHÓA"}
                </Button>
              </DialogFooter>
            </DialogContent>
          </Dialog>

          <Button variant="outline" size="sm" onClick={handleToday} className="h-9 text-xs font-bold border-gray-200">Hôm nay</Button>
          <div className="flex items-center bg-gray-50 rounded-lg p-0.5 border border-gray-200">
            <Button variant="ghost" size="icon" onClick={handlePrevDay} className="h-7 w-7 text-gray-500 hover:text-emerald-600">
              <ChevronLeft size={16} />
            </Button>
            <div className="px-3 text-xs font-bold min-w-[100px] text-center text-gray-700">
              {format(selectedDate, "dd/MM/yyyy")}
            </div>
            <Button variant="ghost" size="icon" onClick={handleNextDay} className="h-7 w-7 text-gray-500 hover:text-emerald-600">
              <ChevronRight size={16} />
            </Button>
          </div>
        </div>

        <div className="flex items-center gap-4">
          <div className="flex items-center gap-1.5">
            <div className="w-3 h-3 rounded bg-white border border-gray-200" />
            <span className="text-[10px] font-medium text-gray-600">Trống</span>
          </div>
          <div className="flex items-center gap-1.5">
            <div className="w-3 h-3 rounded bg-violet-500" />
            <span className="text-[10px] font-medium text-gray-600">Gộp</span>
          </div>
          <div className="flex items-center gap-1.5">
            <div className="w-3 h-3 rounded bg-rose-500" />
            <span className="text-[10px] font-medium text-gray-600">Đã đặt</span>
          </div>
          <div className="flex items-center gap-1.5">
            <div className="w-3 h-3 rounded bg-gray-400" />
            <span className="text-[10px] font-medium text-gray-600">Khóa</span>
          </div>
        </div>
      </div>

      {/* Timeline Grid */}
      <div className="flex-1 overflow-auto relative">
        <div className="min-w-[1200px]">
          {/* Time Header */}
          <div className="flex border-b border-gray-100 bg-gray-50/50 sticky top-0 z-20">
            <div className="w-40 shrink-0 border-r border-gray-100 p-3 bg-gray-50 flex items-center gap-2">
              <Clock size={14} className="text-gray-400" />
              <span className="text-[10px] font-bold text-gray-400 uppercase tracking-wider">Sân con</span>
            </div>
            <div className="flex flex-1">
              {TIME_SLOTS.map((time, idx) => (
                <div 
                  key={time} 
                  className={cn(
                    "flex-1 text-center py-2 text-[9px] font-bold text-gray-400 border-r border-gray-50/50",
                    idx % 2 !== 0 && "bg-gray-100/30"
                  )}
                >
                  {time}
                </div>
              ))}
            </div>
          </div>

          {/* Sub-court Rows */}
          <div className="divide-y divide-gray-100">
            {subCourts.map((sub, rowIndex) => {
              const query = subCourtQueries[rowIndex];
              const slots = query.data || [];
              
              return (
                <div key={sub.subCourtId} className="flex group hover:bg-gray-50/30 transition-colors relative hover:z-40">
                  {/* Sub-court info */}
                  <div className="w-40 shrink-0 border-r border-gray-100 p-4 bg-white sticky left-0 z-10 shadow-[2px_0_5px_rgba(0,0,0,0.02)]">
                    <p className="font-bold text-sm text-gray-900 truncate">{sub.name}</p>
                    <p className="text-[9px] text-gray-400 truncate">ID: {sub.subCourtId.split('-')[0]}</p>
                  </div>

                  {/* Slots row container */}
                  <div className="flex-1 relative h-16 bg-gray-50/10">
                    {/* Background Grid Lines */}
                    <div className="absolute inset-0 flex">
                      {TIME_SLOTS.slice(0, -1).map((time) => (
                        <div key={time} className="flex-1 border-r border-gray-100/50" />
                      ))}
                    </div>

                    {isLoading ? (
                      <div className="absolute inset-0 flex items-center justify-center px-4">
                        <div className="w-full h-2 bg-emerald-100 animate-pulse rounded-full" />
                      </div>
                    ) : (
                      <div className="absolute inset-0">
                        {slots.map((slot, slotIdx) => {
                          const [sH, sM] = slot.startTime.split(':').map(Number);
                          const [eH, eM] = slot.endTime.split(':').map(Number);
                          
                          // Clamp times to timeline range (05:00 - 23:00)
                          const startMins = Math.max(0, (sH - 5) * 60 + sM);
                          const endMins = Math.min(1080, (eH - 5) * 60 + eM);
                          
                          if (startMins >= endMins) return null;

                          const left = (startMins / 1080) * 100;
                          const width = ((endMins - startMins) / 1080) * 100;
                          
                          const durationMins = endMins - startMins;
                          const isMerged = slot.isAvailable && durationMins > 60;
                          const isBooked = !slot.isAvailable && slot.reason?.includes("khách đặt");

                          return (
                            <div 
                              key={`${slot.startTime}-${slotIdx}`}
                              className="absolute h-full py-2 px-0.5 transition-all duration-300"
                              style={{ left: `${left}%`, width: `${width}%` }}
                            >
                              <div 
                                onClick={() => {
                                  if (slot.type === "Booked" && slot.bookingDetailId) {
                                    setSelectedBookingDetailId(slot.bookingDetailId);
                                    setIsDetailModalOpen(true);
                                  }
                                }}
                                className={cn(
                                  "w-full h-full rounded-lg border flex flex-col items-center justify-center gap-0.5 transition-all hover:brightness-95 cursor-pointer shadow-sm relative group/slot",
                                  slot.type === "Override" ? "bg-violet-500 border-violet-600 text-white" :
                                  slot.type === "Booked" ? "bg-rose-500 border-rose-600 text-white" :
                                  slot.type === "Blocked" ? "bg-gray-400 border-gray-500 text-white" :
                                  "bg-white border-gray-100 text-gray-700"
                                )}
                              >
                                <span className={cn(
                                  "text-[10px] font-black leading-none",
                                  durationMins < 45 && "hidden" // Hide text if too narrow
                                )}>
                                  {slot.startTime.substring(0, 5)}
                                </span>
                                {durationMins >= 60 && (
                                  <span className="text-[8px] opacity-80 font-bold leading-none">
                                    {slot.price.toLocaleString()}đ
                                  </span>
                                )}

                                {/* Hover Tooltip */}
                                <div className={cn(
                                  "absolute left-1/2 -translate-x-1/2 w-48 p-2 bg-gray-900 text-white text-[10px] rounded-xl opacity-0 group-hover/slot:opacity-100 pointer-events-none transition-all z-50 shadow-2xl border border-white/10",
                                  rowIndex === 0 ? "top-[110%]" : "bottom-[110%]"
                                )}>
                                  <div className="flex items-center justify-between border-b border-white/10 pb-1.5 mb-1.5">
                                    <span className="font-black text-emerald-400">{slot.startTime.substring(0, 5)} - {slot.endTime.substring(0, 5)}</span>
                                    <Badge variant="outline" className="text-[8px] h-4 border-white/20 text-white">
                                      {durationMins} phút
                                    </Badge>
                                  </div>
                                  <p className="font-medium leading-relaxed">
                                    {slot.reason || (isMerged ? "Khung giờ đã gộp" : "Khung giờ mặc định")}
                                  </p>
                                  <p className="mt-1.5 text-emerald-400 font-bold">Giá: {slot.price.toLocaleString()} VNĐ</p>
                                </div>
                              </div>
                            </div>
                          );
                        })}
                      </div>
                    )}
                  </div>
                </div>
              );
            })}
          </div>
        </div>
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
    </>
  );
}
