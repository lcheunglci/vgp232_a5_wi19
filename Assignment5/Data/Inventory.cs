using System;
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

        public void Load(string inventoryFile, ItemsData itemsData)
        {
            using (var writer = XmlWriter.Create(inventoryFile))
                (new XmlSerializer(typeof(Inventory))).Serialize(writer, this);

            using (StreamReader reader2 = new StreamReader(inventoryFile))
            {
                var serializer = new XmlSerializer(typeof(Inventory));
                try
                {
                    Inventory inventory = serializer.Deserialize(reader2) as Inventory;
                    if (inventory != null)
                    {
                        foreach (var item in inventory.ItemToQuantity)
                        {
                            Item newitem = itemsData.FindItem(item.Key.ToString());
                            Console.WriteLine("Item: {0} Quantity: {1} Description {2} Effect {3} UnlockRequirement {4}"
                                , item.Key, item.Value, newitem.Description,newitem.Effect,newitem.UnlockRequirement);
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Cannot load {0} due to the following {1}",
                        inventoryFile, ex.Message);
                }

            }
        }

        public void Save(string fileName)
        {
            string outputFile = fileName;
            FileStream fs;
            if (File.Exists(fileName))
            {
                fs = File.Open(outputFile, FileMode.Append);
            }
            else
            {
                fs = File.Open(outputFile, FileMode.Create);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(Inventory));
            serializer.Serialize(fs, this);
            fs.Close();
        }
    }
}
