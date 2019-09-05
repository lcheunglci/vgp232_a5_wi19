﻿using System;
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
            // TODO: implement function to get all items and add unit to confirm it works.
            List<Item> UnlockedItems;
            UnlockedItems = Items.FindAll(o => o.UnlockRequirement <= level);

            return UnlockedItems;
        }

        /// <summary>
        /// Gets the item with the matching name
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <returns>The item with the name specified or null if not found</returns>
        public Item FindItem(string name)
        {
            // TODO: implement function to find the item with the name specified.
            Item FoundItem = new Item();

            int foundIndex = (Items.FindIndex(o => o.Name == name));
            if(foundIndex >= 1)
            {
                FoundItem = Items[foundIndex];
            }
            else 
            {
                FoundItem.Name = "Item Not found";
            }

            return FoundItem;
        }

        public Entry FindEntry(List<Entry> entries, string name)
        {
           return entries.Find(o => o.Key.ToString() == name);
        }

        public List<Entry> UnlockedEntries(int level, ItemsData itemsData)
        {
            List<Entry> inventoryitems = new List<Entry>();

            for(int i = 0; i < itemsData.Items.Count(); ++i)
            {
                if(itemsData.Items[i].UnlockRequirement <= level)
                {
                    inventoryitems.Add(new Entry(itemsData.Items[i].Name, null));
                }
            }
            return inventoryitems;
        }
    }
}
