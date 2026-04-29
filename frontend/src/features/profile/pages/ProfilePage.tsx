import { useNavigate } from "react-router";
import { ArrowLeft, LogOut } from "lucide-react";
import { useProfile } from "../hooks/useProfile";
import { AvatarUpload } from "../components/AvatarUpload";
import { ProfileForm } from "../components/ProfileForm";
import { PasswordSection } from "../components/PasswordSection";
import { OwnerRegistrationSection } from "../components/OwnerRegistrationSection";

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
        <button
          onClick={() => navigate("/")}
          className="px-6 py-2 bg-emerald-500 text-white rounded-xl font-bold"
        >
          Về trang chủ
        </button>
      </div>
    );
  }

  const initials = user.name
    ? user.name.split(" ").map((n) => n[0]).slice(-2).join("")
    : "U";

  const handleLogout = () => {
    logout();
    navigate("/");
  };

  return (
    <div className="max-w-xl mx-auto px-4 sm:px-6 py-6 pb-24 md:pb-8">
      {/* Header */}
      <div className="flex items-center gap-3 mb-6">
        <button
          onClick={() => navigate(-1)}
          className="w-9 h-9 rounded-xl flex items-center justify-center"
          style={{ background: "#f3f4f6" }}
        >
          <ArrowLeft size={16} />
        </button>
        <h1 style={{ fontWeight: 800, fontSize: "1.2rem", color: "#1a1a2e" }}>
          Hồ sơ cá nhân
        </h1>
      </div>

      {/* Avatar */}
      <AvatarUpload
        currentAvatar={user.avatar}
        initials={initials}
        onAvatarChange={(base64) => updateProfile({ ...user, avatar: base64 } as any)}
      />

      {/* Basic info form */}
      <ProfileForm
        initialData={{
          name: user.name || "",
          email: user.email || "",
          phone: user.phone || "",
          location: (user as any).preferredLocation || "Tân Bình",
          level: (user as any).level || "intermediate",
        }}
        onSave={updateProfile}
        isSaving={isSaving}
      />

      {/* Password change */}
      <PasswordSection
        phone={user.phone || ""}
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
      <button
        onClick={handleLogout}
        className="w-full flex items-center justify-center gap-2 py-3 rounded-xl text-sm font-semibold transition hover:bg-red-50"
        style={{ background: "#FEF2F2", color: "#DC2626", border: "1.5px solid #FECACA" }}
      >
        <LogOut size={16} /> Đăng xuất
      </button>
    </div>
  );
}

export default ProfilePage;