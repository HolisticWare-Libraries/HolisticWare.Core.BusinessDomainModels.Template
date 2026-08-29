Fuzzing

Fuzzing

    https://github.com/metalnem/sharpfuzz

    <PackageReference Include="SharpFuzz" Version="2.3.0" />


    brew install afl++

    https://github.com/aflplusplus/aflplusplus
    
    https://github.com/twcclegg/libphonenumber-csharp/tree/main/csharp/PhoneNumbers.Fuzz

    https://github.com/Metalnem/sharpfuzz-samples

    https://github.com/ovska/FlameCsv/tree/main/tools/Fuzzing

    https://github.com/Dubzer/Dubzer.WhatwgUrl/tree/master/src/Dubzer.WhatwgUrl.Fuzzing

    https://github.com/Metalnem/dotnet-fuzzers

    https://github.com/Yubico/Yubico.NET.SDK/blob/main/Yubico.Core/fuzz/Program.cs

    
    https://lcamtuf.coredump.cx/afl/README.txt

https://github.com/Metalnem/sharpfuzz-samples

https://raw.githubusercontent.com/Metalnem/sharpfuzz/master/scripts/fuzz.ps1

https://github.com/Metalnem/sharpfuzz/blob/master/README.md

https://mijailovic.net/2019/01/03/sharpfuzz/

https://mijailovic.net/2023/07/23/sharpfuzz-anniversary/

https://writeasync.net/?p=5714

https://blog.objektkultur.de/Automate-Bug-Finding-Fuzzing-C-Sharp-Code-on-Windows/

https://blog.objektkultur.de/Automate-Bug-Finding-Fuzzing-C-Sharp-Code-on-Windows/

https://allthingsreversed.io/20260308-fuzzing-dotnet-libraries.html

https://raw.githubusercontent.com/Metalnem/sharpfuzz/master/scripts/install.sh

https://lcamtuf.coredump.cx/afl/QuickStartGuide.txt

https://lcamtuf.coredump.cx/afl/status_screen.txt

https://lcamtuf.coredump.cx/afl/technical_details.txt


Fuzzing (or fuzz testing) is an automated software testing method that feeds invalid, unexpected, or random data into a program. The system is then watched for crashes, memory leaks, or security flaws

How Fuzzing WorksInput Injection: The tool (fuzzer) sends massive amounts of malformed data into a program's interface, file reader, or network protocol.Behavior Monitoring: The system tracks if the software crashes, hangs, or throws an unhandled exception.Bug Discovery: A crash usually points to a deeper issue like a buffer overflow or memory corruption bug.Main Types of FuzzingMutation-based: Modifies existing valid data samples (like changing parts of a JPEG file) to see how the parser reacts.Generation-based: Creates completely new input data from scratch based on structural rules or protocol specifications.Coverage-guided: Uses runtime feedback from code instrumentation to alter inputs strategically and reach deeper, untested paths in the source code.


SharpFuzz is the undisputed standard for coverage-guided fuzz testing in C# and .NET.Fuzzing has historically focused on memory-unsafe languages like C/C++, but tools like SharpFuzz bring this capability to managed environments to find complex logical errors, unhandled exceptions, infinite loops, and denial-of-service vulnerabilities.

https://blog.objektkultur.de/Automate-Bug-Finding-Fuzzing-C-Sharp-Code-on-Windows/

https://en.wikipedia.org/wiki/Fuzzing


Fuzzlyn

What it is: A specialized structure-aware fuzzer for the C# compiler itself.How it works: It utilizes Microsoft's Roslyn
compiler platform to generate random, syntactically valid C# programs.Best used for: Stress-testing the .NET runtime and
JIT compiler (RyuJIT) by identifying execution differences between Debug and Release builds.

https://github.com/jakobbotsch/Fuzzlyn

https://mattwarren.org/2018/08/28/Fuzzing-the-.NET-JIT-Compiler/

https://developer.arm.com/community/arm-community-blogs/b/architectures-and-processors-blog/posts/part-2-dev-testing-in-dotnet

FuzzDotNet

What it is: An alternative C# library designed for synthetic application data generation and automated data-driven test
generation.Best used for: Translating data specifications into edge-case scenarios to find software logic flaws.

https://github.com/pensono/FuzzDotNet




🏆 Popular General Fuzzing Tools (Engines)

Because C# fuzzers often rely on external engines to manage the generation and mutation of data, you will frequently pair C# tools with these industry standards:AFL++ (American Fuzzy Lop): The de facto standard for mutation-based, gray-box fuzzing. It tracks code coverage automatically and is widely used across academia and enterprise security.LibFuzzer: An in-process, coverage-guided fuzzing engine that runs directly alongside your test targets, heavily favored for its execution speed and integration with LLVM infrastructure.Radamsa: A highly versatile, black-box mutation fuzzer. Instead of analyzing code paths, it takes valid sample inputs (like a valid JSON payload) and aggressively mutates them to break systems.OneFuzz / ClusterFuzz: Open-source distributed fuzzing platforms developed by Microsoft and Google. They automate the infrastructure layer, managing thousands of fuzzing sessions, tracking crashes, and deduplicating bugs at scale.




