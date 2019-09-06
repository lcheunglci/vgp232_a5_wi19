using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    /// <summary>
    /// Contains all the pokemons caught based listing them with their index
    /// </summary>
    [Serializable]
    public class PokemonBag
    {
        [XmlArray]
        public List<int> Pokemons { get; set; }

        public PokemonBag()
        {
            Pokemons = new List<int>();
        }

        public void AddPokemon(Pokemon pokemon)
        {
            if (pokemon==null)
            {
                return;
            }
            Pokemons.Add(pokemon.Index);
        }

        public void Save(string filepath)
        {
            PokemonReader reader = new PokemonReader();
            reader.SavePokemonBag(this,filepath);
        }
        public PokemonBag Load(string filepath)
        {
            PokemonReader reader = new PokemonReader();
            return reader.LoadPokemonBag(filepath);
        }
    }
}
