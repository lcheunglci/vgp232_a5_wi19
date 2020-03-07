using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assignment5.Data;

namespace Assignment5.Data
{
    class Pokemon_Test
    {
        const string TEST_XML_OUTPUT_FILE = "output.xml";
        const string TEST_XML_INPUT_FILE = "pokemon151.xml";
        string testXMLFile = "";
        string testInputXMLFile = "";
        Pokedex PokeTest;


        [Test]
        public void Test()
        {
            string actualName = "Test";
            string expectedName = "Test";
            Assert.AreEqual(actualName, expectedName);
        }

        [TestCase("0", "0")]
        [TestCase("TEST", "TEST")]
        [TestCase("teST", "TEST")]
        [TestCase("test123", "TEST123")]
        [TestCase("test", "TEST")]
        public void AnotherTest(string input, string expected)
        {
            string actual = input.ToUpper();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExceptionTest()
        {
            Assert.That(() => {
                List<Pokemon> pokemons = new List<Pokemon>();
                Console.WriteLine(pokemons[1]);
            },
                Throws.InstanceOf<System.ArgumentOutOfRangeException>());
        }

        [SetUp]
        public void Setup()
        {
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);
            string appDir = AppContext.BaseDirectory;
            testXMLFile = Path.Combine(appDir, TEST_XML_OUTPUT_FILE);
            testInputXMLFile = Path.Combine(appDir, TEST_XML_INPUT_FILE);
            PokeTest = new Pokedex();
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(TEST_XML_OUTPUT_FILE))
            {
                File.Delete(TEST_XML_OUTPUT_FILE);
            }
        }


        [TestCase(256)]
        public void DefenseTest(int input)
        {
            Pokemon pokemon = PokeTest.GetHighestDefensePokemon();
            int actual = pokemon.Defense;

            Assert.AreEqual(input, actual);
        }

        [TestCase(300)]
        public void AttackTest(int input)
        {
            Pokemon pokemon = PokeTest.GetHighestAttackPokemon();
            int actual = pokemon.Attack;

            Assert.AreEqual(input, actual);
        }

        [TestCase(487)]
        public void HPTest(int input)
        {
            Pokemon pokemon = PokeTest.GetHighestHPPokemon();
            int actual = pokemon.HP;

            Assert.AreEqual(input, actual);
        }

        [TestCase(4178)]
        public void CPTest(int input)
        {
            Pokemon pokemon = PokeTest.GetHighestMaxCPPokemon();
            int actual = pokemon.MaxCP;

            Assert.AreEqual(input, actual);
        }

    }
}
