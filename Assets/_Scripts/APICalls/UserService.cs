using System.Collections.Generic;
using System.IO;
using System.Net;
using _Scripts.StaticData;
using UnityEngine;

namespace _Scripts.APICalls
{
    public class UserService : IUserService
    {
        public UserData GetUserData()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(StaticDataAPIs.UserDataAPI);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            UserData users = JsonUtility.FromJson<UserData>(json);
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