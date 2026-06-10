# Decision Categories & Significance Criteria
 
Read this file when auditing a project's decision log for gaps, or when deciding whether a
choice warrants an ADR.
 
## Table of Contents
 
1. Architectural Significance Criteria
2. Common Decision Categories
3. Decision Identification Triggers
 
---
 
## 1. Architectural Significance Criteria
 
A decision is architecturally significant if it meets one or more of these criteria
(adapted from Zimmermann's 5+2 criteria):
 
| Criterion | Question to Ask |
|-----------|----------------|
| **Business value / risk** | Does this choice directly affect revenue, compliance, or business continuity? |
| **Stakeholder concern** | Has a stakeholder explicitly raised this as important? |
| **Quality attribute impact** | Does this measurably affect performance, security, scalability, maintainability, or reliability? |
| **External dependency** | Does this introduce or change a dependency on a vendor, service, or third-party component? |
| **Cross-cutting** | Does this affect multiple components, services, or teams? |
| **First-of-a-kind** | Is this the first time the project faces this type of decision? (Sets a precedent.) |
| **Past troublemaker** | Has this type of decision caused problems in past projects or earlier iterations? |
 
**Rule of thumb:** If you'd explain this choice to a new team member during onboarding,
it probably deserves an ADR.
 
---
 
## 2. Common Decision Categories
 
Use these categories to audit a project's decision log for gaps. Not every project needs
ADRs in every category — but for each category that applies, check whether the significant
choices are documented.
 
### Technology Choices
 
- Programming language(s)
- Framework(s) and runtime(s)
- Database(s) — type, engine, hosting
- Message broker / event bus
- Cache layer
- Search engine
- CI/CD platform
- Cloud provider and core services
- Container orchestration
- Monitoring and observability stack
- Package manager and dependency strategy
 
### Architecture Patterns
 
- System decomposition (monolith, modular monolith, microservices, serverless)
- Communication patterns (sync REST, async messaging, gRPC, GraphQL)
- Data ownership and boundaries (per-service DB, shared DB, CQRS, event sourcing)
- API style and versioning strategy
- Error handling philosophy (fail-fast, circuit breaker, retry policies)
- State management (stateless services, session affinity, distributed state)
 
### Security & Compliance
 
- Authentication mechanism (OAuth2, SAML, API keys, mTLS)
- Authorization model (RBAC, ABAC, policy engine)
- Data encryption (at rest, in transit, field-level)
- Data residency and sovereignty constraints
- PII handling and retention policies
- Audit logging approach
- Secrets management
- Compliance framework adherence (SOC2, HIPAA, GDPR, etc.)
 
### Infrastructure & Operations
 
- Deployment strategy (blue/green, canary, rolling)
- Environment topology (dev, staging, prod, preview envs)
- Infrastructure-as-code tool and approach
- Scaling strategy (horizontal, vertical, auto-scaling policies)
- Disaster recovery and backup strategy
- SLO/SLA targets and error budgets
 
### Development Process
 
- Branching and merge strategy
- Code review requirements
- Testing strategy (unit/integration/e2e balance, coverage targets)
- Documentation approach (co-located, wiki, generated)
- Dependency update policy
- Feature flag system
 
### Data & Integration
 
- Data pipeline architecture
- ETL/ELT approach
- Schema evolution and migration strategy
- Third-party integration patterns
- Event schema format (Avro, Protobuf, JSON Schema)
- Idempotency and deduplication strategy
 
---
 
## 3. Decision Identification Triggers
 
These situations signal that an ADR should be created or consulted:
 
### During Development
 
- Choosing between two or more libraries, frameworks, or tools
- Introducing a new dependency
- Changing a public API contract
- Modifying the database schema in a structural way (new table, index strategy change)
- Setting up a new service or module
- Implementing a pattern for the first time in the codebase
- Working around a constraint imposed by a previous decision
- Noticing that code contradicts a documented decision
 
### During Review
 
- A PR introduces an architectural pattern not seen elsewhere in the codebase
- A reviewer asks "why did you do it this way?" and the answer isn't obvious
- A change affects more than one service or major component
- A change modifies infrastructure configuration
 
### During Planning
 
- Sprint planning surfaces a "we need to decide" item
- A new feature requires choosing between implementation approaches
- Scaling concerns emerge that require infrastructure changes
- A vendor contract is being evaluated or renewed
 
### In Claude Code / Agentic Workflows
 
- Claude is about to make a structural choice (file organization, module boundaries, etc.)
- Claude encounters a pattern question it can't answer from the codebase alone
- Claude is implementing something that might conflict with an existing decision
- Claude is starting work on a new feature area — check for relevant ADRs first
 