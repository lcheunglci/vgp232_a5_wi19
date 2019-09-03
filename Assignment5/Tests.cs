using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assignment5.Data;

namespace Assignment5
{
    class Tests
    {
        string myOutputFilename = "PokemonBag.xml";
        string myInputFilename = "pokemon151.xml";
        string myTestInputPath = "";
        string myTestOutputPath = "";
        string myDirPath;

        [SetUp]
        public void SetUp()
        {
            myDirPath = System.AppContext.BaseDirectory;
            myTestInputPath = Path.Combine(myDirPath, myInputFilename);
            myTestOutputPath = Path.Combine(myDirPath, myOutputFilename);

            myDirPath = AppDomain.CurrentDomain.BaseDirectory;

            myDirPath = this.GetType().Assembly.Location;
            myDirPath = Path.GetDirectoryName(myDirPath);
        }


        [TestCase("Pikachu")]
        public void SavePokemonBagFile(string name)
        {
            PokemonReader reader = new PokemonReader();
            Pokedex pokedex = reader.Load(myTestInputPath);
            PokemonBag pokemonBag = new PokemonBag();
            pokemonBag.AddPokemon(pokedex.GetPokemonByName(name));
            pokemonBag.Save(myTestOutputPath);
            Assert.IsTrue(File.Exists(myTestOutputPath));

        }
        [Test]
        public void LoadPokemonBagFile()
        {
            PokemonReader reader = new PokemonReader();
            Pokedex pokedex = reader.Load(myTestInputPath);
            PokemonBag pokemonBag = new PokemonBag();
            pokemonBag.AddPokemon(pokedex.GetPokemonByName("bulbasaur"));
            pokemonBag.AddPokemon(pokedex.GetPokemonByName("bulbasaur"));
            pokemonBag.AddPokemon(pokedex.GetPokemonByName("Charizard"));
            pokemonBag.AddPokemon(pokedex.GetPokemonByName("mew"));
            pokemonBag.AddPokemon(pokedex.GetPokemonByName("dragonite"));
            pokemonBag.Save(myTestOutputPath);
            pokemonBag.Load(myTestOutputPath);

            Assert.AreEqual(5, pokemonBag.Pokemons.Count);
        }

    }
}
