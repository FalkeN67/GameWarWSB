using System.Windows;
using System.Windows.Controls;
using GameWarWSB;

namespace GameWarWSB
{
    public partial class ShopWindow : Window
    {
        private Character player;
        private Shop shop;

        public ShopWindow(Character player, Shop shop)
        {
            InitializeComponent();

            this.player = player;
            this.shop = shop;

            UpdateShopItems();
        }

        private void UpdateShopItems()
        {
            // Wyczyszczenie istniejących elementów w ListView
            ShopItemsListView.Items.Clear();

            // Dodanie dostępnych broni ze sklepu do ListView
            foreach (Weapon weapon in shop.GetWeapons())
            {
                ShopItemsListView.Items.Add(weapon);
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdzenie, czy wybrana broń jest zaznaczona
            if (ShopItemsListView.SelectedItem is Weapon selectedWeapon)
            {
                // Zakup wybranej broni
                shop.BuyWeapon(player, selectedWeapon);

                // Uaktualnienie dostępnych broni w sklepie
                UpdateShopItems();
            }
        }

        private void ShopWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GoldTextBlock.Text = player.Gold.ToString();
        }
    }
}