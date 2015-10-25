using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Lab4_wphone
{
    public partial class PageAdd : PhoneApplicationPage
    {

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            txtElem.Text = "";
            txtMoney.Text = "";
            checkActive.IsChecked = false;

            txtElem.Focus();
        }


        public PageAdd()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Изменения будут потеряны. Продолжить ? ", "Отмена", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                NavigationService.GoBack();
            }
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (txtElem.Text.Trim().Length > 0)
            {
                if (txtMoney.Text.Trim().Length > 0)
                {
                    NavigationService.Navigate(new Uri("/MainPage.xaml?name=" + Uri.EscapeDataString(txtElem.Text) +
                                                "&isactive=" + Uri.EscapeDataString(checkActive.IsChecked.Value.ToString()) +
                                                "&money=" + Uri.EscapeDataString(txtMoney.Text), UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Поле суммы не может быть пустым.");
                    txtMoney.Focus();
                }
            }
            else
            {
                if (checkActive.IsChecked.Value)
                    MessageBox.Show("Поле дохода не может быть пустым.");
                else
                    MessageBox.Show("Поле расхода не может быть пустым.");

                txtElem.Focus();
            }
        }



        private void checkActive_Click(object sender, RoutedEventArgs e)
        {
            if (checkActive.IsChecked.Value)
                lblElem.Text = "Доход:";
            else
                lblElem.Text = "Расход:";
        }

    }
}