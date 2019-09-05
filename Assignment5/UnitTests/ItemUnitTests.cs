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
    public class ItemUnitTests
    {
        private ItemsData mitemsData;

        //Intialize itemsdata to contain items from the file
        [SetUp]
        public void Init()
        {
            string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "itemData.xml");
            ItemReader mitemReader = new ItemReader();
            mitemsData = mitemReader.Load(filename);
        }

        [TearDown]
        public void CleanUp()
        {

        }

        [Test]
        public void Load_Items_From_XML_File()
        {
            foreach(Item item in mitemsData.Items)
            {
                item.Print();
            }

            Assert.IsTrue(mitemsData.Items.Count == 15);
        }

        [Test]
        public void Item_Less_Than_Unlocked_Level()
        {
            List<Item> unlockeditem = mitemsData.UnlockedItemsAtLevel(10);
            foreach (Item item in unlockeditem)
            {
                item.Print();
            }
            Assert.IsTrue(unlockeditem.Count == 8);
        }

        [Test]
        public void Search_For_Item()
        {
            string itemname = "Super Potion";
            Item itemfound = mitemsData.FindItem(itemname);
            itemfound.Print();

            Assert.IsTrue(itemfound.Name == "Super Potion");
        }


    }
}
