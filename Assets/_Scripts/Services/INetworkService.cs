using RSG;

namespace _Scripts.Services
{
    public interface INetworkService 
    {
       public T GetData<T>(string API);
    }
}
