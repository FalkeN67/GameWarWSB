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
            DisplayWeaponDamage();
            UpdateShopItems();
        }



        private void UpdateShopItems()
        {
            ShopItemsListView.Items.Clear();

            foreach (Weapon weapon in shop.GetWeapons())
            {
                ShopItemsListView.Items.Add(weapon);
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {

            if (ShopItemsListView.SelectedItem is Weapon selectedWeapon)
            {
                shop.BuyWeapon(player, selectedWeapon);
                player.activeWeapon = selectedWeapon;
                UpdateShopItems();
            }
        }

        private void ShopWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GoldTextBlock.Text = player.Gold.ToString();
        }

        private void DisplayWeaponDamage()
        {
            activeWeaponDamage.Content = player.activeWeapon.Damage.ToString();
        }

        private void ShopItemsListView_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }
    }
}