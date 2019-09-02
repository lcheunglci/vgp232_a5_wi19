using Assignment5.Data;
using NUnit.Framework;
using System;
using System.IO;

namespace Assignment5.Tests
{
    [TestFixture]
    public class Pokedex_Test
    {
        private Pokedex mPokedex;
        // First step to initialize tests
        [SetUp]
        public void Init()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pokemon151.xml");

            PokemonReader reader = new PokemonReader();
            mPokedex = reader.Load(filePath);
        }

        // Last step of tests
        [TearDown]
        public void CleanUp()
        {
            // nothing to do
        }

        [Test]
        public void PokeDex_Get_Pokemon_By_Index()
        {
            // index 6 is Charizard
            Pokemon pokemon = mPokedex.GetPokemonByIndex(6);
            Assert.IsTrue(pokemon.Name == "Charizard");
        }

        [Test]
        public void PokeDex_Get_Pokemon_By_Name()
        {
            // Name = Charizard
            Pokemon pokemon = mPokedex.GetPokemonByName("Charizard");
            Assert.IsTrue(pokemon.Name == "Charizard");
        }

        [Test]
        public void Pokedex_Get_Highest_HP()
        {
            Pokemon pokemon = mPokedex.GetHighestHPPokemon();
            Assert.IsTrue(pokemon.HP >= 487);
        }

        [Test]
        public void Pokedex_Get_Highest_Attack()
        {
            Pokemon pokemon = mPokedex.GetHighestAttackPokemon();
            Assert.IsTrue(pokemon.Attack >= 300);
        }

        [Test]
        public void Pokedex_Get_Highest_Defense()
        {
            Pokemon pokemon = mPokedex.GetHighestDefensePokemon();
            Assert.IsTrue(pokemon.Defense >= 250);
        }

        [Test]
        public void Pokedex_Get_highest_MaxCP()
        {
            Pokemon pokemon = mPokedex.GetHighestMaxCPPokemon();
            Assert.IsTrue(pokemon.MaxCP >= 4000);
        }

    }
}
