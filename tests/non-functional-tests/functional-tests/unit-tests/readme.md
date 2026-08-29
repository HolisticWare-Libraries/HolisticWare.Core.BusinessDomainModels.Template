# Unit Testing

*   https://martinfowler.com/bliki/UnitTest.html

*   NUnit

    *   https://docs.nunit.org/articles/nunit/writing-tests/setup-teardown/index.html
    
    *   https://docs.nunit.org/articles/nunit/writing-tests/attributes/setup.html

*   MSTest

    *   https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.classinitializeattribute

    use [TestInitialize] for [SetUp] and [TestCleanup] for [TearDown]

    ```csharp
    // Source - https://stackoverflow.com/a/21304674
    // Posted by Dunken, modified by community. See post 'Timeline' for change history
    // Retrieved 2026-05-04, License - CC BY-SA 4.0

            [AssemblyInitialize()]
            public static void AssemblyInit(TestContext context) {}

            [ClassInitialize()]
            public static void ClassInit(TestContext context) {}

            [TestInitialize()]
            public void Initialize() {}

            [TestCleanup()]
            public void Cleanup() {}

            [ClassCleanup()]
            public static void ClassCleanup() {}

            [AssemblyCleanup()]
            public static void AssemblyCleanup() {}
    ```

*   XUnit

    *   inheritance

    *   https://xunit.net/docs/shared-context
