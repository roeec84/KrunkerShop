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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace KrunkerEx
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ManagerReceiptions : Page
    {
        Service serv;
        List<Receiption> receiptionsList;
        public ManagerReceiptions()
        {
            this.InitializeComponent();
            serv = MainPage.serv;
            receiptionsList = serv.GetReceiptions();
            double totalmoney = 0;
            foreach(Receiption receiption in receiptionsList)
            {
                receList.Items.Add($"Reception No. {receiption.ID}");
                totalmoney += receiption.Bill;
            }
            totalMoney.Text = $"Total Money: {totalmoney}$";
            totalReceipts.Text = $"Total Receipts: {receiptionsList.Count}";
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void receList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            receDetails.Text = receiptionsList[receList.SelectedIndex].ToString();
        }
    }
}
