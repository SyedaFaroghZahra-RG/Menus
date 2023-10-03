using System.Collections.Generic;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Services
{
    public class UserService : IUserService
    {
        private Dictionary<string, Result> users = new Dictionary<string, Result>();

        public void SetUserData(Result user, string key)
        {
            if (!users.ContainsKey(key))
            {
                users.Add(key,user);
            }
        }

        public bool ContainsKey(string key)
        {
            if (users.ContainsKey(key))
            {
                return true;
            }

            return false;
        }
        public Result GetUserData(string key)
        {
            if (!users.ContainsKey(key))
            {
                Debug.Log("Wrong Id");
            }
            return users[key];
        }
        
        
    }
}