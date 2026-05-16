import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { MessageSquare, Loader2 } from "lucide-react";

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
import { Input } from "@/shared/components/ui/input";
import { Textarea } from "@/shared/components/ui/textarea";
import { createSystemReportSchema, type CreateSystemReportFormValues } from "../schema";
import { useCreateSystemReport } from "../hooks/useReports";

interface ReportSystemDialogProps {
  isOpen: boolean;
  onOpenChange: (open: boolean) => void;
}

export function ReportSystemDialog({
  isOpen,
  onOpenChange,
}: ReportSystemDialogProps) {
  const { mutate: createReport, isPending } = useCreateSystemReport();

  const form = useForm<CreateSystemReportFormValues>({
    resolver: zodResolver(createSystemReportSchema),
    defaultValues: {
      title: "",
      reason: "",
    },
  });

  const onSubmit = (values: CreateSystemReportFormValues) => {
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
          <div className="mx-auto mb-4 flex h-12 w-12 items-center justify-center rounded-full bg-emerald-100">
            <MessageSquare className="h-6 w-6 text-emerald-600" />
          </div>
          <DialogTitle className="text-center text-xl font-black">Báo cáo hệ thống</DialogTitle>
          <DialogDescription className="text-center">
            Chúng tôi luôn lắng nghe ý kiến của bạn để cải thiện hệ thống tốt hơn.
          </DialogDescription>
        </DialogHeader>

        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-4 py-4">
            <FormField
              control={form.control}
              name="title"
              render={({ field }) => (
                <FormItem>
                  <FormLabel className="font-bold">Tiêu đề</FormLabel>
                  <FormControl>
                    <Input
                      placeholder="Nhập tiêu đề báo cáo..."
                      className="rounded-2xl h-11 focus-visible:ring-[#00897B]"
                      {...field}
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />

            <FormField
              control={form.control}
              name="reason"
              render={({ field }) => (
                <FormItem>
                  <FormLabel className="font-bold">Nội dung chi tiết</FormLabel>
                  <FormControl>
                    <Textarea
                      placeholder="Mô tả chi tiết vấn đề bạn đang gặp phải hoặc góp ý..."
                      className="min-h-[120px] rounded-2xl resize-none focus-visible:ring-[#00897B]"
                      {...field}
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />

            <DialogFooter className="flex-col sm:flex-row gap-3 pt-4">
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
                className="flex-1 bg-[#00897B] hover:bg-[#00796B] text-white font-bold rounded-2xl h-11"
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
