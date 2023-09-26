using System.Collections;
using System.Collections.Generic;
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
        _thisButton = this.GetComponent<Button>();
        _thisButton.onClick.AddListener(UI_ViewDetails);
    }

    private void UI_ViewDetails()
    {
        Signals.Get<ViewUserDetailsSignal>().Dispatch(GetClickedUser());
    }
    private UserDetailsProperty GetClickedUser()
    {
        User user = GetComponentInParent<UserDataController>().user;
        Sprite userImage = GetComponentInParent<UserDataController>().isprite;
        UserDetailsProperty UserProps = new UserDetailsProperty(user, userImage);
        return UserProps;
    }
}
