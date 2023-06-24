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
    public partial class BarracksWindow : Window
    {
        private Character player;
        public BarracksWindow(Character player)
        {
            this.player = player;
            InitializeComponent();
            DisplayCharacterStats();
        }

        private void IncreaseDamageButton_Click(object sender, RoutedEventArgs e)
        {
             int cost = 20;

            if (player.Gold >= cost)
            {
                int damageToAdd = 10;
                player.IncreaseDamage(damageToAdd);
                player.DecreaseGold(cost);
                MessageBox.Show($"Dodano {damageToAdd} obrażeń do postaci!");
                DisplayCharacterStats();
            }
            else
            {
                MessageBox.Show("Nie masz wystarczającej ilości złota!");
            }
        }

        private void IncreaseDefensButton_Click(object sender, RoutedEventArgs e)
        {
            int cost = 20;
            if (player.Gold >= cost)
            {
                int healthPoints = 10;
                player.IncreaseDefense(healthPoints);
                player.DecreaseGold(cost);
                MessageBox.Show($"Dodano {healthPoints} punktów życia do postaci!");
                DisplayCharacterStats();
            }
            else
            {
                MessageBox.Show("Nie masz wystarczającej ilości złota!");
            }

        }

        private void DisplayCharacterStats()
        {
            healthPointsLabel.Content = player.HealthPoints.ToString();
            damageLabel.Content = player.Damage.ToString();
            goldLabel.Content = player.Gold.ToString();
        }
    }
}

