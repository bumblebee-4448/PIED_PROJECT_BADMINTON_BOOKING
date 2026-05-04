import { useNavigate } from "react-router";
import { ArrowLeft, LogOut } from "lucide-react";
import { useProfile } from "../hooks/useProfile";
import { AvatarUpload } from "../components/AvatarUpload";
import { ProfileForm } from "../components/ProfileForm";
import { PasswordSection } from "../components/PasswordSection";
import { OwnerRegistrationSection } from "../components/OwnerRegistrationSection";
import { Button } from "@/shared/components/ui/button";

export function ProfilePage() {
  const navigate = useNavigate();
  const {
    user,
    logout,
    isSaving,
    isChangingPassword,
    isRegisteringOwner,
    updateProfile,
    changePassword,
    registerOwner,
  } = useProfile();

  if (!user) {
    return (
      <div className="flex flex-col items-center justify-center min-h-[60vh] px-4">
        <p className="text-gray-500 mb-4">Vui lòng đăng nhập để xem hồ sơ.</p>
        <Button
          onClick={() => navigate("/")}
          variant="default"
          className="rounded-xl font-bold px-6 py-2"
        >
          Về trang chủ
        </Button>
      </div>
    );
  }

  const initials = user.firstName && user.lastName
    ? `${user.lastName[0]}${user.firstName[0]}`
    : user.firstName ? user.firstName[0] : "U";

  const handleLogout = () => {
    logout();
    navigate("/");
  };

  return (
    <div className="max-w-xl mx-auto px-4 sm:px-6 py-6 pb-24 md:pb-8">
      {/* Header */}
      <div className="flex items-center gap-3 mb-6">
        <Button
          onClick={() => navigate(-1)}
          variant="secondary"
          size="icon"
          className="rounded-xl"
        >
          <ArrowLeft size={16} />
        </Button>
        <h1 style={{ fontWeight: 800, fontSize: "1.2rem", color: "#1a1a2e" }}>
          Hồ sơ cá nhân
        </h1>
      </div>

      {/* Avatar */}
      <AvatarUpload
        currentAvatar={user.avartarUrl || undefined}
        initials={initials}
        onAvatarChange={(url) => updateProfile({ ...user, avartarUrl: url } as any)}
      />

      {/* Basic info form */}
      <ProfileForm
        initialData={{
          firstName: user.firstName || "",
          lastName: user.lastName || "",
          email: user.email || "",
          phoneNumber: user.phoneNumber || "",
          avartarUrl: user.avartarUrl,
        }}
        onSave={updateProfile}
        isSaving={isSaving}
      />

      {/* Password change */}
      <PasswordSection
        phone={user.phoneNumber || ""}
        onUpdate={changePassword}
        isLoading={isChangingPassword}
      />

      {/* Register as owner */}
      {!user.isOwner && (
        <OwnerRegistrationSection
          onRegister={registerOwner}
          isLoading={isRegisteringOwner}
        />
      )}

      {/* Logout */}
      <Button
        onClick={handleLogout}
        variant="destructive_outline"
        className="w-full rounded-xl py-3 h-auto"
      >
        <LogOut size={16} /> Đăng xuất
      </Button>
    </div>
  );
}

export default ProfilePage;