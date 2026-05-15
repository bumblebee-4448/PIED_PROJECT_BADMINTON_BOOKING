import type { ReactNode } from "react";

interface CourtDetailItemProps {
  icon: ReactNode;
  iconClassName: string;
  label: string;
  value: string;
}

export function CourtDetailItem({
  icon,
  iconClassName,
  label,
  value,
}: CourtDetailItemProps) {
  return (
    <div className="flex items-start gap-4 rounded-2xl border border-gray-100 bg-white p-5 shadow-sm">
      <div className={`rounded-xl p-3 ${iconClassName}`}>{icon}</div>
      <div>
        <p className="mb-1 text-[10px] font-black uppercase tracking-[0.2em] text-gray-400">
          {label}
        </p>
        <p className="text-sm font-black leading-6 text-[#0B2421]">{value}</p>
      </div>
    </div>
  );
}
