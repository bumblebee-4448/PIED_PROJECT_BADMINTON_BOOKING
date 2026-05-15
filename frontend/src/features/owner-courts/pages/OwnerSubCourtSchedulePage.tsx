import { useState } from "react";
import { useParams, useNavigate, useSearchParams } from "react-router-dom";
import { useAvailableSlots, useCreateOverrideSlot, useCreateExceptionSlot } from "../hooks/useOwnerSlots";
import { 
  ArrowLeft, 
  Calendar as CalendarIcon, 
  Clock, 
  Loader2, 
  Lock,
  CalendarCheck,
  MessageSquare
} from "lucide-react";
import { useBookingDetail } from "../hooks/useOwnerSlots";
import { Button } from "@/shared/components/ui/button";
import { Badge } from "@/shared/components/ui/badge";
import { cn } from "@/lib/utils";
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
import { toast } from "sonner";

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


export default function OwnerSubCourtSchedulePage() {
  const { id: subCourtId } = useParams();
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();
  const isScheduleContext = searchParams.get("mode") === "schedule";
  
  const today = new Date().toISOString().split('T')[0];
  const [selectedDate, setSelectedDate] = useState(today);
  
  // Modals state
  const [isMergeModalOpen, setIsMergeModalOpen] = useState(false);
  const [isBlockModalOpen, setIsBlockModalOpen] = useState(false);

  // Merge Form states
  const [isRecurring, setIsRecurring] = useState(false);
  const [selectedDays, setSelectedDays] = useState<number[]>([]);
  const [mergeDate, setMergeDate] = useState(today);
  const [mergeStartTime, setMergeStartTime] = useState("05:00");
  const [mergeEndTime, setMergeEndTime] = useState("06:00");
  const [mergePrice, setMergePrice] = useState("");

  // Block Form states
  const [blockDate, setBlockDate] = useState(today);
  const [blockStartTime, setBlockStartTime] = useState("05:00");
  const [blockEndTime, setBlockEndTime] = useState("06:00");
  const [blockReason, setBlockReason] = useState("");
  const [isBlockRecurring, setIsBlockRecurring] = useState(false);
  const [selectedBlockDays, setSelectedBlockDays] = useState<number[]>([]);
  
  const [selectedBookingDetailId, setSelectedBookingDetailId] = useState<string | null>(null);
  const [isDetailModalOpen, setIsDetailModalOpen] = useState(false);

  const { data: availableSlotsRaw, isLoading: isSlotsLoading } = useAvailableSlots({
    subCourtId: subCourtId || "",
    date: selectedDate
  });


  // Backend đã trả về reason trực tiếp trong GetAvailableSlots
  const availableSlots = availableSlotsRaw;

  const createOverrideMutation = useCreateOverrideSlot();
  const createExceptionMutation = useCreateExceptionSlot();

  const handleMergeSlots = async () => {
    if (!mergeStartTime || !mergeEndTime || !mergePrice) {
      toast.error("Vui lòng nhập đầy đủ thông tin");
      return;
    }

    const payloadBase = {
      subCourtId: subCourtId || "",
      isRecurring,
      startTime: mergeStartTime + ":00",
      endTime: mergeEndTime + ":00",
      price: Number(mergePrice),
    };

    try {
      if (isRecurring) {
        if (selectedDays.length === 0) {
          toast.error("Vui lòng chọn ít nhất một thứ trong tuần");
          return;
        }
        for (const day of selectedDays) {
          await createOverrideMutation.mutateAsync({
            ...payloadBase,
            dayOfWeek: day,
          });
        }
      } else {
        await createOverrideMutation.mutateAsync({
          ...payloadBase,
          date: mergeDate,
        });
      }
      setIsMergeModalOpen(false);
      setMergePrice("");
      setSelectedDays([]);
    } catch (error) {}
  };

  const handleBlockSlots = async () => {
    if (!blockStartTime || !blockEndTime || !blockReason) {
      toast.error("Vui lòng nhập đầy đủ thông tin khóa sân");
      return;
    }

    const payloadBase = {
      subCourtId: subCourtId || "",
      isRecurring: isBlockRecurring,
      startTime: blockStartTime + ":00",
      endTime: blockEndTime + ":00",
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
          date: blockDate,
        });
      }
      setIsBlockModalOpen(false);
      setBlockReason("");
      setSelectedBlockDays([]);
    } catch (error) {}
  };

  const formatDate = (dateStr: string) => {
    const d = new Date(dateStr);
    return new Intl.DateTimeFormat('vi-VN', { 
      weekday: 'long', 
      year: 'numeric', 
      month: 'long', 
      day: 'numeric' 
    }).format(d);
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

  return (
    <div className="p-6 max-w-6xl mx-auto space-y-6">
      {/* Header */}
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div className="flex items-center gap-4">
          <Button 
            variant="ghost" 
            size="icon" 
            onClick={() => navigate(-1)}
            className="rounded-full hover:bg-gray-100"
          >
            <ArrowLeft size={20} />
          </Button>
          <div>
            <h1 className="text-xl font-bold text-gray-900">
              Quản lý lịch sân
            </h1>
            <p className="text-xs text-gray-500 mt-0.5">
              Theo dõi tình trạng đặt sân và cấu hình ngoại lệ
            </p>
          </div>
        </div>

        <div className="flex items-center gap-3">
          {isScheduleContext && (
            <>
              {/* Merge Modal */}
              <Dialog open={isMergeModalOpen} onOpenChange={setIsMergeModalOpen}>
                <DialogTrigger asChild>
                  <Button className="bg-emerald-600 hover:bg-emerald-700 text-white rounded-xl h-11 px-6 shadow-lg shadow-emerald-600/20 font-bold">
                    Gộp slot mới
                  </Button>
                </DialogTrigger>
                <DialogContent className="sm:max-w-[450px] rounded-2xl p-0 overflow-hidden border-none shadow-2xl">
                  <div className="bg-emerald-600 p-6 text-white">
                    <DialogHeader>
                      <DialogTitle className="text-xl font-black">Gộp Slot Mới</DialogTitle>
                    </DialogHeader>
                    <p className="text-emerald-100 text-xs mt-1 font-medium">Tạo khung giờ cố định cho sân này</p>
                  </div>

                  <div className="p-6 space-y-6">
                    <div className="flex items-center space-x-3 bg-gray-50 p-4 rounded-xl border border-gray-100">
                      <Checkbox 
                        id="recurring" 
                        checked={isRecurring}
                        onCheckedChange={(checked) => setIsRecurring(!!checked)}
                        className="border-emerald-200 data-[state=checked]:bg-emerald-600 data-[state=checked]:border-emerald-600"
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
                                selectedDays.includes(day.value) 
                                  ? "bg-emerald-50 border-emerald-200" 
                                  : "bg-white border-gray-100 hover:border-gray-200"
                              )}
                            >
                              <Checkbox 
                                checked={selectedDays.includes(day.value)}
                                className="border-emerald-200 data-[state=checked]:bg-emerald-600 data-[state=checked]:border-emerald-600 pointer-events-none"
                              />
                              <span className={cn(
                                "text-xs font-bold",
                                selectedDays.includes(day.value) ? "text-emerald-700" : "text-gray-600"
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
                        <div className="relative">
                          <CalendarIcon className="absolute left-3 top-1/2 -translate-y-1/2 text-emerald-500" size={16} />
                          <Input 
                            type="date" 
                            value={mergeDate}
                            onChange={(e) => setMergeDate(e.target.value)}
                            className="pl-10 h-12 rounded-xl bg-emerald-50 border-emerald-100 focus:bg-white transition-all font-bold text-emerald-700"
                          />
                        </div>
                        <p className="text-[10px] text-emerald-600/60 font-medium pl-1 italic">
                          * {formatDate(mergeDate)}
                        </p>
                      </div>
                    )}

                    <div className="grid grid-cols-2 gap-4">
                      <div className="space-y-2">
                        <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Giờ bắt đầu</Label>
                        <div className="relative">
                          <Clock className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={16} />
                          <Input 
                            type="time" 
                            value={mergeStartTime}
                            onChange={(e) => setMergeStartTime(e.target.value)}
                            className="pl-10 h-12 rounded-xl bg-gray-50 border-gray-100 focus:bg-white transition-all font-bold"
                          />
                        </div>
                      </div>
                      <div className="space-y-2">
                        <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Giờ kết thúc</Label>
                        <div className="relative">
                          <Clock className="absolute left-3 top-1/2 -translate-y-1/2 text-gray-400" size={16} />
                          <Input 
                            type="time" 
                            value={mergeEndTime}
                            onChange={(e) => setMergeEndTime(e.target.value)}
                            className="pl-10 h-12 rounded-xl bg-gray-50 border-gray-100 focus:bg-white transition-all font-bold"
                          />
                        </div>
                      </div>
                    </div>

                    <div className="space-y-2">
                      <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Giá tiền (VNĐ)</Label>
                      <div className="relative">
                        <span className="absolute left-4 top-1/2 -translate-y-1/2 text-gray-400 font-bold text-sm">₫</span>
                        <Input 
                          type="number" 
                          placeholder="Ví dụ: 100000"
                          value={mergePrice}
                          onChange={(e) => setMergePrice(e.target.value)}
                          className="pl-8 h-12 rounded-xl bg-gray-50 border-gray-100 focus:bg-white transition-all font-bold"
                        />
                      </div>
                    </div>
                  </div>

                  <DialogFooter className="p-6 bg-gray-50 border-t border-gray-100">
                    <Button variant="ghost" onClick={() => setIsMergeModalOpen(false)} className="rounded-xl font-bold text-gray-500">Hủy bỏ</Button>
                    <Button 
                      onClick={handleMergeSlots}
                      disabled={createOverrideMutation.isPending}
                      className="bg-emerald-600 hover:bg-emerald-700 text-white rounded-xl px-8 font-black"
                    >
                      {createOverrideMutation.isPending ? <Loader2 className="animate-spin" size={20} /> : "XÁC NHẬN GỘP"}
                    </Button>
                  </DialogFooter>
                </DialogContent>
              </Dialog>

              {/* Block Modal */}
              <Dialog open={isBlockModalOpen} onOpenChange={setIsBlockModalOpen}>
                <DialogTrigger asChild>
                  <Button variant="outline" className="text-red-600 border-red-100 hover:bg-red-50 rounded-xl h-11 px-6 font-bold">
                    Khóa slot
                  </Button>
                </DialogTrigger>
                <DialogContent className="sm:max-w-[450px] rounded-2xl p-0 overflow-hidden border-none shadow-2xl">
                  <div className="bg-red-600 p-6 text-white">
                    <DialogHeader>
                      <DialogTitle className="text-xl font-black">Khóa Slot Sân</DialogTitle>
                    </DialogHeader>
                    <p className="text-red-100 text-xs mt-1 font-medium">Chặn đặt sân cho khoảng thời gian cụ thể</p>
                  </div>

                  <div className="p-6 space-y-6">
                    <div className="flex items-center space-x-3 bg-gray-50 p-4 rounded-xl border border-gray-100">
                      <Checkbox 
                        id="blockRecurring" 
                        checked={isBlockRecurring}
                        onCheckedChange={(checked) => setIsBlockRecurring(!!checked)}
                        className="border-red-200 data-[state=checked]:bg-red-600 data-[state=checked]:border-red-600"
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
                                  ? "bg-red-50 border-red-200" 
                                  : "bg-white border-gray-100 hover:border-gray-200"
                              )}
                            >
                              <Checkbox 
                                checked={selectedBlockDays.includes(day.value)}
                                className="border-red-200 data-[state=checked]:bg-red-600 data-[state=checked]:border-red-600 pointer-events-none"
                              />
                              <span className={cn(
                                "text-xs font-bold",
                                selectedBlockDays.includes(day.value) ? "text-red-700" : "text-gray-600"
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
                        <div className="relative">
                          <CalendarIcon className="absolute left-3 top-1/2 -translate-y-1/2 text-red-500" size={16} />
                          <Input 
                            type="date" 
                            value={blockDate}
                            onChange={(e) => setBlockDate(e.target.value)}
                            className="pl-10 h-12 rounded-xl bg-red-50 border-red-100 focus:bg-white transition-all font-bold text-red-700"
                          />
                        </div>
                        <p className="text-[10px] text-red-600/60 font-medium pl-1 italic">
                          * {formatDate(blockDate)}
                        </p>
                      </div>
                    )}

                    <div className="grid grid-cols-2 gap-4">
                      <div className="space-y-2">
                        <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Giờ bắt đầu</Label>
                        <Input 
                          type="time" 
                          value={blockStartTime}
                          onChange={(e) => setBlockStartTime(e.target.value)}
                          className="h-12 rounded-xl bg-gray-50 border-gray-100 focus:bg-white transition-all font-bold"
                        />
                      </div>
                      <div className="space-y-2">
                        <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Giờ kết thúc</Label>
                        <Input 
                          type="time" 
                          value={blockEndTime}
                          onChange={(e) => setBlockEndTime(e.target.value)}
                          className="h-12 rounded-xl bg-gray-50 border-gray-100 focus:bg-white transition-all font-bold"
                        />
                      </div>
                    </div>

                    <div className="space-y-2">
                      <Label className="text-[10px] font-black uppercase tracking-widest text-gray-400">Lý do khóa sân</Label>
                      <div className="relative">
                        <MessageSquare className="absolute left-3 top-3 text-gray-400" size={16} />
                        <Textarea 
                          placeholder="Ví dụ: Sân đang bảo trì, Tổ chức sự kiện..."
                          value={blockReason}
                          onChange={(e) => setBlockReason(e.target.value)}
                          className="pl-10 min-h-[100px] rounded-xl bg-gray-50 border-gray-100 focus:bg-white transition-all font-bold resize-none"
                        />
                      </div>
                    </div>
                  </div>

                  <DialogFooter className="p-6 bg-gray-50 border-t border-gray-100">
                    <Button variant="ghost" onClick={() => setIsBlockModalOpen(false)} className="rounded-xl font-bold text-gray-500">Hủy bỏ</Button>
                    <Button 
                      onClick={handleBlockSlots}
                      disabled={createExceptionMutation.isPending}
                      className="bg-red-600 hover:bg-red-700 text-white rounded-xl px-8 font-black shadow-lg shadow-red-600/20"
                    >
                      {createExceptionMutation.isPending ? <Loader2 className="animate-spin" size={20} /> : "XÁC NHẬN KHÓA"}
                    </Button>
                  </DialogFooter>
                </DialogContent>
              </Dialog>
            </>
          )}

          <div className="flex items-center gap-3 bg-white p-2 pl-4 rounded-xl border border-gray-100 shadow-sm h-11">
            <CalendarIcon size={16} className="text-emerald-500" />
            <input 
              type="date" 
              className="border-none focus:ring-0 text-sm font-bold text-gray-700 outline-none cursor-pointer"
              value={selectedDate}
              onChange={(e) => setSelectedDate(e.target.value)}
            />
          </div>
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-4 gap-8">
        {/* Statistics / Info */}
        <div className="lg:col-span-1 space-y-6">
          <div className="bg-white rounded-xl border border-gray-100 p-5 shadow-sm space-y-4">
            <h2 className="text-sm font-bold text-gray-900 border-b border-gray-50 pb-3">Trạng thái slot</h2>
            <div className="space-y-3">
              <div className="flex items-center gap-3">
                <div className="w-3 h-3 rounded-full bg-white border border-gray-200" />
                <span className="text-xs font-medium text-gray-600">Còn trống</span>
              </div>
              <div className="flex items-center gap-3">
                <div className="w-3 h-3 rounded-full bg-rose-500" />
                <span className="text-xs font-medium text-gray-600">Đã đặt</span>
              </div>
              <div className="flex items-center gap-3">
                <div className="w-3 h-3 rounded-full bg-gray-400" />
                <span className="text-xs font-medium text-gray-600">Bị khóa</span>
              </div>
              <div className="flex items-center gap-3">
                <div className="w-3 h-3 rounded-full bg-violet-500" />
                <span className="text-xs font-medium text-gray-600">Bị gộp</span>
              </div>
            </div>
          </div>

          <div className="bg-emerald-600 rounded-xl p-5 text-white shadow-lg shadow-emerald-600/20">
            <p className="text-[10px] font-bold uppercase tracking-widest opacity-80 mb-1">Ngày đang xem</p>
            <p className="text-xl font-black">{formatDate(selectedDate)}</p>
          </div>
        </div>

        {/* Slots Grid */}
        <div className="lg:col-span-3">
          <div className="bg-white rounded-2xl border border-gray-100 shadow-sm p-8 min-h-[500px]">
            <div className="flex items-center justify-between mb-8">
              <h2 className="font-bold text-gray-900 flex items-center gap-2">
                <CalendarCheck size={18} className="text-emerald-600" />
                Lịch trình chi tiết
              </h2>
              {availableSlots && (
                <p className="text-[10px] font-bold text-gray-400 uppercase tracking-widest">
                  {availableSlots.filter(s => s.isAvailable).length} Trống / {availableSlots.length} Tổng
                </p>
              )}
            </div>

            {isSlotsLoading ? (
              <div className="flex flex-col items-center justify-center py-24 gap-4 text-gray-400">
                <Loader2 className="animate-spin" size={40} />
                <p className="text-xs font-medium uppercase tracking-[0.2em]">Đang tải lịch sân...</p>
              </div>
            ) : availableSlots && availableSlots.length > 0 ? (
              <div className="grid grid-cols-1 sm:grid-cols-2 xl:grid-cols-3 gap-4">
                {availableSlots.map((slot, index) => (
                  <div 
                    key={index}
                    onClick={() => {
                      if (slot.type === "Booked" && slot.bookingDetailId) {
                        setSelectedBookingDetailId(slot.bookingDetailId);
                        setIsDetailModalOpen(true);
                      }
                    }}
                    className={cn(
                      "p-5 rounded-xl border transition-all duration-300 relative overflow-hidden group",
                      slot.type === "Booked" ? "bg-rose-50 border-rose-100 hover:shadow-md cursor-pointer" :
                      slot.type === "Blocked" ? "bg-gray-50 border-gray-200 opacity-60" :
                      slot.type === "Override" ? "bg-violet-50 border-violet-100 hover:shadow-md" :
                      "bg-white border-gray-100 hover:border-amber-400 hover:shadow-md"
                    )}
                  >
                    <div className="flex items-center justify-between mb-4">
                      <div className={cn(
                        "p-2 rounded-lg transition-colors",
                        slot.isAvailable ? "bg-emerald-50" : "bg-gray-100"
                      )}>
                        <Clock size={16} className={slot.isAvailable ? "text-emerald-600" : "text-gray-400"} />
                      </div>
                      <Badge 
                        variant="outline"
                        className={cn(
                          "text-[10px] font-bold border-none px-3",
                          slot.type === "Booked" ? "bg-rose-500 text-white" :
                          slot.type === "Blocked" ? "bg-gray-400 text-white" :
                          slot.type === "Override" ? "bg-violet-500 text-white" :
                          "bg-emerald-50 text-emerald-600"
                        )}
                      >
                        {slot.type === "Booked" ? "ĐÃ ĐẶT" :
                         slot.type === "Blocked" ? "BỊ KHÓA" :
                         slot.type === "Override" ? "BỊ GỘP" :
                         "TRỐNG"}
                      </Badge>
                    </div>

                    <div className="space-y-1">
                      <p className="text-lg font-black text-gray-900 tracking-tight">
                        {slot.startTime.substring(0, 5)} - {slot.endTime.substring(0, 5)}
                      </p>
                      
                      {slot.reason ? (
                        <div className="mt-2 bg-red-50 p-2 rounded-lg border border-red-100">
                          <p className="text-[10px] font-bold text-red-600 uppercase tracking-tight">
                            Lý do khóa:
                          </p>
                          <p className="text-[11px] font-medium text-red-500 leading-tight">
                            {slot.reason}
                          </p>
                        </div>
                      ) : (
                        <p className="text-xs font-bold text-emerald-600">
                          {slot.price.toLocaleString('vi-VN')} đ
                        </p>
                      )}
                    </div>

                    {!slot.isAvailable && (
                      <div className="absolute -bottom-2 -right-2 opacity-5">
                        <Lock size={60} />
                      </div>
                    )}
                  </div>
                ))}
              </div>
            ) : (
              <div className="py-24 flex flex-col items-center justify-center text-center">
                <h3 className="text-lg font-bold text-gray-400">Không có dữ liệu lịch</h3>
                <p className="text-xs text-gray-400 mt-1 max-w-[300px] mx-auto font-medium">
                  Hiện tại không có slot nào được ghi nhận cho ngày đã chọn.
                </p>
              </div>
            )}
          </div>
        </div>
      </div>

      <BookingDetailModal 
        bookingDetailId={selectedBookingDetailId}
        isOpen={isDetailModalOpen}
        onOpenChange={setIsDetailModalOpen}
      />
    </div>
  );
}
