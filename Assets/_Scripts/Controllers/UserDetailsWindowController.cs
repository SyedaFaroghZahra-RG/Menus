using System;
using _Scripts.Core;
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
        this._userImage = _userImage;
    }
}
public class UserDetailsWindowController : AWindowController<UserDetailsProperty>
{
    [SerializeField] private TextMeshProUGUI _userNameTitle;
    [SerializeField] private Image _userImage;
    [SerializeField] private TextMeshProUGUI _firstName;
    [SerializeField] private TextMeshProUGUI _lastName;
    [SerializeField] private TextMeshProUGUI _height;
    [SerializeField] private TextMeshProUGUI _weight;
    [SerializeField] private TextMeshProUGUI _eyecolor;
    [SerializeField] private TextMeshProUGUI _bloodgroup;
    protected override void OnPropertiesSet()
    {
        _userNameTitle.text = Properties._user.username;
        _userImage.sprite = Properties._userImage;
        _firstName.text = Properties._user.firstName;
        _lastName.text = Properties._user.lastName;
        _height.text = Properties._user.height.ToString();
        _weight.text = Properties._user.weight.ToString();
        _eyecolor.text = Properties._user.eyeColor;
        _bloodgroup.text = Properties._user.bloodGroup;
    }
}
