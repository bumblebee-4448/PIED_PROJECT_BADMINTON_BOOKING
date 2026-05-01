import { useState, useEffect, useCallback } from "react";

export const useOtpTimer = (initialSeconds: number = 60) => {
  const [timer, setTimer] = useState(initialSeconds);

  useEffect(() => {
    let interval: ReturnType<typeof setInterval> | undefined;
    if (timer > 0) {
      interval = setInterval(() => {
        setTimer((prev) => prev - 1);
      }, 1000);
    }
    return () => {
      if (interval) clearInterval(interval);
    };
  }, [timer]);

  const resetTimer = useCallback(() => {
    setTimer(initialSeconds);
  }, [initialSeconds]);

  return {
    timer,
    resetTimer,
    isExpired: timer === 0
  };
};
