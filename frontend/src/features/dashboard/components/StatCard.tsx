import React from "react";

interface StatCardProps {
  label: string;
  value: string | number;
  icon: React.ReactNode;
  color: string;
  trend?: boolean;
  sub?: string;
  onClick?: () => void;
}

export function StatCard({ label, value, icon, color, sub, onClick, trend }: StatCardProps) {
  return (
    <div 
      onClick={onClick} 
      className={`bg-white rounded-2xl p-5 ${onClick ? "cursor-pointer hover:shadow-md transition" : ""} flex flex-col gap-2`} 
      style={{ border: "1px solid rgba(0,0,0,0.06)" }}
    >
      <div className="flex items-center justify-between">
        <span style={{ fontSize: "0.78rem", color: "#6b7280", fontWeight: 600 }}>{label}</span>
        <div className="w-9 h-9 rounded-xl flex items-center justify-center" style={{ background: `${color}15` }}>
          {icon}
        </div>
      </div>
      <p style={{ fontWeight: 900, fontSize: "1.5rem", color: "#1a1a2e" }}>{value}</p>
      {sub && (
        <div className="flex items-center gap-1 mt-1">
          {trend && <span style={{ color: "#10B981" }}>↗</span>}
          <span style={{ fontSize: "0.72rem", color: trend ? "#10B981" : "#9ca3af", fontWeight: trend ? 600 : 400 }}>{sub}</span>
        </div>
      )}
    </div>
  );
}
