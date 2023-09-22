using System;
using System.Collections;
using System.Collections.Generic;
using deVoid.UIFramework;
using deVoid.Utils;
using UnityEngine;

public class ViewUserDetailsSignal : ASignal<UserDetailsProperty> { }

[Serializable]
public class UserDetailsProperty : WindowProperties
{
    public readonly User _User;
    public UserDetailsProperty(User user)
    {
        _User = user;
    }
}
public class UserDetailsWindowController : AWindowController<UserDetailsProperty>
{
    protected override void OnPropertiesSet()
    {
        Debug.Log(Properties._User.username);
    }
    
    
}
