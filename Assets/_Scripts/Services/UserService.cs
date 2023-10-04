using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Services
{
    public class UserService : IUserService
    {
        private Dictionary<string, object> users = new Dictionary<string, object>();
        private bool _callAPI;
        public void SetUserData<T>(T user, string key) where T : class
        {
            if (!users.ContainsKey(key))
            {
                users.Add(key,user);
            }
        }
        public T GetUserData<T>(string key) where T : class
        {
            if (!users.ContainsKey(key))
            {
                Debug.Log("Wrong Id");
            }
            return users[key] as T;
        }
        public void setterCallAPI(bool callAPI)
        {
            _callAPI = callAPI;
        }
        public bool getterCallAPI()
        {
            return _callAPI;
        }
        
    }
}