import React, { useState, useCallback } from "react";

export const useOtpInput = (length: number = 6) => {
  const [otp, setOtp] = useState<string[]>(new Array(length).fill(""));

  const handleChange = useCallback((index: number, value: string) => {
    const newOtp = [...otp];
    
    if (value) {
      const char = value.slice(-1).toUpperCase();
      newOtp[index] = char;
      setOtp(newOtp);

      // Auto focus next
      if (index < length - 1) {
        document.getElementById(`otp-${index + 1}`)?.focus();
      }
    } else {
      newOtp[index] = "";
      setOtp(newOtp);
    }
  }, [otp, length]);

  const handleKeyDown = useCallback((index: number, e: React.KeyboardEvent) => {
    if (e.key === "Backspace") {
      if (!otp[index] && index > 0) {
        const prevInput = document.getElementById(`otp-${index - 1}`) as HTMLInputElement;
        if (prevInput) {
          prevInput.focus();
          const newOtp = [...otp];
          newOtp[index - 1] = "";
          setOtp(newOtp);
        }
      }
    }
  }, [otp]);

  const handlePaste = useCallback((e: React.ClipboardEvent) => {
    e.preventDefault();
    const pasteData = e.clipboardData.getData("text").slice(0, length).toUpperCase();
    const newOtp = [...otp];
    
    pasteData.split("").forEach((char, i) => {
      if (i < length) newOtp[i] = char;
    });
    
    setOtp(newOtp);
    
    const nextIndex = Math.min(pasteData.length, length - 1);
    document.getElementById(`otp-${nextIndex}`)?.focus();
  }, [otp, length]);

  const getOtpValue = useCallback(() => otp.join(""), [otp]);

  return {
    otp,
    handleChange,
    handleKeyDown,
    handlePaste,
    getOtpValue,
    isComplete: otp.join("").length === length
  };
};
