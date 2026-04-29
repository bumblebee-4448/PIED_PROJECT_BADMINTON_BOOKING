import React from "react";

interface StatCardProps {
  label: string;
  value: string | number;
  icon: React.ReactNode;
  color: string;
  sub?: string;
  onClick?: () => void;
}

export function StatCard({ label, value, icon, color, sub, onClick }: StatCardProps) {
  return (
    <div 
      onClick={onClick} 
      className={`bg-white rounded-2xl p-5 ${onClick ? "cursor-pointer hover:shadow-md transition" : ""}`} 
      style={{ border: "1px solid rgba(0,0,0,0.06)" }}
    >
      <div className="flex items-start justify-between mb-2">
        <span style={{ fontSize: "0.75rem", color: "#9ca3af", fontWeight: 600 }}>{label}</span>
        <div className="w-9 h-9 rounded-xl flex items-center justify-center" style={{ background: `${color}18` }}>
          {icon}
        </div>
      </div>
      <p style={{ fontWeight: 900, fontSize: "1.6rem", color: "#1a1a2e", lineHeight: 1 }}>{value}</p>
      {sub && <p style={{ fontSize: "0.7rem", color: "#9ca3af", marginTop: "4px" }}>{sub}</p>}
    </div>
  );
}
