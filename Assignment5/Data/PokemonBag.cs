using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    /// <summary>
    /// Contains all the pokemons caught based listing them with their index
    /// </summary>
    [XmlRoot("PokemonBag")]
    public class PokemonBag
    {
        [XmlArray("Pokemons")]
        [XmlArrayItem("Index")]
        public List<int> Pokemons { get; set; }

        public PokemonBag()
        {
            Pokemons = new List<int>();
        }

        public void Add(int pokemonIndex) => Pokemons.Add(pokemonIndex);

        public void Save(string filepath) => new PokemonReader().SavePokemonBag(filepath, this);

        public PokemonBag Load(string filepath) => new PokemonReader().LoadPokemonBag(filepath);
    }
}
