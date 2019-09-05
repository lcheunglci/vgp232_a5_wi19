﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Assignment5.Data
{
    /// <summary>
    /// Contains all the pokemons caught based listing them with their index
    /// </summary>
    public class PokemonBag
    {
        [XmlArray]
        public List<int> Pokemons { get; set; }
        XmlSerializer serializer;

        public PokemonBag()
        {
            Pokemons = new List<int>();
            serializer = new XmlSerializer(typeof(List<int>));
        }

        public void SaveBag(string filename)
        {
            using (TextWriter tw = new StreamWriter(filename))
            {
                serializer.Serialize(tw, Pokemons);
            }
        }

        public PokemonBag LoadBag(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new Exception(string.Format("{0} does not exist", filepath));
            }

            PokemonBag bag = new PokemonBag();
            using (var file = new StreamReader(filepath))
            {
                try
                {
                    bag.Pokemons = serializer.Deserialize(file) as List<int>;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Unable to deserialize the {0} due to following: {1}",
                        filepath, ex.Message));
                }
            }

            return bag;
        }
    }
}
