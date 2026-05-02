---
name: antigravity-debug
description: Analyzes and explains code errors in JavaScript/TypeScript projects built inside Google Antigravity IDE. Use when the user shares an error log, stack trace, screenshot of an error, or describes a bug in their Antigravity project. Trigger on keywords like "lỗi", "bug", "crash", "error", "stack trace", "không chạy được", "fix", "debug", "undefined", "null", "exception", "failed", "cannot read".
---

# Antigravity Debug Skill

This skill defines the standard process for diagnosing code errors in projects built inside Google Antigravity IDE. The goal is fast, concise root cause analysis — no unnecessary explanation, no rewriting entire files.

## When to use this skill

- Use when the user pastes an error log or stack trace from their Antigravity project.
- Use when the user shares a screenshot showing a runtime or compile-time error.
- Use when the user describes unexpected behavior or a crash in their JS/TS code.
- Do **not** use for IDE platform issues (login loop, agent stuck, IDE crash) — those are Antigravity platform bugs, not code errors.

## How to use it

### Core Principles

1. **Short is the priority** — If the fix takes 1–2 lines, the explanation should match. Never over-explain.
2. **Language follows the user** — Reply in Vietnamese if the user writes Vietnamese, English if English.
3. **Identify Antigravity-generated code** — If the error is in agent-generated code (look for hallucinated APIs, wrong type assumptions, non-existent imports), flag it explicitly so the user knows to re-prompt the agent.
4. **One clarifying question max** — If the error is ambiguous, ask exactly one question to unblock diagnosis.

### Error Classification

| Error Type | Signature |
|---|---|
| **TypeError** | `Cannot read properties of undefined/null`, `is not a function` |
| **ReferenceError** | `X is not defined` |
| **Async/Promise** | `UnhandledPromiseRejection`, `[object Promise]`, missing `await` |
| **TypeScript type** | `Type 'X' is not assignable to type 'Y'` |
| **Module/Import** | `Cannot find module`, `ERR_MODULE_NOT_FOUND` |
| **Runtime crash** | `heap out of memory`, non-zero exit code, `SIGTERM` |
| **API/Network** | `fetch failed`, `ECONNREFUSED`, HTTP 4xx/5xx in code |
| **Agent hallucination** | Import or API call that does not exist in the codebase or any npm package |

### Step-by-Step Process

1. **Identify input type** — Determine whether the user provided a stack trace, screenshot, or verbal description. For verbal descriptions, ask one clarifying question if the error message is unclear.
2. **Classify the error** — Match against the table above to identify error type quickly.
3. **Find root cause** — Focus on the first line of the error message and the first relevant stack frame. Ignore noise from node_modules.
4. **Detect agent origin** — Check if the error originates from agent-generated code. If so, note this in the response.
5. **Respond in standard format** — Always use the output format below.

### Output Format

```
🔴 [Error name]
📍 Cause: [1–2 sentences max]
✅ Fix: [specific step or code snippet, 1–5 lines]
⚠️ Note: [only if there is an important edge case — omit otherwise]
```

### Pre-diagnosis Checklist

- [ ] Is the error in user-written code or agent-generated code?
- [ ] Is there a stack trace, or only a vague description?
- [ ] Does the error involve async/await, which is the most common source of confusion in Antigravity agent output?
- [ ] Is there a missing import pointing to a file the agent planned but never created?