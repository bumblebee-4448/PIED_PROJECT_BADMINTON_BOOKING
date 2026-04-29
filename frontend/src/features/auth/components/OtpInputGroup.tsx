import React from "react";

interface OtpInputGroupProps {
  otp: string[];
  onChange: (index: number, value: string) => void;
  onKeyDown: (index: number, e: React.KeyboardEvent) => void;
  onPaste: (e: React.ClipboardEvent) => void;
}

export const OtpInputGroup: React.FC<OtpInputGroupProps> = ({
  otp,
  onChange,
  onKeyDown,
  onPaste,
}) => {
  return (
    <div className="flex justify-center gap-2 md:gap-3 mb-10">
      {otp.map((digit, index) => (
        <input
          key={index}
          id={`otp-${index}`}
          type="text"
          value={digit}
          onChange={(e) => onChange(index, e.target.value)}
          onKeyDown={(e) => onKeyDown(index, e)}
          onPaste={onPaste}
          className="w-12 h-14 md:w-14 md:h-16 text-center text-2xl font-black text-[#004E43] bg-white border-2 border-[#E5E7EB] rounded-2xl focus:border-[#00CE98] focus:ring-4 focus:ring-[#00CE98]/10 transition-all outline-none shadow-sm"
          maxLength={1}
          autoComplete="one-time-code"
        />
      ))}
    </div>
  );
};
