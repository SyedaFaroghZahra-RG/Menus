using System;
using _Scripts.Controllers;
using _Scripts.Core;
using _Scripts.Services;
using _Scripts.StaticData;
using deVoid.UIFramework;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.ScreenControllers
{
    [Serializable]
    public class AllUsersWindowProperty : WindowProperties
    {
        private bool _callAPI;
        public AllUsersWindowProperty(bool callAPI)
        {
            _callAPI = callAPI;
        }
        public void setterCallAPI(bool callAPI)
        {
            _callAPI = callAPI;
        }

        public bool getterCallAPI()
        {
            return _callAPI;
        }
    }
    
    public class AllUsersWindowController : AWindowController<AllUsersWindowProperty>
    {
        //[SerializeField] private GameObject _parent;
        //[SerializeField] private GameObject _User;
        [SerializeField] private GameObject _grid;
        [SerializeField] private Button _backButton;
        
        private UserData u;
        private UserPool _userPool;
        
        private void  SetData()
        {
            if (ServiceLocator.Instance.GetService<IUserService>().isEmpty())
            {
                foreach (var t in u.results)
                {
                    var user = _userPool.GetUserFromPool(_grid.transform);
                    //var user = Instantiate(_User, _parent.transform);
                    user.GetComponent<UserDataController>().UserID = t.login.uuid;
                    ServiceLocator.Instance.GetService<IUserService>().SetUserData(t, t.login.uuid);
                }
            }
            else
            {
                
            }
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            _backButton.onClick.AddListener(HandleBackButton);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            _backButton.onClick.RemoveListener(HandleBackButton);
        }

        protected override void WhileHiding()
        {
            base.WhileHiding();
            Properties.setterCallAPI(false);
        }

        private void HandleBackButton()
        {
            UI_Close();
        }

        protected override void OnPropertiesSet()
        {
            base.OnPropertiesSet();
            _userPool = FindObjectOfType<UserPool>();
            if (Properties.getterCallAPI())
            {
                u = ServiceLocator.Instance.GetService<INetworkService>().GetData<UserData>(StaticDataAPIs.UserDataAPI);
                SetData();
            }
        }
    }
}
