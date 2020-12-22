using KrunkerBL.Service;
using KrunkerCommon.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Receipt : Page
    {
        List<AbstractItem> boughtItems;
        Service serv;
        public Receipt()
        {
            this.InitializeComponent();
            serv = MainPage.serv;
            boughtItems = serv.GetItems();
            double totalbill = 0;
            for (int i = 0; i < boughtItems.Count; i++)
            {
                itemsListBox.Items.Add(boughtItems[i].Name);
                totalbill += boughtItems[i].ActualPrice;
            }
            totalBill.Text = $"Total: {totalbill}$";
        }

        private void itemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemImg.Source = new BitmapImage(new Uri(boughtItems[itemsListBox.SelectedIndex].UriPath));
            itemDetails.Text = boughtItems[itemsListBox.SelectedIndex].ToString();
        }

        private void cartBtn_Click(object sender, RoutedEventArgs e)
        {
            serv.Clear(true);
            this.Frame.GoBack();
        }
    }
}
