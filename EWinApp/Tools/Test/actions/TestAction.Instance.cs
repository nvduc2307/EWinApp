using Autodesk.Revit.UI;
using EWinApp.Utils.SelectFilters;
using System.Diagnostics;

namespace EWinApp.Tools.Test.actions
{
    public partial class TestAction
    {
        private FamilyInstance GetElement()
        {
            var ele = _uiDocument.Selection.PickElement(_document, null, _selectionFilter);
            if (ele is not FamilyInstance f) return null;
            if(f.Symbol.FamilyName != _fName) return null;
            return f;
        }

        private void GetGeometries(FamilyInstance familyInstance)
        {
            _r1 = familyInstance.Symbol.LookupParameter("R1").AsDouble();
            _r2 = familyInstance.Symbol.LookupParameter("R2").AsDouble();
            _r3 = familyInstance.Symbol.LookupParameter("R3").AsDouble();
            _r4 = familyInstance.Symbol.LookupParameter("R4").AsDouble();
            _r5 = familyInstance.Symbol.LookupParameter("R5").AsDouble();

            _h1 = familyInstance.Symbol.LookupParameter("H1").AsDouble();
            _h2 = familyInstance.Symbol.LookupParameter("H2").AsDouble();
            _h3 = familyInstance.Symbol.LookupParameter("H3").AsDouble();
            _h4 = familyInstance.Symbol.LookupParameter("H4").AsDouble();
            _h5 = familyInstance.Symbol.LookupParameter("H5").AsDouble();

            var ts = familyInstance.GetTransform();
            _vtx = ts.BasisX;
            _vty = ts.BasisY;
            _vtz = ts.BasisZ;
            _origin = ts.Origin;
        }
    }
}
