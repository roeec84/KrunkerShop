using KrunkerBL.Service;
using KrunkerCommon.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace KrunkerEx
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserCart : Page
    {
        Service serv;
        List<AbstractItem> userItemsList;
        public UserCart()
        {
            this.InitializeComponent();
            serv = MainPage.serv;
            userItemsList = serv.GetItems();
            List<string> itemsType = serv.GetAvailableTypes();
            categoryList.Items.Add("All");
            categoryList.SelectedIndex = 0;
            for (int i = 0; i < itemsType.Count; i++)
            {
                categoryList.Items.Add(itemsType[i]);
            }
            UpdateItemsSummary();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void categoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemsList.Items.Clear();
            itemsShow.Items.Clear();
            if (categoryList.SelectedItem.Equals("All"))
            {
                for (int i = 0; i < userItemsList.Count; i++)
                {
                    itemsList.Items.Add(userItemsList[i].Name);
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(userItemsList[i].UriPath));
                    itemsShow.Items.Add(img);
                }
            }
            else
            {
                for (int i = 0; i < userItemsList.Count; i++)
                {
                    if (userItemsList[i].GetType().Name.Equals(categoryList.SelectedItem))
                    {
                        itemsList.Items.Add(userItemsList[i].Name);
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri(userItemsList[i].UriPath));
                        itemsShow.Items.Add(img);
                    }
                }
            }
        }
        private void itemsShow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemsList.SelectedIndex = itemsShow.SelectedIndex;
            if (itemsList.SelectedItem != null)
            {
                var tempItem = serv.GetItemByName(itemsList.SelectedItem.ToString(), true);
                itemDetails.Text = tempItem.ToString();
            }
            else
                itemDetails.Text = "";
        }

        private void itemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemsShow.SelectedIndex = itemsList.SelectedIndex;
            if (itemsList.SelectedItem != null)
            {
                var tempItem = serv.GetItemByName(itemsList.SelectedItem.ToString(), true);
                itemDetails.Text = tempItem.ToString();
            }
            else
                itemDetails.Text = "";
        }

        private async void itemsShow_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (itemsList.SelectedItem != null)
            {
                var tempItem = serv.GetItemByName(itemsList.SelectedItem.ToString(), true);
                var msgDialog = new MessageDialog($"Are you sure you want to remove {tempItem.Name} from the cart?");
                msgDialog.Commands.Add(new UICommand("Yes", RemoveFromCart));
                msgDialog.Commands.Add(new UICommand("No"));
                await msgDialog.ShowAsync();
            }
        }
        private void RemoveFromCart(IUICommand cmd)
        {
            serv.DeleteItem(serv.GetItemByName(itemsList.Items[itemsList.SelectedIndex].ToString()));
            if (itemsShow.Items.Count > 0 && itemsList.Items.Count > 0)
                itemsList.SelectedIndex = itemsShow.SelectedIndex -= 1;
            else
                itemsList.SelectedIndex = itemsShow.SelectedIndex = -1;
            itemsList.Items.Remove(itemsList.Items[itemsList.SelectedIndex +1]);
            itemsShow.Items.Remove(itemsShow.Items[itemsShow.SelectedIndex + 1]);
            UpdateItemsSummary();
        }

        private void emptyCartBtn_Click(object sender, RoutedEventArgs e)
        {
            itemsList.Items.Clear();
            itemsShow.Items.Clear();
            categoryList.SelectedIndex = 0;
            userItemsList.Clear();
            serv.Clear(true);
            UpdateItemsSummary();
        }
        private void UpdateItemsSummary()
        {
            double totalprice = 0;
            for (int i = 0; i < userItemsList.Count; i++)
            {
                totalprice += userItemsList[i].ActualPrice;
            }
            totalItemsDetail.Text = $"Items in the cart: {userItemsList.Count}\nTotal price: {totalprice}$";
        }

        private async void buyBtn_Click(object sender, RoutedEventArgs e)
        {
            if(userItemsList.Count == 0)
            {
                await new MessageDialog("Your cart is empty.").ShowAsync();
                return;
            }
            serv.AddReceiption(new Receiption(userItemsList, DateTime.Now.ToString()));
            serv.UpdateAmounts(userItemsList);
            this.Frame.Navigate(typeof(Receipt));
        }
    }
}
