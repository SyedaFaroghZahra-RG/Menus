using System;
using System.Collections;
using System.Collections.Generic;
using deVoid.UIFramework;
using deVoid.Utils;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private UISettings _defaultUISettings;
    private UIFrame _uiFrame;

    private void Awake()
    {
        _uiFrame = _defaultUISettings.CreateUIInstance();
        Signals.Get<ViewAllUsersSignal>().AddListener(OnViewAllUsers);
        Signals.Get<NavigateToPreviousScreenSignal>().AddListener(OnPreviousWindow);
    }

    private void Start()
    {
        _uiFrame.OpenWindow(ScreenIDs.StartWindow);
    }

    private void OnViewAllUsers()
    {
        _uiFrame.OpenWindow(ScreenIDs.AllUsersWindow);
        _uiFrame.ShowPanel(ScreenIDs.BackBtnNavigation);
    }
    private void OnPreviousWindow()
    {
        _uiFrame.CloseCurrentWindow();
        _uiFrame.HidePanel(ScreenIDs.BackBtnNavigation);
    }
}
