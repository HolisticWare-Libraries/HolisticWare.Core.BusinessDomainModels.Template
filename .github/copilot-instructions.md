# AI Coding Agent Instructions for HW.Test

## Project Overview
This is a .NET 10.0 solution containing multiple components:
- Business domain logic models (source/business-domain-logic-models)
- User interface implementations (source/user-interface-ui)
- Utility libraries (source/utilities)
- Comprehensive test suite (tests/)

## Key Architectural Patterns
1. **Domain-Driven Design**: The business domain is modeled in `HolisticWare.Core.BusinessDomainLogicModels`
2. **Clean Architecture**: UI and business logic are separated into distinct projects
3. **Cross-Cutting Concerns**: Utilities are centralized in the `HolisticWare.Utilities` project

## Development Workflows
1. **Build Process**:
   - Use `dotnet build` for incremental builds
   - Use `dotnet clean && dotnet build` for full rebuilds
2. **Testing**:
   - Run all tests: `dotnet test`
   - Run specific test project: `cd tests/unit-tests/UnitTests.XUnit && dotnet test`
3. **Debugging**:
   - Launch with debugger: `dotnet run --project samples/clients/AppConsole.SampleDemo/AppConsole.SampleDemo.csproj`

## Coding Conventions
1. Use C# 10.0 language features consistently
2. Follow .NET naming conventions (PascalCase for types, camelCase for members)
3. Implement interfaces explicitly when appropriate
4. Prefer dependency injection over static dependencies
5. Use nullable reference types throughout the codebase

## Integration Points
1. External services are configured in `Directory.Packages.props.txt`
2. Cross-component communication follows interface-based design
3. Configuration is centralized in `configs/` directory

## Important Files and Directories
tests/unit-tests/: Contains all unit tests for the solution
samples/clients/: Sample applications demonstrating usage patterns
source/utilities/: Shared utility libraries used across components

When making changes:
- Update related test cases
- Consider impact on sample applications
- Document public API changes in XML comments
