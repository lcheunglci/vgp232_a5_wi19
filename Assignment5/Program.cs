using Assignment5.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

//Testing Merge and Pull request Hi Cyro Macacao
namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Assignment 5 - Pokemon Edition");

            PokemonReader reader = new PokemonReader();
            Pokedex pokedex = reader.Load("pokemon151.xml");

            Console.WriteLine("Displaying List of Pokemon:");
            // List out all the pokemons loaded
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                Console.WriteLine(pokemon.Name);
            }


            // TODO: Add a pokemon bag with 2 bulbsaur, 1 charlizard, 1 mew and 1 dragonite
            // and save it out and load it back and list it out.



            // TODO: Add item reader and print out all the items


            ItemReader itemreader = new ItemReader();
            ItemsData itemsdata = itemreader.Load("itemData.xml");

            Console.WriteLine("\nDisplaying List of Items from file");

            foreach (Item item in itemsdata.Items)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.UnlockRequirement);
                Console.WriteLine(item.Description);
                if (item.Effect == string.Empty)
                {
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine(item.Effect);
                    Console.WriteLine("\n");
                }
            }


            // TODO: hook up item data to display with the inventory (Still unsure what this means)

            string InventoryFile = "inventory.xml";

            var source = new Inventory()
            {
                ItemToQuantity =
                    new Dictionary<object, object> { { "Poke ball", 10 }, { "Potion", 10 } }
            };

            source.Serialize(source);
            source.Deserialize(InventoryFile);

      
            Console.ReadKey();
        }
    }
}
