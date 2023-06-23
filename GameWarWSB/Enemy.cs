using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWarWSB
{
    public class Enemy : ICombatant
    {
        public int HealthPoints { get; set; }
        public int Damage { get; set; }

        public Enemy(int healthPoints, int damage)
        {
            HealthPoints = healthPoints;
            Damage = damage;
        }

        public Enemy()
        {
        }

        public void TakeDamage(int damage)
        {
            HealthPoints -= damage;
            if (HealthPoints < 0)
            {
                HealthPoints = 0;
            }
        }

        public void IncreaseDifficulty()
        {
            HealthPoints += 20;
            Damage += 5;
        }
    }
}
