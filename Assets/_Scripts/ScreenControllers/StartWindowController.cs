using deVoid.UIFramework;
using deVoid.Utils;

namespace _Scripts.ScreenControllers
{
    public class ViewAllUsersSignal : ASignal{}
    public class StartWindowController : AWindowController
    {
        public void UI_StartBtnViewAll()
        {
            Signals.Get<ViewAllUsersSignal>().Dispatch();
        }
    }
}