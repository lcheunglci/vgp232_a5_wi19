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
        Inventory source;
        ItemReader itemReader;
        ItemsData itemsDatafile;
        [SetUp]
        public void Init()
        {
            string InventoryFile = "inventory.xml";
            string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "itemData.xml");
            Console.WriteLine("-----Creating Inventory-----");
            source = new Inventory()
            {
                ItemToQuantity =
                    new Dictionary<object, object> { { "Poke ball", 10 }, { "Potion", 10 },
                                                      {"Premier ball", 20 }, {"Revive",3}, {"Great ball",8 },
                                                     {"Hyper Potion", 2 } }
            };

            source.Serialize(source);
            source = source.Deserialize(InventoryFile);

             itemReader = new ItemReader();
             itemsDatafile = itemReader.Load(filename);
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

        [Test]
        public void Find_Item_In_Inventory()
        {
            string entry = "Poke ball";
            Console.WriteLine("\nSearching for {0} in Inventory", entry);
            source.FindItem("Poke ball");

            Assert.IsTrue(source.Items.Exists(o => o.Key.ToString() == entry));
        }

        [Test] 
        public void Show_Usable_Items_In_Inventory()
        {
            int iLevelLock = 10;
            List<Entry> unlockedItems;
            Console.WriteLine("Showing items in inventory whose Level Req < {0}", iLevelLock);
            unlockedItems = source.UnlockItems(iLevelLock, itemsDatafile);

            Assert.IsTrue(!unlockedItems.Exists(o => o.Key.ToString() == "Hyper Potion"));

        }
    }
}
