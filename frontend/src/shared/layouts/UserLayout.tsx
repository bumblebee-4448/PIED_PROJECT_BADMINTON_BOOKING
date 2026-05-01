import { Outlet, useLocation } from "react-router-dom";
import { Navbar } from "@/features/landing";
import { LoginPromptDialog } from "@/shared/components/common/LoginPromptDialog";
import { UserProfileCard } from "@/features/auth/components/UserProfileCard";
import { useMe } from "@/features/profile/hooks/useMe";

export function UserLayout() {
  const location = useLocation();
  const hideHeaderFooter = ["/login", "/register"].includes(location.pathname);

  // Sử dụng React Query tối ưu thay cho useEffect
  useMe();

  return (
    <div className="min-h-screen flex flex-col">
      <LoginPromptDialog />
      
      {/* ─── Profile Sticky Card (Visible for all logged-in roles) ─── */}
      {!hideHeaderFooter && <UserProfileCard />}

      {/* ─── Header ─────────────────────────────────────── */}
      {!hideHeaderFooter && <Navbar />}

      {/* ─── Main Content ───────────────────────────────── */}
      <main className="flex-1">
        <Outlet />
      </main>

      {/* ─── Footer ─────────────────────────────────────── */}
      {!hideHeaderFooter && (
        <footer
          style={{ background: "linear-gradient(180deg, #0B2421 0%, #05100E 100%)" }}
          className="text-white pt-20 pb-10 border-t border-emerald-900/30"
        >
          <div className="max-w-7xl mx-auto px-6">
            <div className="grid grid-cols-1 md:grid-cols-4 gap-12 mb-16">
              {/* Brand */}
              <div className="md:col-span-1">
                <div className="flex items-center gap-2 mb-6">
                  <div
                    className="w-11 h-11 rounded-2xl flex items-center justify-center shadow-lg shadow-emerald-500/20"
                    style={{
                      background: "linear-gradient(135deg, #00C896, #00897B)",
                    }}
                  >
                    <span style={{ fontSize: "1.3rem" }}>🏸</span>
                  </div>
                  <span
                    style={{
                      fontSize: "1.5rem",
                      fontWeight: 800,
                      color: "#FFFFFF",
                      letterSpacing: "-0.5px"
                    }}
                  >
                    RallyHub
                  </span>
                </div>
                <p
                  className="text-emerald-100/50"
                  style={{
                    fontSize: "0.95rem",
                    lineHeight: 1.8,
                  }}
                >
                  Nền tảng đặt sân cầu lông hàng đầu Việt Nam. Kết nối người chơi
                  với sân cầu lông chất lượng cao chỉ trong vài click.
                </p>
                <div className="flex gap-4 mt-8">
                  {["📘", "📸", "🐦", "📺"].map((icon, i) => (
                    <div
                      key={i}
                      className="w-10 h-10 rounded-xl flex items-center justify-center cursor-pointer transition-all hover:bg-emerald-500/20 hover:scale-110 border border-white/5"
                      style={{
                        background: "rgba(255,255,255,0.03)",
                        fontSize: "1.1rem",
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
                    className="text-white font-bold mb-6 text-base tracking-tight"
                  >
                    {col.title}
                  </h4>
                  <ul className="flex flex-col gap-4">
                    {col.links.map((link, j) => (
                      <li key={j}>
                        <a
                          href="#"
                          className="text-emerald-100/40 hover:text-emerald-400 transition-all duration-300 text-sm font-medium inline-block hover:translate-x-1"
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
              className="border-t border-white/5 pt-8 flex flex-col md:flex-row justify-between items-center gap-6"
            >
              <p className="text-emerald-100/30 text-sm font-medium">
                © 2025 RallyHub. All rights reserved. Made with 🏸 in Vietnam.
              </p>
              <div className="flex items-center gap-4">
                <span
                  className="px-4 py-1.5 rounded-xl text-xs font-bold"
                  style={{
                    background: "rgba(0,200,150,0.1)",
                    color: "#00C896",
                    border: "1px solid rgba(0,200,150,0.15)",
                  }}
                >
                  🇻🇳 Việt Nam
                </span>
                <span
                  className="px-4 py-1.5 rounded-xl text-xs font-bold"
                  style={{
                    background: "rgba(255,255,255,0.03)",
                    color: "rgba(255,255,255,0.3)",
                    border: "1px solid rgba(255,255,255,0.05)",
                  }}
                >
                  v3.0.0
                </span>
              </div>
            </div>
          </div>
        </footer>
      )}
    </div>
  );
}
