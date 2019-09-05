using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace Assignment5.Data
{
    class nUnit
    {
        string fileName;
        string outputFile;
        Pokedex dex;
        PokemonReader reader;

        [SetUp]
        public void Init()
        {
            reader = new PokemonReader();
            fileName = Path.Combine(System.AppContext.BaseDirectory, "pokemon151.xml");
        }

        [Test]
        public void LoadPokemonFile_HappyPath()
        {
            dex = reader.Load(fileName);
        }

        [Test]
        public void LoadFile_FileDoesNotExist_ThrowException()
        {
            try
            {
                dex = reader.Load("something");
            }
            catch(Exception err)
            {
                Assert.AreEqual(err.Message, "something does not exist");
            }
        }
    }
}
