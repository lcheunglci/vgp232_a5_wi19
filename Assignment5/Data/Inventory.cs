﻿using System;
using System.Collections.Generic;
using System.IO;
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

        // TODO: move this into a inventory with a serialize and deserialize function.
        public void Serialize(string invFile)
        {
            using (var writer = XmlWriter.Create(invFile))
                (new XmlSerializer(typeof(Inventory))).Serialize(writer, this);
        }

        public Inventory Deserialize(string invFile)
        {
            Inventory inventory = null;
            using (var invReader = new StreamReader(invFile))
            {
                var serializer = new XmlSerializer(typeof(Inventory));
                try
                {
                    inventory = serializer.Deserialize(invReader) as Inventory;
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
                        invFile, ex.Message);
                }

            }

            return inventory; 
        }
    }
}
