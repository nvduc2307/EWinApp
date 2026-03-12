using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB.Structure;
using EWinApp.Utils;

namespace EWinApp.Tools.Test.actions
{
    public partial class TestAction
    {
        public void InstallR6()
        {
            var rebarStyle = RebarStyle.Standard;
            RebarBarType rebarType = _rebarBarTypes.FirstOrDefault(x => x.Name == _diameterName);
            if (rebarType == null) return;

            var offsetZ = 3850.0.FromMillimeters();
            var posCenter = _origin.Add(_vtz.Negate() * offsetZ);

            double currentRadius = 3890.0.FromMillimeters();   // Vòng đầu tiên cách tâm 3890 mm
            double thresholdRadius = 7970.0.FromMillimeters(); // Mốc thay đổi khoảng cách rải

            // Cách mép ngoài 70mm lớp bảo vệ
            double maxRadius = _r1 - 70.0.FromMillimeters();

            XYZ xAxis = _vtx.Normalize();
            XYZ yAxis = _vtz.CrossProduct(xAxis).Normalize();

            while (currentRadius <= maxRadius)
            {
                double startAngle = 0.0;
                double endAngle = 2 * Math.PI - 1e-4;

                Arc circleArc = Arc.Create(posCenter, currentRadius, startAngle, endAngle, xAxis, yAxis);
                var newCurves = new List<Curve>() { circleArc };

                var rb = Rebar.CreateFromCurves(
                    _document,
                    rebarStyle,
                    rebarType,
                    null,
                    null,
                    _host,
                    _vtz,
                    newCurves,
                    RebarHookOrientation.Right,
                    RebarHookOrientation.Right,
                    true,
                    true);

                rb?.SetSolidRebar3DView(_document.ActiveView);

                // Nếu bán kính hiện tại >= mốc 7970 mm thì bước nhảy là 200mm, ngược lại là 120mm
                double currentSpacing = (currentRadius >= thresholdRadius)
                                        ? 200.0.FromMillimeters()
                                        : 120.0.FromMillimeters();

                currentRadius += currentSpacing;
            }
        }
    }
}
