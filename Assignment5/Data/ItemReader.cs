using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    class ItemReader
    {
        XmlSerializer serializer;

        public ItemReader()
        {
            serializer = new XmlSerializer(typeof(ItemsData));
        }

        public ItemsData Load(string filePath)
        {
            ItemsData itemsData = null;
            using (var file = new StreamReader(filePath))
            {
                try
                {
                    itemsData = serializer.Deserialize(file) as ItemsData;
                }
                catch(Exception ex)
                {
                    throw new Exception(string.Format("Unable to deserialize the {0} due to following: {1}",
                        filePath, ex.Message));
                }
            }

            return itemsData;
        }

    }
}
