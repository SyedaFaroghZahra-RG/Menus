using _Scripts.Core;

namespace _Scripts.Services
{
    public interface IUserService
    {
        public void SetUserData(User user, int key);
        public User AccessUserData(int key);
    }
}