using System;
using System.IO;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    public class PokemonReader
    {
        private readonly XmlSerializer serializer;

        /// <summary>
        /// Construtor
        /// </summary>
        public PokemonReader()
        {
            serializer = new XmlSerializer(typeof(Pokedex));
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
                    dex = serializer.Deserialize(file) as Pokedex;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Unable to deserialize the {0} due to following: {1}",
                        filepath, ex.Message));
                }
            }

            return dex;
        }

    }
}
