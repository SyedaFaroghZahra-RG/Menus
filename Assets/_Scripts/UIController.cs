using _Scripts.Controllers;
using _Scripts.Core;
using _Scripts.Services;
using _Scripts.StaticData;
using deVoid.UIFramework;
using deVoid.Utils;
using UnityEngine;


//Main Entry point of code
public class UIController : MonoBehaviour
{
    [SerializeField] private UISettings _defaultUISettings;
    private UIFrame _uiFrame;
    private void Awake()
    {
        //Register Service Locator's here (can also make a separate bootstrap object)
        ServiceLocator.Instance.Register<IUserService>(new UserService());
        ServiceLocator.Instance.Register<IImageService>(new ImageService());
        ServiceLocator.Instance.Register<INetworkService>(new NetworkService());
        
        _uiFrame = _defaultUISettings.CreateUIInstance();
        
        //Listeners of Signals
        Signals.Get<ViewUserDetailsSignal>().AddListener(ViewUserDetails);
        Signals.Get<NavigateToAllUsersScreenSignal>().AddListener(AllUsersScreen);
    }

    private void Start()
    {
        _uiFrame.OpenWindow(ScreenIDs.StartWindow);
    }

    private void ViewUserDetails(UserDetailsProperty userPayLoad)
    {
        _uiFrame.OpenWindow(ScreenIDs.UserDetailsWindow, userPayLoad);
    }
    
    private void AllUsersScreen()
    {
        _uiFrame.OpenWindow(ScreenIDs.AllUsersWindow);
    }
}
