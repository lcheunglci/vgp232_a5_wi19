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
            throw new NotImplementedException();
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
