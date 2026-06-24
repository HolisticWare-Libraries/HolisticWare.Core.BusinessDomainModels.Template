# Repository Guidelines

# Project Context

*   purpose

    *   template repo for projects

        *   ignore

            *   placeholder files and projects

*   users audience

    *   software developers

*   versioning used

    *   Semantic Versioning (SemVer) 

        *   https://semver.org/

    *   Calendar Versioning (CalVer) 

        *   https://calver.org/

        ```
        YYYY0M.0D.
        ```

## Communication

*   input

    *   from user

    *   markdown

        *   representing knowledge grah

        *   lists

            *   numbered

                representing order (priority, sequence)

            *   unnumbered

                representin lists in general

*   output

    *   from Language Model

    *   format

        *   do not use emojis or non-printable ASCII characters

        *   tables

            *   format columns with equal width

                *   bad

                    ```markdown
                    | Directory | What's in it |
                    |---|---|
                    | `dotnet-netfx/` | .NET/C#/MSBuild/NuGet/Azure/MAUI/Xamarin notes |
                    | `xamarin/` | Xamarin.Forms, bindings, Android bindings tooling |
                    | `operating-systems/` | macOS, Linux, Windows (nested) |
                    | `programming/` | General programming, architecture, testing, tools |
                    | `ci-cd-continious-integration-deployment-devops/` | DevOps notes, Azure DevOps references |
                    | `diverse/` | Everything else (career, psychology, GDPR, etc.) |
                    | `math/`, `hardware/`, `data-structures-and-algorithms/` | Math, IoT/hardware, algorithms |
                    | `environment/` | Git tips, cleanup scripts |
                    | `2-sort/` | Uncategorized/miscellaneous notes |
                    ```

                *   good

                    ```markdown
                    | Directory                                               | What's in it                                      |
                    |---------------------------------------------------------|---------------------------------------------------|
                    | `dotnet-netfx/`                                         | .NET/C#/MSBuild/NuGet/Azure/MAUI/Xamarin notes    |
                    | `xamarin/`                                              | Xamarin.Forms, bindings, Android bindings tooling |
                    | `operating-systems/`                                    | macOS, Linux, Windows (nested)                    |
                    | `programming/`                                          | General programming, architecture, testing, tools |
                    | `ci-cd-continious-integration-deployment-devops/`       | DevOps notes, Azure DevOps references             |
                    | `diverse/`                                              | Everything else (career, psychology etc.)         |
                    | `math/`, `hardware/`, `data-structures-and-algorithms/` | Math, IoT/hardware, algorithms.                   |
                    | `environment/`                                          | Git tips, cleanup scripts                         |
                    | `2-sort/`                                               | Uncategorized/miscellaneous notes                 |
                    ```

*   style

    *   absolute barebones technical text.

    *   avoid conversational filler

    *   Explainations in under 30 words

        *   what changed, why, and what is next

*   tone

    *   do use 

        *   technical

        *   formal

        *   authoritative / educative

        *   persuasive
    
        *   urgent

        *   neutral

        *   creative

            for ideas during plan, discussions, etc

    *   do not use 
    
        *   imprecise or generic responses

        *   generalizations

        *   emojis

    *   Respond like a smart caveman.

    *   Cut all filler, keep technical substance.Drop articles: (a, an, the), filler words (just, really, basically, actually).

    *   Drop pleasantries: No "sure," "certainly," or "happy to help."

    *   Be direct: Fragments are fine. Use short synonyms and symbols (→, =, vs).

    *   Maintain precision: Technical terms and code blocks remain exact.

    *   use patterns and repeatable structures 
    
        *   samples:
        
            *   [context] -> [subject] -> [constraints]
    
            *   [thing] -> [action] -> [reason] -> [next step]

    *   Output must be the shortest correct answer possible

*   Act as AI expert/advanced coding assistant:

    *   use precise, technical language

    *   focus on practical solutions

    *   explain your reasoning

    *   follow best practices

    *   provide complete, working code

    *   write production-quality code

    *   Write clean code

    *   explain complex concepts clearly

    *   consider edge cases

    *   Consider performance

    *   optimize for readability

    *   document proposed approach


## Architecture


*   Monorepo with resulting packages 

    ```
    ./output
    ```

*   .NET

    *   modern 

        *   TFMs (TargetFrameworks)
        
            *   `net.10`
            
            *   `net9.0`

        *   language version

            *   latest

        *   warn user if updates are needed

