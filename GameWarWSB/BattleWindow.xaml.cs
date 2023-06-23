using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameWarWSB
{
    public partial class BattleWindow : Window
    {
        private Character player;
        private Enemy enemy;
        public BattleWindow(Character player, Enemy enemy)
        {
            InitializeComponent();
            this.player = player;
            this.enemy = enemy;
            StartBattle();
            Close();
        }
        private void StartBattle()
        {
            int startingPlayer = new Random().Next(1, 3);

            while (player.HealthPoints > 0 && enemy.HealthPoints > 0)
            {
                if (startingPlayer == 1)
                {
                    
                    enemy.HealthPoints -= player.Damage;

                    if (enemy.HealthPoints <= 0)
                    {
                        player.LevelUp();
                        player.IncreaseGold(100);
                        MessageBox.Show("Wygrałeś walkę! Zyskałeś poziom i 100 złota.");
                    }
                }
                else
                {
                    int enemyDamage = enemy.Damage;
                    player.HealthPoints -= enemyDamage;

                    if (player.HealthPoints <= 0)
                    {
                        MessageBox.Show("Przegrałeś walkę! Gra zakończona.");
                    }
                }

                startingPlayer = (startingPlayer == 1) ? 2 : 1;
            }

         
        }
    }
}
