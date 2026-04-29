---
name: feature-development
description: Enforces Feature-Based Architecture and shared UI usage when building or refactoring features. Use when creating a new feature in src/features/[feature-name] or restructuring an existing one to match project conventions.
---

# Feature Development Skill

This skill defines the standard rules and process for building a new feature in the project. The goal is strict adherence to **Feature-Based Architecture** — keeping directory structure clean, UI consistent across the system, and logic clearly separated from view layer.

## When to use this skill

- Use when scaffolding a new feature under `src/features/[feature-name]`.
- Use when refactoring an existing feature to comply with project architecture.
- Use when unsure whether a component, hook, or store belongs inside or outside a feature boundary.

## How to use it

### Core Principles

1. **Self-contained feature boundary** — All code for a feature lives entirely inside `src/features/[feature-name]/`. Never leak feature code into other layers.
2. **Always use shared UI components** — Prioritize reusable components from `src/shared/ui` (Button, Input, Modal, etc.) before creating new ones.
3. **Separation of concerns** — Components only render UI. API calls and complex data logic belong in `hooks/` or `store.ts`.
4. **Type-safe and validated** — Define Zod schemas and TypeScript types before writing logic.

### Required Directory Structure

```text
src/features/[feature-name]/
├── components/   # Feature-specific UI, imports base components from src/shared/ui
├── hooks/        # Custom hooks (API calls, business logic)
├── pages/        # Full pages assembled from components and hooks
├── index.ts      # Public API (barrel exports only)
├── store.ts      # Zustand store (if needed)
├── schema.ts     # Zod schemas
└── types.ts      # TypeScript types
```

### Step-by-Step Process

1. **Scaffold** — Create the feature directory and all required files following the structure above.
2. **Data model** — Define Zod schemas in `schema.ts` and TypeScript types in `types.ts`.
3. **Logic and state** — Write hooks in `hooks/` and store in `store.ts` to handle data and side effects.
4. **UI construction** — Build components using `src/shared/ui` primitives, then assemble them into pages.
5. **Export** — Expose only the necessary modules through `index.ts`.

### Pre-commit Checklist

- [ ] Feature code is fully contained inside `src/features/[feature-name]/`
- [ ] Components use `src/shared/ui` instead of custom one-off elements
- [ ] Business logic is extracted out of components into hooks or store
- [ ] Zod schemas and TypeScript types are defined before logic
- [ ] `index.ts` only exports what consumers actually need
