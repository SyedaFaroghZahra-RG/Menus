using _Scripts.Core;

namespace _Scripts.Services
{
    public interface IUserService
    {
        public T GetUserData<T>(string API);
        public void SetUserData(User user, int key);
        public User AccessUserData(int key);
    }
}