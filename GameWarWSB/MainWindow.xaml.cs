using System;
using System.Windows;

namespace GameWarWSB
{
    public partial class MainWindow : Window
    {
        private Character player;
        private Shop shop;
        private Enemy enemy;
        public int PlayerGameDay;


        public MainWindow()
        {
            InitializeComponent();

            player = new Character();
            shop = new Shop();
            enemy = new Enemy(player, "Jack");

            shop.AddWeapon(new Weapon("Miecz", 10, 50, 1));
            shop.AddWeapon(new Weapon("Topór", 15, 75, 2));
            shop.AddWeapon(new Weapon("Łuk", 12, 60, 1));

            shop.UpdateOffer();
        }

        private void FightButton_Click(object sender, RoutedEventArgs e)
        {
            BattleWindow battleWindow = new BattleWindow(player, enemy);
            battleWindow.ShowDialog();
        }

        private void ShopButton_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow shopWindow = new ShopWindow(player, shop);
            shopWindow.ShowDialog();
        }

        private void BarracksButton_Click(object sender, RoutedEventArgs e)
        {
            BarracksWindow barracksWindow = new BarracksWindow(player);
            barracksWindow.ShowDialog();
        }

        private void SleepButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nastał nowy dzień...");
            player.gameDay++;
            player.Energy = 3;
            enemy.Level++;

            
            Random random1 = new Random();

            enemy.HealthPoints = 10;
            
            if(player.HealthPoints < 20)
            {
                enemy.HealthPoints = random1.Next(5, 25);
            }
            else
            {
                enemy.HealthPoints = random1.Next(player.HealthPoints - 20, player.HealthPoints + 20);
            }
            
            enemy.Damage = random1.Next(player.Damage - 20, player.Damage + 20);

            Array enemyNames = Enum.GetValues(typeof(Enemy.EnemyName));
            Random random = new Random();
            int randomIndex = random.Next(enemyNames.Length);
            enemy.Name = enemyNames.GetValue(randomIndex).ToString();

        }
        private void WorkButton_Click(object sender, RoutedEventArgs e)
        {
            if(player.Energy > 0)
            {
                player.Gold += 40;
                player.Energy--;
                MessageBox.Show("Skończono pracę, zarobiłeś 40 złota");
            }
            else
            {
                MessageBox.Show("Masz za mało energii aby dziś pracować");
            }
            
        }
        private void CharacterStatsButton_Click(object sender, RoutedEventArgs e)
        {
            CharacterStatsWindow statsWindow = new CharacterStatsWindow(player);
            statsWindow.ShowDialog();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}