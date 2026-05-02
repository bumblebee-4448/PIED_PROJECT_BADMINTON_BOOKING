import {
  AreaChart,
  Area,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  ResponsiveContainer,
} from "recharts";
import type { VisitorData } from "../types";

interface VisitorChartProps {
  data: VisitorData[];
  visitorsToday: number;
  visitorsThisWeek: number;
}

const CustomTooltip = ({ active, payload, label }: any) => {
  if (!active || !payload?.length) return null;
  return (
    <div
      className="bg-white rounded-xl px-3 py-2 shadow-lg"
      style={{ border: "1px solid #e5e7eb" }}
    >
      <p
        style={{
          fontSize: "0.72rem",
          fontWeight: 700,
          color: "#1a1a2e",
          marginBottom: "4px",
        }}
      >
        {label}
      </p>
      {payload.map((p: any) => (
        <p key={p.name} style={{ fontSize: "0.7rem", color: p.color }}>
          {p.name}:{" "}
          <strong>
            {typeof p.value === "number" && p.value > 100
              ? p.value.toLocaleString()
              : p.value}
          </strong>
        </p>
      ))}
    </div>
  );
};

export function VisitorChart({
  data,
  visitorsToday,
  visitorsThisWeek,
}: VisitorChartProps) {
  return (
    <div
      className="lg:col-span-2 bg-white rounded-2xl p-5"
      style={{ border: "1px solid rgba(0,0,0,0.06)" }}
    >
      <div className="mb-4">
        <h3 style={{ fontWeight: 700, color: "#1a1a2e", fontSize: "0.95rem" }}>
          Lượt truy cập hệ thống
        </h3>
        <div className="flex gap-4 mt-2">
          <div>
            <p
              style={{ fontWeight: 800, fontSize: "1.3rem", color: "#6366F1" }}
            >
              {visitorsToday.toLocaleString()}
            </p>
            <p style={{ fontSize: "0.7rem", color: "#9ca3af" }}>Hôm nay</p>
          </div>
          <div>
            <p
              style={{ fontWeight: 800, fontSize: "1.3rem", color: "#00897B" }}
            >
              {visitorsThisWeek.toLocaleString()}
            </p>
            <p style={{ fontSize: "0.7rem", color: "#9ca3af" }}>Tuần này</p>
          </div>
        </div>
      </div>
      <ResponsiveContainer width="100%" height={200}>
        <AreaChart data={data}>
          <defs>
            <linearGradient id="visitGrad" x1="0" y1="0" x2="0" y2="1">
              <stop offset="5%" stopColor="#6366F1" stopOpacity={0.2} />
              <stop offset="95%" stopColor="#6366F1" stopOpacity={0} />
            </linearGradient>
          </defs>
          <CartesianGrid strokeDasharray="3 3" stroke="#f3f4f6" />
          <XAxis
            dataKey="day"
            tick={{ fontSize: 10, fill: "#9ca3af" }}
            axisLine={false}
            tickLine={false}
          />
          <YAxis
            tick={{ fontSize: 10, fill: "#9ca3af" }}
            axisLine={false}
            tickLine={false}
            tickFormatter={(v: number) => `${(v / 1000).toFixed(1)}K`}
          />
          <Tooltip content={<CustomTooltip />} />
          <Area
            type="monotone"
            dataKey="visitors"
            name="Lượt truy cập"
            stroke="#6366F1"
            strokeWidth={2.5}
            fill="url(#visitGrad)"
          />
        </AreaChart>
      </ResponsiveContainer>
    </div>
  );
}
