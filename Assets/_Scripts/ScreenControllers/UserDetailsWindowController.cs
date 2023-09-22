using System;
using System.Collections;
using System.Collections.Generic;
using deVoid.UIFramework;
using deVoid.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewUserDetailsSignal : ASignal<UserDetailsProperty> { }

[Serializable]
public class UserDetailsProperty : WindowProperties
{
    public readonly User _user;
    public readonly Sprite _userImage;
    public UserDetailsProperty(User user, Sprite _userImage)
    {
        _user = user;
    }
}
public class UserDetailsWindowController : AWindowController<UserDetailsProperty>
{
    [SerializeField] private TextMeshProUGUI _userNameTitle;
    [SerializeField] private Image _userImage;
    protected override void OnPropertiesSet()
    {
        _userNameTitle.text = Properties._user.username;
        _userImage.sprite = Properties._userImage;
    }
}
