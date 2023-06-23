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
    /// <summary>
    /// Logika interakcji dla klasy CharacterStatsWindow.xaml
    /// </summary>
    public partial class CharacterStatsWindow : Window
    {
        private Character character;

        public CharacterStatsWindow(Character character)
        {
            InitializeComponent();
            this.character = character;
            DisplayCharacterStats();
        }

        private void DisplayCharacterStats()
        {
            levelLabel.Content = character.Level.ToString();
            healthPointsLabel.Content = character.HealthPoints.ToString();
            damageLabel.Content = character.Damage.ToString();
            goldLabel.Content = character.Gold.ToString();
        }
    }
}
