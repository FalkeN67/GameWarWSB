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
            enemy = new Enemy(player);

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

        private void SleepButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nastał nowy dzień...");
            player.gameDay++;
            enemy.Level++;
            enemy.HealthPoints += 100;
            enemy.Damage += 60;
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