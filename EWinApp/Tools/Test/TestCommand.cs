using Autodesk.Revit.Attributes;
using EWinApp.Tools.Test.actions;
using EWinApp.Utils;
using Nice3point.Revit.Toolkit.External;

namespace EWinApp.Tools.Test
{
    [Transaction(TransactionMode.Manual)]
    public class TestCommand : ExternalCommand
    {
        public override void Execute()
        {

            using (var tsg = new TransactionGroup(Document, "new Command"))
            {
                tsg.Start();
                try
                {
                    var action = new TestAction(UiDocument);
                    action.Execute();
                    tsg.Assimilate();
                }
                catch (Autodesk.Revit.Exceptions.OperationCanceledException) { }
                catch (Exception ex)
                {
                    IO.ShowWarning(ex.Message);
                    tsg.RollBack();
                }
            }

        }
    }
}
