import React from "react";
import { Timer } from "lucide-react";

interface OtpTimerProps {
  timer: number;
  onResend: () => void;
}

export const OtpTimer: React.FC<OtpTimerProps> = ({ timer, onResend }) => {
  return (
    <div className="text-center">
      {timer > 0 ? (
        <p className="text-[#9CA3AF] text-sm font-medium flex items-center justify-center gap-2">
          <Timer size={16} />
          Gửi lại mã sau <span className="text-[#00CE98] font-bold">{timer}s</span>
        </p>
      ) : (
        <button 
          onClick={onResend}
          className="text-[#00CE98] font-black text-sm hover:underline hover:text-[#004E43] transition-all"
        >
          Gửi lại mã OTP
        </button>
      )}
    </div>
  );
};
