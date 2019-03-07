using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace Assignment5.Data
{
    public class Test_PokemonReader
    {
        //PokemonReader tests
        PokemonReader testReader;
        string pokedex_sourceExample_XML;
        string pokemonBag_sourceExample_XML;
        string path;

        [SetUp]
        public void SetUp()
        {
            testReader = new PokemonReader();
            pokedex_sourceExample_XML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                                            "<Pokedex>\n" +
                                                "<Pokemons>\n" +
                                                    "<Pokemon>\n" +
                                                        "<Index>1</Index>\n" +
                                                        "<Name>Bulbasaur</Name>\n" +
                                                        "<Type1>Grass</Type1>\n" +
                                                        "<Type2>Poison</Type2>\n" +
                                                        "<HP>128</HP>\n" +
                                                        "<Attack>118</Attack>\n" +
                                                        "<Defense>111</Defense>\n" +
                                                        "<MaxCP>1115</MaxCP>\n" +
                                                     "</Pokemon>\n" +
                                                 "</Pokemons>\n" + 
                                             "</Pokedex>";

            pokemonBag_sourceExample_XML = "<?xml version=\"1.0\"?>\n" +
                                                "<PokemonBag>\n" +
                                                    "<Pokemons>\n" +
                                                        "<int>151</int>\n" +
                                                        "<int>149</int>\n" +
                                                    "</Pokemons>\n" +
                                                 "</PokemonBag>";

            string now = DateTime.Now.ToString("MMddyyyyhmm");
            string dir = System.AppContext.BaseDirectory;
            path = dir + now;
        }
        [TearDown]
        public void TearDown()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [Test]
        public void PokemonReader_Load_Pokedex_HappyPath()
        {

            Pokedex expect = new Pokedex();
            Pokedex actrual;

            // set up expect 
            Pokemon thePokemon = new Pokemon
            {
                                    Index = 1,
                                    Name = "Bulbasaur",
                                    Type1 = "Grass",
                                    Type2 = "Poison",
                                    HP = 128,
                                    Attack = 118,
                                    Defense = 111,
                                    MaxCP = 1115
                                };
            expect.Pokemons.Add(thePokemon);


            // Create a simple test xml for Pokedex
            
            string fileName = "testUse_pokedex.xml";
            path += fileName;

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(pokedex_sourceExample_XML);
                }
            }

            actrual = testReader.Load_Pokedex(path);

            Assert.AreEqual(expect, actrual);

        }

        [Test]
        public void PokemonReader_Load_Pokedex_Case_FileNotExist()
        {
            string fileName = "testUse_pokedex.xml";
            path += fileName;

            // Delete the file in case its really exist
            File.Delete(path);

            Pokedex dex = new Pokedex();
            Assert.That(() => testReader.Load_Pokedex(path), Throws.TypeOf<Exception>());

        }

        [Test]
        public void PokemonReader_Load_PokemonBag_HappyPath()
        {
            PokemonBag expect = new PokemonBag();
            PokemonBag actrual;

            // set up expect 
            expect.Pokemons.Add(151);
            expect.Pokemons.Add(149);


            // Create a simple test xml for Pokedex
            string fileName = "testUse_pokemonBag.xml";
            path += fileName;

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(pokemonBag_sourceExample_XML);
                }
            }

            actrual = testReader.Load_PokemonBag(path);

            Assert.AreEqual(expect, actrual);
        }

        [Test]
        public void PokemonReader_Load_PokemonBag_Case_FileNotExist()
        {
            string fileName = "testUse_pokedex.xml";
            path += fileName;

            // Delete the file in case its really exist
            File.Delete(path);

            PokemonBag theBag = new PokemonBag();
            Assert.That(() => testReader.Load_Pokedex(path), Throws.TypeOf<Exception>());
        }

    }

    public class Test_PokemonSaver
    {
        PokemonSaver saver;
        //for checking result
        PokemonReader reader;

        string path;

        [SetUp]
        public void Init()
        {
            saver = new PokemonSaver();
            reader = new PokemonReader();

            string now = DateTime.Now.ToString("MMddyyyyhmm");
            string dir = System.AppContext.BaseDirectory;
            path = dir + now;
        }

        [TearDown]
        public void Cleanup()
        {
            if (!path.EndsWith(".xml")) { path = path + ".xml"; }
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [TestCase("pokedex.xml")]
        [TestCase("pokedex")]
        public void PokemonSaver_SavePokedex_HappyPass(string fileName)
        {
            Pokedex expect = new Pokedex();
            Pokedex actrul;

            Pokemon thePokemon = new Pokemon
            {
                Index = 1,
                Name = "Bulbasaur",
                Type1 = "Grass",
                Type2 = "Poison",
                HP = 128,
                Attack = 118,
                Defense = 111,
                MaxCP = 1115
            };
            expect.Pokemons.Add(thePokemon);

            //set up unique fileName
            
            path += fileName;
            saver.Save_Pokedex(expect, path);

            // Load up the actrul
            actrul = reader.Load_Pokedex(path);

            Assert.AreEqual(expect, actrul);
        }

        [TestCase("dex.xml")]
        [TestCase("dex")]
        public void PokemonSaver_SavePokedex_FileAlreadyExist(string fileName)
        {
            Pokedex myDex = new Pokedex();

            path += fileName;
            saver.Save_Pokedex(myDex,path);

            Assert.That(() => saver.Save_Pokedex(myDex, path), Throws.TypeOf<Exception>());

        }

        [TestCase("pokemonBag.xml")]
        [TestCase("pokemonBag")]
        public void PokemonSaver_SavePokemonBag_HappyPass(string fileName)
        {
            PokemonBag expect = new PokemonBag();
            PokemonBag actrul;

            expect.Pokemons.Add(1); // Add a Bulbasaur

            //set up unique fileName

            path += fileName;
            saver.Save_PokeBag(expect, path);

            // Load up the actrul
            actrul = reader.Load_PokemonBag(path);

            Assert.AreEqual(expect, actrul);
        }

        [TestCase("bag.xml")]
        [TestCase("bag")]
        public void PokemonSaver_SavePokemonBag_FileAlreadyExist(string fileName)
        {
            PokemonBag myBag = new PokemonBag();

            path += fileName;
            saver.Save_PokeBag(myBag, path);

            Assert.That(() => saver.Save_PokeBag(myBag, path), Throws.TypeOf<Exception>());
        }
    }

}
