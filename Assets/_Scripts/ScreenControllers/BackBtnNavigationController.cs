using System.Collections;
using System.Collections.Generic;
using deVoid.UIFramework;
using deVoid.Utils;
using UnityEngine;


public class NavigateToPreviousScreenSignal : ASignal { }
public class BackBtnNavigationController : APanelController
{
    public void UI_Previous()
    {
        Signals.Get<NavigateToPreviousScreenSignal>().Dispatch();
    }
}
