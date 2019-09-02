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
            Pokemon PokemonIndex = new Pokemon();
            int foundIndex = (Pokemons.FindIndex(o => o.Index == index));
            if (foundIndex >= 1 )
            {
                PokemonIndex = Pokemons[foundIndex];
            }
            return PokemonIndex;    
        }

        public Pokemon GetPokemonByName(string name)
        {
            Pokemon PokemonName = new Pokemon();
            int foundIndex = Pokemons.FindIndex(o => o.Name == name);
            if(foundIndex >= 1)
            {
                PokemonName = Pokemons[foundIndex];
            }
            return PokemonName;
            

        }

        public List<Pokemon> GetPokemonsOfType(string type)
        {
            // Note to check both Type1 and Type2
            List<Pokemon> PokemonTypes;
            PokemonTypes = Pokemons.FindAll(x => x.Type1 == type || x.Type2 == type);

            return PokemonTypes;
        }

        public Pokemon GetHighestHPPokemon()
        {
            return Pokemons.OrderByDescending(o => o.HP).First();
        }

        public Pokemon GetHighestAttackPokemon()
        {
            return Pokemons.OrderByDescending(o => o.Attack).First();
        }

        public Pokemon GetHighestDefensePokemon()
        {
            return Pokemons.OrderByDescending(o => o.Defense).First();
        }

        public Pokemon GetHighestMaxCPPokemon()
        {
            return Pokemons.OrderByDescending(o => o.MaxCP).First();
        }

    }
}
