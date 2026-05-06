import { useState } from "react";
import { 
  Dialog, 
  DialogContent, 
  DialogHeader, 
  DialogTitle, 
  DialogDescription 
} from "@/shared/components/ui/dialog";
import { AvatarUpload } from "./AvatarUpload";
import { ProfileForm } from "./ProfileForm";
import { PasswordSection } from "./PasswordSection";
import { useProfile } from "../hooks/useProfile";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/shared/components/ui/tabs";
import { User, Lock } from "lucide-react";

interface EditProfileDialogProps {
  isOpen: boolean;
  onOpenChange: (open: boolean) => void;
}

export function EditProfileDialog({ isOpen, onOpenChange }: EditProfileDialogProps) {
  const {
    user,
    isSaving,
    isChangingPassword,
    updateProfile,
    changePassword,
  } = useProfile();

  // State local để giữ thông tin đang sửa, tránh bị reset khi refetch data
  const [localAvatar, setLocalAvatar] = useState<string | null>(null);

  if (!user) return null;

  const initials =
    user.firstName && user.lastName
      ? `${user.lastName[0]}${user.firstName[0]}`
      : user.firstName
        ? user.firstName[0]
        : "U";

  const handleSaveProfile = async (data: any) => {
    // Kết hợp dữ liệu form với ảnh mới (nếu có)
    await updateProfile({
      ...data,
      avatarUrl: localAvatar || user.avatarUrl,
    });
    setLocalAvatar(null); // Reset sau khi lưu thành công
  };

  return (
    <Dialog open={isOpen} onOpenChange={onOpenChange}>
      <DialogContent className="max-w-2xl rounded-3xl p-0 border-none shadow-2xl overflow-hidden">
        <div className="bg-[#004E43] p-8 text-white">
          <DialogHeader className="text-left p-0">
            <DialogTitle className="text-2xl font-black">Cập nhật tài khoản</DialogTitle>
            <DialogDescription className="text-white/70 font-medium pt-1">
              Quản lý thông tin cá nhân và cài đặt bảo mật của bạn
            </DialogDescription>
          </DialogHeader>
        </div>

        <div className="p-6">
          <Tabs defaultValue="basic" className="w-full">
            <TabsList className="grid w-full grid-cols-2 mb-8 bg-gray-100 p-1 rounded-2xl h-12">
              <TabsTrigger 
                value="basic" 
                className="rounded-xl font-bold data-[state=active]:bg-white data-[state=active]:text-[#004E43] data-[state=active]:shadow-sm flex items-center gap-2"
              >
                <User size={16} />
                Thông tin cơ bản
              </TabsTrigger>
              <TabsTrigger 
                value="password" 
                className="rounded-xl font-bold data-[state=active]:bg-white data-[state=active]:text-[#004E43] data-[state=active]:shadow-sm flex items-center gap-2"
              >
                <Lock size={16} />
                Đổi mật khẩu
              </TabsTrigger>
            </TabsList>

            <TabsContent value="basic" className="space-y-6 mt-0 outline-none">
              <div className="flex flex-col md:flex-row gap-8 items-start">
                <div className="shrink-0 mx-auto md:mx-0">
                  <AvatarUpload
                    currentAvatar={localAvatar || user.avatarUrl || undefined}
                    initials={initials}
                    onAvatarChange={setLocalAvatar}
                  />
                </div>
                
                <div className="flex-1 w-full">
                  <ProfileForm
                    key={`${user.firstName}-${user.lastName}-${user.phoneNumber}`}
                    initialData={{
                      firstName: user.firstName || "",
                      lastName: user.lastName || "",
                      email: user.email || "",
                      phoneNumber: user.phoneNumber || "",
                      avatarUrl: localAvatar || user.avatarUrl,
                    }}
                    onSave={handleSaveProfile}
                    isSaving={isSaving}
                  />
                </div>
              </div>
            </TabsContent>

            <TabsContent value="password" className="mt-0 outline-none">
              <PasswordSection
                onUpdate={changePassword}
                isLoading={isChangingPassword}
              />
            </TabsContent>
          </Tabs>
        </div>
      </DialogContent>
    </Dialog>
  );
}
