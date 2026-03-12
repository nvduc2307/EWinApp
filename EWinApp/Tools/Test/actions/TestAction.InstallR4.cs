using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using EWinApp.Utils;

namespace EWinApp.Tools.Test.actions
{
    public partial class TestAction
    {
        public void InstallR4a()
        {
            var rebarStyle = RebarStyle.Standard;
            RebarBarType rebarType = _rebarBarTypes.FirstOrDefault(x => x.Name == _diameterName);
            RebarHookType startHookType = null;
            RebarHookType endHookType = null;
            var vtNorm = _vty;
            var startHookOrien = RebarHookOrientation.Right;
            var EndHookOrien = RebarHookOrientation.Right;
            var center = _origin
                - _vtz * (_h2 + _h3 + _h4 + _h5 - 100.0.FromMillimeters());
            var p1 = center
                + _vtx * (_r1 - 550.0.FromMillimeters());
            var p2 = center
                + _vtx * _r1;
            var p3 = p2
                + _vtz * _h2;
            var p4 = p3 + _vtz * _h3
                - _vtx * (_r1 - _r2);
            var vt = (p4 - p3).Normalize();
            var nor = vt.CrossProduct(_vty);
            var p5 = p4 + vt * 1000.0.FromMillimeters();
            var coverMm = _coverMm + _diameterMm / 2;
            var ps = new List<XYZ>() { p3 + vt * coverMm.FromMillimeters() + nor * coverMm.FromMillimeters(), p5 + nor * coverMm.FromMillimeters() };
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
        public void InstallR4b()
        {
            var rebarStyle = RebarStyle.Standard;
            RebarBarType rebarType = _rebarBarTypes.FirstOrDefault(x => x.Name == _diameterName);
            RebarHookType startHookType = null;
            RebarHookType endHookType = null;
            var vtNorm = _vty;
            var startHookOrien = RebarHookOrientation.Right;
            var EndHookOrien = RebarHookOrientation.Right;
            var center = _origin
                - _vtz * (_h2 + _h3 + _h4 + _h5 - 100.0.FromMillimeters());
            var p1 = center
                + _vtx * (_r1 - 550.0.FromMillimeters());
            var p2 = center
                + _vtx * _r1;
            var p3 = p2
                + _vtz * _h2;
            var p4 = p3 + _vtz * _h3
                - _vtx * (_r1 - _r2);
            var vt = (p4 - p3).Normalize();
            var nor = vt.CrossProduct(_vty);
            var p5 = p4 + vt * 1000.0.FromMillimeters();
            var coverMm = _coverMm + _diameterMm / 2;
            var ps = new List<XYZ>() 
            { p3 + vt * 2000.0.FromMillimeters() 
            + nor * (coverMm.FromMillimeters() + 55.0.FromMillimeters()), 
            p5 + nor * (coverMm.FromMillimeters() + 55.0.FromMillimeters())};
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
