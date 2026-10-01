using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-mstest-writing-tests-controlling-execution#parallelizeattribute
*/
[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]