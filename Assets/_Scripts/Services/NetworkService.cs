using System.IO;
using System.Net;
using System.Text.Json;
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
            T data = JsonSerializer.Deserialize<T>(json);
            return data;
        }
    }
}
