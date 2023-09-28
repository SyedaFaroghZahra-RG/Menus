using System;
using _Scripts.ScreenControllers;
using deVoid.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Buttons
{
    public class ViewAllUsersBtn : MonoBehaviour
    {
        private Button _thisButton;

        private void Start()
        {
            _thisButton = GetComponent<Button>();
            _thisButton.onClick.AddListener(UI_AllUsers);
        }
        private void UI_AllUsers()
        {
            Signals.Get<NavigateToAllUsersScreenSignal>().Dispatch();
        }
    }
}