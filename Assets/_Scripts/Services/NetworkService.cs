using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace _Scripts.Services
{
    public class NetworkService : INetworkService
    {
        public T GetData<T>(string API)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            T data = JsonConvert.DeserializeObject<T>(json);
            return data;
        }
    }
}
