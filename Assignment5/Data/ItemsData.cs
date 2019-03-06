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
            // implement function to get all items and add unit to confirm it works
            List<Item> listFinded = new List<Item>();
            foreach (Item item in Items)
            {
                if (item.UnlockRequirement == level)
                {
                    listFinded.Add(item);
                }
            }

            if (listFinded.Count == 0)
            {
                throw new Exception(string.Format(" item did not finded"));
            }

            return listFinded;
        }

        /// <summary>
        /// Gets the item with the matching name
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <returns>The item with the name specified or null if not found</returns>
        public Item FindItem(string name)
        {
            // implement function to find the item with the name specified.
            Item itemFinded = new Item();
            foreach(Item item in Items)
            {
                if (item.Name == name)
                {
                    Console.WriteLine(name + " finded");
                    itemFinded = item;
                    continue;
                }
            }

            if(itemFinded.Name ==null)
            {
                throw new Exception(string.Format(" item did not finded"));
            }
            
            return itemFinded;
        }
    }
}
