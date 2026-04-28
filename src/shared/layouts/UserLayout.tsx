import { Outlet, useLocation } from "react-router-dom";
import {
  Navbar,
} from "@/features/landing/pages/HomePage";
import { LoginPromptDialog } from "@/shared/components/common/LoginPromptDialog";

export function UserLayout() {
  const location = useLocation();
  const hideHeaderFooter = ["/login", "/register"].includes(location.pathname);

  return (
    <div className="min-h-screen flex flex-col">
      <LoginPromptDialog />
      {/* ─── Header ─────────────────────────────────────── */}
      {!hideHeaderFooter && <Navbar />}

      {/* ─── Main Content ───────────────────────────────── */}
      <main className="flex-1">
        <Outlet />
      </main>

      {/* ─── Footer ─────────────────────────────────────── */}
      {!hideHeaderFooter && (
        <footer
          style={{ background: "#0a1628" }}
          className="text-white pt-16 pb-8"
        >
          {/* ... footer content ... */}
          <div className="max-w-7xl mx-auto px-6">
            <div className="grid grid-cols-1 md:grid-cols-4 gap-10 mb-12">
              {/* Brand */}
              <div className="md:col-span-1">
                <div className="flex items-center gap-2 mb-4">
                  <div
                    className="w-10 h-10 rounded-xl flex items-center justify-center"
                    style={{
                      background: "linear-gradient(135deg, #00C896, #00897B)",
                    }}
                  >
                    <span style={{ fontSize: "1.2rem" }}>🏸</span>
                  </div>
                  <span
                    style={{
                      fontSize: "1.3rem",
                      fontWeight: 700,
                      color: "#00C896",
                    }}
                  >
                    SmashBook
                  </span>
                </div>
                <p
                  style={{
                    color: "rgba(255,255,255,0.5)",
                    fontSize: "0.9rem",
                    lineHeight: 1.8,
                  }}
                >
                  Nền tảng đặt sân cầu lông hàng đầu Việt Nam. Kết nối người chơi
                  với sân cầu lông chất lượng.
                </p>
                <div className="flex gap-3 mt-5">
                  {["📘", "📸", "🐦", "📺"].map((icon, i) => (
                    <div
                      key={i}
                      className="w-9 h-9 rounded-lg flex items-center justify-center cursor-pointer transition-all hover:scale-110"
                      style={{
                        background: "rgba(255,255,255,0.08)",
                        fontSize: "1rem",
                      }}
                    >
                      {icon}
                    </div>
                  ))}
                </div>
              </div>

              {/* Links */}
              {[
                {
                  title: "Dịch vụ",
                  links: [
                    "Đặt sân online",
                    "Tìm sân gần tôi",
                    "Sân cao cấp",
                    "Gói thành viên",
                  ],
                },
                {
                  title: "Công ty",
                  links: [
                    "Về chúng tôi",
                    "Blog thể thao",
                    "Tuyển dụng",
                    "Báo chí",
                  ],
                },
                {
                  title: "Hỗ trợ",
                  links: [
                    "Trung tâm trợ giúp",
                    "Điều khoản sử dụng",
                    "Chính sách bảo mật",
                    "Liên hệ chúng tôi",
                  ],
                },
              ].map((col, i) => (
                <div key={i}>
                  <h4
                    style={{
                      fontWeight: 700,
                      marginBottom: "16px",
                      color: "white",
                      fontSize: "0.95rem",
                    }}
                  >
                    {col.title}
                  </h4>
                  <ul className="flex flex-col gap-3">
                    {col.links.map((link, j) => (
                      <li key={j}>
                        <a
                          href="#"
                          style={{
                            color: "rgba(255,255,255,0.5)",
                            fontSize: "0.875rem",
                          }}
                          className="hover:text-emerald-400 transition-colors duration-200"
                        >
                          {link}
                        </a>
                      </li>
                    ))}
                  </ul>
                </div>
              ))}
            </div>

            {/* Divider */}
            <div
              style={{
                borderTop: "1px solid rgba(255,255,255,0.08)",
                paddingTop: "24px",
                display: "flex",
                flexDirection: "row",
                justifyContent: "space-between",
                alignItems: "center",
                flexWrap: "wrap",
                gap: "12px",
              }}
            >
              <p style={{ color: "rgba(255,255,255,0.4)", fontSize: "0.82rem" }}>
                © 2025 SmashBook. All rights reserved. Made with 🏸 in Vietnam.
              </p>
              <div className="flex gap-2">
                <span
                  className="px-3 py-1 rounded-full text-xs"
                  style={{
                    background: "rgba(0,200,150,0.15)",
                    color: "#00C896",
                    border: "1px solid rgba(0,200,150,0.2)",
                  }}
                >
                  🇻🇳 Việt Nam
                </span>
                <span
                  className="px-3 py-1 rounded-full text-xs"
                  style={{
                    background: "rgba(255,255,255,0.05)",
                    color: "rgba(255,255,255,0.5)",
                  }}
                >
                  v2.5.0
                </span>
              </div>
            </div>
          </div>
        </footer>
      )}
    </div>
  );
}
