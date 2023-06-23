using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWarWSB
{
    public class Weapon
    {
        public string Name { get; private set; }
        public int Damage { get; set; }
        public int Cost { get; set; }
        public int RequiredLevel { get; set; }

        public Weapon(string name = "Null", int cost = 0, int requiredLevel = 0, int damage = 0)
        {
            Name = name;
            Damage = damage;
            Cost = cost;
            RequiredLevel = requiredLevel;
        }
    }
}
