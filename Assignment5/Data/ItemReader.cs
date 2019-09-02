using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    public class ItemReader
    {
        XmlSerializer serializer;

        public ItemReader()
        {
            serializer = new XmlSerializer(typeof(ItemsData));
        }

        public ItemsData Load(string filepath)
        {
            if(!File.Exists(filepath))
            {
                throw new Exception(string.Format("{0} does not exist", filepath));
            }

            ItemsData item = null;

            using (var file = new StreamReader(filepath))
            {
                try
                {
                    item = serializer.Deserialize(file) as ItemsData;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Unable to deserialize the {0} due to the following: {1}"
                        , filepath, ex.Message));
                }
            }

            return item; 
        }
    }
}
