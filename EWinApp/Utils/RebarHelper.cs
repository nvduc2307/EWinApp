using Autodesk.Revit.DB.Structure;

namespace EWinApp.Utils
{
    public static class RebarHelper
    {
        public static Element CreateRebarHost(
        this Document document, 
        BuiltInCategory builtInCategory = BuiltInCategory.OST_StructuralFoundation)
        {
            return DirectShape.CreateElement(document, new ElementId(builtInCategory));
        }
        public static void SetSolidRebar3DView(this Rebar rebar, View view)
        {
            if (view is View3D view3d)
            {
                if (rebar != null)
                {
#if REVIT2021 || REVIT2022
                    rebar.SetSolidInView(view3d, true);
#endif
                    rebar.SetUnobscuredInView(view3d, true);
                }
            }
        }
    }
}
