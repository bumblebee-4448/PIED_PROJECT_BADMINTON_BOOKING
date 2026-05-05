import { useState } from "react";
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
import { useOwnerRegistration } from "../hooks/useOwnerRegistration";
import { useOwnerRegistrationStore } from "../store";
import type { OwnerRegistrationForm } from "../types";

// Type cho field người dùng tự nhập (không bao gồm read-only fields từ user)
type EditableFormData = Omit<
  OwnerRegistrationForm,
  "firstName" | "lastName" | "phoneNumber"
>;

export function OwnerRegistrationDialog() {
  const { isDialogOpen, setDialogOpen } = useOwnerRegistrationStore();
  const { registerOwner, isLoading } = useOwnerRegistration();
  const { user } = useAuthStore();

  // State chỉ giữ field người dùng tự nhập
  const [formData, setFormData] = useState<EditableFormData>({
    businessName: "",
    taxCode: "",
    businessAddress: "",
    identityNumber: "",
    businessLicenseFile: null,
    identityCardFrontFile: null,
    identityCardBackFile: null,
  });

  const handleInputChange = (field: keyof EditableFormData, value: string) => {
    setFormData((prev) => ({ ...prev, [field]: value }));
  };

  const handleFileChange = (
    field: keyof EditableFormData,
    file: File | null,
  ) => {
    setFormData((prev) => ({ ...prev, [field]: file }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    // Validation - kiểm tra field người dùng tự nhập
    const requiredFields: (keyof EditableFormData)[] = [
      "businessName",
      "taxCode",
      "businessAddress",
      "identityNumber",
      "businessLicenseFile",
      "identityCardFrontFile",
      "identityCardBackFile",
    ];

    for (const field of requiredFields) {
      const value = formData[field];
      if (!value || (typeof value === "string" && value.trim() === "")) {
        alert(
          "Vui lòng điền đầy đủ thông tin và tải lên tất cả các tài liệu cần thiết.",
        );
        return;
      }
    }

    // Kiểm tra user data có sẵn không
    if (!user?.firstName || !user?.lastName || !user?.phoneNumber) {
      alert("Thông tin tài khoản không đầy đủ. Vui lòng cập nhật hồ sơ trước.");
      return;
    }

    // Merge với user data để gửi đầy đủ field backend yêu cầu
    const completeData: OwnerRegistrationForm = {
      ...formData,
      firstName: user?.firstName || "",
      lastName: user?.lastName || "",
      phoneNumber: user?.phoneNumber || "",
    };
    registerOwner(completeData);
  };

  const handleClose = () => {
    if (!isLoading) {
      setDialogOpen(false);
    }
  };

  return (
    <Dialog open={isDialogOpen} onOpenChange={handleClose}>
      <DialogContent className="max-w-2xl max-h-[90vh] overflow-y-auto">
        <DialogHeader>
          <DialogTitle className="flex items-center gap-3 text-xl font-bold">
            <div className="w-10 h-10 rounded-xl flex items-center justify-center bg-emerald-50">
              <Building2 className="text-emerald-600" size={20} />
            </div>
            Đăng ký trở thành chủ sân
          </DialogTitle>
        </DialogHeader>

        <form onSubmit={handleSubmit} className="space-y-6">
          {/* Business Information */}
          <div className="space-y-4">
            <h3 className="font-semibold text-gray-900 flex items-center gap-2">
              <Building2 size={16} className="text-emerald-600" />
              Thông tin doanh nghiệp
            </h3>

            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
              <div>
                <Label htmlFor="businessName">Tên doanh nghiệp *</Label>
                <Input
                  id="businessName"
                  value={formData.businessName}
                  onChange={(e) =>
                    handleInputChange("businessName", e.target.value)
                  }
                  placeholder="Nhập tên doanh nghiệp"
                  required
                />
              </div>

              <div>
                <Label htmlFor="taxCode">Mã số thuế *</Label>
                <Input
                  id="taxCode"
                  value={formData.taxCode}
                  onChange={(e) => handleInputChange("taxCode", e.target.value)}
                  placeholder="Nhập mã số thuế"
                  required
                />
              </div>
            </div>

            <div>
              <Label htmlFor="businessAddress">Địa chỉ kinh doanh *</Label>
              <Input
                id="businessAddress"
                value={formData.businessAddress}
                onChange={(e) =>
                  handleInputChange("businessAddress", e.target.value)
                }
                placeholder="Nhập địa chỉ kinh doanh"
                required
              />
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
                <Label htmlFor="identityNumber">Số CCCD/CMND *</Label>
                <Input
                  id="identityNumber"
                  value={formData.identityNumber}
                  onChange={(e) =>
                    handleInputChange("identityNumber", e.target.value)
                  }
                  placeholder="Nhập số CCCD/CMND"
                  required
                />
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
              <div>
                <Label>Giấy phép kinh doanh *</Label>
                <div className="mt-2">
                  <input
                    type="file"
                    id="businessLicense"
                    accept="image/*,.pdf"
                    onChange={(e) =>
                      handleFileChange(
                        "businessLicenseFile",
                        e.target.files?.[0] || null,
                      )
                    }
                    className="hidden"
                    required
                  />
                  <label
                    htmlFor="businessLicense"
                    className="flex flex-col items-center justify-center w-full h-32 border-2 border-dashed border-gray-300 rounded-lg cursor-pointer hover:border-emerald-400 transition-colors bg-gray-50 hover:bg-emerald-50"
                  >
                    {formData.businessLicenseFile ? (
                      <div className="text-center">
                        <FileText
                          size={24}
                          className="text-emerald-600 mx-auto mb-2"
                        />
                        <p className="text-sm text-gray-700 truncate max-w-full">
                          {formData.businessLicenseFile.name}
                        </p>
                      </div>
                    ) : (
                      <div className="text-center">
                        <Upload
                          size={24}
                          className="text-gray-400 mx-auto mb-2"
                        />
                        <p className="text-sm text-gray-500">
                          Tải lên giấy phép
                        </p>
                      </div>
                    )}
                  </label>
                </div>
              </div>

              <div>
                <Label>CCCD mặt trước *</Label>
                <div className="mt-2">
                  <input
                    type="file"
                    id="identityCardFront"
                    accept="image/*"
                    onChange={(e) =>
                      handleFileChange(
                        "identityCardFrontFile",
                        e.target.files?.[0] || null,
                      )
                    }
                    className="hidden"
                    required
                  />
                  <label
                    htmlFor="identityCardFront"
                    className="flex flex-col items-center justify-center w-full h-32 border-2 border-dashed border-gray-300 rounded-lg cursor-pointer hover:border-emerald-400 transition-colors bg-gray-50 hover:bg-emerald-50"
                  >
                    {formData.identityCardFrontFile ? (
                      <div className="text-center">
                        <FileText
                          size={24}
                          className="text-emerald-600 mx-auto mb-2"
                        />
                        <p className="text-sm text-gray-700 truncate max-w-full">
                          {formData.identityCardFrontFile.name}
                        </p>
                      </div>
                    ) : (
                      <div className="text-center">
                        <Upload
                          size={24}
                          className="text-gray-400 mx-auto mb-2"
                        />
                        <p className="text-sm text-gray-500">
                          Tải lên CCCCD trước
                        </p>
                      </div>
                    )}
                  </label>
                </div>
              </div>

              <div>
                <Label>CCCD mặt sau *</Label>
                <div className="mt-2">
                  <input
                    type="file"
                    id="identityCardBack"
                    accept="image/*"
                    onChange={(e) =>
                      handleFileChange(
                        "identityCardBackFile",
                        e.target.files?.[0] || null,
                      )
                    }
                    className="hidden"
                    required
                  />
                  <label
                    htmlFor="identityCardBack"
                    className="flex flex-col items-center justify-center w-full h-32 border-2 border-dashed border-gray-300 rounded-lg cursor-pointer hover:border-emerald-400 transition-colors bg-gray-50 hover:bg-emerald-50"
                  >
                    {formData.identityCardBackFile ? (
                      <div className="text-center">
                        <FileText
                          size={24}
                          className="text-emerald-600 mx-auto mb-2"
                        />
                        <p className="text-sm text-gray-700 truncate max-w-full">
                          {formData.identityCardBackFile.name}
                        </p>
                      </div>
                    ) : (
                      <div className="text-center">
                        <Upload
                          size={24}
                          className="text-gray-400 mx-auto mb-2"
                        />
                        <p className="text-sm text-gray-500">
                          Tải lên CCCCD sau
                        </p>
                      </div>
                    )}
                  </label>
                </div>
              </div>
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
              style={{
                background: "linear-gradient(135deg, #00C896, #00897B)",
              }}
            >
              {isLoading ? "Đang gửi..." : "Gửi yêu cầu đăng ký"}
            </Button>
          </div>
        </form>
      </DialogContent>
    </Dialog>
  );
}
