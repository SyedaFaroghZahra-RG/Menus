using System.Collections.Generic;
using System.IO;
using System.Net;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Services
{
    public class UserService : IUserService
    {
        private Dictionary<int, User> users = new Dictionary<int, User>();

        public void  SetUserData(User user, int key)
        {
            if (!users.ContainsKey(key))
            {
                users.Add(key,user);
            }
        }

        public User AccessUserData(int key)
        {
            if (!users.ContainsKey(key))
            {
                Debug.Log("Wrong Id");
            }
            return users[key];
        }
        
        
    }
}