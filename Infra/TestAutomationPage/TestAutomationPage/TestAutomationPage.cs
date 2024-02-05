using OpenQA.Selenium;
using System;

namespace TestAutomationPage
{
    public class TestAutomationPage : BasePage.BasePage
    {        
        public TestAutomationPage(Common.Common common) : base(common)
        {            
            //PageFactory.InitElements(common.GetWebDriver(), this);
        }
        public void Verify_TestAutomation_Page()
        {
            if (!IsElementPresent(By.CssSelector(".mw-page-container")))
            {
                Common.Common.Report("TestAutomation not found", Common.Common.MessageColor.RED);
            }

            if (common.GetWebDriver().FindElement(By.CssSelector(".mw-page-title-main")).Text.Trim().Contains("Test automation"))
            {
                Common.Common.Report("TestAutomationPage presented");
            }
            else
            {
                Common.Common.Report("TestAutomationPage not found", Common.Common.MessageColor.RED);
            }
        }

        public string Get_TextContent_ByTitle(string title)
        {
            string foundText = "";

            try
            {
                foundText = common.GetWebDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//p[preceding-sibling::h3/span[contains(.,'"+ title + "')]][1]"))).Text;
            }
            catch (Exception e)
            {
                Common.Common.Report(e.Message, Common.Common.MessageColor.RED);
            }

            return foundText;
        }

        public string Get_TestDrivenDevelopmentTitle_Text()
        {
            string foundText = "";

            try
            {
                foundText = common.GetWebDriver().FindElement(By.Id("Test-driven_development")).Text;
            }
            catch (Exception e)
            {
                Common.Common.Report(e.Message, Common.Common.MessageColor.RED);
            }

            return foundText;
        }
    }
}
