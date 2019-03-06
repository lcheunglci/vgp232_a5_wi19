using Assignment5.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
    
namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Assignment 5 - Pokemon Edition");

            // load the itemData xml
            string inputFile = "itemData.xml";
            
            ItemsData itemsData = new ItemsData();
            ItemReader itemReader = new ItemReader();
            Inventory inventory = new Inventory();
            if (string.IsNullOrEmpty(inputFile))
            {
                //show message to user that input file path was not not specified
                Console.WriteLine("input file path was not specified");
            }
            else if (!File.Exists((inputFile)))
            {
                //show message to user that the input file path does not exist
                Console.WriteLine("input file path does not exist");
            }
            else
            {
                // add item to ItemReader
                itemsData = itemReader.LoadFile(inputFile);
            }


            // print out all the items nmae
            Console.WriteLine("\nfollowing are the name of item: ");
            foreach (Item item in itemsData.Items)
            {
                Console.WriteLine(item.Name);
            }


            // hook up item data to display with the inventory
            Console.WriteLine("\nfollowing is test for inventory");
            var source = new Inventory()
            {
                ItemToQuantity =
                    new Dictionary<object, object> { { "Poke ball", 10 }, { "Potion", 10 } }
            };
            string inventoryFile = null;

            inventoryFile = inventory.WriteInventory(source);
            inventory.LoadInventory(inventoryFile);


            // test for find
            Console.WriteLine("\nfollowing is test for find: ");
            Item itemFinded = new Item();
            itemFinded = itemsData.FindItem("Potion");

            //test for unlock level
            Console.WriteLine("\nfollowing is test for unlock level: ");
            int level = 5;
            List<Item> itemDataFinded = itemsData.UnlockedItemsAtLevel(level);

            foreach (Item items in itemDataFinded)
            {
                Console.WriteLine("item: {0}", items.Name);
            }


            Console.ReadKey();
        }
    }
}
