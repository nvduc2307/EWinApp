namespace EWinApp.Tools.Test.actions
{
    public partial class TestAction
    {
        private bool _selectionFilter(Element element)
        {
            if (element is not FamilyInstance f) return false;
            if (f.Symbol.FamilyName == _fName) return true;
            return false;
        }
    }
}
