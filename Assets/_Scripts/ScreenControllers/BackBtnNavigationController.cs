using deVoid.UIFramework;
using deVoid.Utils;

namespace _Scripts.ScreenControllers
{
    public class NavigateToPreviousScreenSignal : ASignal { }
    public class BackBtnNavigationController : APanelController
    {
        public void UI_Previous()
        {
            Signals.Get<NavigateToPreviousScreenSignal>().Dispatch();
        }
    }
}