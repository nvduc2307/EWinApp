namespace EWinApp.Utils
{
    public static class GeometryHelper
    {
        public static bool IsParallel(this XYZ vt1, XYZ vt2)
        {
            return Math.Abs(vt1.DotProduct(vt2)).IsAlmostEqual(1);
        }
        public static XYZ RayIntersectPlane(this XYZ point, XYZ vecRay, Plane plane)
        {
            XYZ p = null;
            var ori = plane.Origin;
            var normal = plane.Normal.Normalize();
            if (vecRay.DotProduct(normal) != 0)
            {
                var dist = (ori - point).DotProduct(normal) / (vecRay.DotProduct(normal));
                p = point.Add(dist * vecRay.Normalize());
            }
            return p;
        }
    }
}
