using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class UserService
    {
        public User Login(string email, string password)
        {
            foreach (var user in DB.users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            throw new NotFoundException("password");
        }

        public void AddUser(User user)
        {
            int newLength = DB.users.Length + 1;
            Array.Resize(ref DB.users, newLength);
            DB.users[newLength - 1] = user;
        }
    }
}
