# HolisticWare BusinessDomainLogic App Suite

# HolisticWare BusinessDomainLogic App Suite

## Architecture

Overview

This is a .NET 10.0 solution following Domain-Driven Design and Clean Architecture patterns:

```
 HolisticWare.Core.BusinessDomainModels.TemplateRepo/
 ├─ source/
 │  ├─ business-domain-logic-models/                        # Core domain models (netstandard2.0, net9.0, net10.0)
 │  │  └─ HolisticWare.Core.BusinessDomainLogicModels/
 │  ├─ user-interface-ui/                                   # UI implementations
 │  │  ├─ HolisticWare.Core.UserInterfaceUI/                # Base UI library (net9.0, net10.0)
 │  │  ├─ HolisticWare.Core.UserInterfaceUI.MAUI/           # MAUI mobile UI (android, ios, maccatalyst, windows)
 │  │  └─ HolisticWare.Core.UserInterfaceUI.Razor/          # Blazor/Razor components
 │  └─ utilities/                                           # Cross-cutting concerns
 │     └─ HolisticWare.Utilities/                           # Shared utilities (includes Core.Diagnostic)
 └─ tests/
    ├─ unit-tests/                                          # Unit tests (XUnit, MSTest, NUnit, TUnit)
    └─ benchmark-tests/                                     # BenchmarkDotNet benchmarks
```

## Key Projects

| Project                                       | Target Frameworks                          | Purpose                         |
|-----------------------------------------------|--------------------------------------------|---------------------------------|
| `HolisticWare.Core.BusinessDomainLogicModels` | netstandard2.0, net9.0, net10.0            | Core business domain models     |
| `HolisticWare.Utilities`                      | netstandard2.0, net9.0, net10.0            | Shared utilities and diagnostics|
| `HolisticWare.Core.UserInterfaceUI`           | net9.0, net10.0                            | Base UI abstractions            |
| `HolisticWare.Core.UserInterfaceUI.MAUI`      | net10.0-android, ios, maccatalyst, windows | Mobile UI via MAUI              |
| `HolisticWare.Core.UserInterfaceUI.Razor`     | net10.0                                    | Blazor/Razor components         |

## Development Commands

```bash
# Build entire solution
dotnet build

# Build specific project
dotnet build source/business-domain-logic-models/HolisticWare.Core.BusinessDomainLogicModels/

# Run all tests
dotnet test

# Run specific test project
dotnet test tests/unit-tests/UnitTests.XUnit/

# Run benchmarks
dotnet \
    run \
        --project tests/benchmark-tests/BenchmarkTests.BenchmarkDotNet/BenchmarkTests.BenchmarkDotNet.csproj \
        --configuration Release

# Run sample console app
dotnet \
    run \
        --project samples/clients/console/cli/AppConsole.SampleDemo/
```

## Coding Conventions

- **Nullable reference types** enabled throughout
- **Implicit usings** enabled
- **PascalCase** for types and members
- Target frameworks: netstandard2.0 for libraries, net10.0 for UI applications
- MAUI projects use `<UseMaui>true</UseMaui>` and `<SingleProject>true</SingleProject>`

## Solution Structure

- Main solution: `HolisticWare.Core.BusinessDomainModels.TemplateRepo.sln`
- Solution nodes (slnx files) organize projects by category:
  - `source/source.slnx` - Source projects
  - `tests/tests.slnx` - All test projects
  - `tests/unit-tests/unit-tests.slnx` - Unit tests only
  - `tests/benchmark-tests/benchmark-tests.slnx` - Benchmark tests
  - `samples/samples.slnx` - Sample applications