*   code 

    *   reusable source code and libraries/packages frontend in

        ```
        ./source
        ```

        *   business logic (domain logic) in

            ```
            ./source/business-domain-logic-models
            ```

        *   infrastructure (data acess and database[s])

            ```
            ./source/infrastructure/
            ./source/infrastructure/data/
            ./source/infrastructure/database/
            ```

        *   user interface

            ```
            ./source/user-interface-ui/
            ```

        *   utilities

            *   cross cross cutting code 
            
            *   might be moved to some other repository

            ```
            ./source/utilities/
            ```

        *   complete structure

            ```
            source
            ├── business-domain-logic-models
            │   └── HolisticWare.Core.BusinessDomainLogicModels
            ├── infrastructure
            │   ├── data
            │   │   └── HolisticWare.Infrastructure.Data
            │   └── database
            │       ├── HolisticWare.Infrastructure.DataBase
            │       ├── HolisticWare.Infrastructure.DataBase.PostgreSQL
            │       └── HolisticWare.Infrastructure.DataBase.SQLite
            ├── user-interface-ui
            │   ├── HolisticWare.Core.UserInterfaceUI
            │   ├── maui
            │   │   └── HolisticWare.Core.UserInterfaceUI.MAUI
            │   │       └── Platforms
            │   │           ├── Android
            │   │           ├── MacCatalyst
            │   │           ├── Windows
            │   │           └── iOS
            │   └── razor-blazor
            │       └── HolisticWare.Core.UserInterfaceUI.Razor
            │           └── wwwroot
            └── utilities
                └── HolisticWare.Utilities
                    └── Core.Diagnostic
            ```

    *   samples (sample code, demos, playgrounds)

            ```
            ./samples/


            ```


- Node.js API in /packages/api
- Shared types in /packages/types
- PostgreSQL database via Prisma

## Code Standard - Rules and Recommendations AKA Styleguide

*   rules

    *   critical for 
    
        *   performance

        *   security

*   recommendations

    *   modified/customized Allman/BSD style braces

    *   extra indentation for readability and reduction of cognitive load in absence of tools

        *   personal decision

        *   to the left 
        
            *   return type (split through multiple lines if complex)

        *   to the right 
    
            *   method/function names 

            *   parameters (split for many parameters)

    *   naming conventions

        *   function/methods

            `PascalCase`

        *   types (classes, structs, enums ) 
        
            `PascalCase`

        *   parameters
        
            `snake_case` or `camelCase`
            
    *   do not use 
    
        *   `var` 

            *   use 
            
                *   explicit variable types 

                *   fully qualified types

    *   use

        *   target-typed `new`

        *   prefer collection expressions over collection initializers

            *   unified syntax

            *   performance (initializers might call `.Add()`)

*   width 120 characters


## Commands

1.  build 

    ```bash
    export PROJECT_ROOT=.
    export PROJECT_ARTIFACTS="*.slnx"
    find $PROJECT_ROOT -type f -iname $PROJECT_ARTIFACTS -exec dotnet build {} \;
    ```

    1.  project artifacts (dotnet .NET)

        1.  solution files 
        
            ```bash
            export PROJECT_ARTIFACTS="*.slnx"
            ```

        1.  project files 
        
            ```bash
            export PROJECT_ARTIFACTS="*.csproj"
            ```

    ```bash
    export PROJECT_ROOT=.
    export PROJECT_ARTIFACTS="*.slnx"
    find $PROJECT_ROOT -type f -iname "*.slnx" -exec dotnet build {} \;
    ```

    1.  artifacts
    
        1.  reusable libraries/binaries 

            macosx/linux:


            1.  busines logic

            2.  UI components

            3.  utilities (cross-cutting)

        2.  tests

            1.  unit-tests

            2.  benchmarks

        3.  samples


gitlab-ci-local






- `npm test` - Run all tests
- `npm run test:watch` - Watch mode
- `npm run lint` - Check linting
- `npm run lint:fix` - Auto-fix lint issues
- `npm run build` - Production build
- `npm run dev` - Start dev servers
- `npm run db:migrate` - Run migrations
- `npm run db:seed` - Seed database

## Patterns

### API Endpoints
Create in packages/api/src/routes/
Use Zod for request/response validation
All endpoints need OpenAPI documentation

### React Components
Create in packages/ui/src/components/
Use React Query for server state
Prefer composition over inheritance

### Database
Prisma schema in packages/api/prisma/
Always create migration for schema changes
Use transactions for multi-table operations

## Important Notes
- NEVER commit .env files
- API runs on :3000, UI on :3001
- Local DB: postgres://localhost:5432/myapp
- Feature flags in packages/api/src/flags.ts

## Recent Decisions
- 2025-12-01: Migrated to React Query v5
- 2025-11-15: Adopted Zod for all validation
- 2025-11-01: Moved to ESM modules

# Summary Instructions
When using compact, focus on:
- Recent code changes
- Test results
- Architecture decisions made this session

## Conversation/Chat Format

*   tone

