using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;


namespace Assignment5.Data
{
    class Tests
    {
        string invetoryFile = "inventory.xml";
        string itemsFile = "itemData.xml";
        string pokemonFile = "pokemon151.xml";
        string pokebagFile = "pokebag.xml";

        string TestPokemonFile = "";
        string TestItemsFile = "";
        string TestPokebag = "";
        string TestInvetoryFile = "";

        Pokedex pokedex;
        Pokemon pokemon;
        PokemonBag pokeBag;
        PokemonReader reader;
        Item item;
        ItemsData itemsData;
        ItemReader itemReader;
        Inventory invetory;

        [SetUp]
        public void SetUp()
        {
            reader = new PokemonReader();
            itemReader = new ItemReader();
            itemsData = new ItemsData();
            pokemon = new Pokemon();
            pokeBag = new PokemonBag();
            item = new Item();
            invetory = new Inventory();

            string myDirPath = System.AppContext.BaseDirectory;
            TestPokemonFile = Path.Combine(myDirPath, pokemonFile);
            TestItemsFile = Path.Combine(myDirPath, itemsFile);
            TestPokebag = Path.Combine(myDirPath, pokebagFile);
            TestInvetoryFile = Path.Combine(myDirPath, invetoryFile);

            pokedex = reader.Load(TestPokemonFile);
            itemsData = itemReader.Load(TestItemsFile);
        }

        [Test]
        public void GetPokemonByIndex()
        {
            var actual = pokedex.GetPokemonByIndex(7);
            var expected = "Squirtle";
            Assert.AreEqual(expected, actual.Name);
        }

        [Test]
        public void GetPokemonByName()
        {
            var actual = pokedex.GetPokemonByName("Squirtle");
            var expected = 7;
            Assert.AreEqual(expected, actual.Index);
        }

        [Test]
        public void GetPokemonsByType()
        {
            Pokedex dex = new Pokedex();
            dex.Pokemons = pokedex.GetPokemonsOfType("Water");
            var actual = dex.Pokemons.Count;
            var expected = 32;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetHighetsHP()
        {
            pokedex.GetHighestHPPokemon();
            var expected = true;
            var actual = pokedex.Pokemons[0].Name == "Chansey";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetHighetsDefense()
        {
            pokedex.GetHighestDefensePokemon();
            var expected = true;
            var actual = pokedex.Pokemons[0].Name == "Cloyster";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetHighetsAttack()
        {
            pokedex.GetHighestAttackPokemon();
            var expected = true;
            var actual = pokedex.Pokemons[0].Name == "Mewtwo";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetHighetsMaxCP()
        {
            pokedex.GetHighestMaxCPPokemon();
            var expected = true;
            var actual = pokedex.Pokemons[0].Name == "Mewtwo";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PokemonBagSave()
        {
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                if (pokemon.Name == "Bulbasaur")
                {
                    pokeBag.Pokemons.Add(pokemon.Index);
                    pokeBag.Pokemons.Add(pokemon.Index);
                }
                if (pokemon.Name == "Charizard" || pokemon.Name == "Mew" || pokemon.Name == "Dragonite")
                {
                    pokeBag.Pokemons.Add(pokemon.Index);
                }
            }
            pokeBag.SaveBag(TestPokebag);
            var expected = true;
            var actual = File.Exists(TestPokebag);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PokemonBagLoad()
        {
            pokeBag = pokeBag.LoadBag(TestPokebag);
            int expected = 5;
            int actual = pokeBag.Pokemons.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PokemonReaderLoad()
        {
            var expected = 151;
            var actual = pokedex.Pokemons.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ItemReaderLoad()
        {
            var expected = 15;
            var actual = itemsData.Items.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UnlockItemsAtLevel()
        {
            itemsData.Items = itemsData.UnlockedItemsAtLevel(10);
            var expected = 8;
            var actual = itemsData.Items.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindItem()
        {
            var actual = itemsData.FindItem("Potion");
            var expected = 5;
            Assert.AreEqual(expected, actual.UnlockRequirement);
        }

        [Test]
        public void InvetorySerialized()
        {
            var inventoryItems = new Inventory()
            {
                ItemToQuantity = new Dictionary<object, object> { { "Poke ball", 10 }, { "Potion", 10 } }
            };

            invetory.Serialize(TestInvetoryFile, inventoryItems);
            var expected = true;
            var actual = File.Exists(TestInvetoryFile);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InvetoryDeserialized()
        {
            invetory = invetory.Deserialize(TestInvetoryFile);
            var expected = 2;
            var actual = invetory.Items.Count;
            Assert.AreEqual(expected, actual);
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
