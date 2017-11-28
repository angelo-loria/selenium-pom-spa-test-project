using OpenQA.Selenium;
using SPAAutomation.Support;
using System.Collections.ObjectModel;
using System.Linq;

namespace SPAAutomation.PageObjects
{
    public class HomePage : PageBase
    {
        public HomePage(IWebDriver driver) : base(driver) => this.driver = driver;

        private ReadOnlyCollection<IWebElement> _menuItems => driver.WaitForElements(
            By.ClassName("products"));
        private ReadOnlyCollection<IWebElement> _cartItems => driver.WaitForElements(
            By.ClassName("selected-products-list"));
        private IWebElement _cartItemCount => driver.WaitForElement(
            By.CssSelector("#cart-info > span > span"));
        private IWebElement _cartTotalPrice => driver.WaitForElement(
            By.CssSelector("#shopping-cart > p"));

        public string CartItemCount => _cartItemCount.Text;
        public string CartTotalPrice => _cartTotalPrice.Text;

        public IWebElement GetMenuItem(string menuItem)
        {
            return _menuItems.Single(x => x.Text.StartsWith(menuItem));
        }

        public IWebElement GetCartItem(string cartItem)
        {
            string imgSrcFormat = cartItem.Replace(" ", "-").ToLower();
            return _cartItems.Single(x => x.
            FindElement(By.CssSelector("a img")).GetAttribute("src").Contains(imgSrcFormat));
        }
    }

    public static class HomePageExtensions
    {
        public static void AddToCart(this IWebElement element)
        {
            element.FindElement(By.ClassName("add-to-cart")).Click();
        }

        public static void ViewItemDetail(this IWebElement element)
        {
            element.Click();
        }

        public static string QuantityAndPrice(this IWebElement element)
        {
            return element.Text;
        }

        public static void RemoveFromCart(this IWebElement element)
        {
            element.Click();
        }
    }
}

