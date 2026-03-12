using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using EWinApp.Utils;

namespace EWinApp.Tools.Test.actions
{
    public partial class TestAction
    {
        public void InstallR3a()
        {
            var rebarStyle = RebarStyle.Standard;
            RebarBarType rebarType = _rebarBarTypes.FirstOrDefault(x => x.Name == _diameterName);
            RebarHookType startHookType = null;
            RebarHookType endHookType = null;
            var vtNorm = _vty;
            var startHookOrien = RebarHookOrientation.Right;
            var EndHookOrien = RebarHookOrientation.Right;
            var coverMm = _coverMm + _diameterMm / 2;
            var center = _origin
                - _vtz * (_h2 + _h3 + _h4 + _h5 - 100.0.FromMillimeters());
            var p1 = center
                + _vtz * (coverMm.FromMillimeters() + 110.0.FromMillimeters())
                + _vtx * (_r1 - 7100.0.FromMillimeters());
            var p2 = center
                + _vtz * (coverMm.FromMillimeters() + 110.0.FromMillimeters())
                + _vtx * 1450.0.FromMillimeters();
            var ps = new List<XYZ>() { p1, p2 };
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
