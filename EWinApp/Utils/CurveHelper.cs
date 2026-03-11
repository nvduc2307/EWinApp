namespace EWinApp.Utils
{
    public static class CurveHelper
    {
        public static XYZ Direction(this Curve c)
        {
            return (c.GetEndPoint(0) - c.GetEndPoint(1)).Normalize();
        }
        public static XYZ Direction(this Line l)
        {
            return (l.GetEndPoint(0) - l.GetEndPoint(1)).Normalize();
        }
        public static XYZ Mid(this Curve c)
        {
            return (c.GetEndPoint(0) + c.GetEndPoint(1)) * 0.5;
        }
        public static XYZ Mid(this Line l)
        {
            return (l.GetEndPoint(0) + l.GetEndPoint(1)) * 0.5;
        }
        public static List<Curve> CreateCurves(this List<XYZ> ps, bool isClose = false)
        {
            var result = new List<Curve>();
            if (ps == null) return result;
            var c = ps.Count;
            if (c < 2) return result;
            for (int i = 0; i < c; i++)
            {
                var j = i == 0 ? c - 1 : i - 1;
                if (!isClose && i == 0) continue;
                result.Add(Line.CreateBound(ps[j], ps[i]));
            }
            return result;
        }
        public static List<Curve> OffSet(this List<Curve> curves, XYZ dir, double offsetValue)
        {
            // curves phải là những line liên tiếp nhau.
            var result = new List<Curve>();
            var resultCheck = new List<Curve>();
            foreach (var item in curves)
            {
                var c = item.CreateOffset(offsetValue, dir);
                resultCheck.Add(c);
            }
            if (resultCheck.Any())
            {
                var ps = new List<XYZ>();
                var c = resultCheck.Count;
                if (c < 2) return curves;
                for (int i = 0; i < c; i++)
                {
                    if (i == 0) continue;
                    var j = i - 1;
                    var normal2 = resultCheck[i].Direction().CrossProduct(dir);
                    var plane = Plane.CreateByNormalAndOrigin(normal2, resultCheck[i].Mid());
                    var intersect = resultCheck[j].Mid().RayIntersectPlane(resultCheck[j].Direction(), plane);
                    if (intersect == null) continue;
                    ps.Add(intersect);
                }
                if (ps.Any())
                {
                    ps.Insert(0, resultCheck.First().GetEndPoint(0));
                    ps.Add(resultCheck.Last().GetEndPoint(1));
                    result = ps.CreateCurves();
                }
            }
            return result.Any() ? result : curves;
        }
        public static void CreateCurves(this Document document, List<Curve> curves)
        {
            foreach (var l in curves)
            {
                try
                {
                    var nor = l.Direction().IsParallel(XYZ.BasisZ) ? l.Direction().CrossProduct(XYZ.BasisX) : l.Direction().CrossProduct(XYZ.BasisZ);
                    var plane = Plane.CreateByNormalAndOrigin(nor, l.Mid());
                    var sket = SketchPlane.Create(document, plane);

                    document.Create.NewModelCurve(l, sket);
                }
                catch (Exception)
                {
                }
            }
        }
        public static void CreateCurves(this Document document, Curve curve)
        {
            try
            {
                var nor = curve.Direction().IsParallel(XYZ.BasisZ) ? curve.Direction().CrossProduct(XYZ.BasisX) : curve.Direction().CrossProduct(XYZ.BasisZ);
                var plane = Plane.CreateByNormalAndOrigin(nor, curve.Mid());
                var sket = SketchPlane.Create(document, plane);

                document.Create.NewModelCurve(curve, sket);
            }
            catch (Exception)
            {
            }
        }
    }
}
