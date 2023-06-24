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


            for (int i = 0; i < 6; i++)
            {
                Weapon.WeaponName weaponName = (Weapon.WeaponName)random.Next(Enum.GetValues(typeof(Weapon.WeaponName)).Length);
                string name = weaponName.ToString();    

                int damage = random.Next(10, 20);
                int requiredLevel = random.Next(1, 10);
                int cost = random.Next(40, 100);

                Weapon newWeapon = new Weapon(name, cost, requiredLevel, damage);
                weapons.Add(newWeapon);
            }
        }



        public void BuyWeapon(Character character, Weapon weapon)
        {
            if (character.Gold >= weapon.Cost && character.Level >= weapon.RequiredLevel)
            {
                character.DecreaseGold(weapon.Cost);
                character.Damage -= character.activeWeapon.Damage;
                character.activeWeapon = weapon;
                character.Damage += character.activeWeapon.Damage;
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
