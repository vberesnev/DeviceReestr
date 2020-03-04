using DeviceReestr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReestr.ViewModel
{
    class AddDeviceViewModel: ViewModelBase
    {
        private RelayCommand addDeviceCommand;
        public RelayCommand AddDeviceCommand
        {
            get
            {
                return addDeviceCommand ??
                    (addDeviceCommand = new RelayCommand(obj =>
                    {
                        if (IsFill())
                        {
                            Device device = new Device(SerialNo, Type, Description, currentUser);
                            if (device.Save())
                            {
                                Info = "Устройсто добавлено!";
                                SerialNo = Type = Description = String.Empty;
                            }
                            else
                            {
                                Info = "Ошибка сохранения устройства";
                            }
                        }
                        else
                        {
                            Info = "Заполните все данные";
                        }
                    }));
            }
        }

        private string serialNo;
        public string SerialNo
        {
            get { return serialNo; }
            set { serialNo = value;  OnPropertyChanged("SerialNo"); }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged("Type"); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        private string info;
        public string Info
        {
            get { return info; }
            set { info = value; OnPropertyChanged("Info"); }
        }

        private User currentUser;
        public AddDeviceViewModel(AuthViewModel authViewModel)
        {
            currentUser = authViewModel.GetUser();
        }

        private bool IsFill()
        {
            return (!string.IsNullOrEmpty(SerialNo) && !string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(Description));
        }
    }
}
