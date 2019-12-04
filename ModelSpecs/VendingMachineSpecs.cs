using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;

namespace ModelSpecs
{
    [TestClass]
    public class VendingMachineSpecs
    {
        [TestMethod]
        public void IsInstallingRacks()
        {
            var vendingMachine = new VendingMachine();
            var rack1 = new Rack(10);
            var rack2 = new Rack(10);

            vendingMachine.InstallRacks(new Dictionary<int, Rack>
            {
                {1,rack1 },
                {22,rack2 }
            });
            Assert.AreEqual(vendingMachine.Racks.Count, 2);
            Assert.AreEqual(vendingMachine.Racks[1], rack1);
            Assert.AreEqual(vendingMachine.Racks[22], rack2);
        }

        [TestMethod]
        public void IsInstallingRacksPreservingExistingRacks()
        {
            var vendingMachine = new VendingMachine();
            var rack1 = new Rack(10);
            var rack2 = new Rack(10);
            var rack3 = new Rack(10);

            vendingMachine.InstallRacks(new Dictionary<int, Rack>
            {
                {1,rack1 },
                {22,rack2 }
            });

            vendingMachine.InstallRacks(new Dictionary<int, Rack>
            {
                {333,rack3 },
            });
            Assert.AreEqual(vendingMachine.Racks.Count, 3);
            Assert.AreEqual(vendingMachine.Racks[333], rack3);
        }
    }
}
