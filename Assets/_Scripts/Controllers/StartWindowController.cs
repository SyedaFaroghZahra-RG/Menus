using _Scripts.Core;
using _Scripts.Services;
using deVoid.UIFramework;
using deVoid.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Controllers
{
    public class NavigateToAllUsersScreenSignal : ASignal { } 
    
    //First Window to open. Contains a single button to view all users
    public class StartWindowController : AWindowController
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
            //API should be called only when view all users button of start window is clicked; Setting that going to all users screen from start.
            ServiceLocator.Instance.GetService<IUserService>().setterCallAPI(true);
            Signals.Get<NavigateToAllUsersScreenSignal>().Dispatch();
        }
    }
}