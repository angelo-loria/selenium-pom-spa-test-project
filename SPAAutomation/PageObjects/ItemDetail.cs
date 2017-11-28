using OpenQA.Selenium;
using SPAAutomation.Support;
using System.Collections.ObjectModel;
using System.Threading;

namespace SPAAutomation.PageObjects
{
    public class ItemDetail : PageBase
    {
        public ItemDetail(IWebDriver driver) : base(driver) => this.driver = driver;
        public enum NutritionalItems {  Protein, Fat, Carbohydrate, Energy_kJ, Energy_kcal, Sugar}

        private IWebElement _itemDetailHeader => driver.WaitForElement(By.CssSelector("#description > h1"));
        private IWebElement _itemDetailDescription => driver.WaitForElement(By.CssSelector("#description > p"));
        private IWebElement _itemPrice => driver.WaitForElement(By.CssSelector("#price-quantity"));
        private ReadOnlyCollection<IWebElement> _nutritionalItems => driver.WaitForElements(By.CssSelector("#nutrition-info > dl > dd"));
        private IWebElement _buttonNext => driver.WaitForElement(By.Id("navigate-next"));

        public string Title => _itemDetailHeader.Text;
        public string Description => _itemDetailDescription.Text;
        public string Price => _itemPrice.Text;

        public void NextItem()
        {
            _buttonNext.Click();
            while (driver.FindElements(By.ClassName("k-fx-current")).Count > 0)
            {
                Thread.Sleep(250);
            }
        }

        public string NutritionalInformation(NutritionalItems nutrient)
        {
            return _nutritionalItems[(int)nutrient].Text;
        }
    }
}
