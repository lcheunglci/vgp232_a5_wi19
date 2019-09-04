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
        XmlSerializer serializer;

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
            Pokedex pokeDex = new Pokedex();
            try
            {
                using (FileStream fs = new FileStream(filepath, FileMode.Open))
                {
                    try
                    {
                        pokeDex = serializer.Deserialize(fs) as Pokedex;
                        foreach (var pokemon in pokeDex.Pokemons)
                        {
                            pokeDex.Pokemons.Add(pokemon);
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                }
            }
            catch (FileNotFoundException err)
            {
                Console.WriteLine(err.Message);
            }
            return pokeDex;
        }

        public void Save(string fileName, Pokedex pokedex)
        {
            string outputFile = fileName + ".xml";
            FileStream fs;
            if (File.Exists(fileName))
            {
                fs = File.Open(outputFile, FileMode.Append);
            }
            else
            {
                fs = File.Open(outputFile, FileMode.Create);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(Pokedex));
            serializer.Serialize(fs, pokedex);
            fs.Close();
        }
    }
}
