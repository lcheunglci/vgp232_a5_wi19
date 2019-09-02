using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    public class PokemonReader
    {
        XmlSerializer dexserializer;
        XmlSerializer bagserializer; 

        /// <summary>
        /// Construtor
        /// </summary>
        public PokemonReader()
        {
            dexserializer = new XmlSerializer(typeof(Pokedex));
            bagserializer = new XmlSerializer(typeof(PokemonBag));
        }


        /// <summary>
        /// Load a xml file that contains Pokemon Data to be deserialized into a list of Pokemons
        /// </summary>
        /// <param name="filepath">The location of the xml file</param>
        /// <returns>A list of Pokemons</returns>
        public Pokedex Load(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new Exception(string.Format("{0} does not exist", filepath));
            }

            Pokedex dex = null;
            using (var file = new StreamReader(filepath))
            {
                try
                {
                    dex = dexserializer.Deserialize(file) as Pokedex;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Unable to deserialize the {0} due to following: {1}",
                        filepath, ex.Message));
                }
            }

            return dex;
        }


        public void PokemonBagSave(string filename, PokemonBag pokemonlist)
        {
            FileStream fs;

            using (fs = new FileStream(filename, FileMode.Create))
            {
                bagserializer = new XmlSerializer(typeof(PokemonBag));
                bagserializer.Serialize(fs, pokemonlist);
            }
        }

        public PokemonBag LoadPokemonBag(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new Exception(string.Format("{0} does not exist", filename));
            }

            PokemonBag pokemonBag = null;
            using (var file = new StreamReader(filename))
            {
                try
                {
                    pokemonBag = bagserializer.Deserialize(file) as PokemonBag;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Unable to deserialize the {0} due to following: {1}",
                        filename, ex.Message));
                }
            }

            return pokemonBag;
        }

    }
}
