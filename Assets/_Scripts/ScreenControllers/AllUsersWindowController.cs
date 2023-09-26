using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Scripts.APICalls;
using deVoid.UIFramework;
using deVoid.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

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
            u = ServiceLocator.ServiceLocator.Instance.GetIGameService().GetUserData();
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
