using System;
using System.IO;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    public class PokemonReader
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public PokemonReader()
        {

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
                throw new Exception($"{filepath} does not exist");
            }

            Pokedex dex = null;
            using (var file = new StreamReader(filepath))
            {
                try
                {
                    dex = new XmlSerializer(typeof(Pokedex)).Deserialize(file) as Pokedex;

                }
                catch (Exception ex)
                {
                    throw new Exception($"Unable to deserialize the {filepath} due to following: {ex.Message}");
                }
            }

            return dex;
        }
        public PokemonBag LoadPokemonBag(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new Exception($"{filepath} does not exist");
            }

            PokemonBag dex = null;
            using (var file = new StreamReader(filepath))
            {
                try
                {
                    dex = new XmlSerializer(typeof(PokemonBag)).Deserialize(file) as PokemonBag;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unable to deserialize the {filepath} due to following: {ex.Message}");
                }
            }

            return dex;
        }

        public void SavePokemonBag(string filepath, PokemonBag input)
        {
            using (FileStream fs = File.Open(filepath,
                File.Exists(filepath) ? FileMode.Append : FileMode.Create))
            {
                new XmlSerializer(typeof(PokemonBag)).Serialize(fs, input);
            }
        }

    }
}
