/* eslint-disable react-refresh/only-export-components */
import * as React from "react";
import { Slot } from "@radix-ui/react-slot";
import { cva, type VariantProps } from "class-variance-authority";

import { cn } from "@/lib/utils";

const buttonVariants = cva(
  "inline-flex items-center justify-center gap-2 whitespace-nowrap rounded-md text-sm font-medium ring-offset-background transition-colors focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 disabled:pointer-events-none disabled:opacity-50 [&_svg]:pointer-events-none [&_svg]:size-4 [&_svg]:shrink-0",
  {
    variants: {
      variant: {
        default: "bg-[#00897B] text-white hover:bg-[#00897B]/90 shadow-sm",
        destructive:
          "bg-destructive text-destructive-foreground hover:bg-destructive/90",
        destructive_outline:
          "bg-[#FEF2F2] text-[#DC2626] border-[1.5px] border-[#FECACA] hover:bg-red-50",
        outline:
          "border border-[#E5E7EB] bg-white hover:bg-gray-50 text-gray-700 shadow-sm",
        secondary:
          "bg-gray-100 text-gray-700 hover:bg-gray-200",
        ghost: "hover:bg-gray-100 text-gray-600",
        ghost_primary: "text-[#00897B] hover:bg-[#00897B]/10 font-semibold",
        link: "text-primary underline-offset-4 hover:underline",
        gradient: "bg-gradient-to-r from-[#00C896] to-[#00897B] text-white hover:opacity-90 hover:shadow-lg hover:scale-[1.02] transition-all duration-200",
        gradient_dark: "bg-gradient-to-r from-[#004E43] to-[#00CE98] text-white hover:shadow-lg hover:shadow-[#00CE98]/40 active:scale-[0.98] transition-all duration-300",
      },
      size: {
        default: "h-10 px-4 py-2",
        sm: "h-9 rounded-md px-3 text-xs",
        lg: "h-11 rounded-md px-8",
        xl: "h-12 md:h-[52px] rounded-xl px-8 text-base md:text-lg",
        icon: "h-9 w-9",
      },
    },
    defaultVariants: {
      variant: "default",
      size: "default",
    },
  },
);

interface ButtonProps
  extends
    React.ButtonHTMLAttributes<HTMLButtonElement>,
    VariantProps<typeof buttonVariants> {
  asChild?: boolean;
}

const Button = React.forwardRef<HTMLButtonElement, ButtonProps>(
  ({ className, variant, size, asChild = false, ...props }, ref) => {
    const Comp = asChild ? Slot : "button";
    return (
      <Comp
        className={cn(buttonVariants({ variant, size, className }))}
        ref={ref}
        {...props}
      />
    );
  },
);
Button.displayName = "Button";

export { Button };
export { buttonVariants };
export type { ButtonProps };
