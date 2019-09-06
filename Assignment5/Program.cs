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

            PokemonBag pokemonBag = new PokemonBag();
            pokemonBag.AddPokemon(pokedex.GetPokemonByName("bulbasaur"));
            pokemonBag.AddPokemon(pokedex.GetPokemonByName("bulbasaur"));
            pokemonBag.AddPokemon(pokedex.GetPokemonByName("Charizard"));
            pokemonBag.AddPokemon(pokedex.GetPokemonByName("mew"));
            pokemonBag.AddPokemon(pokedex.GetPokemonByName("dragonite"));

            string filepath = Environment.CurrentDirectory + "\\PokemonBag.xml";
            pokemonBag.Save(filepath);
            PokemonBag pokemonBag2 = pokemonBag.Load(filepath);

            Console.WriteLine();
            foreach (var bagItem in pokemonBag2.Pokemons)
            {
                Console.WriteLine(pokedex.GetPokemonByIndex(bagItem).Name);
            }

                      var source = new Inventory()
            {
                ItemToQuantity =
                    new Dictionary<object, object> { { "Poke ball", 10 }, { "Potion", 10 } }
            };
            source.Serialize("itemData.xml");
            source.Deserialize("itemData.xml");
            source.PrintItems();

            source.Serialize("itemData.xml");

            Console.ReadKey();
        }
    }
}
