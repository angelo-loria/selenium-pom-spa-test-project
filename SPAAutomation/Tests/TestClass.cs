using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPAAutomation.PageObjects;
using SPAAutomation.Support;
using static SPAAutomation.PageObjects.ItemDetail;

namespace SPAAutomation
{
    [TestClass]
    public class TestClass : TestBase
    {
        public string MenuItem;

        /// <summary>
        /// Add menu items to cart
        /// Assert total quantity of cart items
        /// Assert price and quantity of specific cart item
        /// Remove items from cart
        /// </summary>
        [TestMethod]
        public void AddRemoveCartItems()
        {
            MenuItem = "Sashimi salad";
            HomePage.GetMenuItem(MenuItem).AddToCart();
            Assert.AreEqual("1", HomePage.CartItemCount, 
                "Cart count not equal to 1.");
            Assert.AreEqual("1x$12.00", HomePage.GetCartItem(MenuItem).QuantityAndPrice());
            Assert.AreEqual("$12.00", HomePage.CartTotalPrice);

            MenuItem = "Edamame";
            HomePage.GetMenuItem(MenuItem).AddToCart();
            Assert.AreEqual("2", HomePage.CartItemCount, 
                "Cart count not equal to 2.");
            Assert.AreEqual("1x$4.00", HomePage.GetCartItem(MenuItem).QuantityAndPrice());
            Assert.AreEqual("$16.00", HomePage.CartTotalPrice);

            MenuItem = "Sashimi salad";
            HomePage.GetMenuItem(MenuItem).AddToCart();
            Assert.AreEqual("2", HomePage.CartItemCount, 
                "Cart count not equal to 2.");
            Assert.AreEqual("2x$12.00", HomePage.GetCartItem(MenuItem).QuantityAndPrice());
            Assert.AreEqual("$28.00", HomePage.CartTotalPrice);

            HomePage.GetCartItem(MenuItem).RemoveFromCart();
            Assert.AreEqual("1", HomePage.CartItemCount, 
                "Cart count not equal to 1.");
            Assert.AreEqual("$4.00", HomePage.CartTotalPrice);

            MenuItem = "Edamame";
            HomePage.GetCartItem(MenuItem).RemoveFromCart();
            Assert.AreEqual("0", HomePage.CartItemCount, 
                "Cart count not equal to 1.");
            Assert.AreEqual("$0.00", HomePage.CartTotalPrice);
        }

        /// <summary>
        /// View/assert menu item details
        /// Click button for next item
        /// View/assert menu item details
        /// </summary>
        [TestMethod]
        public void ViewMenuItemDetails()
        {
            MenuItem = "Maguro";
            HomePage.GetMenuItem(MenuItem).ViewItemDetail();

            Assert.AreEqual(MenuItem, ItemDetail.Title,
                $"Unexpected value: {MenuItem} Title.");
            Assert.AreEqual("Tuna pieces.", ItemDetail.Description,
                $"Unexpected value: {MenuItem} Description.");
            Assert.AreEqual("$12.50", ItemDetail.Price,
                $"Unexpected value: {MenuItem} Price.");
            Assert.AreEqual("2.2293", ItemDetail.NutritionalInformation(NutritionalItems.Protein),
                $"Unexpected value: {MenuItem} Protein.");
            Assert.AreEqual("0.7329", ItemDetail.NutritionalInformation(NutritionalItems.Fat),
                $"Unexpected value: {MenuItem} Fat.");
            Assert.AreEqual("0.7329", ItemDetail.NutritionalInformation(NutritionalItems.Carbohydrate),
                $"Unexpected value: {MenuItem} Carbohydrate.");
            Assert.AreEqual("28.2176", ItemDetail.NutritionalInformation(NutritionalItems.Energy_kJ),
                $"Unexpected value: {MenuItem} Energy(kJ).");
            Assert.AreEqual("6.7442", ItemDetail.NutritionalInformation(NutritionalItems.Energy_kcal),
                $"Unexpected value: {MenuItem} Energy(kcal).");
            Assert.AreEqual("0.4018", ItemDetail.NutritionalInformation(NutritionalItems.Sugar),
                $"Unexpected value: {MenuItem} Sugar.");

            ItemDetail.NextItem();
            MenuItem = "Shake";

            Assert.AreEqual(MenuItem, ItemDetail.Title,
                $"Unexpected value: {MenuItem} Title.");
            Assert.AreEqual(string.Empty, ItemDetail.Description,
                $"Unexpected value: {MenuItem} Description");
            Assert.AreEqual("$10.00", ItemDetail.Price,
                $"Unexpected value: {MenuItem} Price.");
            Assert.AreEqual("1.4804", ItemDetail.NutritionalInformation(NutritionalItems.Protein),
                $"Unexpected value: {MenuItem} Protein.");
            Assert.AreEqual("1.4739", ItemDetail.NutritionalInformation(NutritionalItems.Fat),
                $"Unexpected value: {MenuItem} Fat.");
            Assert.AreEqual("1.4739", ItemDetail.NutritionalInformation(NutritionalItems.Carbohydrate),
                $"Unexpected value: {MenuItem} Carbohydrate.");
            Assert.AreEqual("16.9406", ItemDetail.NutritionalInformation(NutritionalItems.Energy_kJ),
                $"Unexpected value: {MenuItem} Energy(kJ).");
            Assert.AreEqual("4.0489", ItemDetail.NutritionalInformation(NutritionalItems.Energy_kcal),
                $"Unexpected value: {MenuItem} Energy(kcal).");
            Assert.AreEqual("0.245", ItemDetail.NutritionalInformation(NutritionalItems.Sugar),
                $"Unexpected value: {MenuItem} Sugar.");
        }
    }
}
