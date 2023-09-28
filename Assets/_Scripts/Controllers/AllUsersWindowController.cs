using _Scripts.Core;
using _Scripts.Services;
using _Scripts.StaticData;
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
            u = ServiceLocator.Instance.GetService<INetworkService>().GetData<UserData>(StaticDataAPIs.UserDataAPI);
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
