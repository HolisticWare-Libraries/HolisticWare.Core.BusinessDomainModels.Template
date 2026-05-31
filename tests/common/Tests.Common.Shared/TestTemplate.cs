#if XUNIT
using Xunit;
// NUnit aliases
using Test = Xunit.FactAttribute;
using OneTimeSetUp = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
// XUnit aliases
using TestClass = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
#elif NUNIT
using NUnit.Framework;
// MSTest aliases
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestProperty = NUnit.Framework.PropertyAttribute;
using TestClass = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
// XUnit aliases
using Fact=NUnit.Framework.TestAttribute;
#elif MSTEST
using Microsoft.VisualStudio.TestTools.UnitTesting;
// NUnit aliases
using Test = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
using OneTimeSetUp = Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute;
// XUnit aliases
using Fact = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
#endif

#if BENCHMARKDOTNET
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Attributes.Jobs;
#else
using Benchmark = HolisticWare.Core.Testing.BenchmarkTests.Benchmark;
using ShortRunJob = HolisticWare.Core.Testing.BenchmarkTests.ShortRunJob;
#endif

using HolisticWare.Ph4ct3x.DiagnosticTests.Morphological.SomatoTypes;

namespace Tests.Common.Shared;

[TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
public class TestTemplate
{
    [Test]
    public 
        void
                                        Test
                                        (                                            
                                        )
    {            

        double value_test               = Test_Arrange();
        double value_actual_correct     = Test_Act();

        #if MSTEST
        Assert.AreEqual
                    (
                        value_test,
                        value_actual_correct,
                        // accuracy value
                        0.1
                    );
        #elif NUNIT
        Assert.AreEqual
                    (
                        value_test,
                        value_actual_correct,
                        // accuracy value
                        0.1
                    );
        #elif XUNIT
        Assert.Equal
                    (
                        value_test,
                        value_actual_correct,
                        // accuracy decimal places
                        1
                    );
        #endif
        //TODO: add TUnit

        return;
    }

    public 
        void
                                        Test_Arrange
                                        (                                            
                                        )
    {
        return;
    }

    public 
        void
                                        Test_Act
                                        (                                            
                                        )
    {
        return;
    }

    public 
        void
                                        Test_Assert
                                        (                                            
                                        )
    {
        return;
    }
}


