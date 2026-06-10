# Architectural Smell Catalog
 
Common structural problems encountered during reviews, organized by detection signal and severity. Reference this when a pattern looks familiar but you need to articulate the root cause precisely.
 
## Data Pipeline Smells
 
### Ghost Data
**Signal**: Algorithms running on placeholder, random, or toy data instead of real inputs.
**Root Cause**: The mathematical/algorithmic layer was built before the ingestion layer. Common in research-to-product transitions.
**Impact**: All downstream analysis is meaningless. Patterns detected are artifacts of noise.
**Action**: Trace data flow from source to algorithm input. If any link in the chain uses synthetic data, flag it and prioritize real data wiring.
 
### Format Thrashing
**Signal**: Data converted between formats in hot paths (e.g., COO → CSR → LIL → CSR, or JSON → dict → dataclass → dict → JSON).
**Root Cause**: Multiple contributors or evolution over time without format standardization.
**Impact**: Performance degradation, memory pressure, subtle bugs from lossy conversions.
**Action**: Pick one canonical format per layer boundary. Convert once at the boundary, never in the interior.
 
### Hollow Coupling
**Signal**: Cross-component relationships defined in code but populated with empty/zero data.
**Root Cause**: Interface designed top-down before real data exists to populate it.
**Impact**: Components appear connected but operate in isolation. Integration is illusory.
**Action**: Either populate with real data (preferred) or remove the coupling and acknowledge the components are independent until real data exists.
 
## Abstraction Smells
 
### Premature Abstraction
**Signal**: Abstract base class with exactly one concrete implementation.
**Root Cause**: Designing for flexibility that hasn't been needed yet.
**Impact**: Added indirection without value. Harder to navigate, no polymorphism benefit.
**Action**: Collapse to concrete unless a second implementation is planned for the current sprint. Interfaces are cheap to extract later.
 
### Abstraction Inversion
**Signal**: High-level operations implemented by reaching through abstractions to low-level primitives (e.g., calling `.toarray()` on a sparse matrix inside a "scalable" solver).
**Root Cause**: Abstraction boundary doesn't match actual computation needs.
**Impact**: Defeats the purpose of the abstraction. Performance guarantees broken.
**Action**: Fix the abstraction boundary so the operation can be performed at the correct level.
 
### Theory-Practice Gap
**Signal**: Sophisticated mathematical framework with toy/broken implementation underneath.
**Root Cause**: Research-first development where theory outpaces engineering.
**Impact**: Impressive on paper, useless in practice. Demo results are misleading.
**Action**: Freeze theory development. Wire up real data end-to-end for ONE use case before extending the theory further.
 
## Performance Smells
 
### Dense Fallback
**Signal**: Sparse data structures converted to dense for operations that have sparse equivalents.
**Root Cause**: Developer familiarity with dense operations, or library API gaps.
**Impact**: Memory scales as O(n²) instead of O(nnz). Fails silently at scale.
**Action**: Audit all `.toarray()`, `.todense()`, or equivalent calls. Replace with sparse operations from the same library.
 
### Blocking Pipeline
**Signal**: Synchronous/blocking calls in a path that should be concurrent (e.g., `subprocess.run()` in an agent orchestrator).
**Root Cause**: Prototype code that was never made async.
**Impact**: Throughput bottleneck. N sequential operations take N × latency instead of max(latency).
**Action**: Identify the critical path. Make it async. Blocking operations move to background workers with job queues.
 
### Rebuild-Everything
**Signal**: Full recomputation on every change instead of incremental updates.
**Root Cause**: Incremental update logic is harder to implement correctly.
**Impact**: Latency scales with total data size, not change size. Unusable for interactive workflows.
**Action**: Identify the most frequent change type. Implement incremental update for that one case first. Full rebuild remains as fallback.
 
## Integration Smells
 
### Impedance Denial
**Signal**: Two systems with fundamentally different models (sync vs async, stateless vs stateful, request-response vs event-driven) being integrated without an explicit translation layer.
**Root Cause**: Assuming both sides can "just" adapt.
**Impact**: One side's model gets forced on the other, creating bugs, performance issues, and maintenance burden.
**Action**: Name the mismatch explicitly. Design an adapter that translates between the two models at the boundary.
 
### Shared State Assumption
**Signal**: Integration assumes both systems can read/write the same state without coordination.
**Root Cause**: Works in prototype (single machine), breaks in production (distributed).
**Impact**: Race conditions, stale reads, lost updates.
**Action**: Define ownership. One system owns each piece of state. Others read through defined interfaces with explicit consistency guarantees.
 
### Missing Transaction Boundaries
**Signal**: Multi-step operations across systems with no atomicity, rollback, or compensation logic.
**Root Cause**: "Happy path" development — it works when nothing fails.
**Impact**: Partial state on failure. Data corruption. Manual recovery required.
**Action**: Define where transactions begin and end. Implement compensation (saga pattern) or explicit rollback for each step.
 
## Development Process Smells
 
### Dogfood Avoidance
**Signal**: Tool designed to analyze/process X has never been run on itself.
**Root Cause**: Team focuses on external validation before internal validation.
**Impact**: Obvious issues go undetected. Credibility suffers when the tool can't handle its own domain.
**Action**: Run the tool on its own codebase. If it can't produce useful results on a known-structure project, it's not ready for unknown projects.
 
### Demo-Driven Development
**Signal**: Features built to look good in demos rather than to solve real problems. Metrics chosen for impressiveness rather than meaningfulness.
**Root Cause**: Pressure to show progress.
**Impact**: Working demo, broken product. Technical debt disguised as features.
**Action**: Define success metrics from user needs, not demo scripts. Validate against real workloads.
 
