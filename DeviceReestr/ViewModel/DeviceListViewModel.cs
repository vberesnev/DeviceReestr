using DeviceReestr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReestr.ViewModel
{
  
    class DeviceListViewModel: ViewModelBase
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged("Title"); }
        }

        private DeviceList deviceList;
        public DeviceList DeviceList
        {
            get { return deviceList; }
            set { deviceList = value; OnPropertyChanged("DeviceList"); }
        }

        private IEnumerable<Device> devices;
        public IEnumerable<Device> Devices
        {
            get { return devices; }
            set { devices = value; OnPropertyChanged("Devices"); }
        }

        private User currentUser;
        public DeviceListViewModel(AuthViewModel authViewModel)
        {
            currentUser = authViewModel.GetUser();
            Title = $"Список устройств пользователя {currentUser.Login}";
            DeviceList = new DeviceList(currentUser);
            Devices = DeviceList.Devices;
        }

        public DeviceListViewModel()
        {
            DeviceList = new DeviceList();
            Devices = DeviceList.FilterDevices;
        }
    }
}
