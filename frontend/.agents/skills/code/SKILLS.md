# Agent Skill: Feature-Based Development Standard

## 🎯 Mục Đích (Objective)
Skill này cung cấp bộ quy tắc và quy trình chuẩn (Standard Operating Procedure) cho Agent để phát triển một tính năng (feature) mới trong dự án. Mục tiêu tối thượng là đảm bảo code tuân thủ chặt chẽ kiến trúc **Feature-Based Architecture**, giữ tính toàn vẹn của cấu trúc thư mục, đồng nhất giao diện (UI) toàn hệ thống và tách biệt rõ ràng giữa logic và view.

---

## 🛑 Quy Tắc Cốt Lõi (Core Principles)

1. **Tuân thủ Cấu trúc Feature Độc lập**: Mọi tính năng mới PHẢI được đặt trọn vẹn trong `src/features/[feature-name]/`. Tuyệt đối không để rò rỉ mã nguồn (leak code) ra bên ngoài cấu trúc này.
2. **[QUAN TRỌNG] Bắt buộc sử dụng Shared UI Components**: Để đảm bảo tính đồng nhất về thiết kế toàn dự án, Agent **BẮT BUỘC** phải ưu tiên sử dụng các reusable components có sẵn trong thư mục `src/shared/ui` (ví dụ: Button, Input, Modal, Card, v.v.) trước khi quyết định viết mới một UI component cục bộ hoặc sử dụng thẻ HTML/Tailwind thuần.
3. **Tách biệt Mối quan tâm (Separation of Concerns)**: Component chỉ chịu trách nhiệm render UI. Mọi logic gọi API, xử lý dữ liệu phức tạp bắt buộc phải được đưa vào `hooks/` hoặc `store.ts`.
4. **Type-Safe & Data Validation**: Bắt buộc sử dụng **Zod** cho validation và **TypeScript** để định nghĩa interface/type rõ ràng trước khi implement logic.

---

## 🛠 Cấu Trúc Bắt Buộc Của Một Feature

Mỗi feature khi khởi tạo phải luôn tuân theo cấu trúc chuẩn sau đây:

```text
src/features/[feature-name]/
├── components/       # Component UI đặc thù của feature. LUÔN import core UI từ `src/shared/ui`
├── hooks/            # Chứa các custom hook (e.g., fetch data, handle logic)
├── pages/            # Nơi lắp ghép components và hooks thành trang hoàn chỉnh
├── index.ts          # Public API của feature (Chỉ export những gì bên ngoài cần)
├── store.ts          # Zustand store cho global state của feature (nếu có)
├── schema.ts         # Zod schemas để validate dữ liệu đầu vào/ra
└── types.ts          # Định nghĩa TypeScript Interfaces/Types
```

---

## 🚀 Quy Trình Phát Triển Từng Bước (Step-by-step Workflow)

Khi nhận lệnh từ User: *"Tạo/code feature [feature-name]"*, Agent phải tuần tự thực hiện các bước sau:

### Bước 1: Phân tích & Khởi tạo cấu trúc
- Xác định phạm vi và yêu cầu của feature.
- Tạo thư mục `src/features/[feature-name]` và khởi tạo đầy đủ các thư mục/file như cấu trúc yêu cầu ở trên.

### Bước 2: Định nghĩa Data Model (Types & Schema)
- Viết các rule validation dữ liệu vào `schema.ts` sử dụng **Zod**.
- Định nghĩa các interface/type tương ứng trong `types.ts`.
- *Góc nhìn Senior: Làm chuẩn xác bước này sẽ giúp toàn bộ quá trình implement phía sau được IDE và TypeScript hỗ trợ tối đa, triệt tiêu bug runtime do sai kiểu dữ liệu.*

### Bước 3: Phát triển State & Logic (Store & Hooks)
- Nếu feature cần quản lý trạng thái dùng chung giữa các component con sâu bên trong, cấu hình file `store.ts` sử dụng **Zustand**.
- Khởi tạo các custom hooks trong `hooks/` để xử lý API calls (khuyên dùng React Query) hoặc tách các business logic phức tạp.

### Bước 4: Xây dựng UI (Components & Pages)
- Xây dựng các component UI cắt nhỏ trong `components/`.
- **Hành động bắt buộc**: Agent phải trỏ đường dẫn import về `src/shared/ui` để gọi các thành phần giao diện gốc ra dùng (như button, form input, label...). Nếu nhận thấy dự án đang thiếu một core UI component, Agent hãy đề xuất tạo mới trong `shared/ui` thay vì tự ý tạo cục bộ.
- Lắp ráp các component con và kết hợp với hook/store tại `pages/` để dựng thành view hoàn chỉnh.

### Bước 5: Đóng gói (Exposing via `index.ts`)
- Mở file `index.ts` của feature.
- Áp dụng pattern *Barrel Export*. Chỉ export các `pages`, `hooks` hoặc `types` mà phần khác của hệ thống (ví dụ: Router) thực sự cần gọi đến. Tuyệt đối không export các component nội bộ.

---

## ✅ Checklist Kiểm Tra (Validation Checklist)
Trước khi báo cáo hoàn thành cho User, Agent phải tự rà soát lại (self-review) theo danh sách:
- [ ] Feature đã được khoanh vùng hoàn toàn trong `src/features/[feature-name]` chưa?
- [ ] Đã tái sử dụng triệt để các component UI từ thư mục `src/shared/ui` chưa?
- [ ] Đã tách sạch logic (API, data manipulation) ra khỏi component file chưa?
- [ ] File `schema.ts` và `types.ts` đã khai báo đầy đủ và đang được import vào các file khác để check type chưa?
- [ ] File `index.ts` đã tuân thủ việc chỉ export những module được phép public chưa?
