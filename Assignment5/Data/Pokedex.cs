using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    [XmlRoot("Pokedex")]
    public class Pokedex
    {
        [XmlArray("Pokemons")]
        [XmlArrayItem("Pokemon")]
        public List<Pokemon> Pokemons { get; set; }

        public Pokedex()
        {
            Pokemons = new List<Pokemon>();
        }

        public Pokemon GetPokemonByIndex(int index)
        {
            Pokemon poke = new Pokemon();
            for (int i = 0; i < Pokemons.Count; i++)
            {
                if (Pokemons[i].Index == index)
                {
                    poke = Pokemons[i];
                }
            }
            return poke;
        }

        public Pokemon GetPokemonByName(string name)
        {
            Pokemon poke = new Pokemon();
            foreach (Pokemon pokemon in Pokemons)
            {
                if (pokemon.Name == name)
                {
                    poke = pokemon;
                }
            }
            return poke; ;
        }

        public List<Pokemon> GetPokemonsOfType(string type)
        {
            List<Pokemon> poke = new List<Pokemon>();
            foreach (Pokemon pokemon in Pokemons)
            {
                if (pokemon.Type1 == type || pokemon.Type2 == type)
                {
                    poke.Add(pokemon);
                }
            }
            return poke;
        }

        public Pokemon GetHighestHPPokemon()
        {
            List<Pokemon> temp = Pokemons;
            temp.Sort(Pokemon.CompareByPokemonHP);
            return temp[0];
        }

        public Pokemon GetHighestAttackPokemon()
        {
            List<Pokemon> temp = Pokemons;
            temp.Sort(Pokemon.CompareByPokemonAttack);
            return temp[0];
        }

        public Pokemon GetHighestDefensePokemon()
        {
            List<Pokemon> temp = Pokemons;
            temp.Sort(Pokemon.CompareByPokemonDefense);
            return temp[0];
        }

        public Pokemon GetHighestMaxCPPokemon()
        {
            List<Pokemon> temp = Pokemons;
            temp.Sort(Pokemon.CompareByPokemonMaxCP);
            return temp[0];
        }

    }
}
