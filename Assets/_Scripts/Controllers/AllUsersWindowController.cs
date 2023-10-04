using System.Collections.Generic;
using _Scripts.Core;
using _Scripts.Services;
using _Scripts.StaticData;
using deVoid.UIFramework;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Controllers
{
    public class AllUsersWindowController : AWindowController
    {
        [SerializeField] private GameObject _grid;
        [SerializeField] private Button _backButton;
        [SerializeField] private ScrollRect _scrollRect;
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
                if(!ServiceLocator.Instance.GetService<IUserService>().ContainsKey(t.login.uuid))
                    ServiceLocator.Instance.GetService<IUserService>().SetUserData(t, t.login.uuid);
                _allUsers.Add(user);
            }
        }

        protected override void OnPropertiesSet()
        {
            base.OnPropertiesSet();
            if (ServiceLocator.Instance.GetService<IUserService>().getterCallAPI())
            {
                _userPool = FindObjectOfType<UserPool>();
                u = ServiceLocator.Instance.GetService<INetworkService>().GetData<UserData>(StaticDataAPIs.UserDataAPI);
                _scrollRect.verticalNormalizedPosition = 1f;
                SetData();
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
            ServiceLocator.Instance.GetService<IUserService>().setterCallAPI(false);
        }

        private void HandleBackButton()
        {
            foreach (var u in _allUsers)
            {
                _userPool.ReturnUserToPool(u);
            }
            _allUsers.Clear();
            UI_Close();
        }
    }
}
