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
            Pokemon pok = new Pokemon();
            foreach (var poke in Pokemons)
            {
                if(poke.Index == index)
                {
                    pok = poke;
                }
            }
            return pok;
        }

        public Pokemon GetPokemonByName(string name)
        {
            foreach (Pokemon pok in Pokemons)
            {
                if(pok.Name == name)
                {
                    return pok;
                }
            }
            return null;
        }

        public List<Pokemon> GetPokemonsOfType(string type)
        {
            List<Pokemon> poks = new List<Pokemon>();
            foreach (var pok in Pokemons)
            {
                if(pok.Type1 == type || pok.Type2 == type)
                {
                    poks.Add(pok);
                }
            }
            return poks;
        }

        public Pokemon GetHighestHPPokemon()
        {
            Pokemon pok = new Pokemon();
            pok.HP = 0;
            foreach (var poke in Pokemons)
            {
                if(poke.HP > pok.HP)
                {
                    pok = poke;
                }
            }
            return pok;
        }

        public Pokemon GetHighestAttackPokemon()
        {
            Pokemon pok = new Pokemon();
            pok.Attack = 0;
            foreach (var poke in Pokemons)
            {
                if (poke.Attack > pok.Attack)
                {
                    pok = poke;
                }
            }
            return pok;
        }

        public Pokemon GetHighestDefensePokemon()
        {
            Pokemon pok = new Pokemon();
            pok.Defense = 0;
            foreach (var poke in Pokemons)
            {
                if (poke.Defense > pok.Defense)
                {
                    pok = poke;
                }
            }
            return pok;
        }

        public Pokemon GetHighestMaxCPPokemon()
        {
            Pokemon pok = new Pokemon();
            pok.MaxCP = 0;
            foreach (var poke in Pokemons)
            {
                if (poke.MaxCP > pok.MaxCP)
                {
                    pok = poke;
                }
            }
            return pok;
        }

    }
}
