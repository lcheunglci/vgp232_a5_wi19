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
            throw new NotImplementedException();
        }

        public Pokemon GetPokemonByName(string name)
        {
            //return Pokemons.
            Pokemon pokemonName = new Pokemon();
            foreach(var pokemon in Pokemons)
            {
                if(pokemon.Name == name)
                {
                    pokemonName = pokemon;
                    break;
                }
                else
                {
                    pokemonName = null;
                }
            }

            return pokemonName;
        }

        List<Pokemon> GetPokemonsOfType(string type)
        {
            // Note to check both Type1 and Type2
            throw new NotImplementedException();
        }

        public Pokemon GetHighestHPPokemon()
        {
            throw new NotImplementedException();
        }

        public Pokemon GetHighestAttackPokemon()
        {
            throw new NotImplementedException();
        }

        public Pokemon GetHighestDefensePokemon()
        {
            throw new NotImplementedException();
        }

        public Pokemon GetHighestMaxCPPokemon()
        {
            throw new NotImplementedException();
        }

    }
}
