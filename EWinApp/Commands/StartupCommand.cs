using Autodesk.Revit.Attributes;
using EWinApp.ViewModels;
using EWinApp.Views;
using Nice3point.Revit.Toolkit.External;

namespace EWinApp.Commands
{
    /// <summary>
    ///     External command entry point
    /// </summary>
    [UsedImplicitly]
    [Transaction(TransactionMode.Manual)]
    public class StartupCommand : ExternalCommand
    {
        public override void Execute()
        {
            var viewModel = new EWinAppViewModel();
            var view = new EWinAppView(viewModel);
            view.ShowDialog();
        }
    }
}