using Autodesk.Revit.DB.Structure;
using EWinApp.Utils;
using System.Windows;

namespace EWinApp.Tools.Test.actions
{
    public partial class TestAction
    {
        private void RotateCopy(Rebar rb)
        {
            var axis = Line.CreateUnbound(_origin, _vtz);
            for (int i = 1; i < 120; i++)
            {
                var ids = ElementTransformUtils.CopyElement(_document, rb.Id, _vtx * 0);
                if (ids == null) continue;
                if (!ids.Any()) continue;
                _document.Regenerate();
                ElementTransformUtils.RotateElement(_document, ids.First(), axis, i * _angleRotate * Math.PI / 180);
                var rbC = _document.GetElement(ids.First()) as Rebar;
                if (rbC == null) continue;
                rbC.SetSolidRebar3DView(_document.ActiveView);
            }
        }
    }
}
