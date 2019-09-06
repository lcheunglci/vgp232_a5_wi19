using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
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
                Items = value.Select(x => new Entry() { Key = x.Key, Value = x.Value }).ToList();
            }
        }

        public Inventory()
        {
            Items = new List<Entry>();
        }

        public void Serialize(string filePath) // Functionally the save function of Inventory
        {
            //string inventoryFile = "inventory.xml";
            if(!File.Exists(filePath))
            {
                throw new Exception(string.Format("{0} does not exist", filePath));                
            }
            using (var writer = XmlWriter.Create(filePath))
                (new XmlSerializer(typeof(Inventory))).Serialize(writer, this);
            return;
        }

        
        public Inventory Deserialize(string filePath) // Functionally the load function of Inventory
        {
            if (!File.Exists(filePath))
                throw new Exception(string.Format("{0} does not exist", filePath));

            Inventory inventory = null;
            using (var reader = new StreamReader(filePath))
            {
                var serializer = new XmlSerializer(typeof(Inventory));
                try
                {
                    inventory = serializer.Deserialize(reader) as Inventory;
                    if (inventory != null)
                    {
                        foreach (var item in inventory.ItemToQuantity)
                        {
                            Console.WriteLine("Item: {0} Quantity: {1}", item.Key, item.Value);                            
                        }
                        Items = inventory.Items;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Cannot load {0} due to the following {1}",
                        filePath, ex.Message);
                }
            }
            return inventory;
        }

        public void PrintItems()
        {
            if (Items.Any())
            { 
                foreach (var item in Items)
                {
                    Console.WriteLine("Item: {0} Quantity: {1}", item.Key, item.Value);
                }
            }
            else
            {
                Console.WriteLine("No Items in bag");
            }
        }

        
        public void DisplayItem(Item input) // Displays item details through ItemData.cs
        {
            foreach(var item in Items)
            {
                if(item.Key == input)
                {
                    // TODO make the itemData display through this?
                    return;
                }
            }
        }
    }
}
