using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SPAAutomation.PageObjects;

namespace SPAAutomation.Support
{
    public class TestBase
    {
        protected IWebDriver driver;

        public HomePage HomePage => new HomePage(driver);
        public ItemDetail ItemDetail => new ItemDetail(driver);

        [TestInitialize]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(@"http://demos.telerik.com/kendo-ui/websushi/#/");
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
