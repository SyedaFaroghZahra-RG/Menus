using System.Collections.Generic;
using _Scripts.Core;
using _Scripts.Services;
using _Scripts.StaticData;
using deVoid.UIFramework;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Controllers
{
    //All users window contains a scrollable list of Users(prefab) and a back button to go back to start window
    public class AllUsersWindowController : AWindowController
    {
        [SerializeField] private GameObject _grid;
        [SerializeField] private Button _backButton;
        [SerializeField] private ScrollRect _scrollRect;
        
        private UserData u;
        private UserPool _userPool;
        private List<GameObject> _allUsers;
        
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
        protected override void OnPropertiesSet()
        {
            base.OnPropertiesSet();
            //checking if we came to this window from start window
            if (ServiceLocator.Instance.GetService<IUserService>().getterCallAPI())
            {
                _userPool = FindObjectOfType<UserPool>();
                
                //call api and get data in UserData object
                u = ServiceLocator.Instance.GetService<INetworkService>().GetData<UserData>(StaticDataAPIs.UserDataAPI);
                
                //Set the scroll rect position to top
                _scrollRect.verticalNormalizedPosition = 1f;
                
                SetData();
            }
        }
        private void  SetData()
        {
            _allUsers = new List<GameObject>();
            //iterate over all users(results) in User Data object
            foreach (var t in u.results)
            {
                //get instantiated user object from pool
                var user = _userPool.GetUserFromPool(_grid.transform);
                //set ID of that particular user
                user.GetComponent<UserDataController>().UserID = t.login.uuid;
                //if this user have not appeared before set its data in a in memory dictionary
                if(!ServiceLocator.Instance.GetService<IUserService>().ContainsKey(t.login.uuid))
                    ServiceLocator.Instance.GetService<IUserService>().SetUserData(t, t.login.uuid);
                //add user game object in a list for later cleanup
                _allUsers.Add(user);
            }
        }
        private void HandleBackButton()
        {
            //when back button is clicked put all user game objects back in pool
            foreach (var u in _allUsers)
            {
                _userPool.ReturnUserToPool(u);
            }
            _allUsers.Clear();
            UI_Close();
        }
        protected override void WhileHiding()
        {
            base.WhileHiding();
            //to make sure api is not called from a window other than start set it to false
            ServiceLocator.Instance.GetService<IUserService>().setterCallAPI(false);
        }
        
    }
}
