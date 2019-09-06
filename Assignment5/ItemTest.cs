using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Assignment5.Data;

namespace Assignment5
{
    class ItemTest
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
            myTestInputPath = Path.Combine(myDirPath, myInputFilename);
            myTestOutputPath = Path.Combine(myDirPath, myOutputfileName);

            myDirPath = AppDomain.CurrentDomain.BaseDirectory;

            myDirPath = this.GetType().Assembly.Location;
            myDirPath = Path.GetDirectoryName(myDirPath);
        }

        [TestCase("Potion")]
        public void FindItem( string name)
        {
            ItemReader reader = new ItemReader();
            ItemsData itemsData = reader.Load(myTestInputPath);
            Item items = itemsData.FindItem(name);
            Assert.AreEqual(items.Name, name);
        }

        [TestCase(20)]
        public void UnlockedItemsAtLevel(int level)
        {
            ItemReader reader = new ItemReader();
            ItemsData itemsData = reader.Load(myTestInputPath);
            List<Item> items = itemsData.UnlockedItemsAtLevel(level);
            foreach (var item in items)
            {
                Assert.LessOrEqual(item.UnlockRequirement, level);
            }
        }
    }
}
