---
name: ears-planning-method
description: >
  Structured planning method for code changes using EARS (Easy Approach to Requirements Syntax),
  RFC 2119 keywords, C4 architectural decomposition, and traceable verification. Use this skill
  whenever planning code changes, refactors, feature additions, bug fixes, or architectural work.
  Trigger on any request involving "plan", "design", "architect", "implement", "refactor",
  "restructure", or when the user asks for an EARS plan explicitly. Also trigger when a change
  touches multiple files/modules or when the user asks how something should be built. For trivial
  single-file fixes, produce a lightweight plan automatically — no need for the user to ask for
  "lightweight" explicitly. Scale up to full EARS + C4 as complexity grows.
---
 
# EARS Planning Method
 
Produce structured, traceable plans for code changes. Every plan separates **what the system must do** (requirements) from **how the agent will do it** (implementation) from **how we prove it works** (verification).
 
## Complexity Tiers
 
Assess the change and pick the appropriate tier. Do not over-plan trivial work.
 
| Tier | Signal | Plan shape |
|------|--------|------------|
| **Light** | Single file, isolated bug fix, < ~30 LOC delta | Requirements (2-3 R#) → Steps (1-2 S#) → Verification (1 V#). No C4. |
| **Standard** | Multi-file feature, moderate refactor, new component | Full EARS requirements → Implementation steps → Verification. C4 Component diagram if 2+ modules interact. |
| **Heavy** | Cross-cutting concern, new subsystem, architectural migration | Full EARS + RFC 2119 precision → C4 (depth as needed) → Implementation chunked into committable units with USER checkpoints → Comprehensive verification matrix. |
 
When in doubt, start Standard and escalate if you discover hidden complexity while drafting.
 
---
 
## 1. Requirements — EARS Syntax
 
Write requirements about the **system/component under change**, not about the agent's to-do list. Name the system explicitly (e.g. `AuthService`, `WizardState`, `bep new`).
 
### Patterns
 
| Pattern | Template | Use when |
|---------|----------|----------|
| **Ubiquitous** | `The <system> SHALL <response>.` | Invariant, always true |
| **State-driven** | `While <precondition(s)>, the <system> SHALL <response>.` | Behavior depends on state |
| **Event-driven** | `When <trigger>, the <system> SHALL <response>.` | Reaction to a stimulus |
| **Optional/Scope** | `Where <feature/scope>, the <system> SHALL <response>.` | Conditional feature |
| **Unwanted** | `If <unwanted condition>, then the <system> SHALL <mitigation>.` | Error/edge-case handling |
| **Complex** | `While <precondition(s)>, when <trigger>, the <system> SHALL <response>.` | State + event combined |
 
### Requirement rules
 
- Assign IDs: `R1`, `R2`, … — implementation and verification reference these.
- Prefer **observable behavior and invariants**. Avoid file/function names unless they are part of the external contract.
- One testable assertion per requirement. If a requirement contains "and" joining two distinct behaviors, split it.
- Use **RFC 2119 keywords** (see §4) for precision: distinguish MUST from SHOULD from MAY.
 
---
 
## 2. Implementation Plan
 
Describe how you will satisfy the requirements as concrete agent actions, chunked into small committable units.
 
### Rules
 
- Size steps to the change: few steps for small fixes, multiple git-committable chunks for large changes.
- One concrete outcome per step: a code edit, a test addition, a verification run, or a USER checkpoint.
- Prefix with `S1`, `S2`, … and annotate which requirements each step addresses (`→ R1, R3`).
- Include a `USER checkpoint` step before and after risky or irreversible changes.
- Steps MUST be ordered so that each chunk leaves the codebase in a valid (ideally green-tests) state.
 
### Step types
 
| Marker | Meaning |
|--------|---------|
| `S#:` | Code change or file operation |
| `S# [TEST]:` | Test addition or modification |
| `S# [USER]:` | Checkpoint — pause for user review/commit |
| `S# [VERIFY]:` | Run verification (build, lint, test suite) |
 
---
 
## 3. Verification
 
Explicit checks that map back to requirements. Every R# MUST appear in at least one V#.
 
### Format
 
```
V<n> (R<x>, R<y>): <check command or manual validation description>
```
 
### Rules
 
- Each V# references one or more R# IDs.
- Name the check concretely: `npm test`, `cargo clippy`, `pytest tests/auth/`, or a targeted manual validation.
- If a requirement is not mechanically verifiable, say so and describe the manual check.
- Coverage: every R# MUST be covered. If you find an uncovered R#, add a V# or flag the gap.
 
---
 
## 4. RFC 2119 Keywords
 
Use these per [RFC 2119](https://www.rfc-editor.org/rfc/rfc2119) to convey requirement strength. Bold or uppercase when used normatively.
 
| Keyword | Meaning |
|---------|---------|
| **MUST** / **SHALL** | Absolute requirement. Violation = defect. |
| **MUST NOT** / **SHALL NOT** | Absolute prohibition. |
| **SHOULD** / **RECOMMENDED** | Strong default; deviation requires documented justification. |
| **SHOULD NOT** / **NOT RECOMMENDED** | Strong suggestion against; deviation requires justification. |
| **MAY** / **OPTIONAL** | Truly discretionary. Implementations that omit this are conformant. |
 
Apply within EARS requirements to distinguish hard constraints from preferences. If every requirement says SHALL, the distinction is lost — use the full range.
 
---
 
## 5. C4 Architectural Breakdown
 
Include a C4 decomposition when the change involves interactions across module boundaries. Pick the shallowest depth that makes the change legible.
 
Read `references/c4-guide.md` for diagramming patterns and depth selection criteria before producing C4 output.
 
### Quick depth selector
 
| Depth | Include when |
|-------|-------------|
| **Context** (L1) | Change affects external system integrations or user-facing boundaries |
| **Container** (L2) | Change spans services, databases, or deployment units |
| **Component** (L3) | Change involves 2+ internal modules/packages within a container |
| **Code** (L4) | Detailed class/function-level design needed (rare — usually pseudo is sufficient) |
 
Produce diagrams as Mermaid (`flowchart` or `C4Context`/`C4Container`/`C4Component` if using the C4 Mermaid extension) or as structured pseudocode tables — whichever is clearer for the change at hand.
 
### Pseudo-structural breakdown (alternative to diagrams)
 
When a full diagram is overkill but you need to show responsibilities:
 
```
Component: AuthService
  Responsibilities: Token issuance, validation, revocation
  Dependencies: UserStore, TokenCache
  Exposes: authenticate(), refresh(), revoke()
 
Component: TokenCache
  Responsibilities: Short-lived token storage, TTL enforcement
  Dependencies: Redis
  Exposes: get(), set(), invalidate()
```
 
This is often more useful than a diagram for Standard-tier plans.
 
---
 
## 6. Compartmentalization Principles
 
These principles govern how you decompose work. They are not optional style preferences — they protect code quality and maintainability.
 
1. **Single Responsibility per step.** Each implementation step (S#) touches one concern. If a step requires edits across unrelated modules, split it.
 
2. **Interface-first.** When a change introduces or modifies a boundary between components, define the interface (types, contracts, API surface) in a dedicated step before implementing either side.
 
3. **Test isolation.** Test additions (S# [TEST]) SHOULD be in separate steps from the code they validate. This ensures tests are written against the contract, not reverse-engineered from the implementation.
 
4. **Blast radius awareness.** For each S#, annotate the blast radius — which other components could break. This informs checkpoint placement: if blast radius > 1 module, insert a `[USER]` checkpoint.
 
5. **Dependency direction.** Note dependency flow in the plan. Changes MUST NOT introduce circular dependencies. If you detect a cycle, flag it and restructure before proceeding.
 
6. **Rollback feasibility.** Each committable chunk SHOULD be independently revertable. If a step cannot be reverted without also reverting a later step, merge them or flag the coupling.
 
---
 
## Plan Template
 
Use this shape. Omit sections that don't apply at the chosen tier (e.g. Light tier omits C4 and checkpoints).
 
```
## Context
<1-2 sentences: what's changing and why>
 
## Tier: <Light | Standard | Heavy>
 
## Architecture (Standard+)
<C4 diagram/pseudo-breakdown at appropriate depth>
 
## Requirements
R1: <EARS pattern with RFC 2119 keyword>
R2: ...
 
## Implementation
S1: <edit description> → R1
S2 [TEST]: <test addition> → R1
S3 [USER]: Review/commit chunk 1
S4: <edit description> → R2
S5 [VERIFY]: <build/test command>
 
## Verification
V1 (R1): <concrete check>
V2 (R2): <concrete check>
V3 (R1, R2): <integration check>
```
 
---
 
## Examples
 
### Light Tier — Bug fix
 
```
## Context
Off-by-one in pagination causes last item to be duplicated on page boundaries.
 
## Tier: Light
 
## Requirements
R1: When the page boundary aligns with the last item index,
    the PaginationService SHALL NOT duplicate the boundary item.
R2: The PaginationService SHALL return exactly `pageSize` items
    per page (or fewer on the final page).
 
## Implementation
S1: Fix boundary calculation in offset derivation → R1, R2
S2 [VERIFY]: npm test -- --grep pagination
 
## Verification
V1 (R1, R2): npm test -- --grep pagination (existing suite covers boundary cases)
```
 
### Standard Tier — New feature
 
```
## Context
Add rate limiting to the public API gateway.
 
## Tier: Standard
 
## Architecture
Component: RateLimiter
  Responsibilities: Per-client request counting, window management, limit enforcement
  Dependencies: Redis (sliding window counter), APIGateway (middleware hook)
  Exposes: checkLimit(clientId): {allowed: bool, retryAfter?: number}
 
Component: APIGateway
  Responsibilities: Request routing, middleware pipeline
  Change: Insert RateLimiter middleware before auth
 
## Requirements
R1: When a client exceeds 100 requests per 60s window,
    the RateLimiter SHALL reject the request with HTTP 429
    and a Retry-After header.
R2: The RateLimiter SHOULD use a sliding window algorithm.
    Fixed-window MAY be used if Redis version < 6.2.
R3: If Redis is unreachable, then the RateLimiter SHALL
    fail open (allow the request) and emit a warning log.
R4: The APIGateway SHALL invoke RateLimiter before
    authentication middleware.
 
## Implementation
S1: Define RateLimiter interface and types → R1, R2
S2: Implement sliding window counter against Redis → R2
S3 [TEST]: Unit tests for RateLimiter (under limit, at limit, over limit, window rollover) → R1, R2
S4: Implement fail-open fallback → R3
S5 [TEST]: Test Redis-unavailable path → R3
S6: Wire RateLimiter into APIGateway middleware pipeline → R4
S7 [USER]: Review — rate limiter is now active in the request path
S8 [VERIFY]: npm test && npm run test:integration
 
## Verification
V1 (R1, R2): Unit tests: rate_limiter.test.ts
V2 (R3): Unit test: redis_failover.test.ts
V3 (R4): Integration test: middleware_order.test.ts
V4 (R1): Manual: curl burst > 100 reqs, confirm 429 + Retry-After
```