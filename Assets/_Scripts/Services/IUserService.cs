namespace _Scripts.Services
{
    public interface IUserService
    {
        public void SetUserData<T>(T user, string key) where T : class;
        public T GetUserData<T>(string key) where T : class;
        public void setterCallAPI(bool callAPI);
        public bool getterCallAPI();
    }
}