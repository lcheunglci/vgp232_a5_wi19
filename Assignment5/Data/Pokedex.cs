using System.Collections.Generic;
using System.Linq;
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
            Pokemon temp = new Pokemon();
            int idx = Pokemons.FindIndex(i => i.Index == index);
            if (idx != -1)
            {
                temp = Pokemons[idx];
            }
            return temp;

        }

        public Pokemon GetPokemonByName(string name)
        {

            Pokemon temp = new Pokemon();
            int index = Pokemons.FindIndex(i => i.Name == name);
            if (index != -1)
            {
                temp = Pokemons[index];
            }
            return temp;
        }

        public List<Pokemon> GetPokemonsOfType(string type) => Pokemons.FindAll(p => p.Type1 == type || p.Type2 == type);

        public Pokemon GetHighestHPPokemon() => Pokemons.OrderByDescending(p => p.HP).First();

        public Pokemon GetHighestAttackPokemon() => Pokemons.OrderByDescending(p => p.Attack).First();

        public Pokemon GetHighestDefensePokemon() => Pokemons.OrderByDescending(p => p.Defense).First();

        public Pokemon GetHighestMaxCPPokemon() => Pokemons.OrderByDescending(p => p.MaxCP).First();


    }
}
