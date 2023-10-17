namespace Allure.Examples.NUnit3.WebUITests;

[AllureFeature("Milestones UI")]
public class MilestoneTests : WebUITestFixtureBase
{
    protected override async Task RollbackChanges()
    {
        await Step(
            "Delete milestone \"hello\"",
            async () => await Task.CompletedTask
        );
    }

    [Fact(DisplayName = "Create new milestone by authorized user")]
    [AllureTag("regress", "smoke")]
    public async Task CreateNewMilestoneByAuthorizedUser()
    {
        await this.OpenMilestonesPage();
        await this.CreateMilestone("hello");
        await this.AssertMilestone("hello");
    }

    [Fact(DisplayName = "Close existing milestone by authorized user")]
    [AllureTag("regress")]
    public async Task CloseMilestoneByAuthorizedUser()
    {
        await this.OpenMilestonesPage();
        await this.CreateMilestone("hello");
        await this.CloseMilestone("hello");
        await this.AssertNoMilestone("hello");
    }

    [AllureStep("When I open milestones page")]
    async Task OpenMilestonesPage() => await Task.CompletedTask;

    [AllureStep("And I create milestone with title {milestoneTitle}")]
    async Task CreateMilestone(string milestoneTitle) => await Task.CompletedTask;

    [AllureStep("And I close milestone with title {milestoneTitle}")]
    async Task CloseMilestone(string milestoneTitle) => await Task.CompletedTask;

    [AllureStep("Then I should see milestone with title {milestoneTitle}")]
    async Task AssertMilestone(string milestoneTitle) => await Task.CompletedTask;

    [AllureStep("Then I should not see milestone with title {milestoneTitle}")]
    async Task AssertNoMilestone(string milestoneTitle) => await Task.CompletedTask;
}
