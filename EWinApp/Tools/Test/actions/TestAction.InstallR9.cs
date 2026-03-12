using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using EWinApp.Utils;

namespace EWinApp.Tools.Test.actions
{
    public partial class TestAction
    {
        public void InstallR9()
        {
            var rebarStyle = RebarStyle.Standard;
            RebarBarType rebarType = _rebarBarTypes.FirstOrDefault(x => x.Name == _diameterName);
            RebarHookType startHookType = null;
            RebarHookType endHookType = null;
            var vtNorm = _vty;
            var startHookOrien = RebarHookOrientation.Right;
            var EndHookOrien = RebarHookOrientation.Right;
            var c = _origin
                    - _vtz * (_h1 + _h2 + _h3 + _h4 + _h5 - 100.0.FromMillimeters());
            for (int i = 0; i < 80; i++)
            {
                var center = c
                    + _vtz * (815.0 + i * 20).FromMillimeters();
                var r = 11870.0 - i * 100;
                var p1 = center + _vtx * r.FromMillimeters();
                var p2 = center + _vtx * r.FromMillimeters() + _vty * 1.0.FromMillimeters();
                var p3 = center - _vtx * r.FromMillimeters();
                var arc = Arc.Create(p1, p2, p3);
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
                    new List<Curve>() { arc },
                    startHookOrien,
                    EndHookOrien,
                    true,
                    true);
                if (rb == null) return;
                rb.SetSolidRebar3DView(_document.ActiveView);
            }
        }
    }
}
