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
    public class PokemonBag
    {
        [XmlArray]
        public List<int> Pokemons { get; set; }

        public PokemonBag()
        {
            Pokemons = new List<int>();
        }

        public void AddPokemon(Pokedex dex, string name)
        {
            try
            {
                Pokemon thePokemon = dex.GetPokemonByName(name);
                Pokemons.Add(thePokemon.Index);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        public void PrettyPrint(Pokedex dex)
        {
            Console.WriteLine("****<Your PokemonBeg>****");
            Console.WriteLine("----Currently contain: {0} pokemons.", Pokemons.Count);
            Console.WriteLine("");

            // Print pokemon section
            Console.WriteLine("\t<Pokemon>");
            foreach (var element in Pokemons)
            {
                Pokemon currentPokemon = dex.GetPokemonByIndex(element);
                Console.WriteLine("\t [{0}]\t\t*HP: {1}\t*Attack: {2}\t*Defence: {3}", currentPokemon.Name, currentPokemon.HP, currentPokemon.Attack, currentPokemon.Defense);
            }
        }

        public override bool Equals(object obj)
        {
            bool returnBool;
            if (obj == null || GetType() != obj.GetType())
            {
                returnBool = false;
            }

            PokemonBag other = (PokemonBag)obj;
            if (Pokemons.Count == other.Pokemons.Count)
            {
                for (int i = 0; i < Pokemons.Count; i++)
                {
                    if (!(Pokemons[i] == other.Pokemons[i]))
                    {
                        returnBool = false;
                    }
                }
                returnBool = true;
            }
            else
            {
                returnBool = false;
            }

            return returnBool;
        }
    }
}
