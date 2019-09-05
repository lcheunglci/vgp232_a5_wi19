using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Assignment5.Data
{
    class ItemReader
    {
        XmlSerializer serializer;

        /// <summary>
        /// Construtor
        /// </summary>
        public ItemReader()
        {
            serializer = new XmlSerializer(typeof(Inventory));
        }

        /// <summary>
        /// Load a xml file that contains Pokemon Data to be deserialized into a list of Pokemons
        /// </summary>
        /// <param name="filepath">The location of the xml file</param>
        /// <returns>A list of Pokemons</returns>
        public ItemsData Load(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new Exception(string.Format("{0} does not exist", filepath));
            }

            ItemsData itemsData = null;
            using (var file = new StreamReader(filepath))
            {
                try
                {
                    itemsData = serializer.Deserialize(file) as ItemsData;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Unable to deserialize the {0} due to following: {1}",
                        filepath, ex.Message));
                }
            }
            return itemsData;
        }

        public void SaveInventory(Inventory inventory, string filepath)
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(Inventory));
            using (FileStream fs = new FileStream(filepath, FileMode.Create))
            {
                xmlserializer.Serialize(fs, inventory);
            }
        }
        public ItemsData LoadInventory(string filepath)
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(Inventory));
            if (!File.Exists(filepath))
            {
                throw new Exception(string.Format("{0} does not exist", filepath));
            }

            ItemsData itemsData = null;
            using (var file = new StreamReader(filepath))
            {
                try
                {
                    itemsData = xmlserializer.Deserialize(file) as ItemsData;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Unable to deserialize the {0} due to following: {1}",
                        filepath, ex.Message));
                }
            }
            return itemsData;
        }
    }
}
