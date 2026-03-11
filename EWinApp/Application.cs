using EWinApp.Commands;
using Nice3point.Revit.Toolkit.External;

namespace EWinApp
{
    /// <summary>
    ///     Application entry point
    /// </summary>
    [UsedImplicitly]
    public class Application : ExternalApplication
    {
        public override void OnStartup()
        {
            CreateRibbon();
        }

        private void CreateRibbon()
        {
            var panel = Application.CreatePanel("Commands", "EWinApp");

            panel.AddPushButton<StartupCommand>("Execute")
                .SetImage("/EWinApp;component/Resources/Icons/RibbonIcon16.png")
                .SetLargeImage("/EWinApp;component/Resources/Icons/RibbonIcon32.png");
        }
    }
}