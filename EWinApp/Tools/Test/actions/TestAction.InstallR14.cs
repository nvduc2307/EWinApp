using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using EWinApp.Utils;

namespace EWinApp.Tools.Test.actions
{
    public partial class TestAction
    {
        public void InstallR14()
        {
            var rebarStyle = RebarStyle.Standard;
            RebarBarType rebarType = _rebarBarTypes.FirstOrDefault(x => x.Name == _diameterName);
            RebarHookType startHookType = null;
            RebarHookType endHookType = null;
            var vtNorm = _vty;
            var startHookOrien = RebarHookOrientation.Right;
            var EndHookOrien = RebarHookOrientation.Right;
            var center = _origin
                - _vtz * 220.0.FromMillimeters();
            var p1 = center
                + _vtx * _r2
                - _vtz * 400.0.FromMillimeters();
            var p0 = p1 - _vtx * 1325.0.FromMillimeters();
            var p2 = p1 + _vtz * 400.0.FromMillimeters();
            var p3 = p2
                - _vtx * 2650.0.FromMillimeters();
            var p4 = p3 - _vtz * 400.0.FromMillimeters();
            var p5 = p4 + _vtx * 1325.0.FromMillimeters();
            var ps = new List<XYZ>() { p0, p1, p2, p3, p4, p5 };
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
            RotateCopy(rb);
        }
    }
}
