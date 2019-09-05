using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Data
{
    public class Pokemon
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int MaxCP { get; set; }

        public static int CompareByPokemonHP(Pokemon left, Pokemon right)
        {
            return right.HP.CompareTo(left.HP);
        }

        public static int CompareByPokemonAttack(Pokemon left, Pokemon right)
        {
            return right.Attack.CompareTo(left.Attack);
        }

        public static int CompareByPokemonDefense(Pokemon left, Pokemon right)
        {
            return right.Defense.CompareTo(left.Defense);
        }

        public static int CompareByPokemonMaxCP(Pokemon left, Pokemon right)
        {
            return right.MaxCP.CompareTo(left.MaxCP);
        }
    }
}
