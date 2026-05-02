import { useState } from "react";
import { ChevronRight, Eye, EyeOff } from "lucide-react";
import type { PasswordChangeSchema } from "../schema";
import { Button } from "@/shared/components/ui/button";

interface PasswordSectionProps {
  phone: string;
  onUpdate: (data: PasswordChangeSchema) => void;
  isLoading: boolean;
}

export function PasswordSection({ phone, onUpdate, isLoading }: PasswordSectionProps) {
  const [showSection, setShowSection] = useState(false);
  const [otpSent, setOtpSent] = useState(false);
  const [otp, setOtp] = useState("");
  const [newPass, setNewPass] = useState("");
  const [showPass, setShowPass] = useState(false);
  const [otpTimer, setOtpTimer] = useState(0);
  const [otpCount, setOtpCount] = useState(0);

  const handleSendOtp = () => {
    if (otpCount >= 5) return;
    setOtpSent(true);
    setOtpCount((c) => c + 1);
    setOtpTimer(60);
    const t = setInterval(() => {
      setOtpTimer((v) => {
        if (v <= 1) {
          clearInterval(t);
          return 0;
        }
        return v - 1;
      });
    }, 1000);
  };

  const handleConfirm = () => {
    onUpdate({ otp, newPassword: newPass });
  };

  return (
    <div className="bg-white rounded-2xl overflow-hidden mb-4" style={{ border: "1px solid rgba(0,0,0,0.07)" }}>
      <Button
        variant="ghost"
        onClick={() => setShowSection(!showSection)}
        className="w-full flex items-center justify-between px-5 py-4 h-auto rounded-none hover:bg-gray-50 transition"
      >
        <div className="flex items-center gap-3">
          <div className="w-8 h-8 rounded-lg flex items-center justify-center" style={{ background: "#f0fdf9" }}>🔒</div>
          <span style={{ fontWeight: 700, fontSize: "0.9rem", color: "#1a1a2e" }}>Đổi mật khẩu</span>
        </div>
        <ChevronRight
          size={16}
          className="text-gray-400"
          style={{ transform: showSection ? "rotate(90deg)" : "none", transition: "0.2s" }}
        />
      </Button>
      {showSection && (
        <div className="px-5 pb-5 border-t border-gray-50">
          <p style={{ fontSize: "0.8rem", color: "#9ca3af", margin: "12px 0 14px" }}>
            OTP sẽ được gửi qua số điện thoại <strong>{phone}</strong>. Tối đa 5 lần/ngày.
          </p>
          {!otpSent ? (
            <Button
              onClick={handleSendOtp}
              disabled={otpCount >= 5}
              variant={otpCount >= 5 ? "secondary" : "gradient"}
              className="w-full py-2.5 rounded-xl text-sm font-bold"
            >
              {otpCount >= 5 ? "Đã đạt giới hạn 5 lần/ngày" : "Gửi OTP qua SĐT"}
            </Button>
          ) : (
            <div className="flex flex-col gap-3">
              <div className="flex gap-2">
                <input
                  value={otp}
                  onChange={(e) => setOtp(e.target.value)}
                  placeholder="Nhập mã OTP (6 số)"
                  maxLength={6}
                  className="flex-1 px-3 py-2.5 rounded-xl outline-none text-sm text-center font-bold tracking-widest"
                  style={{ border: "1.5px solid #e5e7eb", background: "#f9fafb", fontSize: "1.1rem" }}
                />
                <Button
                  onClick={otpTimer === 0 ? handleSendOtp : undefined}
                  disabled={otpTimer > 0}
                  variant="secondary"
                  className="px-3 py-2.5 rounded-xl text-xs font-semibold"
                  style={{ color: otpTimer > 0 ? "#9ca3af" : "#00897B" }}
                >
                  {otpTimer > 0 ? `${otpTimer}s` : "Gửi lại"}
                </Button>
              </div>
              <div className="relative">
                <input
                  type={showPass ? "text" : "password"}
                  value={newPass}
                  onChange={(e) => setNewPass(e.target.value)}
                  placeholder="Mật khẩu mới"
                  className="w-full pr-10 px-3 py-2.5 rounded-xl outline-none text-sm"
                  style={{ border: "1.5px solid #e5e7eb", background: "#f9fafb" }}
                />
                <Button
                  type="button"
                  variant="ghost"
                  size="icon"
                  onClick={() => setShowPass(!showPass)}
                  className="absolute right-3 top-1/2 -translate-y-1/2 text-gray-400 hover:bg-transparent"
                >
                  {showPass ? <EyeOff size={15} /> : <Eye size={15} />}
                </Button>
              </div>
              <Button
                onClick={handleConfirm}
                disabled={isLoading}
                variant="gradient"
                className="w-full py-2.5 rounded-xl text-sm font-bold"
              >
                {isLoading ? "Đang xử lý..." : "Xác nhận đổi mật khẩu"}
              </Button>
              <p style={{ fontSize: "0.72rem", color: "#9ca3af", textAlign: "center" }}>
                Đã dùng {otpCount}/5 lần OTP hôm nay
              </p>
            </div>
          )}
        </div>
      )}
    </div>
  );
}
