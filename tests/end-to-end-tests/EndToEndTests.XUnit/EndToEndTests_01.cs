using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using Xunit;

namespace EndToEndTests.XUnit;

/// <summary>
/// E2E test template — replace placeholder URLs with a local dev server endpoint.
/// Current targets an external site; update before enabling in CI.
/// </summary>
public class EndToEndTests_01: PageTest
{
    // TODO: Replace with http://localhost:<port> when a local dev server is available.
    private const string BaseUrl = "https://playwright.dev";

    [Fact(Skip = "Placeholder — targets external site. Update BaseUrl to a local server before CI use.")]
    public async Task HasTitle()
    {
        await Page.GotoAsync(BaseUrl);

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new System.Text.RegularExpressions.Regex("Playwright"));
    }

    [Fact(Skip = "Placeholder — targets external site. Update BaseUrl to a local server before CI use.")]
    public async Task GetStartedLink()
    {
        await Page.GotoAsync(BaseUrl);

        // Click the get started link.
        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

        // Expects page to have a heading with the name of Installation.
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
    }
}
