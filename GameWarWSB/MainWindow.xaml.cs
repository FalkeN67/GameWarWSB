using System.Windows;

namespace GameWarWSB
{
    public partial class MainWindow : Window
    {
        private Character player;
        private Shop shop;

        public MainWindow()
        {
            InitializeComponent();

            // Inicjalizacja postaci gracza i sklepu
            player = new Character();
            shop = new Shop();

            // Dodaj dostępne bronie do sklepu
            shop.AddWeapon(new Weapon("Miecz", 10, 50, 1));
            shop.AddWeapon(new Weapon("Topór", 15, 75, 2));
            shop.AddWeapon(new Weapon("Łuk", 12, 60, 1));

            // Uaktualnij ofertę sklepu
            shop.UpdateOffer();
        }

        private void FightButton_Click(object sender, RoutedEventArgs e)
        {
            // Implementacja logiki walki
        }

        private void ShopButton_Click(object sender, RoutedEventArgs e)
        {
            // Otwórz okno sklepu
            ShopWindow shopWindow = new ShopWindow(player, shop);
            shopWindow.ShowDialog();
        }

        private void SleepButton_Click(object sender, RoutedEventArgs e)
        {
            // Implementacja logiki snu
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Zamknij aplikację
            Close();
        }
    }
}