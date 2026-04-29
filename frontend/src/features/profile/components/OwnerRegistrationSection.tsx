import { useState } from "react";
import { ChevronRight } from "lucide-react";
import type { OwnerRegistrationSchema } from "../schema";

interface OwnerRegistrationSectionProps {
  onRegister: (data: OwnerRegistrationSchema) => void;
  isLoading: boolean;
}

export function OwnerRegistrationSection({ onRegister, isLoading }: OwnerRegistrationSectionProps) {
  const [showSection, setShowSection] = useState(false);
  const [bizName, setBizName] = useState("");
  const [bizPhone, setBizPhone] = useState("");
  const [idCard, setIdCard] = useState("");

  const handleSubmit = () => {
    onRegister({ bizName, bizPhone, idCard });
  };

  return (
    <div className="bg-white rounded-2xl overflow-hidden mb-4" style={{ border: "1px solid rgba(0,0,0,0.07)" }}>
      <button
        onClick={() => setShowSection(!showSection)}
        className="w-full flex items-center justify-between px-5 py-4 hover:bg-gray-50 transition"
      >
        <div className="flex items-center gap-3">
          <div className="w-8 h-8 rounded-lg flex items-center justify-center" style={{ background: "#f0fdf9" }}>🏢</div>
          <div className="text-left">
            <span style={{ fontWeight: 700, fontSize: "0.9rem", color: "#1a1a2e" }}>Đăng ký chủ sân</span>
            <p style={{ fontSize: "0.72rem", color: "#9ca3af" }}>Quản lý sân và nhận tiền định kỳ</p>
          </div>
        </div>
        <ChevronRight
          size={16}
          className="text-gray-400"
          style={{ transform: showSection ? "rotate(90deg)" : "none" }}
        />
      </button>
      {showSection && (
        <div className="px-5 pb-5 border-t border-gray-50">
          <p style={{ fontSize: "0.8rem", color: "#9ca3af", margin: "12px 0 14px", lineHeight: 1.6 }}>
            Cung cấp thông tin để xác minh danh tính và bắt đầu quản lý sân cầu lông của bạn.
          </p>
          {[
            { label: "Tên doanh nghiệp / cá nhân", value: bizName, set: setBizName },
            { label: "SĐT kinh doanh", value: bizPhone, set: setBizPhone },
            { label: "Số CCCD / CMND", value: idCard, set: setIdCard },
          ].map(({ label, value, set }) => (
            <div key={label} className="mb-3">
              <label style={{ fontSize: "0.75rem", fontWeight: 600, color: "#6b7280", display: "block", marginBottom: "6px" }}>{label}</label>
              <input
                value={value}
                onChange={(e) => set(e.target.value)}
                className="w-full px-3 py-2.5 rounded-xl outline-none text-sm"
                style={{ border: "1.5px solid #e5e7eb", background: "#f9fafb" }}
              />
            </div>
          ))}
          <div className="mb-4">
            <label style={{ fontSize: "0.75rem", fontWeight: 600, color: "#6b7280", display: "block", marginBottom: "6px" }}>
              Ảnh giấy tờ xác minh
            </label>
            <div className="flex gap-2">
              {["CCCD mặt trước", "CCCD mặt sau", "Giấy phép kinh doanh"].map((doc) => (
                <div
                  key={doc}
                  className="flex-1 border-2 border-dashed rounded-xl p-3 text-center cursor-pointer hover:border-emerald-400 transition"
                  style={{ borderColor: "#e5e7eb" }}
                >
                  <div style={{ fontSize: "1.2rem", marginBottom: "4px" }}>📄</div>
                  <p style={{ fontSize: "0.62rem", color: "#9ca3af" }}>{doc}</p>
                </div>
              ))}
            </div>
          </div>
          <button
            onClick={handleSubmit}
            disabled={isLoading}
            className="w-full py-3 rounded-xl text-white font-bold text-sm disabled:opacity-50"
            style={{ background: "linear-gradient(135deg,#00C896,#00897B)" }}
          >
            {isLoading ? "Đang gửi..." : "Gửi yêu cầu đăng ký"}
          </button>
        </div>
      )}
    </div>
  );
}
