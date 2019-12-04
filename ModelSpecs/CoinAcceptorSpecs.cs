using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace ModelSpecs
{
    [TestClass]
    public class CoinAcceptorSpecs
    {
        [TestMethod]
        public void IsSetToAcceptCoins()
        {
            var coinAcceptor = new CoinAcceptor();
            coinAcceptor.Setup(.05m);

            CollectionAssert.AreEqual(new decimal[] { .05m }, coinAcceptor.AcceptedCoins);
        }
        [TestMethod]
        public void IsAcceptingCoins()
        {
            var coinAcceptor = new CoinAcceptor();
            coinAcceptor.Setup(.05m);

            coinAcceptor.Insert(.05m);
        }
        [TestMethod]
        public void IsNotifyingOfInsertedCoins()
        {
            var coinAcceptor = new CoinAcceptor();
            coinAcceptor.Setup(.05m);

            var insertedCoin = 0m;
            coinAcceptor.CoinInserted += (sender,coinValue) => insertedCoin = coinValue;

            coinAcceptor.Insert(.05m);

            Assert.AreEqual(.05m, insertedCoin);
        }
        [TestMethod]
        public void IsCalculatingTotal()
        {
            var coinAcceptor = new CoinAcceptor();
            coinAcceptor.Setup(.05m);
            coinAcceptor.Setup(.03m);

            coinAcceptor.Insert(.05m);
            coinAcceptor.Insert(.05m);
            coinAcceptor.Insert(.03m);

            Assert.AreEqual(0.13m, coinAcceptor.Total);
        }
        [TestMethod]
        public void IsEmptying()
        {
            var coinAcceptor = new CoinAcceptor();
            coinAcceptor.Setup(.05m);
            coinAcceptor.Setup(.03m);

            coinAcceptor.Insert(.05m);
            coinAcceptor.Insert(.05m);
            coinAcceptor.Insert(.03m);
            
            coinAcceptor.Empty();

            Assert.AreEqual(0, coinAcceptor.Total);
        }
        [TestMethod]
        public void IsReturningTotalWhenEmptying()
        {
            var coinAcceptor = new CoinAcceptor();
            coinAcceptor.Setup(.05m);
            coinAcceptor.Setup(.03m);

            coinAcceptor.Insert(.05m);
            coinAcceptor.Insert(.05m);
            coinAcceptor.Insert(.03m);

            var total= coinAcceptor.Empty();

            Assert.AreEqual(.13m, total);
        }
    }
}
