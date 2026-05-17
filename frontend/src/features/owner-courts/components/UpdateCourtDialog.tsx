import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { useUpdateCourtInfo } from "../hooks/useOwnerCourts";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
} from "@/shared/components/ui/dialog";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from '@/shared/components/ui/form';
import { updateCourtSchema, type UpdateCourtFormValues } from "../schema";
import type { MyCourtListItem } from "../types";

import { Input } from "@/shared/components/ui/input";
import { Button } from "@/shared/components/ui/button";
import { Upload } from "lucide-react";
import { Textarea } from "@/shared/components/ui/textarea";

interface UpdateCourtDialogProps {
  court: MyCourtListItem | null;
  open: boolean;
  onOpenChange: (open: boolean) => void;
}

export const UpdateCourtDialog = ({ court, open, onOpenChange }: UpdateCourtDialogProps) => {
  const updateCourt = useUpdateCourtInfo();

  const form = useForm<UpdateCourtFormValues>({
    resolver: zodResolver(updateCourtSchema),
    values: {
      name: court?.name || "",
      openTime: court?.startTime || "05:00:00",
      closeTime: court?.endTime || "22:00:00",
      address: court?.address || "",
      mapUrl: court?.mapUrl || "",
      description: (court as any)?.description || "",
      timeRefundBefore: (court as any)?.timeRefundBefore || 0,
    },
  });

  const onSubmit = (values: UpdateCourtFormValues) => {
    if (!court) return;
    updateCourt.mutate({ ...values, courtId: court.courtId }, {
      onSuccess: () => {
        onOpenChange(false);
      },
    });
  };

  return (
    <Dialog open={open} onOpenChange={onOpenChange}>
      <DialogContent className="sm:max-w-[600px] p-0 overflow-hidden flex flex-col max-h-[90vh] rounded-2xl">
        <DialogHeader className="p-6 pb-4 border-b border-slate-100 flex-shrink-0">
          <DialogTitle className="text-2xl font-bold text-gray-900">Cập nhật thông tin sân 🏸</DialogTitle>
          <DialogDescription className="mt-1.5">
            Chỉnh sửa thông tin sân của bạn.
          </DialogDescription>
        </DialogHeader>

        <div className="flex-1 overflow-y-auto p-6 custom-scrollbar">
          <Form {...form}>
            <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-4">
              <FormField
                control={form.control}
                name="name"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Tên sân</FormLabel>
                    <FormControl>
                      <Input placeholder="VD: Sân Cầu Lông ABC" {...field} />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />

              <div className="grid grid-cols-2 gap-4">
                <FormField
                  control={form.control}
                  name="openTime"
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Giờ mở cửa</FormLabel>
                      <FormControl>
                        <Input type="time" step="1" {...field} />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name="closeTime"
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Giờ đóng cửa</FormLabel>
                      <FormControl>
                        <Input type="time" step="1" {...field} />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
              </div>

              <FormField
                control={form.control}
                name="address"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Địa chỉ</FormLabel>
                    <FormControl>
                      <Input placeholder="Số nhà, tên đường, quận/huyện..." {...field} />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />


              <FormField
                control={form.control}
                name="mapUrl"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Google Maps URL</FormLabel>
                    <FormControl>
                      <Input placeholder="https://maps.google.com/..." {...field} />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />

              <FormField
                control={form.control}
                name="description"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Mô tả sân</FormLabel>
                    <FormControl>
                      <Textarea placeholder="Nhập mô tả về sân của bạn..." className="resize-none h-32" {...field} />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />

              <FormField
                control={form.control}
                name="pictureUrl"
                render={({ field: { value, onChange, ...field } }) => (
                  <FormItem>
                    <FormLabel>Thay đổi ảnh đại diện (Không chọn nếu muốn giữ ảnh cũ)</FormLabel>
                    <FormControl>
                      <div className="flex items-center gap-4">
                        <Input
                          type="file"
                          accept="image/*"
                          className="hidden"
                          id="update-court-image"
                          onChange={(e) => onChange(e.target.files?.[0] || null)}
                          {...field}
                        />
                        <label
                          htmlFor="update-court-image"
                          className="flex flex-col items-center justify-center w-full h-24 border-2 border-dashed border-gray-300 rounded-xl cursor-pointer hover:bg-gray-50 transition-colors"
                        >
                          {value instanceof File ? (
                            <div className="flex items-center gap-2 text-emerald-600 font-medium">
                              <Upload size={20} />
                              <span>{value.name}</span>
                            </div>
                          ) : (
                            <div className="flex flex-col items-center text-gray-500">
                              <Upload size={20} className="mb-1" />
                              <span className="text-xs">Nhấn để tải ảnh mới</span>
                            </div>
                          )}
                        </label>
                      </div>
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />

              <DialogFooter className="pt-4">
                <Button
                  type="submit"
                  className="w-full bg-emerald-600 hover:bg-emerald-700 text-white py-6 rounded-xl font-bold text-lg shadow-lg shadow-emerald-200 transition-all active:scale-[0.98]"
                  disabled={updateCourt.isPending}
                >
                  {updateCourt.isPending ? "Đang xử lý..." : "Lưu thay đổi"}
                </Button>
              </DialogFooter>
            </form>
          </Form>
        </div>
      </DialogContent>
    </Dialog>
  );
};
