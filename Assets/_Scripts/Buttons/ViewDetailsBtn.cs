using System.Collections;
using System.Collections.Generic;
using _Scripts.APICalls;
using _Scripts.Core;
using _Scripts.ScreenControllers;
using deVoid.Utils;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
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
        int uid = GetComponentInParent<UserDataController>().UserID;
        User user = GetComponentInParent<UserDataController>().user;
       // Sprite userImage = GetComponentInParent<UserDataController>().isprite;
        Sprite userImage = ServiceLocator.Instance.GetService<IImageService>().GetImage(uid);
        UserDetailsProperty UserProps = new UserDetailsProperty(user, userImage);
        return UserProps;
    }
}
