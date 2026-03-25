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

## Testing Details

### Running Tests

```bash
# Run all tests across all frameworks
dotnet test

# Run specific test framework
dotnet test tests/unit-tests/UnitTests.XUnit/UnitTests.XUnit.csproj
dotnet test tests/unit-tests/UnitTests.NUnit/UnitTests.NUnit.csproj
dotnet test tests/unit-tests/UnitTests.MSTest/UnitTests.MSTest.csproj
dotnet test tests/unit-tests/UnitTests.TUnit/UnitTests.TUnit.csproj

# Run single test by name (XUnit)
dotnet test tests/unit-tests/UnitTests.XUnit/ --filter "FullyQualifiedName~TestClass.TestMethod"

# Run single test by name (NUnit)
dotnet test tests/unit-tests/UnitTests.NUnit/ --filter "Name~TestMethod"

# Run single test by name (MSTest)
dotnet test tests/unit-tests/UnitTests.MSTest/ --filter "FullyQualifiedName~TestClass.TestMethod"

# Run with detailed output
dotnet test --verbosity normal
```

### Test Framework Support

The codebase supports multiple test frameworks with compatibility aliases:

- **XUnit** (default): `Fact`, `Theory`, `InlineData`
- **NUnit**: `[Test]`, `[TestFixture]`, `[SetUp]`, `[TearDown]`
- **MSTest**: `[TestMethod]`, `[TestClass]`, `[TestInitialize]`, `[TestCleanup]`
- **TUnit**: Modern assertion syntax

Test common shared helpers use preprocessor directives for framework compatibility:

```csharp
#if XUNIT
using Xunit;
using Test = Xunit.FactAttribute;
#elif NUNIT
using NUnit.Framework;
using Test = NUnit.Framework.TestAttribute;
#elif MSTEST
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
#endif
```

## Code Style Guidelines

### Formatting

- **Indentation**: 4 spaces
- **Braces**: Allman style (opening brace on new line)
- **Line length**: Max 120 characters preferred

```csharp
public class Example
{
    private readonly string _name;

    public Example(string name)
    {
        _name = name;
    }

    public string GetGreeting()
    {
        return $"Hello, {_name}!";
    }
}
```

### Imports/Usings

- Place `using` directives at file top
- Group by: System → Third-party → Project namespaces
- Use `global::` for ambiguous types

### Naming Conventions

- **Types**: PascalCase (`public class BusinessModel`)
- **Private fields**: camelCase with underscore prefix (`private string _fieldName`)
- **Public members**: PascalCase (`public string PropertyName { get; set; }`)
- **Constants**: PascalCase (`public const int MaxValue = 100;`)
- **Interfaces**: IPrefix (`public interface IRepository`)
- **Namespaces**: `HolisticWare.{Area}.{Component}`

### Error Handling

- Use `ArgumentNullException.ThrowIfNull()` for null checks
- Use custom exceptions for domain errors
- Log exceptions with context

```csharp
public void ProcessData(string input)
{
    ArgumentNullException.ThrowIfNull(input);

    try
    {
        // Processing logic
    }
    catch (InvalidOperationException ex)
    {
        throw new DomainProcessingException("Failed to process data", ex);
    }
}
```

### Async/Await

- Use `async Task` for async methods
- Avoid `async void` (except event handlers)
- Use `ConfigureAwait(false)` in library code
- Prefer `CancellationToken` for long-running operations

### Documentation

- XML comments for public APIs (`/// <summary>`, `<param>`, `<returns>`)
- Summary comments for complex logic

## Copilot Instructions

See `.github/copilot-instructions.md` for additional AI agent guidelines:

- Maintain Domain-Driven Design and Clean Architecture patterns
- Use dependency injection over static dependencies
- Update related test cases when making changes
- Document public API changes in XML comments



