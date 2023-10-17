namespace Allure.Examples.NUnit3.WebUITests;

[AllureFeature("Labels UI")]
public class LabelTests : WebUITestFixtureBase
{
    protected override async Task RollbackChanges()
    {
        await Step(
            "Delete label \"hello\"",
            async () => await Task.CompletedTask
        );
    }

    [Fact(DisplayName = "Create new label by authorized user")]
    [AllureTag("regress")]
    public async Task CreateNewLabelByAuthorizedUser()
    {
        await this.OpenLabelsPage();
        await this.CreateLabel("hello");
        await this.AssertLabel("hello");
    }

    [Fact(DisplayName = "Add label to existing issue by authorized user")]
    [AllureTag("smoke")]
    public async Task AddLabelToExistingIssueByAuthorizedUser()
    {
        var issueId = this.Random.Next(1000);
        await this.OpenIssuePage(issueId);
        await this.AddLabelToIssue(issueId, "hello");
        await this.OpenIssuesPage();
        await this.FilterIssuesByLabel("hello");
        await this.AssertIssueWithLabel(issueId, "hello");
    }

    [Fact(DisplayName = "Delete existing label by authorized user")]
    [AllureTag("smoke")]
    public async Task DeleteExistingLabelByAuthorizedUser()
    {
        await this.OpenLabelsPage();
        await this.CreateLabel("hello");
        await this.DeleteLabel("hello");
        await this.AssertNoLabel("hello");
    }

    [AllureStep("When I open labels page")]
    async Task OpenLabelsPage()
    {
        await this.MaybeThrowElementNotFoundException();
    }

    [AllureStep("When I open issue with id {issueId}")]
    async Task OpenIssuePage(int issueId)
    {
        await this.MaybeThrowElementNotFoundException();
    }

    [AllureStep("And I create label with title {title}")]
    async Task CreateLabel(string title)
    {
        await this.MaybeThrowElementNotFoundException();
    }

    [AllureStep("And I add label with title {labelTitle} to issue")]
    async Task AddLabelToIssue(int issueId, string labelTitle)
    {
        await this.MaybeThrowElementNotFoundException();
    }

    [AllureStep("And I open issues page")]
    async Task OpenIssuesPage()
    {
        await this.MaybeThrowElementNotFoundException();
    }

    [AllureStep("And I filter issues by label {labelTitle}")]
    async Task FilterIssuesByLabel(string labelTitle)
    {
        await this.MaybeThrowElementNotFoundException();
    }

    [AllureStep("And I delete label with title {labelTitle}")]
    async Task DeleteLabel(string labelTitle)
    {
        await this.MaybeThrowElementNotFoundException();
    }

    [AllureStep("Then I should see label with title {labelTitle}")]
    async Task AssertLabel(string labelTitle) => await Task.CompletedTask;

    [AllureStep("Then I should see issue with label title {labelTitle}")]
    async Task AssertIssueWithLabel(int issueId, string labelTitle)
    {
        await this.MaybeThrowAssertionException(
            $"No issue {issueId} in list filtered by {labelTitle} label"
        );
    }

    [AllureStep("Then I should not see label with title {labelTitle}")]
    async Task AssertNoLabel(string labelTitle)
    {
        await this.MaybeThrowAssertionException(
            $"Label {labelTitle} still exists"
        );
    }
}
