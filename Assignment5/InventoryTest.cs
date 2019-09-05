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

        [TestCase("")]
        public void SaveItemBagFile(string name)
        {
            Inventory inventory = new Inventory();
            ItemsData itemsData = inventory.Serialize(myTestInputPath);

        }

        [Test]
        public void LoagItemBagFile()
        {
            Inventory inventory = new Inventory();

        }
    }

}
