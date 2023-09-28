using System.Collections.Generic;
using System.IO;
using System.Net;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Services
{
    public class UserService : IUserService
    {
        public T GetUserData<T>(string API)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            T users = JsonUtility.FromJson<T>(json);
            return users;
        }
        
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