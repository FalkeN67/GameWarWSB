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
            DisplayCharacterStats();
        }
        private void StartBattle()
        {
            int startingPlayer = new Random().Next(1, 3);

            while (player.HealthPoints > 0 && enemy.HealthPoints > 0)
            {
                if (startingPlayer == 1)
                {
                    enemy.HealthPoints -= player.Damage;
                    startingPlayer = 2;

                    if (enemy.HealthPoints <= 0)
                    {
                        player.LevelUp();
                        player.IncreaseGold(100);
                        MessageBox.Show("Wygrałeś walkę! Zyskałeś poziom i 100 złota.");
                    }
                }
                else if(startingPlayer == 2)
                {
                    player.HealthPoints -= enemy.Damage;
                    startingPlayer = 1;

                    if (player.HealthPoints <= 0)
                    {
                        MessageBox.Show("Przegrałeś walkę! Gra zakończona.");
                    }
                }
            }
        }
            private void FightButton_Click(object sender, RoutedEventArgs e)
            {
                StartBattle();
            }

        private void DisplayCharacterStats()
        {
            levelLabel.Content = player.Level.ToString();
            healthPointsLabel.Content = player.HealthPoints.ToString();
            damageLabel.Content = player.Damage.ToString();

            levelLabelEnemy.Content = enemy.Level.ToString();
            healthPointsLabelEnemy.Content = enemy.HealthPoints.ToString();
            damageLabelEnemy.Content = enemy.Damage.ToString();
        }
    }
}
