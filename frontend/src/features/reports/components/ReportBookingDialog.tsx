import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { AlertTriangle, Loader2 } from "lucide-react";

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
} from "@/shared/components/ui/form";
import { Button } from "@/shared/components/ui/button";
import { Textarea } from "@/shared/components/ui/textarea";
import { createReportBookingSchema, type CreateReportBookingFormValues } from "../schema";
import { useCreateReportBooking } from "../hooks/useReports";

interface ReportBookingDialogProps {
  bookingId: string;
  isOpen: boolean;
  onOpenChange: (open: boolean) => void;
  courtName?: string;
}

export function ReportBookingDialog({
  bookingId,
  isOpen,
  onOpenChange,
  courtName,
}: ReportBookingDialogProps) {
  const { mutate: createReport, isPending } = useCreateReportBooking();

  const form = useForm<CreateReportBookingFormValues>({
    resolver: zodResolver(createReportBookingSchema),
    defaultValues: {
      reason: "",
      bookingId: bookingId,
    },
  });

  const onSubmit = (values: CreateReportBookingFormValues) => {
    createReport(values, {
      onSuccess: () => {
        onOpenChange(false);
        form.reset();
      },
    });
  };

  return (
    <Dialog open={isOpen} onOpenChange={onOpenChange}>
      <DialogContent className="sm:max-w-[500px] rounded-3xl">
        <DialogHeader>
          <div className="mx-auto mb-4 flex h-12 w-12 items-center justify-center rounded-full bg-red-100">
            <AlertTriangle className="h-6 w-6 text-red-600" />
          </div>
          <DialogTitle className="text-center text-xl font-black">Báo cáo đơn đặt sân</DialogTitle>
          <DialogDescription className="text-center">
            Bạn đang báo cáo cho sân <span className="font-bold text-gray-900">{courtName || "đã chọn"}</span>. 
            Vui lòng cung cấp lý do chi tiết để chúng tôi có thể hỗ trợ bạn tốt nhất.
          </DialogDescription>
        </DialogHeader>

        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-4 py-4">
            <FormField
              control={form.control}
              name="reason"
              render={({ field }) => (
                <FormItem>
                  <FormLabel className="font-bold">Lý do báo cáo</FormLabel>
                  <FormControl>
                    <Textarea
                      placeholder="Ví dụ: Chủ sân ngưng hoạt động, sân không đúng như mô tả,..."
                      className="min-h-[120px] rounded-2xl resize-none focus-visible:ring-[#00897B]"
                      {...field}
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />

            <DialogFooter className="flex-col sm:flex-row gap-3">
              <Button
                type="button"
                variant="ghost"
                onClick={() => onOpenChange(false)}
                className="flex-1 rounded-2xl font-bold"
                disabled={isPending}
              >
                Hủy bỏ
              </Button>
              <Button
                type="submit"
                className="flex-1 bg-red-600 hover:bg-red-700 text-white font-bold rounded-2xl h-11"
                disabled={isPending}
              >
                {isPending ? (
                  <>
                    <Loader2 className="mr-2 h-4 w-4 animate-spin" />
                    Đang gửi...
                  </>
                ) : (
                  "Gửi báo cáo"
                )}
              </Button>
            </DialogFooter>
          </form>
        </Form>
      </DialogContent>
    </Dialog>
  );
}
