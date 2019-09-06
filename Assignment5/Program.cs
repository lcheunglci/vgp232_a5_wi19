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

            // List out all the pokemons loaded
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                Console.WriteLine(pokemon.Name);
            }


            // TODO: Add a pokemon bag with 2 bulbsaur, 1 charlizard, 1 mew and 1 dragonite
            // and save it out and load it back and list it out.

            // TODO: Add item reader and print out all the items
            ItemReader itemReader = new ItemReader();
            ItemsData itemsData = itemReader.Load("itemData.xml");

            foreach (var item in itemsData.Items)
            {
                Console.WriteLine(item.Name);
            }

            // TODO: hook up item data to display with the inventory

            var source = new Inventory()
            {
                ItemToQuantity =
                    new Dictionary<object, object> { { "Poke ball", 10 }, { "Potion", 10 } }
            };

            // TODO: move this into a inventory with a serialize and deserialize function.
            string inventoryFile = "inventory.xml";
            source.Load(inventoryFile,itemsData);
            source.Save("invent.xml");
  
  
            Console.WriteLine("=========Bag=========");

            PokemonBag pokebag = new PokemonBag();

            pokebag.Pokemons.Add(pokedex.GetPokemonByName("Bulbasaur"));
            pokebag.Pokemons.Add(pokedex.GetPokemonByName("Bulbasaur"));
            pokebag.Pokemons.Add(pokedex.GetPokemonByName("Charizard"));
            pokebag.Pokemons.Add(pokedex.GetPokemonByName("Mew"));
            pokebag.Pokemons.Add(pokedex.GetPokemonByName("Dragonite"));

            Pokedex bagdex = new Pokedex();
            bagdex.Pokemons = pokebag.Pokemons;
            reader.Save("bagdex", bagdex);
            Pokedex loadDex = reader.Load("bagdex.xml");

            foreach (Pokemon pokemon in loadDex.Pokemons)
            {
                Console.WriteLine(pokemon.Name);
            }

            Console.ReadKey();
        }
    }
}
