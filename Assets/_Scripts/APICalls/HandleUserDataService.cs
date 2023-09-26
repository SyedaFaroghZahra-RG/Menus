using System.IO;
using System.Net;
using _Scripts.StaticData;
using UnityEngine;
namespace _Scripts.APICalls
{
    public class HandleUserDataService : IUserService
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
    }
}