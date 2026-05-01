import React from "react";
import { Button } from "@/shared/components/ui/button";
import { OtpInputGroup } from "./OtpInputGroup";
import { OtpTimer } from "./OtpTimer";
import { useOtpInput, useOtpTimer, useVerifyOtp } from "../hooks";
import { toast } from "sonner";

interface VerifyOtpFormProps {
  email: string;
}

export const VerifyOtpForm: React.FC<VerifyOtpFormProps> = ({ email }) => {
  const { otp, handleChange, handleKeyDown, handlePaste, getOtpValue } = useOtpInput(6);
  const { timer, resetTimer } = useOtpTimer(60);
  const verifyMutation = useVerifyOtp();

  const handleSubmit = async () => {
    const otpCode = getOtpValue();
    if (otpCode.length < 6) {
      toast.error("Vui lòng nhập đủ 6 ký tự");
      return;
    }

    verifyMutation.mutate({ email, otp: otpCode });
  };

  const handleResend = () => {
    // Logic for resending OTP can be added here
    toast.info("Đã gửi lại mã OTP mới!");
    resetTimer();
  };

  return (
    <>
      <OtpInputGroup
        otp={otp}
        onChange={handleChange}
        onKeyDown={handleKeyDown}
        onPaste={handlePaste}
      />

      <Button
        onClick={handleSubmit}
        disabled={verifyMutation.isPending}
        className="w-full h-14 rounded-2xl text-white font-extrabold text-lg shadow-lg hover:shadow-[#00CE98]/40 transition-all duration-300 active:scale-[0.98] mb-6"
        style={{ background: "linear-gradient(to right, #004E43, #00CE98)" }}
      >
        {verifyMutation.isPending ? "Đang xác thực..." : "Xác nhận ngay"}
      </Button>

      <OtpTimer timer={timer} onResend={handleResend} />
    </>
  );
};
