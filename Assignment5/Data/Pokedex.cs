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
        Pokemon unknowPokemon;
        static int MAX_POKEMONS = 809; //Max number of pokemons from <Bulbapedia>

        public Pokedex()
        {
            Pokemons = new List<Pokemon>();

            // Return this when try to look for pokemon that current index dont know
            unknowPokemon = new Pokemon
            {
                Index = MAX_POKEMONS,
                Name = "????",
                Type1 = "??",
                Type2 = "??",
                HP = 0,
                Attack = 0,
                Defense = 0,
                MaxCP = 0
            };
        }

        public Pokemon GetPokemonByIndex(int index)
        {
            //Because the data source use 1 base
            index -= 1;
            Pokemon returnPokemon;
            if (index >= Pokemons.Count && index <= MAX_POKEMONS)
            {
                returnPokemon = unknowPokemon;
                returnPokemon.Index = index;
            }
            else if(index < 0 || index > MAX_POKEMONS)
            {
                throw new Exception("Error!, invalid index detected when get pokemon from pokedex");
            }
            else
            {
                returnPokemon = Pokemons[index];
            }

            return returnPokemon;
        }

        public Pokemon GetPokemonByName(string name)
        {
            Pokemon returnPokemon = unknowPokemon;

            foreach (var element in Pokemons)
            {
                if (String.Compare(name, element.Name,true) == 0)
                {
                    returnPokemon = element;
                    break;
                }
            }

            if (returnPokemon == unknowPokemon)
            {
                throw new Exception(string.Format("\n<Pokedex>: Unknow pokemon name '{0}' dectected\n", name));
            }
            return returnPokemon;
        }

        List<Pokemon> GetPokemonsOfType(string type)
        {
            // Note to check both Type1 and Type2
            List<Pokemon> returnPokemons = new List<Pokemon>();
            foreach (var element in Pokemons)
            {
                if (element.Type1 == type || element.Type2 == type)
                {
                    returnPokemons.Add(element);
                }
            }

            return returnPokemons;
        }

        Pokemon GetHighestHPPokemon()
        {
            Pokemon returnPokemon = unknowPokemon;
            foreach (var element in Pokemons)
            {
                if (element.HP >= returnPokemon.HP)
                {
                    returnPokemon = element;
                }
            }

            return returnPokemon;
        }

        Pokemon GetHighestAttackPokemon()
        {
            Pokemon returnPokemon = unknowPokemon;
            foreach (var element in Pokemons)
            {
                if (element.Attack >= returnPokemon.Attack)
                {
                    returnPokemon = element;
                }
            }

            return returnPokemon;
        }

        Pokemon GetHighestDefensePokemon()
        {
            Pokemon returnPokemon = unknowPokemon;
            foreach (var element in Pokemons)
            {
                if (element.Defense >= returnPokemon.Defense)
                {
                    returnPokemon = element;
                }
            }

            return returnPokemon;
        }

        Pokemon GetHighestMaxCPPokemon()
        {
            Pokemon returnPokemon = unknowPokemon;
            foreach (var element in Pokemons)
            {
                if (element.MaxCP >= returnPokemon.MaxCP)
                {
                    returnPokemon = element;
                }
            }

            return returnPokemon;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Pokedex other = (Pokedex)obj;
            if (Pokemons.Count == other.Pokemons.Count)
            {
                for (int i = 0; i < Pokemons.Count; i++)
                {
                    if (!(Pokemons[i].Equals(other.Pokemons[i])))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
