using Assignment5.Data;
using System;
namespace Assignment5
{
    public class Program
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

            // TODO: Add a pokemon bag with 2 bulbsaur, 1 charlizard, 1 mew and 1 dragonite
            // and save it out and load it back and list it out.
            Console.WriteLine("\nSaving more pokemons inside bag\n");
            PokemonBag bag = new PokemonBag();
            bag.Add(pokedex.GetPokemonByName("Bulbasaur").Index);
            bag.Add(pokedex.GetPokemonByName("Bulbasaur").Index);
            bag.Add(pokedex.GetPokemonByName("Charizard").Index);
            bag.Add(pokedex.GetPokemonByName("Mew").Index);
            bag.Add(pokedex.GetPokemonByName("Dragonite").Index);

            const string filepath = "PokeBag.xml";
            bag.Save(filepath);
            PokemonBag loadResult = bag.Load(filepath);
            Console.WriteLine("\nLoad all pokemons from bag..\n");
            loadResult.Pokemons.ForEach(item => Console.WriteLine(item));
            
            Console.ReadKey();
        }
    }

}
