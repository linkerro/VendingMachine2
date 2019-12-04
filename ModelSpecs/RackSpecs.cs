using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;

namespace ModelSpecs
{
    [TestClass]
    public class RackSpecs
    {
        [TestMethod]
        public void IsStocked()
        {
            var product = new Product { Name = "product1", Price = 2.0 };
            var rack = new Rack(10);
            rack.Stock(product, 10);

        }
        [TestMethod]
        public void IsStockedWithCorrectProduct()
        {
            var product = new Product { Name = "product1", Price = 2.0 };
            var rack = new Rack(10);
            rack.Stock(product, 10);

            Assert.AreEqual(rack.Product.Name, product.Name);
            Assert.AreEqual(rack.Product.Price, product.Price);
        }
        [TestMethod]
        public void IsStockedWithCorrectAmmount()
        {
            var product = new Product { Name = "product1", Price = 2.0 };
            var rack = new Rack(10);
            rack.Stock(product, 10);

            Assert.AreEqual(rack.Count, 10);
        }
        [TestMethod]
        public void IsStockedByAddingToExistingStock()
        {
            var product = new Product { Name = "product1", Price = 2.0 };
            var rack = new Rack(10);
            rack.Stock(product, 2);

            Assert.AreEqual(rack.Count,2);
            rack.Stock(product, 3);
            Assert.AreEqual(rack.Count, 5);
        }
        [TestMethod]
        public void IsNotStockedWithDifferentProductWhileOldProductStillExists()
        {
            var product = new Product { Name = "product1", Price = 2.0 };
            var product2 = new Product { Name = "product2", Price = 3.0 };
            var rack = new Rack(10);
            rack.Stock(product, 2);

            Assert.AreEqual(rack.Count, 2);
            Assert.ThrowsException<InvalidOperationException>(() => rack.Stock(product2, 4));
        }
        [TestMethod]
        public void IsNotStockedPastMaxStock()
        {
            var product = new Product { Name = "product1", Price = 2.0 };
            var rack = new Rack(10);
            Assert.ThrowsException<InvalidOperationException>(()=> rack.Stock(product, 11));
        }
        [TestMethod]
        public void IsNotRestockedPastMaxStock()
        {
            var product = new Product { Name = "product1", Price = 2.0 };
            var rack = new Rack(10);
            rack.Stock(product, 2);
            Assert.ThrowsException<InvalidOperationException>(()=> rack.Stock(product, 9));
        }
        [TestMethod]
        public void IsNotStockedWithNegativeValues()
        {
            var product = new Product { Name = "product1", Price = 2.0 };
            var rack = new Rack(10);
            Assert.ThrowsException<InvalidOperationException>(() => rack.Stock(product, -1));
        }
        [TestMethod]
        public void IsEmptied()
        {
            var product = new Product { Name = "product1", Price = 2.0 };
            var rack = new Rack(10);
            rack.Stock(product, 2);
            rack.Empty();

            Assert.AreEqual(rack.Count, 0);
        }
        [TestMethod]
        public void IsReturningProductNumberWhenEmptied()
        {
            var product = new Product { Name = "product1", Price = 2.0 };
            var rack = new Rack(10);
            rack.Stock(product, 2);
            var productCount=rack.Empty();

            Assert.AreEqual(productCount, 2);
        }
    }
}
