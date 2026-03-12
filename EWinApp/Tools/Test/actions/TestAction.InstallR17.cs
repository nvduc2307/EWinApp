using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using EWinApp.Utils;

namespace EWinApp.Tools.Test.actions
{
    public partial class TestAction
    {
        public void InstallR17a()
        {
            var rebarStyle = RebarStyle.Standard;
            RebarBarType rebarType = _rebarBarTypes.FirstOrDefault(x => x.Name == _diameterName);
            RebarHookType startHookType = null;
            RebarHookType endHookType = null;
            var vtNorm = _vty;
            var startHookOrien = RebarHookOrientation.Right;
            var EndHookOrien = RebarHookOrientation.Right;
            for (int i = 0; i < 5; i++)
            {
                var center = _origin
                    - _vtz * (55.0 - i * 10).FromMillimeters();
                var r = 1473.0 + i * 160;
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
            for (int i = 0; i < 5; i++)
            {
                var center = _origin
                    - _vtz * (15.0 + i * 10).FromMillimeters();
                var r = 3225.0 + i * 160;
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
            //RotateCopy(rb);
        }
        public void InstallR17b()
        {
            var rebarStyle = RebarStyle.Standard;
            RebarBarType rebarType = _rebarBarTypes.FirstOrDefault(x => x.Name == _diameterName);
            RebarHookType startHookType = null;
            RebarHookType endHookType = null;
            var vtNorm = _vty;
            var startHookOrien = RebarHookOrientation.Right;
            var EndHookOrien = RebarHookOrientation.Right;
            for (int i = 0; i < 8; i++)
            {
                var center = _origin
                    - _vtz * 130.0.FromMillimeters();
                var r = 1473.0 + i * 150;
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
            for (int i = 0; i < 8; i++)
            {
                var center = _origin
                    - _vtz * 130.0.FromMillimeters();
                var r = 2840.0 + i * 150;
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
            //RotateCopy(rb);
        }
        public void InstallR17c()
        {
            var rebarStyle = RebarStyle.Standard;
            RebarBarType rebarType = _rebarBarTypes.FirstOrDefault(x => x.Name == _diameterName);
            RebarHookType startHookType = null;
            RebarHookType endHookType = null;
            var vtNorm = _vty;
            var startHookOrien = RebarHookOrientation.Right;
            var EndHookOrien = RebarHookOrientation.Right;
            for (int i = 0; i < 8; i++)
            {
                var center = _origin
                    - _vtz * 200.0.FromMillimeters();
                var r = 1473.0 + i * 150;
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
            for (int i = 0; i < 8; i++)
            {
                var center = _origin
                    - _vtz * 200.0.FromMillimeters();
                var r = 2840.0 + i * 150;
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
            //RotateCopy(rb);
        }
        public void InstallR17d()
        {
            var rebarStyle = RebarStyle.Standard;
            RebarBarType rebarType = _rebarBarTypes.FirstOrDefault(x => x.Name == _diameterName);
            RebarHookType startHookType = null;
            RebarHookType endHookType = null;
            var vtNorm = _vty;
            var startHookOrien = RebarHookOrientation.Right;
            var EndHookOrien = RebarHookOrientation.Right;
            for (int i = 0; i < 8; i++)
            {
                var center = _origin
                    - _vtz * 270.0.FromMillimeters();
                var r = 1473.0 + i * 150;
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
            for (int i = 0; i < 8; i++)
            {
                var center = _origin
                    - _vtz * 270.0.FromMillimeters();
                var r = 2840.0 + i * 150;
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
            //RotateCopy(rb);
        }
    }
}
