using _Scripts.Controllers;
using _Scripts.Core;
using _Scripts.ScreenControllers;
using _Scripts.Services;
using _Scripts.StaticData;
using deVoid.UIFramework;
using deVoid.Utils;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private UISettings _defaultUISettings;
    private UIFrame _uiFrame;
    private void Awake()
    {
        ServiceLocator.Instance.Register<IUserService>(new UserService());
        ServiceLocator.Instance.Register<IImageService>(new ImageService());
        ServiceLocator.Instance.Register<INetworkService>(new NetworkService());
        
        _uiFrame = _defaultUISettings.CreateUIInstance();
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
    
    private void AllUsersScreen(AllUsersWindowProperty callAPI)
    {
        _uiFrame.OpenWindow(ScreenIDs.AllUsersWindow, callAPI);
    }
}
