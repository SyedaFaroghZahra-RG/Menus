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
    [SerializeField] private Button _thisButton;

    public int buttonId { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        _thisButton.onClick.AddListener(UI_ViewDetails);
    }

    private void UI_ViewDetails()
    {
        Signals.Get<ViewUserDetailsSignal>().Dispatch(GetClickedUser());
    }
    private UserDetailsProperty GetClickedUser()
    {
        User user = GetComponentInParent<UserForPrefab>().user;
        Sprite userImage = GetComponentInParent<UserForPrefab>()._ProfilePic;
        UserDetailsProperty UserProps = new UserDetailsProperty(user, userImage);
        return UserProps;
    }
}
