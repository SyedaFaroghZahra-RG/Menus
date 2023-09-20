using System.Collections;
using System.Collections.Generic;
using deVoid.UIFramework;
using deVoid.Utils;
using UnityEngine;

public class ViewAllUsersSignal : ASignal{}
public class StartWindowController : AWindowController
{
    public void UI_StartBtnViewAll()
    {
        Signals.Get<ViewAllUsersSignal>().Dispatch();
    }
}
