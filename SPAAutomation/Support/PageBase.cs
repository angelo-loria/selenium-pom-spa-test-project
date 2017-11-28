using OpenQA.Selenium;

namespace SPAAutomation.Support
{
    public abstract class PageBase
    {
        protected IWebDriver driver;
        public PageBase(IWebDriver driver) => this.driver = driver;
    }
}
