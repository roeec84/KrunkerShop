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
    public sealed partial class ManagerPage : Page
    {
        Service serv;
        List<AbstractItem> storeItems;
        public ManagerPage()
        {
            serv = MainPage.serv;
            this.InitializeComponent();
            storeItems = serv.GetAvailableItems();
            categoryList.Items.Add("All");
            List<string> types = serv.GetAvailableTypes();
            for (int j = 0; j < types.Count; j++)
                categoryList.Items.Add(types[j]);
            for (int i = 0; i < storeItems.Count; i++)
            {
                itemsList.Items.Add(storeItems[i].Name);
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(storeItems[i].UriPath));
                itemsShow.Items.Add(img);
            }
            categoryList.SelectedIndex = 0;
            itemsList.SelectedIndex = 0;
            itemsShow.SelectedIndex = 0;
        }

        private async void itemCreate_Click(object sender, RoutedEventArgs e)
        {
            if(itemsList.SelectedIndex == -1)
            {
                await new MessageDialog("You must to choose an item.").ShowAsync();
                return;
            }
            var tempItem = serv.GetStorageItemByName(itemsList.SelectedItem.ToString());
            if (tempItem != null)
            {
                if (itemPrice.Text.Length == 0 || itemAmount.Text.Length == 0 || itemDiscount.Text.Length == 0)
                {
                    await new MessageDialog("All fields must be filled.").ShowAsync();
                    return;
                }
                double price, discount;
                int amount;
                bool tryprice = double.TryParse(itemPrice.Text, out price);
                bool tryamount = int.TryParse(itemAmount.Text, out amount);
                bool trydiscount = double.TryParse(itemDiscount.Text, out discount);
                if (!tryprice || !tryamount || !trydiscount)
                {
                    await new MessageDialog("One of the fields is invalid.").ShowAsync();
                    return;
                }
                if (discount < 0 || discount > 100)
                {
                    await new MessageDialog("Discount must be between 0% to 100%.").ShowAsync();
                    return;
                }
                tempItem.Price = price;
                tempItem.AvailableAmount = amount;
                tempItem.Discount = discount;
                bool flag = serv.CreateItem(tempItem, false);
                if (flag)
                    await new MessageDialog($"{tempItem.Name} has added successfuly to the store.").ShowAsync();
                else
                    await new MessageDialog($"{tempItem.Name} is already in stock.").ShowAsync();
            }
        }

        private void OnItemListCreateChange(object sender, SelectionChangedEventArgs e)
        {
            itemsShow.SelectedIndex = itemsList.SelectedIndex;
            if (itemsList.SelectedItem != null)
            {
                var tempItem = serv.GetStorageItemByName(itemsList.SelectedItem.ToString());
                if (tempItem is Clothing)
                {
                    sizeStack.Visibility = Visibility.Visible;
                    Clothing tempCloth = (Clothing)tempItem;
                    itemSize.Text = tempCloth.Size.ToString();
                }
                else
                    sizeStack.Visibility = Visibility.Collapsed;
                itemName.Text = tempItem.Name;
                itemPrice.Text = tempItem.Price.ToString();
                itemAmount.Text = tempItem.AvailableAmount.ToString();
                itemDiscount.Text = tempItem.Discount.ToString();
            }
        }

        private void categoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemsList.Items.Clear();
            itemsShow.Items.Clear();
            for (int i = 0; i < storeItems.Count; i++)
            {
                if(storeItems[i].GetType().Name.Equals(categoryList.SelectedItem))
                {
                    itemsList.Items.Add(storeItems[i].Name);
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(storeItems[i].UriPath));
                    itemsShow.Items.Add(img);
                }else if(categoryList.SelectedItem.Equals("All"))
                {
                    itemsList.Items.Add(storeItems[i].Name);
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(storeItems[i].UriPath));
                    itemsShow.Items.Add(img);
                }
            }
            itemsList.SelectedIndex = 0;
            itemsShow.SelectedIndex = 0;
        }

        private void itemsShow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemsList.SelectedIndex = itemsShow.SelectedIndex;
            if (itemsShow.SelectedItem != null)
            {
                var tempItem = serv.GetStorageItemByName(itemsList.SelectedItem.ToString());
                if (tempItem is Clothing)
                {
                    sizeStack.Visibility = Visibility.Visible;
                    Clothing tempCloth = (Clothing)tempItem;
                    itemSize.Text = tempCloth.Size.ToString();
                }
                else
                    sizeStack.Visibility = Visibility.Collapsed;
                itemName.Text = tempItem.Name;
                itemPrice.Text = tempItem.Price.ToString();
                itemAmount.Text = tempItem.AvailableAmount.ToString();
                itemDiscount.Text = tempItem.Discount.ToString();
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void receBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ManagerReceiptions));
        }

        private void sortCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (sortCmbx.SelectedItem.ToString())
            {
                case "Name":
                    storeItems.Sort(new Comparison<AbstractItem>((x, y) => x.Name.CompareTo(y.Name)));
                    break;
                case "Price":
                    storeItems.Sort(new Comparison<AbstractItem>((x, y) => x.ActualPrice.CompareTo(y.ActualPrice)));
                    break;
                case "Discount":
                    storeItems.Sort(new Comparison<AbstractItem>((x, y) => y.Discount.CompareTo(x.Discount)));
                    break;
            }
            categoryList_SelectionChanged(sender, e);
        }
    }
}
