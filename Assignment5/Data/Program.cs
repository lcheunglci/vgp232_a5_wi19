using Assignment5.Data;
using System;
using System.Collections.Generic;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Assignment 5 - Pokemon Edition");

            PokemonReader pokemonReader = new PokemonReader();
            Pokedex pokedex = pokemonReader.Load("pokemon151.xml");

            // List out all the pokemons loaded
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                Console.WriteLine(pokemon.Name);
            }

            PokemonBag pokemonBag = new PokemonBag();
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                if (pokemon.Name == "Bulbasaur")
                {
                    pokemonBag.Pokemons.Add(pokemon.Index);
                    pokemonBag.Pokemons.Add(pokemon.Index);
                }
                if (pokemon.Name == "Charizard" || pokemon.Name == "Mew" || pokemon.Name == "Dragonite")
                {
                    pokemonBag.Pokemons.Add(pokemon.Index);
                }
            }

            pokemonBag.SaveBag("pokemonBag.xml");
            pokemonBag.LoadBag("pokemonBag.xml");

            Pokemon poke = new Pokemon();
            Console.WriteLine();
            Console.WriteLine("Pokemon Pag contains:");
            for (int i = 0; i < pokemonBag.Pokemons.Count; i++)
            {
                Console.WriteLine();
                poke = pokedex.GetPokemonByIndex(pokemonBag.Pokemons[i]);
                Console.WriteLine($"Index:{poke.Index}");
                Console.WriteLine($"Name:{poke.Name}");
                Console.WriteLine($"HP:{poke.HP}");
                Console.WriteLine($"Attack:{poke.Attack}");
                Console.WriteLine($"Defense:{poke.Defense}");
                Console.WriteLine($"MaxCP:{poke.MaxCP}");
                Console.WriteLine($"Type1:{poke.Type1}");
                Console.WriteLine($"Type2:{poke.Type2}");
            }

            ItemReader itemReader = new ItemReader();
            ItemsData itemsData = itemReader.Load("itemData.xml");

            foreach (Item item in itemsData.Items)
            {
                Console.WriteLine(item);
            }

            // TODO: hook up item data to display with the inventory

            var inventoryItems = new Inventory()
            {
                ItemToQuantity = new Dictionary<object, object> { { "Poke ball", 10 }, { "Potion", 10 } }
            };

            string inventoryFile = "inventory.xml";
            inventoryItems.Serialize(inventoryFile, inventoryItems);
            inventoryItems = inventoryItems.Deserialize(inventoryFile);

            Console.ReadLine();
        }
    }
}
