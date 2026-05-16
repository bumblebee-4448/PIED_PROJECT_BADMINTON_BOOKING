import {
  Pagination,
  PaginationContent,
  PaginationEllipsis,
  PaginationItem,
  PaginationLink,
} from "@/shared/components/ui/pagination";
import { cn } from "@/lib/utils";
import { Button } from "@/shared/components/ui/button";

interface DataTablePaginationProps {
  pageIndex: number;
  totalPages: number;
  onPageChange: (page: number) => void;
}

export function DataTablePagination({
  pageIndex,
  totalPages,
  onPageChange,
}: DataTablePaginationProps) {
  if (totalPages <= 1) return null;

  const renderPageNumbers = () => {
    const pages = [];

    const createPageLink = (page: number) => (
      <PaginationItem key={page}>
        <PaginationLink
          isActive={pageIndex === page}
          onClick={(e) => {
            e.preventDefault();
            onPageChange(page);
          }}
          className={cn(
            "cursor-pointer rounded-lg font-bold transition-all duration-200 w-8 h-8 border-none text-xs",
            pageIndex === page 
              ? "bg-[#00A067] text-white hover:bg-[#00A067]/90 hover:text-white" 
              : "text-gray-500 hover:text-[#00A067] hover:bg-emerald-50 bg-transparent"
          )}
        >
          {page}
        </PaginationLink>
      </PaginationItem>
    );

    if (totalPages <= 7) {
      for (let i = 1; i <= totalPages; i++) {
        pages.push(createPageLink(i));
      }
    } else {
      // Always show first page
      pages.push(createPageLink(1));

      if (pageIndex > 4) {
        pages.push(
          <PaginationItem key="ellipsis-start">
            <PaginationEllipsis />
          </PaginationItem>
        );
      }

      // Show pages around current
      const start = Math.max(2, pageIndex - 1);
      const end = Math.min(totalPages - 1, pageIndex + 1);

      // Adjust if near start
      let adjustedStart = start;
      let adjustedEnd = end;
      if (pageIndex <= 4) {
        adjustedStart = 2;
        adjustedEnd = 5;
      } else if (pageIndex >= totalPages - 3) {
        adjustedStart = totalPages - 4;
        adjustedEnd = totalPages - 1;
      }

      for (let i = adjustedStart; i <= adjustedEnd; i++) {
        pages.push(createPageLink(i));
      }

      if (pageIndex < totalPages - 3) {
        pages.push(
          <PaginationItem key="ellipsis-end">
            <PaginationEllipsis />
          </PaginationItem>
        );
      }

      // Always show last page
      pages.push(createPageLink(totalPages));
    }

    return pages;
  };

  return (
    <Pagination>
      <PaginationContent className="gap-2">
        <PaginationItem>
          <Button
            variant="outline"
            onClick={() => {
              if (pageIndex > 1) onPageChange(pageIndex - 1);
            }}
            disabled={pageIndex === 1}
            className="h-9 rounded-xl border-gray-100 text-xs font-bold px-4 text-gray-400 disabled:opacity-50"
          >
            Trước
          </Button>
        </PaginationItem>

        {renderPageNumbers()}

        <PaginationItem>
          <Button
            variant="outline"
            onClick={() => {
              if (pageIndex < totalPages) onPageChange(pageIndex + 1);
            }}
            disabled={pageIndex === totalPages}
            className="h-9 rounded-xl border-gray-100 text-xs font-bold px-4 text-gray-700 disabled:opacity-50"
          >
            Sau
          </Button>
        </PaginationItem>
      </PaginationContent>
    </Pagination>
  );
}
