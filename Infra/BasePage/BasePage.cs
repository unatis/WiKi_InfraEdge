using OpenQA.Selenium;
using System;

namespace BasePage
{
    public class BasePage
    {
        protected Common.Common common = null;
                
        public BasePage(Common.Common common)
        {
            this.common = common;           
        }
        public Boolean IsElementPresent(By locatorKey)
        {
            try
            {
                common.GetWebDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locatorKey));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
