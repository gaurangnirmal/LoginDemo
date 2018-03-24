using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDemo.Model
{
    public class UserDetailsModel
    {
        private List<UserInfo> _userList;
        private UserInfo _currentUser;

        public List<UserInfo> UserList { get => _userList; set => _userList = value; }

        public UserInfo CurrentUser { get => _currentUser; set => _currentUser = value; }
    }

    public class UserInfo
    {
        private string _name;
        private string _email;
        private string _password;
        private string _mobileno;

        public string Email { get => _email; set => _email = value; }
        public string Name { get => _name; set => _name = value; }
        public string Password { get => _password; set => _password = value; }
        public string Mobileno { get => _mobileno; set => _mobileno = value; }
    }
}
