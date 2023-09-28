using System.Collections.Generic;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Services
{
    public class UserService : IUserService
    {
        private Dictionary<string, Result> users = new Dictionary<string, Result>();

        public void  SetUserData(Result user, string key)
        {
            if (!users.ContainsKey(key))
            {
                users.Add(key,user);
            }
        }

        public Result AccessUserData(string key)
        {
            if (!users.ContainsKey(key))
            {
                Debug.Log("Wrong Id");
            }
            return users[key];
        }
        
        
    }
}