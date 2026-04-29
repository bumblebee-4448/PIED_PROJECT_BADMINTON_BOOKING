import { useState, useEffect } from "react";
import { Check } from "lucide-react";
import { DISTRICTS, LEVELS } from "../constants";
import type { ProfileSchema } from "../schema";

interface ProfileFormProps {
  initialData: {
    name: string;
    email: string;
    phone: string;
    location: string;
    level: string;
  };
  onSave: (data: ProfileSchema) => void;
  isSaving: boolean;
}

export function ProfileForm({ initialData, onSave, isSaving }: ProfileFormProps) {
  const [name, setName] = useState(initialData.name);
  const [email, setEmail] = useState(initialData.email);
  const [phone, setPhone] = useState(initialData.phone);
  const [location, setLocation] = useState(initialData.location);
  const [level, setLevel] = useState(initialData.level);
  const [saved, setSaved] = useState(false);

  // Cập nhật state khi initialData thay đổi (ví dụ khi mock data được load)
  useEffect(() => {
    setName(initialData.name);
    setEmail(initialData.email);
    setPhone(initialData.phone);
    setLocation(initialData.location);
    setLevel(initialData.level);
  }, [initialData]);

  const handleSubmit = () => {
    onSave({
      name,
      email,
      phone,
      preferredLocation: location,
      level,
    });
    setSaved(true);
    setTimeout(() => setSaved(false), 2500);
  };

  return (
    <div className="bg-white rounded-2xl p-5 mb-4" style={{ border: "1px solid rgba(0,0,0,0.07)" }}>
      <h3 style={{ fontWeight: 700, fontSize: "0.95rem", color: "#1a1a2e", marginBottom: "14px" }}>
        Thông tin cơ bản
      </h3>
      <div className="flex flex-col gap-4">
        {[
          { label: "Họ và tên", value: name, onChange: setName, type: "text" },
          { label: "Email", value: email, onChange: setEmail, type: "email" },
          { label: "Số điện thoại", value: phone, onChange: setPhone, type: "tel" },
        ].map(({ label, value, onChange, type }) => (
          <div key={label}>
            <label
              style={{
                fontSize: "0.75rem",
                fontWeight: 600,
                color: "#6b7280",
                display: "block",
                marginBottom: "6px",
              }}
            >
              {label}
            </label>
            <input
              type={type}
              value={value}
              onChange={(e) => onChange(e.target.value)}
              className="w-full px-4 py-2.5 rounded-xl outline-none text-sm"
              style={{ border: "1.5px solid #e5e7eb", background: "#f9fafb" }}
            />
          </div>
        ))}
        <div>
          <label
            style={{
              fontSize: "0.75rem",
              fontWeight: 600,
              color: "#6b7280",
              display: "block",
              marginBottom: "6px",
            }}
          >
            Khu vực yêu thích
          </label>
          <select
            value={location}
            onChange={(e) => setLocation(e.target.value)}
            className="w-full px-4 py-2.5 rounded-xl outline-none text-sm appearance-none"
            style={{ border: "1.5px solid #e5e7eb", background: "#f9fafb" }}
          >
            {DISTRICTS.filter((d) => d !== "Tất cả").map((d) => (
              <option key={d}>{d}</option>
            ))}
          </select>
        </div>
        <div>
          <label
            style={{
              fontSize: "0.75rem",
              fontWeight: 600,
              color: "#6b7280",
              display: "block",
              marginBottom: "6px",
            }}
          >
            Trình độ
          </label>
          <select
            value={level}
            onChange={(e) => setLevel(e.target.value)}
            className="w-full px-4 py-2.5 rounded-xl outline-none text-sm appearance-none"
            style={{ border: "1.5px solid #e5e7eb", background: "#f9fafb" }}
          >
            {LEVELS.map((l) => (
              <option key={l.value} value={l.value}>
                {l.label}
              </option>
            ))}
          </select>
        </div>
      </div>
      {saved && (
        <div className="mt-3 flex items-center gap-2 px-3 py-2 rounded-xl" style={{ background: "#ECFDF5" }}>
          <Check size={14} style={{ color: "#10B981" }} />
          <span style={{ fontSize: "0.82rem", color: "#10B981", fontWeight: 600 }}>
            Đã lưu thay đổi!
          </span>
        </div>
      )}
      <button
        onClick={handleSubmit}
        disabled={isSaving}
        className="mt-4 w-full py-3 rounded-xl text-white font-bold text-sm transition hover:opacity-90 disabled:opacity-50"
        style={{ background: "linear-gradient(135deg,#00C896,#00897B)" }}
      >
        {isSaving ? "Đang lưu..." : "Lưu thay đổi"}
      </button>
    </div>
  );
}
