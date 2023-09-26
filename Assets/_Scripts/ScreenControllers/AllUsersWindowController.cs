using _Scripts.APICalls;
using _Scripts.Core;
using deVoid.UIFramework;
using UnityEngine;

namespace _Scripts.ScreenControllers
{
    public class AllUsersWindowController : AWindowController
    {
        [SerializeField] private GameObject _parent;
        [SerializeField] private GameObject _User;
        private UserData u;

        protected override void Awake()
        {
            base.Awake();
            u = ServiceLocator.Instance.GetService<IUserService>().GetUserData();
            SetData();
        }
        
        private void  SetData()
        {
            foreach (var t in u.users)
            {
                var user = Instantiate(_User, _parent.transform);
                user.GetComponent<UserDataController>().SetUserData(t);
            }
        }
    }
}
