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
    public sealed partial class ShopPage : Page
    {
        List<AbstractItem> shopItemsList;
        Service serv;
        public ShopPage()
        {
            this.InitializeComponent();
            //serv = new Service();
            serv = MainPage.serv;
            List<string> itemsType = serv.GetAvailableTypes();
            shopItemsList = serv.GetItems(false);
            categoryList.Items.Add("All");
            for (int i = 0; i < itemsType.Count; i++)
            {
                categoryList.Items.Add(itemsType[i]);
            }
            for (int i = 0; i < shopItemsList.Count; i++)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(shopItemsList[i].UriPath));
                itemsShow.Items.Add(img);
            }
            categoryList.SelectedIndex = 0;
            itemsShow.SelectedIndex = 0;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void categoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemsList.Items.Clear();
            itemsShow.Items.Clear();
            for (int i = 0; i < shopItemsList.Count; i++)
            {
                if (shopItemsList[i].GetType().Name.Equals(categoryList.SelectedItem))
                {
                    itemsList.Items.Add(shopItemsList[i].Name);
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(shopItemsList[i].UriPath));
                    itemsShow.Items.Add(img);
                }
                else if(categoryList.SelectedItem.Equals("All"))
                {
                    itemsList.Items.Add(shopItemsList[i].Name);
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(shopItemsList[i].UriPath));
                    itemsShow.Items.Add(img);
                }
            }
            itemsShow.SelectedIndex = 0;
            itemsList.SelectedIndex = 0;
        }

        private void itemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemsShow.SelectedIndex = itemsList.SelectedIndex;
            if (itemsList.SelectedItem != null)
            {
                var tempItem = serv.GetItemByName(itemsList.SelectedItem.ToString(), false);
                itemDetails.Text = tempItem.ToString();
            }
            else
                itemDetails.Text = "";
        }

        private void cartBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UserCart));
        }

        private async void addToCartBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < shopItemsList.Count; i++)
            {
                if(shopItemsList[i].Name.Equals(itemsList.SelectedItem))
                {
                    bool flag = serv.CreateItem(shopItemsList[i], true);
                    if (flag)
                        await new MessageDialog($"{shopItemsList[i].Name} has added successfuly to the cart.").ShowAsync();
                    else
                        await new MessageDialog($"{shopItemsList[i].Name} is already in your cart.").ShowAsync();
                    break;
                }
            }
        }

        private void itemsShow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemsList.SelectedIndex = itemsShow.SelectedIndex;
            if(itemsList.SelectedItem != null)
            {
                var tempItem = serv.GetItemByName(itemsList.SelectedItem.ToString(), false);
                itemDetails.Text = tempItem.ToString();
            }else
                itemDetails.Text = "";
        }

        private void sortCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(sortCmbx.SelectedItem.ToString())
            {
                case "Name":
                    shopItemsList.Sort(new Comparison<AbstractItem>((x, y) => x.Name.CompareTo(y.Name)));
                    break;
                case "Price":
                    shopItemsList.Sort(new Comparison<AbstractItem>((x, y) => x.ActualPrice.CompareTo(y.ActualPrice)));
                    break;
                case "Discount":
                    shopItemsList.Sort(new Comparison<AbstractItem>((x, y) => y.Discount.CompareTo(x.Discount)));
                    break;
            }
            categoryList_SelectionChanged(sender, e);
        }
    }
}
