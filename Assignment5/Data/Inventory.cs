using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    public class Inventory
    {
        // Since Dictionaries are not serializable in XML, we use this for serialization
        [XmlArray]
        [XmlArrayItem("Entry")]
        public List<Entry> Items { get; set; }
        public string inventoryFile { get; set; }

        [XmlIgnore]
        public Dictionary<object, object> ItemToQuantity
        {
            get { return Items.ToDictionary(x => x.Key, x => x.Value); }
            set
            {
                Items = value.Select(x => new Entry() { Key = x.Key, Value = x.Value }).ToList();
            }
        }

        public Inventory()
        {
            Items = new List<Entry>();
        }

        public void Serialize(Inventory newItem)
        {
            inventoryFile = "inventory.xml";
            using (var writer = XmlWriter.Create(inventoryFile))
                (new XmlSerializer(typeof(Inventory))).Serialize(writer, newItem);
        }

        public Inventory Deserialize(string FileName)
        {
            using (var reader = new StreamReader(inventoryFile))
            {
                var serializer = new XmlSerializer(typeof(Inventory));
                try
                {
                    Inventory inventory = serializer.Deserialize(reader) as Inventory;
                    if (inventory != null)
                    {
                        foreach (var item in inventory.ItemToQuantity)
                        {
                            Console.WriteLine("Item: {0}, Quantity: {1}", item.Key, item.Value);
                        }

                    }
                    return inventory;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot load {0} due to the following {1}",
                        inventoryFile, ex.Message);
                }
                return null;
            }
        }

        public void FindItem(string name)
        {
            ItemsData mItemsdata = new ItemsData();
            Entry entry = mItemsdata.FindEntry(this.Items, name);
            Console.WriteLine("Name: {0} , Quantity: {1}", entry.Key, entry.Value);
        }

        public List<Entry> UnlockItems(int level, ItemsData itemsData)
        {
            List<Entry> inventoryitems = itemsData.UnlockedEntries(level, itemsData);
            List<Entry> UnlockedItems = new List<Entry>();
            foreach (Entry entry in inventoryitems)
            {
                foreach (Entry inventry in Items)
                {
                    if (inventry.Key.ToString() == entry.Key.ToString())
                    {
                        Console.WriteLine("Name: {0}, Quantity: {1}", inventry.Key, inventry.Value);
                        UnlockedItems.Add(new Entry(inventry.Key, inventry.Value));
                    }
                }
            }
            return UnlockedItems;
        }
    }
}

