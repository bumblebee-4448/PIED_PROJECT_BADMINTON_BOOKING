# Hướng Dẫn Kiến Trúc Dự Án (Project Architecture Guide)

Tài liệu này quy định cấu trúc thư mục và quy trình phát triển tính năng (feature) trong dự án. Tất cả các Agent và Developer cần tuân thủ cấu trúc này để đảm bảo tính nhất quán và dễ bảo trì.

## 1. Cấu Trúc Feature (Feature-Based Architecture)

Mỗi module chức năng lớn sẽ được đặt trong thư mục `src/features/[feature-name]`. Một feature tiêu chuẩn PHẢI bao gồm các thư mục và tệp tin sau:

```text
src/features/[feature-name]/
├── components/       # Các UI components con chỉ dùng cho feature này
├── hooks/            # Custom hooks xử lý logic cho feature (API calls, UI logic)
├── pages/            # Các trang (views) chính của feature
├── index.ts          # Entry point: Export các components, hooks, types cần thiết ra ngoài
├── store.ts          # Quản lý global state của feature (Sử dụng Zustand)
├── schema.ts         # Định nghĩa validation schemas (Sử dụng Zod)
└── types.ts          # Định nghĩa TypeScript interfaces/types cho feature
```

### Chi tiết các thành phần:

*   **`hooks/`**: Nơi chứa logic xử lý dữ liệu, gọi API (thường kết hợp với React Query). Tuyệt đối không viết logic xử lý API quá phức tạp trực tiếp trong component.
*   **`components/`**: Chia nhỏ UI thành các component nhỏ có thể tái sử dụng trong nội bộ feature.
*   **`pages/`**: Nơi lắp ghép các components và hooks để tạo thành một trang hoàn chỉnh. Thường sẽ được import vào `src/app/routes` (hoặc cấu trúc routing tương đương).
*   **`store.ts`**: Tập trung quản lý state của feature bằng **Zustand**. Tránh việc prop-drilling quá sâu.
*   **`schema.ts`**: Chứa các quy tắc validate dữ liệu bằng **Zod**, giúp đồng nhất việc kiểm tra dữ liệu từ form hoặc response từ server.
*   **`types.ts`**: Khai báo mọi kiểu dữ liệu để tận dụng tối đa sức mạnh của TypeScript.

## 2. Quy Tắc Phát Triển Feature Mới

Khi nhận yêu cầu tạo một feature mới (ví dụ: `auth`), Agent thực hiện theo các bước sau:

1.  **Khởi tạo cấu trúc thư mục**: Tạo đầy đủ các thư mục `hooks`, `components`, `pages`.
2.  **Định nghĩa Types & Schema**: Viết các interface trong `types.ts` và validation trong `schema.ts` trước để làm nền tảng.
3.  **Xây dựng Logic (Store & Hooks)**: Thiết lập state quản lý trong `stores.ts` và logic lấy/gửi dữ liệu trong `hooks/`.
4.  **Phát triển UI (Components & Pages)**: Xây dựng các component UI và cuối cùng là trang hoàn chỉnh trong `pages/`.
5.  **Exposing**: Cấu hình file `index.ts` để export những thành phần mà các phần khác của ứng dụng cần sử dụng.

## 3. Shared Resources

Nếu một component hoặc logic có khả năng dùng chung cho nhiều feature khác nhau, hãy đặt chúng vào thư mục `src/shared/`:
*   `src/shared/components/`
*   `src/shared/hooks/`
*   `src/shared/utils/`

---
> **Lưu ý cho Agent:** Trước khi bắt đầu code bất kỳ tính năng nào, hãy kiểm tra xem feature đó đã có cấu trúc chuẩn chưa. Nếu chưa, hãy refactor theo đúng hướng dẫn này.
