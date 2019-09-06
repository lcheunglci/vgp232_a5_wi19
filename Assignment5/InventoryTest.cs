using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment5.Data;
using NUnit.Framework;

namespace Assignment5
{
    class InventoryTest
    {
        string myOutputfileName = "itemBag.xml";
        string myInputFilename = "itemData.xml";
        string myTestInputPath = "";
        string myTestOutputPath = "";
        string myDirPath;

        [SetUp]
        public void Setup()
        {
            myDirPath = System.AppContext.BaseDirectory;
            myTestInputPath= Path.Combine(myDirPath, myInputFilename);
            myTestOutputPath = Path.Combine(myDirPath, myOutputfileName);

            myDirPath = AppDomain.CurrentDomain.BaseDirectory;

            myDirPath = this.GetType().Assembly.Location;
            myDirPath = Path.GetDirectoryName(myDirPath);
        }

        [TestCase("Potion")]
        public void SaveItemBagFile(string name, int value)
        {
            ItemReader reader = new ItemReader();
            ItemsData itemsData = reader.Load(myTestInputPath);
            Inventory inventory = new Inventory();
            inventory.Deserialize(myTestInputPath);
            inventory.Serialize(myTestOutputPath);
            Assert.IsTrue(File.Exists(myTestOutputPath));
        }

        [Test]
        public void LoadItemBagFile()
        {
            ItemReader reader = new ItemReader();
            ItemsData itemsData = reader.Load(myTestInputPath);
            Inventory inventory = new Inventory();
            //TODO Possibly have an add items function to inventory
            inventory.Serialize(myTestOutputPath);
            inventory.Deserialize(myTestOutputPath);

        }
    }

}
