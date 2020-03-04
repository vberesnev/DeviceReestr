using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DeviceReestr.ViewModel;

namespace DeviceReestr.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private AuthViewModel authViewModel;
        public MainWindow(ViewModel.AuthViewModel authViewModel)
        {
            this.authViewModel = authViewModel;
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddDevice_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new AddDevicePage(authViewModel));
        }

        private void DeviceList_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new DeviceListPage(authViewModel));
        }

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new StatisticPage());
        }

        
    }
}
