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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DeviceReestr.ViewModel;

namespace DeviceReestr.View
{
    /// <summary>
    /// Логика взаимодействия для AddDevicePage.xaml
    /// </summary>
    public partial class AddDevicePage : Page
    {
        public AddDevicePage(AuthViewModel authViewModel)
        {
            AddDeviceViewModel viewModel = new AddDeviceViewModel(authViewModel);
            DataContext = viewModel;

            InitializeComponent();
            
        }
    }
}
