# Mutation testing

*   Definition

    A software testing technique used to check the quality and effectiveness of an existing test suite.

*   Core Idea

    It tests your tests, not your actual production code.

* The Problem It Solves

    Line coverage only tells you if a line ran, not if your tests actually checked the result or caught errors
    
*   used to evaluate your test suites

*   tools

    *   Stryker Mutator Documentation
  
        https://stryker-mutator.io/docs/
    
        *   explains how automated tools inject small code changes to test your assertions

## How It Works

   1. Mutate: The tool makes a tiny, deliberate change to your source code (like changing > to < or true to false). This modified file is a mutant. [2, 3, 6] 
   2. Run: Your unit tests run against this mutated code. [1, 6] 
   3. Kill or Survive:
   * Killed: A test fails, meaning your test suite successfully caught the change.
      * Survived: All tests pass, meaning your test suite missed the bug and needs a stronger assertion. [1, 2, 6] 
   4. Score: The mutation score is the percentage of mutants killed out of the total generated. A higher score means a more reliable test suite. [2, 4, 8] 

## Common Tools

* JavaScript/TypeScript/C#: Stryker Mutator
* Java: [PIT (Pitest)](https://pitest.org/)
* PHP: Infection
* Python: MutPy or Pester [1, 3, 7, 8, 9] 

If you want to try this out, tell me which programming language you use, and I can help you set up a specific mutation testing tool for your project.

[1] [https://stryker-mutator.io](https://stryker-mutator.io/docs/)
[2] [https://en.wikipedia.org](https://en.wikipedia.org/wiki/Mutation_testing)
[3] [https://www.geeksforgeeks.org](https://www.geeksforgeeks.org/software-engineering/software-testing-mutation-testing/)
[4] [https://testrigor.com](https://testrigor.com/blog/understanding-mutation-testing-a-comprehensive-guide/)
[5] [https://www.augmentcode.com](https://www.augmentcode.com/guides/mutation-testing-ai-generated-code)
[6] [https://circleci.com](https://circleci.com/blog/what-is-mutation-testing/)
[7] https://pitest.org
[8] [https://www.boldare.com](https://www.boldare.com/blog/what-is-mutation-testing/)
[9] [https://learn.microsoft.com](https://learn.microsoft.com/en-us/dotnet/core/testing/mutation-testing)




Stryker.NET is the official and most popular tool for running mutation testing on C# and .NET codebases. It integrates smoothly with the standard .NET command-line interface and evaluates how well your unit tests spot intentional code breaks. [1, 2, 3] 

## How to Install and Run Stryker.NET

   1. Install the Tool: Open your command line and run dotnet tool install -g dotnet-stryker to install the global .NET tool. You can read more via the Stryker.NET Getting Started Guide.
   2. Navigate to Your Test Folder: Open your terminal and change directories to the folder that holds your unit test project (cd MyProject.Tests).
   3. Run the Tool: Type dotnet stryker and press Enter. Stryker will build your solution, inject small code changes, and test your assertions.
   4. View the Results: Open the generated HTML report to check your mutation score and see which injected bugs survived your tests. [2, 3, 4, 5, 6, 7] 

## What Stryker.NET Changes in C#

* 
* Arithmetic Operators: Replaces + with -, or * with /.
* Logical Operators: Replaces && with ||, or swaps true and false.
* Equality Operators: Swaps < for <= or == for !=.
* Statement Removal: Deletes specific blocks or statements to see if your tests notice the missing code. [3, 4, 8, 9] 
* 

If you'd like, tell me which test framework you use (such as xUnit, NUnit, or MSTest), and I can help you create a custom stryker-config.json configuration file. [3, 5, 7, 10] 

[1] [https://stryker-mutator.io](https://stryker-mutator.io/docs/stryker-net/introduction/)
[2] [https://qaskills.sh](https://qaskills.sh/blog/mutation-testing-stryker-guide-2026)
[3] [https://learn.microsoft.com](https://learn.microsoft.com/en-us/dotnet/core/testing/mutation-testing)
[4] [https://www.youtube.com](https://www.youtube.com/watch?v=jUbffHCt8iI&t=303)
[5] [https://stryker-mutator.io](https://stryker-mutator.io/docs/stryker-net/getting-started/)
[6] [https://github.com](https://github.com/stryker-mutator/stryker-net/blob/master/README.md)
[7] [https://www.youtube.com](https://www.youtube.com/watch?v=qRMFwmVPa_U&t=7)
[8] [https://stackoverflow.com](https://stackoverflow.com/questions/60925109/c-sharp-stryker-mutation-framework)
[9] [https://www.youtube.com](https://www.youtube.com/watch?v=sGwfwtkaDfk&t=174)
[10] [https://medium.com](https://medium.com/@RebeldeCuantico/how-to-perform-mutation-testing-in-net-and-c-bd23a530341f)


Stryker.NET abstracts away the testing framework you use by leveraging VSTest or the modern 
[Microsoft Testing Platform (MTP)](https://stryker-mutator.io/blog/stryker-net-mtp-runner/). 
This means that whether you are using xUnit, NUnit, or MSTest, a single standardized configuration file works seamlessly across all of them. [1, 2] 
Create a file named stryker-config.json in your unit test project directory (where your test .csproj file lives) and use the following template to handle your test suite: [3, 4] 

```json
{
  "stryker-config": {
    "solution": "../YourSolution.sln",
    "project": "YourProductionProject.csproj",
    "test-runner": "vstest",
    "mutation-level": "Standard",
    "coverage-analysis": "perTest",
    "reporters": [
      "html",
      "progress",
      "cleartext"
    ],
    "thresholds": {
      "high": 80,
      "low": 60,
      "break": 50
    },
    "mutate": [
      "**/*.cs",
      "!**/Migrations/*",
      "!**/*.Designer.cs"
    ]
  }
}
```

## Key Framework-Agnostic Settings Explained:

* 
* test-runner: Setting this to "vstest" (the default) allows Stryker to communicate directly with xUnit, NUnit, or MSTest runner hooks behind the scenes. If you are migrating to cutting-edge tools like xUnit v3 or TUnit, this can be switched to "mtp". [1, 5, 6] 
* coverage-analysis: Set to "perTest". Stryker maps exactly which test runs cover which line of code. It only executes the relevant tests for a given mutant, drastically speeding up the run. [6] 
* thresholds: The "break" property is your safety net. If your overall mutation score falls below 50%, the build will automatically fail—making it highly effective for CI/CD environments. [6, 7] 
* mutate: Tells Stryker exactly what production code to targets. The ! prefix excludes noisy code blocks like Entity Framework migrations or auto-generated designer files that don't benefit from testing. [6, 8] 
* 

Once this file is saved, execute the tool from that folder by running:

dotnet stryker

Would you like assistance integrating this step into a CI/CD pipeline (such as GitHub Actions or Azure DevOps), or do you need help excluding specific noisy methods from being mutated?

[1] [https://stryker-mutator.io](https://stryker-mutator.io/blog/stryker-net-mtp-runner/)
[2] [https://github.com](https://github.com/stryker-mutator/stryker-net/blob/master/CONTRIBUTING.md)
[3] [https://stryker-mutator.io](https://stryker-mutator.io/docs/stryker-net/configuration/)
[4] [https://medium.com](https://medium.com/@hamed.shirbandi/mutation-testing-with-stryker-in-net-projects-ff1f05ddce8f)
[5] [https://stryker-mutator.io](https://stryker-mutator.io/blog/announcing-dotnet-framework-support/)
[6] [https://stryker-mutator.io](https://stryker-mutator.io/docs/stryker-net/configuration/)
[7] [https://learn.microsoft.com](https://learn.microsoft.com/en-us/dotnet/core/testing/mutation-testing)
[8] [https://learn.microsoft.com](https://learn.microsoft.com/en-us/dotnet/core/testing/mutation-testing)


xUnit works incredibly well with Stryker.NET right out of the box. Since you are using xUnit, your implementation strategy will depend directly on which version of xUnit your project runs. [1, 2, 3] 
------------------------------
## 1. Standard xUnit (v2.x) Configuration
If your tests use standard xUnit v2, Stryker uses the vstest engine to run the suite. [3, 4] 
Ensure your test .csproj has the standard development dependencies:

```xml
<ItemGroup>
  <PackageReference Include="xunit" Version="2.9.2" />
  <PackageReference Include="xunit.runner.visualstudio" Version="2.8.2" />
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.11.1" />
</ItemGroup>
```xml

In your stryker-config.json, configure the runner like this:

```json
{
  "stryker-config": {
    "test-runner": "vstest",
    "coverage-analysis": "perTest"
  }
}
```

Note: perTest optimizes execution speed by instructing Stryker to only run specific xUnit test methods that actually touch the mutated code line. [4] 
------------------------------
## 2. Modern xUnit (v3.x) & Microsoft Testing Platform

If you have upgraded to the newer xUnit v3, you will be using the native [Microsoft Testing Platform (MTP)](https://xunit.net/docs/getting-started/v3/microsoft-testing-platform) runner instead of VSTest. Stryker v5.0.0+ provides full native support for xUnit v3 environments. [3, 5, 6, 7] 
Ensure your test project configuration explicitly turns on the MTP runner engine: [8] 

```xml
<PropertyGroup>
  <OutputType>Exe</OutputType>
  <UseMicrosoftTestingPlatformRunner>true</UseMicrosoftTestingPlatformRunner>
  <TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>
</PropertyGroup>
```

Update your stryker-config.json to swap the engine over:

```json
{
  "stryker-config": {
    "test-runner": "mtp",
    "coverage-analysis": "all"
  }
}
```

Note: The "mtp" runner requires "coverage-analysis" set to "all" or "off", as per-test mutation isolation hooks are natively managed by the framework binary. [4] 

------------------------------

## Tips for xUnit Suites

* 
* Handling Theory Tests: xUnit [Theory] tests with extensive inline or data attributes are treated as a unified block by Stryker's mutations. If an inline dataset throws an unhandled error inside a mutant, Stryker cleanly flags it as Killed. [2, 9] 
* Speed up Execution: If your xUnit suites use heavy parallelization ([Collection]), Stryker runs its own internal concurrent workers. You can cap parallel stress on your CPU inside the configuration file by setting "concurrency": 4 (or matching your logical core count). [10] 
* 

To optimize this specifically for your workflow, let me know:

* 
* Which version of xUnit are you currently using (v2 or v3)?
* Are you running this locally via the terminal, or looking to tie this into a CI/CD pipeline?
* 


[1] [https://medium.com](https://medium.com/@hamed.shirbandi/mutation-testing-with-stryker-in-net-projects-ff1f05ddce8f)
[2] [https://www.youtube.com](https://www.youtube.com/watch?v=qRMFwmVPa_U&t=7)
[3] [https://stryker-mutator.io](https://stryker-mutator.io/blog/stryker-net-mtp-runner/)
[4] [https://github.com](https://github.com/shinji-san/SecretSharingDotNet/issues/343)
[5] [https://www.nuget.org](https://www.nuget.org/packages/dotnet-stryker)
[6] [https://xunit.net](https://xunit.net/docs/getting-started/v3/microsoft-testing-platform)
[7] [https://github.com](https://github.com/stryker-mutator/stryker-net/issues/3094)
[8] [https://github.com](https://github.com/stryker-mutator/stryker-net/issues/3094?timeline_page=1)
[9] [https://learn.microsoft.com](https://learn.microsoft.com/en-us/dotnet/core/testing/mutation-testing)
[10] [https://stryker-mutator.io](https://stryker-mutator.io/docs/stryker-net/configuration/)




NUnit works seamlessly with Stryker.NET out of the box because it integrates natively with the VSTest runner engine. When mutation testing an NUnit project, the setup relies on the standard NUnit3TestAdapter to communicate execution data back to Stryker.
## 1. Project Setup & Prerequisites
Ensure your NUnit test project's .csproj file contains the required test adapter and SDK references. Without the test adapter, Stryker will not be able to discover or execute your NUnit tests:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.11.1" />
  <PackageReference Include="NUnit" Version="4.2.2" />
  <PackageReference Include="NUnit3TestAdapter" Version="4.6.0" />
</ItemGroup>
```

## 2. Optimized NUnit Configuration

Create or update your stryker-config.json file in the root directory of your NUnit test project. This configuration uses "perTest" coverage analysis, which drastically speeds up execution by only running the specific NUnit test cases that cover the modified line of code:

```json
{
  "stryker-config": {
    "test-runner": "vstest",
    "coverage-analysis": "perTest",
    "reporters": [
      "html",
      "progress"
    ]
  }
}
```

## 3. Crucial Tips for NUnit Projects## Handling NUnit Parameterized Tests ([TestCase])

* If you use [TestCase] or [TestCaseSource], Stryker treats the parameterized method as a collective unit under its "perTest" coverage mapping.
* If any of the test cases fail because of a mutation, the mutant is successfully flagged as Killed.

## Dealing with OneTimeSetUp and OneTimeTearDown

* If your NUnit tests rely heavily on [OneTimeSetUp] to spin up databases or expensive shared state, "coverage-analysis": "perTest" might cause issues because Stryker needs to repeatedly spin up and tear down test classes.
* The Fix: If you notice your mutation runs failing or stalling on setup blocks, change "coverage-analysis" to "all" or "off" in your config file. This forces a clean test context execution at the cost of a slightly longer total run time.

## Parallel Test Execution Conflict

* NUnit allows you to run tests in parallel using [Parallelizable].
* Because Stryker already manages its own massive concurrency by spawning multiple test runner instances in parallel, it is highly recommended to disable NUnit-level internal parallelization during mutation runs to prevent CPU starvation and thread locking.

To lock this down for your environment, let me know:

* Do your NUnit suites rely heavily on [OneTimeSetUp] database or API fixtures?
* Are you aiming to capture these results locally in the HTML dashboard, or publish them to a sonar/cloud portal?

To optimize this for your specific setup, let me know:

* Do your NUnit suites rely heavily on [OneTimeSetUp] shared fixtures or databases?
* Are you running this locally to inspect the HTML reports, or aiming to push the results to a CI/CD quality gate?



