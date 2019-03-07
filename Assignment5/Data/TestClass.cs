using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment5.Data
{
    class TestClass
    {
        [Test]
        public void TestItemDataFind()
        {
            string Name = "Potion";
            int UnlockRequirement = 5;
            string Description = "Restores the HP";
            string Effect = "1.5x catch rate";
            ItemsData itemData = new ItemsData();

            itemData.Items.Add(new Item(Name, UnlockRequirement, Description, Effect));


            Item expected = new Item(Name, UnlockRequirement, Description, Effect);
            Item actual = itemData.FindItem(Name);

            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.UnlockRequirement, actual.UnlockRequirement);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.Effect, actual.Effect);
        }

        [Test]
        public void TestItemDataUnlockLevel()
        {
            string Name1 = "Potion";
            int UnlockRequirement1 = 5;
            string Description1 = "Restores the HP";
            string Effect1 = "1.5x catch rate";
            ItemsData itemData = new ItemsData();

            itemData.Items.Add(new Item(Name1, UnlockRequirement1, Description1, Effect1));

            List<Item> items = itemData.UnlockedItemsAtLevel(UnlockRequirement1);
            
            bool expected = itemData.EqualsCheck(items);
            bool actual = true;

            Assert.AreEqual(expected, actual);
        }


    }// end of class
}// end of namespace
