using System.IO;
using System.Net;
using _Scripts.StaticData;
using UnityEngine;

namespace _Scripts.APICalls
{
    public static class GetUserData
    {
        public static string GetNewUser()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(StaticDataAPIs.UserDataAPI);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            UserData user = JsonUtility.FromJson<UserData>(json);
            return user.username;
        }
    }
}
