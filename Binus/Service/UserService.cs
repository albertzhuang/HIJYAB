using Binus.Data;
using Binus.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus.Service
{
    public class UserService
    {
        BinusEntities db = new BinusEntities();

        public User GetUserByCredentials(string username, string password)
        {
            Users tempUser = db.Users1.Where(u => u.Username.Equals(username)
            && u.Password.Equals(password)).FirstOrDefault();
            User user = null;

            if (tempUser != null)
            {
                user = new User() {
                    userID = tempUser.UserID,
                    password = tempUser.Password,
                    username = tempUser.Username,
                    fullname = tempUser.Fullname,
                    role = tempUser.Role
                };
            }

            if (user != null)
            {
                user.password = string.Empty;
            }
            return user;
        }
    }
}