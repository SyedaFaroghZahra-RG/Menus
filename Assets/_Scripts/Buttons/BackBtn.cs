using _Scripts.ScreenControllers;
using deVoid.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Buttons
{
    public class BackBtn : MonoBehaviour
    {
        private Button _thisButton;

        private void Start()
        {
            _thisButton = this.GetComponent<Button>();
            _thisButton.onClick.AddListener(UI_Previous);
        }
        private void UI_Previous()
        {
            Signals.Get<NavigateToPreviousScreenSignal>().Dispatch();
        }
    }
}