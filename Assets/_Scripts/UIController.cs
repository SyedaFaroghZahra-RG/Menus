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
        
        
        _uiFrame = _defaultUISettings.CreateUIInstance();
        Signals.Get<ViewUserDetailsSignal>().AddListener(ViewUserDetails);
        Signals.Get<NavigateToPreviousScreenSignal>().AddListener(OnPreviousWindow);
    }

    private void Start()
    {
        _uiFrame.OpenWindow(ScreenIDs.AllUsersWindow);
    }

    private void ViewUserDetails(UserDetailsProperty userPayLoad)
    {
        _uiFrame.OpenWindow(ScreenIDs.UserDetailsWindow, userPayLoad);
        _uiFrame.ShowPanel(ScreenIDs.BackBtnNavigation);
    }
    private void OnPreviousWindow()
    {
        _uiFrame.CloseCurrentWindow();
        _uiFrame.HidePanel(ScreenIDs.BackBtnNavigation);
    }
}
