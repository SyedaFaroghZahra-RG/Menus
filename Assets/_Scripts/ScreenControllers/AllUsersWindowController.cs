using System;
using _Scripts.APICalls;
using deVoid.UIFramework;
using deVoid.Utils;
using TMPro;
using UnityEngine;

namespace _Scripts.ScreenControllers
{
    public class AllUsersWindowController : AWindowController
    {
        
        //[SerializeField] private GameObject _User;
        [SerializeField] private TextMeshProUGUI _userName;

        protected override void AddListeners()
        {
            base.AddListeners();
            Signals.Get<ViewAllUsersSignal>().AddListener(SetData);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            Signals.Get<ViewAllUsersSignal>().RemoveListener(SetData);
        }
        
        private void SetData()
        {
            _userName.text  = GetUserData.GetNewUser();
            /*for (int i = 0; i < 15; i++)
            {
                var u = Instantiate(_User);
                u.GetComponentInChildren<TextMeshProUGUI>().text = user.username;
            }*/
        }
    }
}
