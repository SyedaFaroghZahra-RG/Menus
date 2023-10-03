using System;
using _Scripts.ScreenControllers;
using deVoid.UIFramework;
using deVoid.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Controllers
{
    public class NavigateToAllUsersScreenSignal : ASignal<AllUsersWindowProperty> { } 
    public class StartScreenController : AWindowController
    {

        [SerializeField] private Button AllUsersButton;

        protected override void AddListeners()
        {
            base.AddListeners();
            
            AllUsersButton.onClick.AddListener(HandleAllUsersButton);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            
            AllUsersButton.onClick.RemoveListener(HandleAllUsersButton);
        }
        
        private void HandleAllUsersButton()
        {
            Signals.Get<NavigateToAllUsersScreenSignal>().Dispatch(ShouldCallAPI());
        }

        private AllUsersWindowProperty ShouldCallAPI()
        {
            AllUsersWindowProperty property = new AllUsersWindowProperty(true);
            return property;
        }
    }
}