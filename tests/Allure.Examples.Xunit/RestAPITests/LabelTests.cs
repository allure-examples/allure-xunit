namespace Allure.Examples.NUnit3.RestAPITests;

[AllureLabel("layer", "rest")]
[AllureFeature("Labels API")]
public class LabelTests : IDisposable
{
    readonly Random random;

    [AllureBefore("Setup API connection")]
    public LabelTests()
    {
        this.random = new Random();
    }

    [AllureAfter("Dispose API connection")]
    public void Dispose() { }

    [Fact(DisplayName = "Create new label via API")]
    [AllureTag("smoke")]
    public void NewLabelTest()
    {
        this.PostNewLabel("hello");
        this.AssertLabel("hello");
    }

    [Fact(DisplayName = "Delete label via API")]
    [AllureTag("regress")]
    public void DeleteLabelTest()
    {
        this.PostNewLabel("hello");
        this.DeleteLabel("hello");
        this.AssertNoLabel("hello");
    }

    [AllureStep("When I create new label with title {title} via API")]
    void PostNewLabel(string title)
    {
        Step("POST /repos/:owner/:repo/labels");
    }

    [AllureStep("And I delete label with title {title} via API")]
    void DeleteLabel(string title)
    {
        var labelId = FindLabelByTitle(title);
        Step($"DELETE /repos/:owner/:repo/labels/{labelId}");
    }

    [AllureStep("Then I should see label with title {title} via api")]
    void AssertLabel(string title)
    {
        var labelId = FindLabelByTitle(title);
        Step($"GET /repos/:owner/:repo/labels/{labelId}");
    }

    [AllureStep("Then I should not see label with title {title} via api")]
    void AssertNoLabel(string title)
    {
        _ = FindLabelByTitle(title);
    }

    int FindLabelByTitle(string title)
    {
        Step("GET /repos/:owner/:repo/labels?text=" + title);
        return random.Next(1000);
    }
}