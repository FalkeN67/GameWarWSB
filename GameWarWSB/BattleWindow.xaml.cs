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
                            MessageBox.Show("Wygrałeś walkę! Zyskałeś poziom i 100 złota. -1pkt energii");
                        }
                    }
                    else if (startingPlayer == 2)
                    {
                        player.HealthPoints -= enemy.Damage;
                        startingPlayer = 1;

                        if (player.HealthPoints <= 0)
                        {
                            MessageBox.Show("Przegrałeś walkę! -1pkt energii");
                            player.HealthPoints = 1;
                            break;
                        }
                    }
                }
            
            player.Energy--;
        }
            private void FightButton_Click(object sender, RoutedEventArgs e)
            {
            if (player.Energy < 1)
            {
                MessageBox.Show("Masz za mało energii aby dzisiaj walczyć");
            }
            else if(enemy.HealthPoints < 0)
            {
                MessageBox.Show("Nie możesz dzisiaj już zawalczyć");
            }
            else
            {
                StartBattle();
            }
                DisplayCharacterStats();
            }

        private void DisplayCharacterStats()
        {
            levelLabel.Content = player.Level.ToString();
            healthPointsLabel.Content = player.HealthPoints.ToString();
            damageLabel.Content = player.Damage.ToString();

            nameLabelEnemy.Content = enemy.Name.ToString();
            levelLabelEnemy.Content = enemy.Level.ToString();
            healthPointsLabelEnemy.Content = enemy.HealthPoints.ToString();
            damageLabelEnemy.Content = enemy.Damage.ToString();
        }
    }
}
