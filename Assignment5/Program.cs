using Assignment5.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Assignment 5 - Pokemon Edition");
            PokemonReader reader = new PokemonReader();
            Pokedex pokedex = reader.Load("pokemon151.xml");
            PokemonBag Bag = new PokemonBag();
            // List out all the pokemons loaded
            Pokemon ppokemon = new Pokemon();
            ppokemon = pokedex.
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {

                Console.WriteLine(pokemon.Name);
                if(pokemon.Name == "Bulbasaur")
                {
                    Bag.Pokemons.Add(pokemon.Index);
                    Bag.Pokemons.Add(pokemon.Index);
                }
                if(pokemon.Name == "Charizard")
                {
                    Bag.Pokemons.Add(pokemon.Index);
                }
                if(pokemon.Name == "Mew")
                {
                    Bag.Pokemons.Add(pokemon.Index);
                }
                if(pokemon.Name == "Dragonite")
                {
                    Bag.Pokemons.Add(pokemon.Index);
                }
                
            }
            
            for (int i = 0; i < Bag.Pokemons.Count; i++)
            {
                Console.WriteLine("{0} added", Bag.Pokemons[i]);
            }
            for (int i = 0; i < Bag.Pokemons.Count; i++)
            {
                for (int f = 0; f < pokedex.Pokemons.Count; f++)
                {
                    if(Bag.Pokemons[i] == pokedex.Pokemons[f].Index)
                    {
                        Console.WriteLine(pokedex.Pokemons[f].Index);
                        Console.WriteLine(pokedex.Pokemons[f].Name);
                        Console.WriteLine(pokedex.Pokemons[f].HP);
                        Console.WriteLine(pokedex.Pokemons[f].Attack);
                        Console.WriteLine(pokedex.Pokemons[f].Defense);
                        Console.WriteLine(pokedex.Pokemons[f].Type1);
                        Console.WriteLine(pokedex.Pokemons[f].Type2);
                        Console.WriteLine(pokedex.Pokemons[f].MaxCP);
                    }
                }
            }
            // TODO: Add a pokemon bag with 2 bulbsaur, 1 charlizard, 1 mew and 1 dragonite
            // and save it out and load it back and list it out.
            Console.ReadKey();
        }
    }
}
