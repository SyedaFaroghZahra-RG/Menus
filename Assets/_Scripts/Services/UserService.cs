using System.Collections.Generic;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Services
{
    public class UserService : IUserService
    {
        private Dictionary<string, Result> users = new Dictionary<string, Result>();
        private bool _shouldCallAPI;

        public void SetUserData(Result user, string key)
        {
            if (!users.ContainsKey(key))
            {
                users.Add(key,user);
            }
        }
        
        public Result GetUserData(string key)
        {
            if (!users.ContainsKey(key))
            {
                Debug.Log("Wrong Id");
            }
            return users[key];
        }

        public bool ShouldCallAPIGetter()
        {
            return _shouldCallAPI;
        }

        public void ShouldCallAPISetter(bool call)
        {
            _shouldCallAPI = call;
        }
    }
}