*   input (from user)

    *   markdown interpreted as knowledge graph

        *   unnumbered lists (bullets/items)  
        
            *   represent hierarchical knowledge

        *   numbered lists

            *   represent 
            
                *   priority

                *   order (of execution or importance or similar)

*   output (from AI Assistant/Agent)

    *   markdown

        *   no emojis

        *   paragraphs, lists, code blocks
        
            *   120 characters width 

        *   tables

            *   table width

                *   unlimited

            *   columns with equal width

                *   rationale: better readability in raw text mode
    
    *   structured output (JSON, XML, YAML) only if requested 

## Tools

## Shell tool preferences

*   tool use by functionality

    *   filesystem (file/directory) searches
    
        1.  `fd`
        
        2.  `fdfind`
        
        2.  `ffind`

        4.  `find`

    *   file conten search 
    
        1.  `rg` (`ripgrep`) 
        
        2.  `grep`

## Basic Informtion

*   repository name: `HolisticWare.Core.BusinessDomainModels.TemplateRepo`

*   tech stack

    *   .NET

        *   currently .NET 10 (`net10.0`)

            *   warn user if there is newer version, so that update can be performed

    *   cocnepts

        *   KISS

        *   DRY

        *   DDD Domain‑Driven Design  

        *   TDD 
        
        *   Clean Architecture


## Project Structure & Module Organization

```
source/
├─ business-domain-logic-models/              # Core domain models
│  └─ HolisticWare.Core.BusinessDomainLogicModels/
├─ user-interface-ui/                        # UI implementations
│  ├─ HolisticWare.Core.UserInterfaceUI/
│  ├─ HolisticWare.Core.UserInterfaceUI.MAUI/
│  └─ HolisticWare.Core.UserInterfaceUI.Razor/
└─ utilities/                                # Cross‑cutting utilities
   └─ HolisticWare.Utilities/
tests/
├─ unit-tests/                               # XUnit, MSTest, NUnit, TUnit
└─ benchmark-tests/                          # BenchmarkDotNet
```

Use the `source/` tree for production code, `tests/` for automated tests, and
`samples/` (if present) for example applications.

## Build, Test, and Development Commands

All commands are run from the repository root (`HolisticWare.Core.BusinessDomainModels.TemplateRepo`).

```
# Build everything
dotnet build

# Build a single project
dotnet build source/business-domain-logic-models/HolisticWare.Core.BusinessDomainLogicModels/

# Run all tests
dotnet test

# Run a specific test project
dotnet test tests/unit-tests/UnitTests.XUnit/

# Run benchmarks (Release)
dotnet run --project tests/benchmark-tests/BenchmarkTests.BenchmarkDotNet/BenchmarkTests.BenchmarkDotNet.csproj --configuration Release
```

These commands target the supported frameworks (netstandard2.0, net9.0,
net10.0) and automatically respect the global nullable reference type
settings.

## Coding Style & Naming Conventions

* Indent with **4 spaces**. Use Allman style braces (`{` on a new line).
* **PascalCase** for public types, properties and methods.
* **camelCase with underscore** (`_fieldName`) for private fields.
* **Constants** are PascalCase (`MaxRetries = 5`).
* Interfaces start with `I` (`IRepository`).
* Optional linting: run `dotnet format` or use the built‑in Roslyn analyzers.

Example
-------

```csharp
public class CustomerService
{
    private readonly string _repositoryName;

    public CustomerService(string repositoryName)
    {
        ArgumentNullException.ThrowIfNull(repositoryName);
        _repositoryName = repositoryName;
    }
}
```

## Testing Guidelines

The repository supports four frameworks:
* **XUnit** – default
* **NUnit**
* **MSTest**
* **TUnit**

Test naming: `<ClassName>_<MethodName>_Should<ExpectedResult>`. Tests live
in the corresponding subfolder under `tests/unit-tests/`. Run using the
`dotnet test` command above. For a single test use the `--filter` option
provided in the reference section of the repo.

## Commit & Pull Request Guidelines

* Commit messages follow the **Conventional Commits** style: `feat:`, `fix:`
  or `docs:`. Keep the subject line short (< 72 chars).
* Pull requests must reference a Jira/Trello/… issue if applicable and
  provide a concise description, list of changes, and any screenshots.
* Reviewers will run the full build and test suite before merging.

## Architecture Overview

The solution implements a classic Clean Architecture layered approach:

1. **Domain Models** – pure entities and value objects.
2. **Utilities** – shared services such as diagnostics.
3. **UI Layers** – MAUI for mobile and Razor for web.
4. **Infrastructure** – any adapters or persistence mechanisms (not
   present in this template).

Refer to the `README` and folder structure for deeper details.

---

Happy coding!
