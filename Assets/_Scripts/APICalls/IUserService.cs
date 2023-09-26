namespace _Scripts.APICalls
{
    public interface IUserService
    {
        UserData GetUserData();
        public void SetUserData(User user, int key);
        public User AccessUserData(int key);
    }
}