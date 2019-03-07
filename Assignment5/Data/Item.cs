using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Data
{
    public class Item
    {
        public string Name { get; set; }
        public int UnlockRequirement { get; set; }
        public string Description { get; set; }
        public string Effect { get; set; }
        public Item() { }

        public Item(string name, int unlockRequirement, string description, string effect)
        {
            this.Name = name;
            this.UnlockRequirement = unlockRequirement;
            this.Description = description;
            this.Effect = effect;
        }

    }

}
