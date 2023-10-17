namespace Allure.Examples.NUnit3.WebUITests;

[AllureLabel("layer", "web")]
public abstract class WebUITestFixtureBase : IAsyncLifetime
{
#nullable disable
    protected Random Random { get; private set; }
#nullable enable

    [AllureBefore("Setup session")]
    public async Task InitializeAsync()
    {
        this.Random = new Random();
        await Task.CompletedTask;
    }

    [AllureAfter("Dispose session")]
    public async Task DisposeAsync()
    {
        await Step("Rollback changes", this.RollbackChanges);
        Step("Close session");
    }

    [AllureStep("Rollback changes")]
    protected virtual async Task RollbackChanges() => await Task.CompletedTask;

    protected async Task MaybeThrowElementNotFoundException()
    {
        if (this.IsTimeToThrowException())
        {
            throw new Exception(
                "Element not found for xpath [//div[@class='something']]"
            );
        }
        await Task.CompletedTask;
    }

    protected async Task MaybeThrowAssertionException(string text)
    {
        if (this.IsTimeToThrowException())
        {
            Assert.Equal("another text", text);
        }
        await Task.CompletedTask;
    }

    bool IsTimeToThrowException()
    {
        return this.Random.Next(4) == 0;
    }
}
