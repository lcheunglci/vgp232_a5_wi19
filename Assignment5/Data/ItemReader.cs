using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    static public class ItemReader
    {
        static public ItemsData Load(string filePath)
        {
         
            ItemsData itemsData = null;
            using (var file = new StreamReader(filePath))
            {
                try
                {
                    var serializer = new XmlSerializer(typeof(ItemsData));
                    itemsData = serializer.Deserialize(file) as ItemsData;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Unable to deserialize the {0} due to following: {1}",
                        filePath, ex.Message));
                }
            }

            return itemsData;
        }
    }
}