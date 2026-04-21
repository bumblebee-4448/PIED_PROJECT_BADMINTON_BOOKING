# TCK React Learning

Frontend project for learning production-ready React patterns with a feature-based architecture.

## Tech Stack

- React + TypeScript + Vite
- React Router
- TanStack Query
- Zustand
- React Hook Form + Zod
- Axios
- Tailwind CSS + shadcn/ui

## Key Features

- Auth flow with protected and guest routes
- User and admin role-based navigation
- Ritual catalog and ritual detail pages
- Admin ritual management (create, edit, list)
- Profile and user management pages

## Prerequisites

- Node.js 18+
- pnpm 8+

## Setup

1. Install dependencies:

```bash
pnpm install
```

2. Create env file:

```bash
cp .env.example .env
```

3. Update environment variables in `.env`.

4. Run development server:

```bash
pnpm dev
```

5. Open `http://localhost:5173`.

## Environment Variables

Required frontend env vars:

```env
VITE_API_URL=http://localhost:3000
```

## Available Scripts

```bash
pnpm dev
pnpm build
pnpm preview
pnpm lint
```

## Project Structure

```text
src/
  app/            # app wiring: router, providers
  features/       # business features
  shared/         # shared ui, layouts, hooks, constants
  lib/            # axios, env, query client
  styles/         # global styles
```

## Deployment Notes

- Set `VITE_API_URL` in the hosting dashboard (Vercel/Netlify).
- Use SPA rewrite rules for client-side routing.
- Ensure backend CORS allows your frontend domain.