To write a complete fuzzing test harness for a C# library using SharpFuzz, we will set up a separate .NET test project that accepts data from the fuzzing engine and passes it to your target library.Because SharpFuzz integrates tightly with libFuzzer, the easiest way to run this on modern machines is via the libfuzzer-dotnet ecosystem or natively via a container.Here is the complete step-by-step setup to create and run your test harness.


Step 1: Create the Fuzz Test ProjectCreate a new .NET console application specifically for fuzzing. It needs to reference your target C# library and the SharpFuzz NuGet package.bash# 1. Create a new console app

```shell
dotnet new console -n MyLibrary.Fuzz Tests
```

# 2. Go into the project directory

```shell
cd MyLibrary.FuzzTests
```

# 3. Add the SharpFuzz package

```shell
dotnet add package SharpFuzz
```

# 4. Reference your actual library project

```shell
dotnet add reference ../MyLibrary/MyLibrary.csproj
```


Step 2: 
Write the Test Harness (Program.cs)The harness must accept a stream of bytes generated by the fuzzer and pass it to your code.

Crucial Rule: 

    must catch all expected validation exceptions (like FormatException or ArgumentException). 

If you don't, the fuzzer will treat normal input rejection as a program crash.
goal is to find unhandled exceptions (like NullReferenceException or IndexOutOfRangeException).

```csharp
using System;
using System.IO;
using SharpFuzz;
using MyLibrary; // Replace with your library's namespace

class Program
{
    static void Main(string[] args)
    {
        // SharpFuzz will repeatedly execute this action block
        Fuzzer.OutOfProcess.Run
        (
            stream =>
            {
                try
                {
                    /* Instantiate your library's target class
                    //MyLibraryParser parser = new ();
                    
                    /*
                    Option A: If your library parses a stream directly
                    */
                    parser.ParseFromStream(stream);

                    /*
                    Option B: If your library parses strings, convert the stream
                    
                    using StreamReader reader = new (stream);
                    string textInput = reader.ReadToEnd();
                    parser.ParseString(textInput);
                    */
                }
                // 1. Catch expected exceptions so the fuzzer skips them
                catch (ArgumentException) 
                {
                } 
                catch (FormatException) 
                {                
                }
                /*
                2. DO NOT catch 
                    NullReferenceException, 
                    IndexOutOfRangeException, 
                    OutOfMemoryException
                    AccessViolationException. 

                    Let them bubble up so the fuzzer registers a crash!
                */
            }
        );
    }
}
```


Step 3: Install the Instrumenter and Prepare the DLLSharpFuzz needs to inject tracking code into your compiled library so it can see which code branches are being executed.Install the global SharpFuzz command-line tool:bashdotnet tool install --global SharpFuzz.CommandLine
Use code with caution.Build your fuzz project in Release mode:bashdotnet build -c Release
Use code with caution.Instrument your target library's compiled DLL (navigate to your build output folder first):bashsharpfuzz MyLibrary.dll
Use code with caution.(Note: Instrument the library DLL itself, not the test harness executable).


Step 4: Run the FuzzerWith the harness written and the library instrumented, you can now feed it data using a libFuzzer runner.Download the libfuzzer-dotnet binary for your OS (Windows/Linux).Create two local folders: inputs (put 2 or 3 tiny, valid sample files here to give the fuzzer a starting point) and artifacts (where crashes will be saved).Start the fuzzing process:bashlibfuzzer-dotnet MyLibrary.FuzzTests.dll inputs artifacts
Use code with caution.The fuzzer will now run indefinitely at thousands of executions per second. It will print statistics on your screen and automatically stop or save a file to the artifacts folder the moment it successfully triggers a crash in your library.To tailor this code precisely to your needs, let me know:What format or data type does your library parse (e.g., JSON string, binary file, custom format)?What is the name of the primary method you want to test?

Microsoft OneFuzz

    closed source (VPN)



fuzz testing .NET Multi-platform App UI (.NET MAUI) applications is highly effective for discovering hidden vulnerabilities, edge-case memory leaks, or unhandled exceptions when processing junk data.Because .NET MAUI targets multiple operating systems (Android, iOS, macOS, and Windows), your fuzzing strategy depends on whether you are fuzzing underlying C# logic or platform-specific UI layers.1. Fuzzing the C# Core Logic (The Best Approach)The most practical way to fuzz a .NET MAUI application is to extract your core logic, data parsing engines, and APIs into a separate C# Class Library. Since .NET MAUI runs on .NET, you can fuzz this library natively using specialized .NET fuzzing tools:SharpFuzz: This is the most popular open-source tool for .NET fuzzing. It brings the power of AFL (American Fuzzy Lop) or libFuzzer to the .NET ecosystem. It works by rewriting the Intermediate Language (IL) of your compiled .NET assemblies to track code coverage while feeding input.FuzzDotNet: A library designed for contract-based fuzz testing and generating massive amounts of synthetic data to test system boundaries.Microsoft OneFuzz: Microsoft's open-source, self-hosted Fuzzing-as-a-Service CLI tool. It helps you scale coverage-guided fuzzing pipelines in Azure.


black-box network fuzzing on app's APIs
