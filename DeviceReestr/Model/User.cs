using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReestr.Model
{
    public class User
    {
        public int Id { get; private set; }
        public string Login { get; private set; }

        public bool IsAuthorized { get; private set; }

        public User(string login)
        {
            Login = login;
        }

        public User()
        {
        }

        public void TryAuthorize(string password)
        {
            //Естественно, пароль надо шифровать. Делать я этого конечно не буду [т.к. в ТЗ об этом ни слова :) ]

            Id = DataBase.TryAuthorize(this, password);
            if (Id > 0)
                IsAuthorized = true;
        }
    }
}
