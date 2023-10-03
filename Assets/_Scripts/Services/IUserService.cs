using _Scripts.Core;

namespace _Scripts.Services
{
    public interface IUserService
    {
        public void SetUserData(Result user, string key);
        public Result GetUserData(string key);
        public bool ShouldCallAPIGetter();
        public void ShouldCallAPISetter(bool call);
    }
}