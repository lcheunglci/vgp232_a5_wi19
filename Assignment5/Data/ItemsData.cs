using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    [XmlRoot("ItemsData")]
    public class ItemsData
    {
        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public List<Item> Items { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ItemsData()
        {
            Items = new List<Item>();
        }

        /// <summary>
        /// Gets all the items that are equal or less than level requirement
        /// </summary>
        /// <param name="level">The minimum required level</param>
        /// <returns>List of items that meet the requirement</returns>
        public List<Item> UnlockedItemsAtLevel(int level)
        {
            List<Item> temp = new List<Item>();
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].UnlockRequirement <= level)
                {
                    temp.Add(Items[i]);
                }
            }
            return temp;
        }

        /// <summary>
        /// Gets the item with the matching name
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <returns>The item with the name specified or null if not found</returns>
        public Item FindItem(string name)
        {
            Item itemFound = new Item();
            foreach (Item item in Items)
            {
                if (item.Name == name)
                {
                    itemFound = item;
                }
            }
            return itemFound;
        }
    }
}
