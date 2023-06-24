using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWarWSB
{
    public class Enemy : ICombatant
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int HealthPoints { get; set; }
        public int Damage { get; set; }

        public Enemy(Character player, int level = 1, int healthPoints = 10, int damage = 10)
        {
            Random random = new Random();
            EnemyName[] enemyNames = (EnemyName[])Enum.GetValues(typeof(EnemyName));
            Name = enemyNames[random.Next(enemyNames.Length)].ToString();

            HealthPoints = healthPoints;
            Damage = damage;
            Level = level;

            HealthPoints += (player.Level * 3);
            Damage += (player.Level * 2);
        }
        public enum EnemyName
        {
            Bob,
            Alice,
            John,
            Emma,
            Tom
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
