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
  
            Console.WriteLine("\nSaving various Pokemon in a bag...");
            PokemonBag pokemonBag = new PokemonBag();
            pokemonBag.Add(pokedex.GetPokemonByName("Bulbasaur").Index);
            pokemonBag.Add(pokedex.GetPokemonByName("Bulbasaur").Index);
            pokemonBag.Add(pokedex.GetPokemonByName("Charizard").Index);
            pokemonBag.Add(pokedex.GetPokemonByName("Mew").Index);
            pokemonBag.Add(pokedex.GetPokemonByName("Dragonite").Index);

            string filename = "PokemonBag.xml";
            pokemonBag.Save(filename);

            Console.WriteLine("Displaying Loaded Pokemon from bag: ");
            PokemonBag loadedbag = pokemonBag.Load(filename);        
            foreach (int pokeindex in loadedbag.Pokemons)
            {
                foreach(Pokemon pokemon in pokedex.Pokemons)
                {
                    if(pokemon.Index == pokeindex)
                    {
                        pokemon.Print();
                    }
                }
            }


            ItemReader itemReader = new ItemReader();
            ItemsData itemsDatafile = itemReader.Load("itemData.xml");

            Console.WriteLine("\nDisplaying List of Items from file");

            foreach (Item item in itemsDatafile.Items)
            {
                item.Print();
      
            }

            int iLevelLock = 10;
            Console.WriteLine("Displaying items unlocked at level {0}", iLevelLock);
            List<Item> UnlockedItems = itemsDatafile.UnlockedItemsAtLevel(iLevelLock);
            foreach (Item item in UnlockedItems)
            {
                item.Print();
            }

            string itemname = "Super Potion";
            Console.WriteLine("Searching for item {0}", itemname);
            itemsDatafile.FindItem(itemname).Print();           

            string InventoryFile = "inventory.xml";

            Console.WriteLine("-----Creating Inventory-----");
            var source = new Inventory()
            {
                ItemToQuantity =
                    new Dictionary<object, object> { { "Poke ball", 10 }, { "Potion", 10 },
                                                      {"Premier ball", 20 }, {"Revive",3}, {"Great ball",8 },
                                                     {"Hyper Potion", 2 } }
            };

            source.Serialize(source);
            source.Deserialize(InventoryFile);

            string entry = "Poke ball";
            Console.WriteLine("\nSearching for {0} in Inventory", entry);
            source.FindItem("Poke ball");

            Console.WriteLine("\nDisplaying items in inventory whose Level Req < {0}", iLevelLock);
            source.UnlockItems(iLevelLock,itemsDatafile);


            Console.ReadKey();
        }
    }

}
