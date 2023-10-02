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
    public class AllUsersWindowController : AWindowController
    {
        [SerializeField] private GameObject _parent;
        [SerializeField] private GameObject _User;
        [SerializeField] private Button _backButton;
        
        private UserData u;
        
        private void  SetData()
        {
            foreach (var t in u.results)
            {
                var user = Instantiate(_User, _parent.transform);
                user.GetComponent<UserDataController>().UserID = t.id.value;
                ServiceLocator.Instance.GetService<IUserService>().SetUserData(t, t.id.value);
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

        private void HandleBackButton()
        {
            UI_Close();
        }

        protected override void OnPropertiesSet()
        {
            base.OnPropertiesSet();
            u = ServiceLocator.Instance.GetService<INetworkService>().GetData<UserData>(StaticDataAPIs.UserDataAPI);
            SetData();
        }
    }
}
