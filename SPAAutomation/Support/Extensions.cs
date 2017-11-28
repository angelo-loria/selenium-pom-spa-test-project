using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAAutomation.Support
{
    public static class Extensions
    {
        public static IWebElement WaitForElement(this IWebDriver driver, By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                return wait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (WebDriverTimeoutException)
            {
                throw new NoSuchElementException($"Element {by} not found within 5 seconds.");
            }
        }

        public static ReadOnlyCollection<IWebElement> WaitForElements(this IWebDriver driver, By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                return wait.Until(drv => drv.FindElements(by).Count > 0 ? drv.FindElements(by) : null);
            }
            catch(WebDriverTimeoutException)
            {
                throw new NoSuchElementException($"Element {by} not found within 5 seconds");
            }
        }
    }
}
