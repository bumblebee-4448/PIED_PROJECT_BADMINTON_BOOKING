import {
  AreaChart,
  Area,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  ResponsiveContainer,
} from "recharts";
import type { StatPoint } from "../services/adminDashboardService";

interface AdminTimelineChartProps {
  title: string;
  data: StatPoint[];
  color: string;
  gradientId: string;
  currentTotal: number;
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
            {typeof p.value === "number" ? p.value.toLocaleString() : p.value}
          </strong>
        </p>
      ))}
    </div>
  );
};

export function AdminTimelineChart({
  title,
  data,
  color,
  gradientId,
  currentTotal,
}: AdminTimelineChartProps) {
  return (
    <div
      className="bg-white rounded-2xl p-6 shadow-sm border border-gray-100 flex flex-col h-full transition-all hover:shadow-md"
    >
      <div className="mb-6 flex items-baseline justify-between">
        <div>
          <h3 className="text-gray-400 text-[10px] font-black uppercase tracking-[0.2em] mb-1">
            {title}
          </h3>
          <p className="text-2xl font-black text-gray-900 tracking-tight">
            {currentTotal.toLocaleString()}
          </p>
        </div>
      </div>
      
      <div className="flex-1 min-h-[180px]">
        <ResponsiveContainer width="100%" height="100%">
          <AreaChart data={data}>
            <defs>
              <linearGradient id={gradientId} x1="0" y1="0" x2="0" y2="1">
                <stop offset="5%" stopColor={color} stopOpacity={0.15} />
                <stop offset="95%" stopColor={color} stopOpacity={0} />
              </linearGradient>
            </defs>
            <CartesianGrid strokeDasharray="3 3" vertical={false} stroke="#f1f5f9" />
            <XAxis
              dataKey="date"
              tick={{ fontSize: 9, fill: "#94a3b8", fontWeight: 600 }}
              axisLine={false}
              tickLine={false}
              dy={10}
            />
            <YAxis
              tick={{ fontSize: 9, fill: "#94a3b8", fontWeight: 600 }}
              axisLine={false}
              tickLine={false}
              dx={-10}
              width={30}
            />
            <Tooltip content={<CustomTooltip />} cursor={{ stroke: color, strokeWidth: 1, strokeDasharray: '4 4' }} />
            <Area
              type="monotone"
              dataKey="count"
              name={title}
              stroke={color}
              strokeWidth={3}
              fill={`url(#${gradientId})`}
              animationDuration={1500}
            />
          </AreaChart>
        </ResponsiveContainer>
      </div>
    </div>
  );
}
