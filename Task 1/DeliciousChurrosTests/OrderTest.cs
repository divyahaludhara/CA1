using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliciousChurros;

namespace DeliciousChurrosTests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void PayBill_ShouldReturnCorrectTotal()
        {
            // Arrange
            Order order = new Order(1, "Churros with plain sugar", 3);
            double price = 6.00;

            // Act
            double result = order.PayBill(price);

            // Assert
            Assert.AreEqual(18.00, result, 0.001);
        }
    }
}