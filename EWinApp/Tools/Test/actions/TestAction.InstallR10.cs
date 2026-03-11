using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using EWinApp.Utils;

namespace EWinApp.Tools.Test.actions
{
    public partial class TestAction
    {
        public void InstallR10()
        {
            var rebarStyle = RebarStyle.Standard;
            RebarBarType rebarType = _rebarBarTypes.FirstOrDefault(x => x.Name == _diameterName);
            RebarHookType startHookType = null;
            RebarHookType endHookType = null;
            var vtNorm = _vty;
            var startHookOrien = RebarHookOrientation.Right;
            var EndHookOrien = RebarHookOrientation.Right;
            var center = _origin
                + _vtz * 100.0.FromMillimeters();
            var p1 = center
                + _vtx * _r2
                - _vtz * (50.0 + 2950).FromMillimeters();
            var p2 = p1 + _vtz * 2950.0.FromMillimeters();
            var p3 = center
                + _vtx * (_r3 + _r5);
            var p4 = p3 - _vtx * 100.0.FromMillimeters()
                - _vtz * 120.0.FromMillimeters();
            var p5 = p4 + (p4 - p3).Normalize() * 500.0.FromMillimeters();
            var ps = new List<XYZ>() { p1, p2, p3, p5 };
            var coverMm = _coverMm + _diameterMm / 2;
            var newCurves = ps.CreateCurves();
            newCurves = newCurves.OffSet(_vty, coverMm.FromMillimeters());
            if (rebarType == null) return;
            //_document.CreateCurves(newCurves);
            var rb = Rebar.CreateFromCurves(
                _document,
                rebarStyle,
                rebarType,
                startHookType,
                endHookType,
                _host,
                vtNorm,
                newCurves,
                startHookOrien,
                EndHookOrien,
                true,
                true);
            if (rb == null) return;
            rb.SetSolidRebar3DView(_document.ActiveView);
            var centerSub = center + _vtx * 2675.0.FromMillimeters();
            var ids = ElementTransformUtils.CopyElement(_document, rb.Id, _vtx * 0);
            ElementTransformUtils.RotateElement(_document, ids.First(), Line.CreateUnbound(centerSub, _vtz), Math.PI);
            var rbC = _document.GetElement(ids.First()) as Rebar;
            rbC.SetSolidRebar3DView(_document.ActiveView);
            //RotateCopy(rb);
            //RotateCopy(rbC);
        }
    }
}
