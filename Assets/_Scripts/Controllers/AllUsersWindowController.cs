using System;
using System.Collections.Generic;
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
        [SerializeField] private GameObject _grid;
        [SerializeField] private Button _backButton;
        
        private UserData u;
        private UserPool _userPool;
        private List<GameObject> _allUsers;
        private void  SetData()
        {
            _allUsers = new List<GameObject>();
             foreach (var t in u.results)
             {
                    var user = _userPool.GetUserFromPool(_grid.transform);
                    user.GetComponent<UserDataController>().UserID = t.login.uuid;
                    ServiceLocator.Instance.GetService<IUserService>().SetUserData(t, t.login.uuid);
                    _allUsers.Add(user);
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
            if (!ServiceLocator.Instance.GetService<IUserService>().ShouldCallAPIGetter())
            {
                foreach (var t in _allUsers)
                {
                    _userPool.ReturnUserToPool(t);
                }
                _allUsers.Clear();
            }
            ServiceLocator.Instance.GetService<IUserService>().ShouldCallAPISetter(true);
            base.WhileHiding();
        }
        
        
        private void HandleBackButton()
        {
            UI_Close();
        }

        protected override void OnPropertiesSet()
        {
            base.OnPropertiesSet();
            if (ServiceLocator.Instance.GetService<IUserService>().ShouldCallAPIGetter())
            {
                _userPool = FindObjectOfType<UserPool>();
                u = ServiceLocator.Instance.GetService<INetworkService>().GetData<UserData>(StaticDataAPIs.UserDataAPI);
                SetData();
            }
        }
    }
}
