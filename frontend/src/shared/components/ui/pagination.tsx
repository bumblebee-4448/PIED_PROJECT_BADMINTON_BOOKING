import * as React from "react";
import { ChevronLeft, ChevronRight, MoreHorizontal } from "lucide-react";

import { cn } from "@/lib/utils";
import { buttonVariants } from "@/shared/components/ui/button";
import type { ButtonProps } from "@/shared/components/ui/button";

/**
 * Component gốc <nav> wrapper.
 * React.ComponentProps<"nav"> = Lấy tất cả props hợp lệ của thẻ <nav> HTML.
 * VD: id, className, onClick, data-*, aria-*, v.v.
 */
const Pagination = ({ className, ...props }: React.ComponentProps<"nav">) => (
  <nav
    role="navigation"
    aria-label="pagination"
    className={cn("mx-auto flex w-full justify-center", className)}
    {...props}
  />
);
/**
 * displayName: Hiển thị tên component trong React DevTools.
 * Giúp debug dễ hơn (thay vì hiện "Anonymous").
 */
Pagination.displayName = "Pagination";

/**
 * React.forwardRef: Cho phép component nhận "ref" từ parent.
 * VD: <PaginationContent ref={ulRef} /> → ref trỏ tới <ul> DOM node.
 * Generic <HTMLUListElement, Props>: ref type + props type.
 */
const PaginationContent = React.forwardRef<
  HTMLUListElement,
  React.ComponentProps<"ul">
>(({ className, ...props }, ref) => (
  <ul
    ref={ref}
    className={cn("flex flex-row items-center gap-1", className)}
    {...props}
  />
));
PaginationContent.displayName = "PaginationContent";

const PaginationItem = React.forwardRef<
  HTMLLIElement,
  React.ComponentProps<"li">
>(({ className, ...props }, ref) => (
  <li ref={ref} className={cn("", className)} {...props} />
));
PaginationItem.displayName = "PaginationItem";

/**
 * Type intersection (&): Kết hợp nhiều types thành 1.
 * Pick<ButtonProps, "size">: Lấy RIÊNG property "size" từ ButtonProps.
 * VD: ButtonProps có {variant, size, disabled} → Pick chỉ lấy {size}.
 * Kết quả: {isActive?, size?, ...all <a> props}
 */
type PaginationLinkProps = {
  isActive?: boolean;
  size?: ButtonProps["size"];
} & React.ComponentProps<"a">;

const PaginationLink = ({
  className,
  isActive,
  size = "icon",
  ...props
}: PaginationLinkProps) => (
  <a
    /**
     * aria-current="page": Accessibility attribute.
     * Báo screen reader biết đây là trang hiện tại.
     * undefined = không set attribute (HTML sạch hơn).
     */
    aria-current={isActive ? "page" : undefined}
    className={cn(
      buttonVariants({
        variant: isActive ? "outline" : "ghost",
        size,
      }),
      className,
    )}
    {...props}
  />
);
PaginationLink.displayName = "PaginationLink";

/**
 * typeof PaginationLink: Lấy type của component đã định nghĩa.
 * React.ComponentProps<typeof PaginationLink> = Props của PaginationLink.
 * Tránh phải viết lại type manually.
 */
const PaginationPrevious = ({
  className,
  ...props
}: React.ComponentProps<typeof PaginationLink>) => (
  <PaginationLink
    {...props}
    aria-label="Go to previous page"
    size="default"
    className={cn("gap-1 pl-2.5", className)}
  >
    <ChevronLeft className="h-4 w-4" />
    <span>Previous</span>
  </PaginationLink>
);
PaginationPrevious.displayName = "PaginationPrevious";

const PaginationNext = ({
  className,
  ...props
}: React.ComponentProps<typeof PaginationLink>) => (
  <PaginationLink
    {...props}
    aria-label="Go to next page"
    size="default"
    className={cn("gap-1 pr-2.5", className)}
  >
    <span>Next</span>
    <ChevronRight className="h-4 w-4" />
  </PaginationLink>
);
PaginationNext.displayName = "PaginationNext";

const PaginationEllipsis = ({
  className,
  ...props
}: React.ComponentProps<"span">) => (
  <span
    /**
     * aria-hidden: Ẩn element khỏi screen reader.
     * Vì "..." không có ý nghĩa cho người khiếm thị.
     */
    aria-hidden
    className={cn("flex h-9 w-9 items-center justify-center", className)}
    {...props}
  >
    <MoreHorizontal className="h-4 w-4" />
    {/**
     * sr-only (screen reader only): Class Tailwind ẩn visual nhưng vẫn đọc được.
     * CSS: position: absolute; width: 1px; height: 1px; overflow: hidden;
     */}
    <span className="sr-only">More pages</span>
  </span>
);
PaginationEllipsis.displayName = "PaginationEllipsis";

export {
  Pagination,
  PaginationContent,
  PaginationEllipsis,
  PaginationItem,
  PaginationLink,
  PaginationNext,
  PaginationPrevious,
};
