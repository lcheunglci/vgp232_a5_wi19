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

            // List out all the pokemons loaded
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                Console.WriteLine(pokemon.Name);
            }

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
