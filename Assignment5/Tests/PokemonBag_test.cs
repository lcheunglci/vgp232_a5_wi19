using Assignment5.Data;
using NUnit.Framework;
using System;
using System.IO;

namespace Assignment5.Tests
{
    [TestFixture]
    public class PokemonBag_test
    {
        private PokemonBag mPokemonBag;
        private Pokedex mPokedex;
        private string mFilePath;

        [SetUp]
        public void Init()
        {
            mFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pokemonBag.xml");
            string fileLoad = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pokemon151.xml");

            mPokemonBag = new PokemonBag();
            mPokedex = new PokemonReader().Load(fileLoad);
        }

        [TearDown]
        public void CleanUp()
        {
            // clean everithing
            if (File.Exists(mFilePath))
            {
                File.Delete(mFilePath);
            }
        }

        private PokemonBag Adding_Test()
        {
            //Add a pokemon bag with 2 bulbsaur, 1 charlizard, 1 mew and 1 dragonite
            mPokemonBag.Add(mPokedex.GetPokemonByName("Bulbasaur").Index);
            mPokemonBag.Add(mPokedex.GetPokemonByName("Bulbasaur").Index);
            mPokemonBag.Add(mPokedex.GetPokemonByName("Charizard").Index);
            mPokemonBag.Add(mPokedex.GetPokemonByName("Mew").Index);
            mPokemonBag.Add(mPokedex.GetPokemonByName("Dragonite").Index);
            return mPokemonBag;
        }

        [Test]
        public void PokemonBag_Add_Pokemons()
        {
            Assert.IsTrue(Adding_Test().Pokemons.Count > 0);
        }

        [Test]
        public void PokemonBag_Save()
        {
            Adding_Test().Save(mFilePath);
            Assert.IsTrue(File.Exists(mFilePath));
        }

        [Test]
        public void PokemonBag_Load()
        {
            if (File.Exists(mFilePath))
            {
                PokemonBag temp = mPokemonBag.Load(mFilePath);
                temp.Pokemons.ForEach(Item => Console.WriteLine(Item));
                Assert.IsTrue(temp.Pokemons.Count >= 5);
            }
        }

    }
}