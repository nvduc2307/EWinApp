using Autodesk.Revit.DB;
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
            RebarBarType rebarType = _rebarBarTypes.FirstOrDefault(x => x.Name == _diameterName);
            RebarHookType startHookType = null;
            RebarHookType endHookType = null;
            var vtNorm = _vtz;
            var startHookOrien = RebarHookOrientation.Right;
            var endHookOrien = RebarHookOrientation.Right;

            if (rebarType == null) return;

            var offsetZ = 3850.0.FromMillimeters();
            var posCenter = _origin.Add(_vtz.Negate() * offsetZ);

            double offsetFromCenter = 2850.0.FromMillimeters();
            var radius = _r1;
            if (offsetFromCenter >= radius) return;

            double stepAngleInRadians = _angleRotate * Math.PI / 180.0;
            double maxAngle = 2 * Math.PI;
            double currentAngle = 0.0;

            while (currentAngle < maxAngle - 1e-6)
            {
                Transform rotation = Transform.CreateRotation(_vtz, currentAngle);
                XYZ currentDirection = rotation.OfVector(_vtx).Normalize();
                XYZ p1 = posCenter + currentDirection * offsetFromCenter;
                XYZ p2 = (posCenter + currentDirection * _r1).Add(currentDirection * -50.0.FromMillimeters());

                if (p1.DistanceTo(p2) > 0.01)
                {
                    var newCurves = new List<Curve>() { Line.CreateBound(p1, p2) };

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
                        endHookOrien,
                        true,
                        true);

                    rb?.SetSolidRebar3DView(_document.ActiveView);
                }
                currentAngle += stepAngleInRadians;
            }
        }
        public void InstallR1b()
        {
            var rebarStyle = RebarStyle.Standard;
            RebarBarType rebarType = _rebarBarTypes.FirstOrDefault(x => x.Name == _diameterName);
            RebarHookType startHookType = null;
            RebarHookType endHookType = null;
            var vtNorm = _vtz;
            var startHookOrien = RebarHookOrientation.Right;
            var endHookOrien = RebarHookOrientation.Right;

            if (rebarType == null) return;

            var offsetZ = 3850.0.FromMillimeters();
            var posCenter = _origin.Add(_vtz.Negate() * offsetZ);

            double offsetFromCenter = 2850.0.FromMillimeters();
            var radius = _r1;
            if (offsetFromCenter >= radius) return;

            double stepAngleInRadians = _angleRotate * Math.PI / 180.0;
            double maxAngle = 2 * Math.PI;

            // Khởi tạo góc bắt đầu bằng một nửa bước góc của R1a
            double currentAngle = stepAngleInRadians / 2.0;

            while (currentAngle < maxAngle - 1e-6)
            {
                Transform rotation = Transform.CreateRotation(_vtz, currentAngle);
                XYZ currentDirection = rotation.OfVector(_vtx).Normalize();
                XYZ p1 = posCenter + currentDirection * offsetFromCenter;
                XYZ p2 = (posCenter + currentDirection * _r1).Add(currentDirection * -50.0.FromMillimeters());

                if (p1.DistanceTo(p2) > 0.01)
                {
                    var newCurves = new List<Curve>() { Line.CreateBound(p1, p2) };

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
                        endHookOrien,
                        true,
                        true);

                    rb?.SetSolidRebar3DView(_document.ActiveView);
                }

                currentAngle += stepAngleInRadians;
            }
        }
    }
}
