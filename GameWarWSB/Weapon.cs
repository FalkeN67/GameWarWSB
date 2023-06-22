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
        public int Damage { get; private set; }
        public int Cost { get; private set; }
        public int RequiredLevel { get; private set; }

        public Weapon(string name, int damage, int cost, int requiredLevel)
        {
            Name = name;
            Damage = damage;
            Cost = cost;
            RequiredLevel = requiredLevel;
        }
    }
}
