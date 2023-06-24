using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWarWSB
{
        public class Character : ICombatant
        {
            public int Level { get; set; }
            public int HealthPoints { get; set; }
            public int Damage { get; set; }
            public int Gold { get; set; }
            
            public int gameDay { get; set; }

            public Weapon activeWeapon { get; set; }

            public Character()
            {
                activeWeapon = new Weapon("Patyk");
            
                Level = 1;
                HealthPoints = 100;
                Damage = 50;
                Gold = 50;
                gameDay = 1;
            }

            public void LevelUp()
            {
                Level++;
                HealthPoints += 10;
                Damage += 15;
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

            public void IncreaseDamage(int amount)
            {
                Damage += amount;
            }

            public void IncreaseDefense(int amount)
            {
                HealthPoints += amount;
            }
        }

     
    }
