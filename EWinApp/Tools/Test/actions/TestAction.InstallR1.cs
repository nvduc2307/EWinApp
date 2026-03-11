using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using EWinApp.Utils;

namespace EWinApp.Tools.Test.actions
{
    public partial class TestAction
    {
        private const double _dR1 = 28; // mm
        private const double _aR1 = 3; // deg
        public void InstallR1a()
        {
            var rebarStyle = RebarStyle.Standard;
            RebarBarType rebarType = _rebarBarTypes.LastOrDefault();
            RebarHookType startHookType = null;
            RebarHookType endHookType = null;
            var vtNorm = _vtz;
            var startHookOrien = RebarHookOrientation.Right;
            var EndHookOrien = RebarHookOrientation.Right;
            var newCurves = new List<Curve>() { Line.CreateBound(_origin, _origin + _vtx * 10000.0.FromMillimeters())};

            if (rebarType == null) return;

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
        }
        public void InstallR1b()
        {

        }
    }
}
