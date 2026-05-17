import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { Upload, FileText, User, Building2 } from "lucide-react";
import { useAuthStore } from "@/features/auth/store";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
} from "@/shared/components/ui/dialog";
import { Button } from "@/shared/components/ui/button";
import { Input } from "@/shared/components/ui/input";
import { Label } from "@/shared/components/ui/label";
import { toast } from "sonner";
import { useOwnerRegistration } from "../hooks/useOwnerRegistration";
import { useOwnerRegistrationStore } from "../store";
import type { OwnerRegistrationForm } from "../types";
import { ownerRegistrationSchema, type OwnerRegistrationSchema } from "../schema";
import { cn } from "@/lib/utils";

export function OwnerRegistrationDialog() {
  const { isDialogOpen, setDialogOpen } = useOwnerRegistrationStore();
  const { registerOwner, isLoading } = useOwnerRegistration();
  const { user } = useAuthStore();

  const {
    register,
    handleSubmit,
    setValue,

    watch,
    formState: { errors },
    reset,
  } = useForm<OwnerRegistrationSchema>({
    resolver: zodResolver(ownerRegistrationSchema),
  });

  const watchedFiles = watch([
    "businessLicenseFile",
    "identityCardFrontFile",
    "identityCardBackFile",
  ]);

  const onSubmit = (data: OwnerRegistrationSchema) => {
    if (!user?.firstName || !user?.lastName || !user?.phoneNumber) {
      toast.error("Thông tin không đầy đủ", {
        description: "Vui lòng cập nhật hồ sơ trước khi đăng ký.",
      });
      return;
    }

    const completeData: OwnerRegistrationForm = {
      ...data,
      firstName: user.firstName,
      lastName: user.lastName,
      phoneNumber: user.phoneNumber,
    };
    registerOwner(completeData);
  };

  const handleClose = () => {
    if (!isLoading) {
      setDialogOpen(false);
      reset();
    }
  };

  const FileUploadField = ({
    id,
    label,
    fieldName,
    accept,
    file,
    error,
  }: {
    id: string;
    label: string;
    fieldName: "businessLicenseFile" | "identityCardFrontFile" | "identityCardBackFile";
    accept: string;
    file: File | undefined;
    error?: string;
  }) => (
    <div>
      <Label className={cn(error && "text-rose-500")}>{label} *</Label>
      <div className="mt-2">
        <input
          type="file"
          id={id}
          accept={accept}
          onChange={(e) => {
            const f = e.target.files?.[0] || undefined;
            setValue(fieldName, f as File, { shouldValidate: true });
          }}
          className="hidden"
        />
        <label
          htmlFor={id}
          className={cn(
            "flex flex-col items-center justify-center w-full h-32 border-2 border-dashed rounded-lg cursor-pointer transition-colors",
            error
              ? "border-rose-400 bg-rose-50 hover:bg-rose-100"
              : file
                ? "border-emerald-400 bg-emerald-50"
                : "border-gray-300 bg-gray-50 hover:border-emerald-400 hover:bg-emerald-50"
          )}
        >
          {file ? (
            <div className="text-center px-2">
              <FileText size={24} className="text-emerald-600 mx-auto mb-2" />
              <p className="text-sm text-gray-700 truncate max-w-full">{file.name}</p>
            </div>
          ) : (
            <div className="text-center">
              <Upload size={24} className={cn("mx-auto mb-2", error ? "text-rose-400" : "text-gray-400")} />
              <p className={cn("text-sm", error ? "text-rose-500" : "text-gray-500")}>
                {error ? error : "Nhấn để tải lên"}
              </p>
            </div>
          )}
        </label>
        {error && file && (
          <p className="text-xs text-rose-500 mt-1">{error}</p>
        )}
      </div>
    </div>
  );

  return (
    <Dialog open={isDialogOpen} onOpenChange={handleClose}>
      <DialogContent className="max-w-2xl p-0 overflow-hidden flex flex-col max-h-[90vh] rounded-2xl">
        <DialogHeader className="p-6 pb-4 border-b border-slate-100 flex-shrink-0">
          <DialogTitle className="flex items-center gap-3 text-xl font-bold">
            <div className="w-10 h-10 rounded-xl flex items-center justify-center bg-emerald-50">
              <Building2 className="text-emerald-600" size={20} />
            </div>
            Đăng ký trở thành chủ sân
          </DialogTitle>
        </DialogHeader>

        <div className="flex-1 overflow-y-auto p-6 custom-scrollbar">
          <form onSubmit={handleSubmit(onSubmit)} className="space-y-6">

            {/* Business Information */}
            <div className="space-y-4">
              <h3 className="font-semibold text-gray-900 flex items-center gap-2">
                <Building2 size={16} className="text-emerald-600" />
                Thông tin doanh nghiệp
              </h3>

              <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                <div>
                  <Label htmlFor="businessName" className={cn(errors.businessName && "text-rose-500")}>
                    Tên doanh nghiệp *
                  </Label>
                  <Input
                    id="businessName"
                    placeholder="Nhập tên doanh nghiệp"
                    className={cn(errors.businessName && "border-rose-400 focus-visible:ring-rose-300")}
                    {...register("businessName")}
                  />
                  {errors.businessName && (
                    <p className="text-xs text-rose-500 mt-1">{errors.businessName.message}</p>
                  )}
                </div>

                <div>
                  <Label htmlFor="taxCode" className={cn(errors.taxCode && "text-rose-500")}>
                    Mã số thuế *
                  </Label>
                  <Input
                    id="taxCode"
                    placeholder="Nhập mã số thuế"
                    className={cn(errors.taxCode && "border-rose-400 focus-visible:ring-rose-300")}
                    {...register("taxCode")}
                  />
                  {errors.taxCode && (
                    <p className="text-xs text-rose-500 mt-1">{errors.taxCode.message}</p>
                  )}
                </div>
              </div>

              <div>
                <Label htmlFor="businessAddress" className={cn(errors.businessAddress && "text-rose-500")}>
                  Địa chỉ kinh doanh *
                </Label>
                <Input
                  id="businessAddress"
                  placeholder="Nhập địa chỉ kinh doanh"
                  className={cn(errors.businessAddress && "border-rose-400 focus-visible:ring-rose-300")}
                  {...register("businessAddress")}
                />
                {errors.businessAddress && (
                  <p className="text-xs text-rose-500 mt-1">{errors.businessAddress.message}</p>
                )}
              </div>
            </div>

            {/* Personal Information */}
            <div className="space-y-4">
              <h3 className="font-semibold text-gray-900 flex items-center gap-2">
                <User size={16} className="text-emerald-600" />
                Thông tin cá nhân
              </h3>

              <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                <div>
                  <Label htmlFor="firstName">Họ *</Label>
                  <Input
                    id="firstName"
                    value={user?.firstName || ""}
                    readOnly
                    className="bg-gray-50 text-gray-600 border-gray-200 cursor-not-allowed"
                    title="Thông tin từ tài khoản của bạn"
                  />
                </div>
                <div>
                  <Label htmlFor="lastName">Tên *</Label>
                  <Input
                    id="lastName"
                    value={user?.lastName || ""}
                    readOnly
                    className="bg-gray-50 text-gray-600 border-gray-200 cursor-not-allowed"
                    title="Thông tin từ tài khoản của bạn"
                  />
                </div>
              </div>

              <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                <div>
                  <Label htmlFor="phoneNumber">Số điện thoại *</Label>
                  <Input
                    id="phoneNumber"
                    value={user?.phoneNumber || ""}
                    readOnly
                    className="bg-gray-50 text-gray-600 border-gray-200 cursor-not-allowed"
                    title="Thông tin từ tài khoản của bạn"
                  />
                </div>
                <div>
                  <Label htmlFor="identityNumber" className={cn(errors.identityNumber && "text-rose-500")}>
                    Số CCCD/CMND *
                  </Label>
                  <Input
                    id="identityNumber"
                    placeholder="Nhập số CCCD/CMND"
                    maxLength={12}
                    className={cn(errors.identityNumber && "border-rose-400 focus-visible:ring-rose-300")}
                    {...register("identityNumber")}
                  />
                  {errors.identityNumber && (
                    <p className="text-xs text-rose-500 mt-1">{errors.identityNumber.message}</p>
                  )}
                </div>
              </div>
            </div>

            {/* Document Upload */}
            <div className="space-y-4">
              <h3 className="font-semibold text-gray-900 flex items-center gap-2">
                <FileText size={16} className="text-emerald-600" />
                Tài liệu đính kèm
              </h3>

              <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
                <FileUploadField
                  id="businessLicense"
                  label="Giấy phép kinh doanh"
                  fieldName="businessLicenseFile"
                  accept="image/*,.pdf"
                  file={watchedFiles[0]}
                  error={errors.businessLicenseFile?.message as string}
                />
                <FileUploadField
                  id="identityCardFront"
                  label="CCCD mặt trước"
                  fieldName="identityCardFrontFile"
                  accept="image/*"
                  file={watchedFiles[1]}
                  error={errors.identityCardFrontFile?.message as string}
                />
                <FileUploadField
                  id="identityCardBack"
                  label="CCCD mặt sau"
                  fieldName="identityCardBackFile"
                  accept="image/*"
                  file={watchedFiles[2]}
                  error={errors.identityCardBackFile?.message as string}
                />
              </div>
            </div>

            {/* Actions */}
            <div className="flex gap-3 pt-4">
              <Button
                type="button"
                variant="outline"
                onClick={handleClose}
                disabled={isLoading}
                className="flex-1"
              >
                Hủy
              </Button>
              <Button
                type="submit"
                disabled={isLoading}
                className="flex-1"
                style={{ background: "linear-gradient(135deg, #00C896, #00897B)" }}
              >
                {isLoading ? "Đang gửi..." : "Gửi yêu cầu đăng ký"}
              </Button>
            </div>
          </form>
        </div>
      </DialogContent>
    </Dialog>
  );
}
