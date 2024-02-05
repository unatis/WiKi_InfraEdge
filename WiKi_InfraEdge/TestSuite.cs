namespace WiKi_InfraEdge
{
    public class Tests
    {
        //dotnet test --filter FullyQualifiedName = WiKi_InfraEdge.Tests.WikiWords --configuration Release
        private Common.Common common = new Common.Common();
        
        [OneTimeSetUp]
        public void Setup()
        {
            common.LaunchBrowser(Common.Common.BrowserType.Chrome);
        }

        [Test]
        public void WikiWords()
        {
            TestAutomationPage.TestAutomationPage testAutomationPage = new TestAutomationPage.TestAutomationPage(common);

            common.NivigateTo("https://en.wikipedia.org/wiki/Test_automation");

            testAutomationPage.Verify_TestAutomation_Page();

            string title = testAutomationPage.Get_TestDrivenDevelopmentTitle_Text();

            string foundText = testAutomationPage.Get_TextContent_ByTitle(title);

            string result = title + " " + foundText;

            result = common.CleanUpText(result);

            Dictionary<string, int> resDicUI = common.CountWords(result);

            Common.Common.Report("UI result:");

            common.PrintResultDictionary(resDicUI);

            API.API api = new API.API();

            string pageSourse = api.Get_PageContent_ByName("Test_automation");

            title = common.Get_TestDrivenDevelopmentTitle_Text(pageSourse);

            foundText = common.Get_TextContent_ByTitle(title, pageSourse);

            result = title + " " + foundText;

            result = common.CleanUpText(result);

            Dictionary<string, int> resDicAPI = common.CountWords(result);

            Common.Common.Report("API result:");

            common.PrintResultDictionary(resDicAPI);

            Assert.That(resDicUI.Count, Is.EqualTo(resDicAPI.Count));

            Common.Common.Report("Found unique words on UI " + resDicUI.Count.ToString() + " Found unique words by API  " + resDicAPI.Count.ToString());
        }

        [TearDown]
        public void TearDownt()
        {
            common.ExitEnvironment();
        }
    }
}