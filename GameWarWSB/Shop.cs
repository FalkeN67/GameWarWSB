using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWarWSB
{
    public class Shop
    {
        private List<Weapon> weapons;

        public List<Weapon> GetWeapons()
        {
            return weapons;
        }

        public Shop()
        {
            weapons = new List<Weapon>();
        }

        public void AddWeapon(Weapon weapon)
        {
            weapons.Add(weapon);
        }

        public void RemoveWeapon(Weapon weapon)
        {
            weapons.Remove(weapon);
        }

        public void UpdateOffer()
        {
            Random random = new Random();
            weapons.Clear();


            for (int i = 0; i < 3; i++)
            {
                string name = "Weapon " + (i + 1);
                int damage = random.Next(10, 20);
                int cost = random.Next(50, 100);
                int requiredLevel = random.Next(1, 5);

                Weapon newWeapon = new Weapon(name, damage, cost, requiredLevel);
                weapons.Add(newWeapon);
            }
        }



        public void BuyWeapon(Character character, Weapon weapon)
        {
            if (character.Gold >= weapon.Cost && character.Level >= weapon.RequiredLevel)
            {
                character.DecreaseGold(weapon.Cost);
                character.IncreaseDamage(weapon.Damage);
                RemoveWeapon(weapon);
            }
            else if (character.Gold <= weapon.Cost)
            {
                MessageBox.Show("Nie masz wystarczającej ilości złota na zakup tej broni.");
            }
            else if (character.Level <= weapon.RequiredLevel)
            {
                MessageBox.Show("Nie masz wystarczająco doświadczenia aby używać tej broni");
            }
            else
            {
                MessageBox.Show("Nie możesz kupić tej broni");
            }
        }
    }
}
