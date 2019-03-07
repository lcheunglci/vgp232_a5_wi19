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

        public override bool Equals(object other )
        {
            if (other == null || GetType() != other.GetType())
            {
                return false;
            }

            Pokemon b = (Pokemon)other;
            if (
                (Index == b.Index) &&
                (Name == b.Name) &&
                (Type1 == b.Type1) &&
                (Type2 == b.Type2) &&
                (HP == b.HP) &&
                (Attack == b.Attack) &&
                (Defense == b.Defense) &&
                (MaxCP == b.MaxCP)
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
