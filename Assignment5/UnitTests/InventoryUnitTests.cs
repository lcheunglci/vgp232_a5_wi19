using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;

namespace Assignment5.Data
{
    [TestFixture]
    class InventoryUnitTests
    {
        [SetUp]
        public void Init()
        {
           
        }

        [TearDown]
        public void CleanUp()
        {

        }

        [Test]
        public void Serialize_Inventory()
        {
         var mInventory = new Inventory()
            {
                ItemToQuantity =
                    new Dictionary<object, object> { { "Master ball", 100 }, { "Potion", 10 } }
            };

            mInventory.Serialize(mInventory);
            Assert.True(File.Exists("inventory.xml"));
        }

        [Test]
        public void Deserialize_Inventory()
        {
            var mInventory = new Inventory()
            {
                ItemToQuantity =
              new Dictionary<object, object> { { "Master ball", 100 }, { "Potion", 10 } }
            };

            mInventory.Serialize(mInventory);
            mInventory = mInventory.Deserialize("inventory.xml");

            Assert.True(mInventory.Items.Count >= 0);
        }
    }
}
