import { useState } from "react";
import type { ProfileSchema } from "../schema";
import { Button } from "@/shared/components/ui/button";

interface ProfileFormProps {
  initialData: {
    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: string;
    avatarUrl?: string | null;
  };
  onSave: (data: ProfileSchema) => void;
  isSaving: boolean;
}

export function ProfileForm({ initialData, onSave, isSaving }: ProfileFormProps) {
  const [firstName, setFirstName] = useState(initialData.firstName);
  const [lastName, setLastName] = useState(initialData.lastName);
  const [email, setEmail] = useState(initialData.email);
  const [phoneNumber, setPhoneNumber] = useState(initialData.phoneNumber);

  const handleSubmit = () => {
    onSave({
      firstName,
      lastName,
      email,
      phoneNumber,
      avatarUrl: initialData.avatarUrl,
    });
  };

  return (
    <div className="bg-white rounded-2xl p-5 mb-4" style={{ border: "1px solid rgba(0,0,0,0.07)" }}>
      <h3 style={{ fontWeight: 700, fontSize: "0.95rem", color: "#1a1a2e", marginBottom: "14px" }}>
        Thông tin cơ bản
      </h3>
      <div className="flex flex-col gap-4">
        <div className="grid grid-cols-2 gap-4">
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
              Họ
            </label>
            <input
              type="text"
              value={lastName}
              onChange={(e) => setLastName(e.target.value)}
              className="w-full px-4 py-2.5 rounded-xl outline-none text-sm"
              style={{ border: "1.5px solid #e5e7eb", background: "#f9fafb" }}
            />
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
              Tên
            </label>
            <input
              type="text"
              value={firstName}
              onChange={(e) => setFirstName(e.target.value)}
              className="w-full px-4 py-2.5 rounded-xl outline-none text-sm"
              style={{ border: "1.5px solid #e5e7eb", background: "#f9fafb" }}
            />
          </div>
        </div>
        {[
          { label: "Email", value: email, onChange: setEmail, type: "email" },
          { label: "Số điện thoại", value: phoneNumber, onChange: setPhoneNumber, type: "tel" },
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
        {/* <div>
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
        </div> */}
      </div>
      <Button
        onClick={handleSubmit}
        disabled={isSaving}
        variant="gradient"
        className="mt-4 w-full py-3 rounded-xl text-white font-bold text-sm"
      >
        {isSaving ? "Đang lưu..." : "Lưu thay đổi"}
      </Button>
    </div>
  );
}
