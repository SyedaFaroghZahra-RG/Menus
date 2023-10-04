using _Scripts.Core;
using _Scripts.Services;
using deVoid.UIFramework;
using deVoid.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Controllers
{
    public class NavigateToAllUsersScreenSignal : ASignal { } 
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
            ServiceLocator.Instance.GetService<IUserService>().setterCallAPI(true);
            Signals.Get<NavigateToAllUsersScreenSignal>().Dispatch();
        }
    }
}