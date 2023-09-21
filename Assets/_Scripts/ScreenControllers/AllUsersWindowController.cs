using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.APICalls;
using deVoid.UIFramework;
using deVoid.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace _Scripts.ScreenControllers
{
    
    public class AllUsersWindowController : AWindowController
    {
        public UnityWebRequest.Result result;
        [SerializeField] private GameObject _parent;
        [SerializeField] private GameObject _User;
        private UserData u;
        private string _userName;
       
        protected override void Awake()
        {
            base.Awake();
            SetData();
        }

        private void SetData()
        { 
            u = GetUserData.GetNewUser();

            for (int i = 0; i < 30; i++)
            {
                _userName = u.users[i].username;
                var user = Instantiate(_User, _parent.transform);
                user.GetComponentInChildren<TextMeshProUGUI>().text = _userName;
                
            }
        }
    }
}
