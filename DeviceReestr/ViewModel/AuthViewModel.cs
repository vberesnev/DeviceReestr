using DeviceReestr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DeviceReestr.ViewModel
{
    public class AuthViewModel: ViewModelBase
    {
        private RelayCommand authCommand;
        public RelayCommand AuthCommand
        {
            get
            {
                return authCommand ??
                    (authCommand = new RelayCommand(obj =>
                    {
                        Info = String.Empty;
                        var password = ((PasswordBox)obj).Password;
                        currentUser = new User(Login);
                        currentUser.TryAuthorize(password);
                        if (currentUser.IsAuthorized)
                        {
                            openWindow();
                        }
                        else if (currentUser.Id == -1)
                        {
                            Info = "Проблемы с подключением";
                            Login = String.Empty;
                            clearPassword();
                        }
                        else
                        {
                            Info = "Доступ запрещен";
                            Login = String.Empty;
                            clearPassword();
                        }
                    }));
            }
        }

        private string info;
        public string Info
        {
            get { return info; }
            set { info = value; OnPropertyChanged("Info"); }
        }

        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; OnPropertyChanged("Login"); }
        }

        private User currentUser;
        public User GetUser()
        {
            return currentUser;
        }

        Action openWindow;
        Action clearPassword;

        public AuthViewModel(Action actionOpenWindow, Action actionClearPassword)
        {
            openWindow = actionOpenWindow;
            clearPassword = actionClearPassword;
        }
    }
}
