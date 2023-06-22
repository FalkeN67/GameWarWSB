using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWarWSB
{
    public class Character : ICombatant
    {
        public int Level { get; private set; }
        public int HealthPoints { get; private set; }
        public int Damage { get; private set; }
        public int Gold { get; private set; }

        public Character()
        {
            Level = 1;
            HealthPoints = 100;
            Damage = 10;
            Gold = 50;
        }

        public void LevelUp()
        {
            Level++;
            HealthPoints = 100;
            Damage += 5;
        }

        public void IncreaseGold(int amount)
        {
            Gold += amount;
        }

        public void DecreaseGold(int amount)
        {
            Gold -= amount;
        }

        public void Attack(Enemy enemy)
        {
            enemy.TakeDamage(Damage);
        }

        public void TakeDamage(int damage)
        {
            HealthPoints -= damage;
            if (HealthPoints < 0)
            {
                HealthPoints = 0;
            }
        }

        public void RestoreHealth()
        {
            HealthPoints = 100;
        }
        public void IncreaseDamage(int amount)
        {
            Damage += amount;
        }
    }

     
}
