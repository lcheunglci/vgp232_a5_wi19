using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Assignment5.Data
{
    public class Inventory
    {
        // Since Dictionaries are not serializable in XML, we use this for serialization
        [XmlArray]
        [XmlArrayItem("Entry")]
        public List<Entry> Items { get; set; }

        [XmlIgnore]
        public Dictionary<object, object> ItemToQuantity
        {
            get { return Items.ToDictionary(x => x.Key, x => x.Value); }
            set
            {
                Items = value.Select(x => new Entry(x.Key, x.Value) { Key = x.Key, Value = x.Value }).ToList();
            }
        }

        XmlSerializer serializer;
        public Inventory()
        {
            Items = new List<Entry>();
            serializer = new XmlSerializer(typeof(Inventory));
        }

        public void Serialize(string inventoryFile, Inventory items)
        {
            using (var writer = XmlWriter.Create(inventoryFile))
            {
                serializer.Serialize(writer, items);
            }
        }

        public Inventory Deserialize(string inventoryFile)
        {
            if (!File.Exists(inventoryFile))
            {
                throw new Exception(string.Format("{0} does not exist", inventoryFile));
            }

            Inventory inventory = null;
            using (var file = new StreamReader(inventoryFile))
            {
                try
                {
                    inventory = serializer.Deserialize(file) as Inventory;
                    if (inventory != null)
                    {
                        foreach (var item in inventory.ItemToQuantity)
                        {
                            Console.WriteLine("Item: {0} Quantity: {1}", item.Key, item.Value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot load {0} due to the following {1}",
                        inventoryFile, ex.Message);
                }
            }
            return inventory;
        }
    }
}
