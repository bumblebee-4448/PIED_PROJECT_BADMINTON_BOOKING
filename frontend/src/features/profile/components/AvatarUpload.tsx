import { useRef, useState, useEffect, type ChangeEvent } from "react";
import { Camera, AlertCircle } from "lucide-react";
import { Button } from "@/shared/components/ui/button";

interface AvatarUploadProps {
  currentAvatar?: string;
  initials: string;
  onAvatarChange: (base64: string) => void;
}

const MAX_AVATAR_SIZE = 2 * 1024 * 1024; // 2MB
const ALLOWED_TYPES = ["image/jpeg", "image/png", "image/webp"];

export function AvatarUpload({ currentAvatar, initials, onAvatarChange }: AvatarUploadProps) {
  const fileRef = useRef<HTMLInputElement>(null);
  const [avatar, setAvatar] = useState(currentAvatar || "");
  const [error, setError] = useState("");

  useEffect(() => {
    setAvatar(currentAvatar || "");
  }, [currentAvatar]);

  const handleFileChange = (e: ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (!file) return;

    setError("");
    if (!ALLOWED_TYPES.includes(file.type)) {
      setError("Chỉ chấp nhận file JPG, PNG hoặc WEBP");
      return;
    }
    if (file.size > MAX_AVATAR_SIZE) {
      setError("Kích thước ảnh tối đa 2MB");
      return;
    }

    const reader = new FileReader();
    reader.onload = (ev) => {
      const base64 = ev.target?.result as string;
      setAvatar(base64);
      onAvatarChange(base64);
    };
    reader.readAsDataURL(file);
  };

  return (
    <div className="flex flex-col items-center mb-6">
      <div className="relative">
        <div
          className="w-24 h-24 rounded-2xl overflow-hidden flex items-center justify-center"
          style={{ background: avatar ? "transparent" : "linear-gradient(135deg,#00C896,#00897B)" }}
        >
          {avatar ? (
            <img src={avatar} alt="avatar" className="w-full h-full object-cover" />
          ) : (
            <span style={{ fontSize: "2rem", fontWeight: 800, color: "white" }}>{initials}</span>
          )}
        </div>
        <Button
          onClick={() => fileRef.current?.click()}
          variant="gradient"
          size="icon"
          className="absolute -bottom-2 -right-2 w-8 h-8 rounded-xl shadow-md"
        >
          <Camera size={14} color="white" />
        </Button>
      </div>
      <input
        ref={fileRef}
        type="file"
        accept="image/jpeg,image/png,image/webp"
        className="hidden"
        onChange={handleFileChange}
      />
      {error && (
        <div className="mt-2 flex items-center gap-1.5 text-xs" style={{ color: "#DC2626" }}>
          <AlertCircle size={12} /> {error}
        </div>
      )}
      <p style={{ color: "#9ca3af", fontSize: "0.75rem", marginTop: "8px" }}>JPG, PNG, WEBP • Tối đa 2MB</p>
    </div>
  );
}
