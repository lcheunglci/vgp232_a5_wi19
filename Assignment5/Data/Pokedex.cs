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
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Index == index)
                {
                    return pokemon;
                }
            }
            return null;
           //throw new NotImplementedException();
        }

        public Pokemon GetPokemonByName(string name)
        {
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Name.ToUpper() == name.ToUpper())
                {
                    return pokemon;
                }
            }
            return null;
            //throw new NotImplementedException();
        }

        public List<Pokemon> GetPokemonsOfType(string type)
        {
            // Note to check both Type1 and Type2
            List <Pokemon> pokemonsType = new List <Pokemon>();
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Type1 == type || pokemon.Type2 == type)
                {
                    pokemonsType.Add(pokemon);
                }
            }
            return pokemonsType;
        }

        public Pokemon GetHighestHPPokemon()
        {
            if (Pokemons.Count ==0)
            {
                return null;
            }
            Pokemon highestHpPokemon = Pokemons[0];
            foreach (var pokemon in Pokemons)
            {
                if (highestHpPokemon.HP < pokemon.HP)
                {
                    highestHpPokemon = pokemon;
                }
            }
            return highestHpPokemon;
            //throw new NotImplementedException();
        }

        public Pokemon GetHighestAttackPokemon()
        {
            if (Pokemons.Count == 0)
            {
                return null;
            }
            Pokemon highestAttackPokemon = Pokemons[0];
            foreach (var pokemon in Pokemons)
            {
                if (highestAttackPokemon.Attack < pokemon.Attack)
                {
                    highestAttackPokemon = pokemon;
                }
            }
            return highestAttackPokemon;
            //throw new NotImplementedException();
        }

        public Pokemon GetHighestDefensePokemon()
        {
            if (Pokemons.Count == 0)
            {
                return null;
            }
            Pokemon highestDefensePokemon = Pokemons[0];
            foreach (var pokemon in Pokemons)
            {
                if (highestDefensePokemon.Defense < pokemon.Defense)
                {
                    highestDefensePokemon = pokemon;
                }
            }
            return highestDefensePokemon;
            //throw new NotImplementedException();
        }

        public Pokemon GetHighestMaxCPPokemon()
        {
            if (Pokemons.Count == 0)
            {
                return null;
            }
            Pokemon highestMaxCpPokemon = Pokemons[0];
            foreach (var pokemon in Pokemons)
            {
                if (highestMaxCpPokemon.MaxCP < pokemon.MaxCP)
                {
                    highestMaxCpPokemon = pokemon;
                }
            }
            return highestMaxCpPokemon;
            //throw new NotImplementedException();
        }

    }
}
