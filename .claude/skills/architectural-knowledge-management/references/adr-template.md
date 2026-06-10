# ADR Templates Reference
 
Read this file when you need the exact template text to populate an ADR, or when a project
uses a non-MADR format and you need to match their convention.
 
## Table of Contents
 
1. MADR 4.0 — Full Template (default)
2. MADR 4.0 — Minimal Template
3. Nygard Template (original ADR format)
4. Y-Statement Template (one-liner format)
5. Bootstrapping ADR (ADR-0000)
6. Retrospective ADR Guide
 
---
 
## 1. MADR 4.0 — Full Template
 
Use this for Standard and Heavyweight decisions. All sections marked `<!-- optional -->` can
be removed if not applicable.
 
```markdown
---
status: "{proposed | accepted | rejected | deprecated | superseded}"
date: {YYYY-MM-DD}
decision-makers: {list}  <!-- optional -->
consulted: {list}  <!-- optional -->
informed: {list}  <!-- optional -->
---
 
# {Short Noun Phrase Title}
 
## Context and Problem Statement
 
{Describe the context and problem statement, e.g., in free form using two to three
sentences or in the form of an illustrative story. You may want to articulate the problem
in the form of a question and add links to collaboration boards or issue management systems.}
 
## Decision Drivers  <!-- optional -->
 
* {Decision driver 1, e.g., a force, facing concern, …}
* {Decision driver 2, e.g., a force, facing concern, …}
* …
 
## Considered Options
 
1. {Title of option 1}
2. {Title of option 2}
3. {Title of option 3}
* …
 
## Decision Outcome
 
Chosen option: "{title of option 1}", because {justification. e.g., only option which
meets k.o. criterion decision driver | which resolves force {force} | … | comes out
best (see below)}.
 
### Consequences  <!-- optional -->
 
* Good, because {positive consequence, e.g., improvement of one or more desired qualities, …}
* Bad, because {negative consequence, e.g., compromising one or more desired qualities, …}
* …
 
### Confirmation  <!-- optional -->
 
{Describe how the implementation of/compliance with the ADR can/will be confirmed. E.g.,
by a review or an automated test. Is the chosen design and its implementation in line
with the decision? Note that although we classify this element as optional, it is included
in many ADRs.}
 
## Pros and Cons of the Options  <!-- optional -->
 
### {Title of Option 1}
 
{Example | description | pointer to more information | …}
 
* Good, because {argument a}
* Good, because {argument b}
* Neutral, because {argument c}
* Bad, because {argument d}
* …
 
### {Title of Option 2}
 
{Example | description | pointer to more information | …}
 
* Good, because {argument a}
* Good, because {argument b}
* Neutral, because {argument c}
* Bad, because {argument d}
* …
 
### {Title of Option 3}
 
{Example | description | pointer to more information | …}
 
* Good, because {argument a}
* Good, because {argument b}
* Neutral, because {argument c}
* Bad, because {argument d}
* …
 
## More Information  <!-- optional -->
 
{You might want to provide additional evidence/confidence for the decision outcome here
and/or document the team agreement on the decision and/or define when/how this decision
should be realized and if/when it should be re-visited. Links to other decisions and
resources might appear here as well.}
```
 
---
 
## 2. MADR 4.0 — Minimal Template
 
Use this for Lightweight decisions or when the project prefers brevity.
 
```markdown
---
status: "{proposed | accepted | rejected | deprecated | superseded}"
date: {YYYY-MM-DD}
---
 
# {Short Noun Phrase Title}
 
## Context and Problem Statement
 
{Describe context and problem in free form, two to three sentences.}
 
## Considered Options
 
1. {Title of option 1}
2. {Title of option 2}
3. {Title of option 3}
* …
 
## Decision Outcome
 
Chosen option: "{title of option 1}", because {justification}.
```
 
---
 
## 3. Nygard Template
 
Michael Nygard's original format from 2011. Simpler, more narrative. Use this if the project
already follows this convention, or if the team prefers prose over structured lists.
 
```markdown
# {ADR Number}. {Title}
 
Date: {YYYY-MM-DD}
 
## Status
 
{Proposed | Accepted | Deprecated | Superseded by [ADR NNNN](NNNN-title.md)}
 
## Context
 
{The forces at play, including technological, political, social, and project local. These
forces are probably in tension, and should be called out as such. The language in this
section is value-neutral. It is simply describing facts.}
 
## Decision
 
{The response to the forces. Stated in full sentences, with active voice. "We will …"}
 
## Consequences
 
{The resulting context, after applying the decision. All consequences should be listed here,
not just the "positive" ones. A particular decision may have positive, negative, and neutral
consequences, but all of them affect the team and project in the future.}
```
 
