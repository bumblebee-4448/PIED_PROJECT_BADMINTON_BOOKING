import React from "react";

interface SectionHeaderProps {
  badge: string;
  title: React.ReactNode;
  subtitle?: string;
  centered?: boolean;
}

export const SectionHeader: React.FC<SectionHeaderProps> = ({
  badge,
  title,
  subtitle,
  centered = true,
}) => {
  return (
    <div className={`${centered ? "text-center" : "text-left"} mb-16`}>
      <div
        className="inline-flex items-center gap-2 px-4 py-2 rounded-full mb-4"
        style={{
          background: "rgba(0,200,150,0.1)",
          border: "1px solid rgba(0,200,150,0.2)",
        }}
      >
        <span
          style={{ color: "#00897B", fontWeight: 600, fontSize: "0.85rem" }}
        >
          {badge}
        </span>
      </div>
      <h2
        style={{
          fontSize: "clamp(1.8rem, 3.5vw, 2.8rem)",
          fontWeight: 800,
          color: "#1a1a2e",
          lineHeight: 1.3,
        }}
      >
        {title}
      </h2>
      {subtitle && (
        <p
          style={{
            color: "#6b7280",
            marginTop: "12px",
            fontSize: "1.05rem",
            maxWidth: centered ? "520px" : "100%",
            margin: centered ? "12px auto 0" : "12px 0 0",
          }}
        >
          {subtitle}
        </p>
      )}
    </div>
  );
};
