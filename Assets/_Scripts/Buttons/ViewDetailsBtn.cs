using _Scripts.Controllers;
using _Scripts.Core;
using _Scripts.Services;
using deVoid.Utils;
using UnityEngine;
using UnityEngine.UI;

public class ViewDetailsBtn : MonoBehaviour
{
    private Button _thisButton;
    void Start()
    {
        _thisButton = GetComponent<Button>();
        _thisButton.onClick.AddListener(UI_ViewDetails);
    }

    private void UI_ViewDetails()
    {
        Signals.Get<ViewUserDetailsSignal>().Dispatch(GetClickedUser());
    }
    private UserDetailsProperty GetClickedUser()
    {
        string uid = GetComponentInParent<UserDataController>().UserID;
        Result user = ServiceLocator.Instance.GetService<IUserService>().GetUserData(uid);
        Sprite userImage = ServiceLocator.Instance.GetService<IImageService>().GetImage(user.picture.medium);
        UserDetailsProperty UserProps = new UserDetailsProperty(user, userImage);
        return UserProps;
    }
}