---
 
## 4. Y-Statement Template
 
A one-liner summary format from Zdun et al. Useful for quick capture that can be expanded
later, or as the TL;DR at the top of a longer ADR.
 
**Short form:**
```
In the context of {use case/user story}, facing {concern},
we decided for {option} to achieve {quality}, accepting {downside}.
```
 
**Long form:**
```
In the context of {use case/user story}, facing {concern},
we decided for {option} and neglected {other options},
to achieve {system qualities/desired consequences},
accepting {downside/undesired consequences},
because {additional rationale}.
```
 
### When to use
 
- As a summary line at the top of a MADR or Nygard ADR
- In meeting notes or chat as a quick capture before writing the full ADR
- When the decision is simple enough that one sentence suffices
 
---
 
## 5. Bootstrapping ADR (ADR-0000)
 
When initializing a new decision log, create this as the first ADR. It serves as both the
meta-decision and a working example of the chosen format.
 
```markdown
---
status: "accepted"
date: {YYYY-MM-DD}
---
 
# Use MADR for Architecture Decision Records
 
## Context and Problem Statement
 
We need to record architecturally significant decisions made in this project. Which format
and structure should these records follow?
 
## Decision Drivers
 
* Decisions must be version-controlled alongside code
* Format must be easy to write and read without special tooling
* Template should encourage structured thinking (context, options, tradeoffs)
* Must be adoptable incrementally — not all-or-nothing
 
## Considered Options
 
1. MADR 4.0 (Markdown Architectural Decision Records)
2. Nygard's original template
3. Y-Statements only
4. Free-form wiki pages
5. No formal decision records
 
## Decision Outcome
 
Chosen option: "MADR 4.0", because it provides structured sections for context, options,
and consequences while remaining lightweight enough for regular use. The minimal template
keeps the barrier low; the full template is available when deeper analysis is warranted.
 
### Consequences
 
* Good, because decisions are captured close to the code in version control
* Good, because the template forces explicit consideration of alternatives and tradeoffs
* Good, because the format is plain Markdown — no special tools required
* Bad, because maintaining ADRs requires discipline that must be reinforced in code review
* Neutral, because the team needs to agree on when a decision warrants an ADR
 
### Confirmation
 
Verify during code reviews that architecturally significant changes reference or include
relevant ADRs.
 
## More Information
 
* MADR project: https://adr.github.io/madr/
* ADR overview: https://adr.github.io/
* Nygard's original post: https://www.cognitect.com/blog/2011/11/15/documenting-architecture-decisions
```
 
---
 
## 6. Retrospective ADR Guide
 
When documenting a decision that was already made (possibly long ago), follow this approach:
 
1. **State clearly this is retrospective.** Add a note in Context:
   "This ADR retroactively documents a decision made in {month/year}."
 
2. **Reconstruct context from evidence.** Git history, old PRs, Slack threads, commit
   messages. State what you can verify and flag what you're inferring.
 
3. **List the options that were likely considered.** Even if you only know what was chosen,
   list the obvious alternatives for completeness. Mark inferred options: "Likely considered
   but not documented."
 
4. **Be honest about gaps.** If you don't know why Option B was rejected, say so. A partial
   ADR is better than no ADR.
 
5. **Set the status to Accepted** (or Deprecated/Superseded if the decision has since
   changed).
 
6. **Use this pattern in Context:**
   ```
   This decision was made approximately {date/period} during {project phase/initiative}.
   The original rationale was not formally documented. This ADR reconstructs the context
   from {sources: git history, team interviews, code comments, etc.}.
   ```
 
---
 
## Format Detection
 
When working in an existing project, detect the ADR format before creating new ones:
 
1. Check `docs/decisions/`, `docs/adr/`, `adr/`, or `decisions/` directories
2. Read 2-3 existing ADRs to identify the template in use
3. Match the existing format — consistency within a project trumps template preference
4. If no existing ADRs but the project has an `.adr-dir` file, honor its path setting
5. If multiple formats coexist, suggest standardizing in a new ADR-0000
