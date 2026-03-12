using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using EWinApp.Utils;
using EWinApp.Utils.Warnings;

namespace EWinApp.Tools.Test.actions
{
    public partial class TestAction
    {
        private const string _diameterName = "D25";
        private const string _fName = "FMRK";
        private const double _diameterMm = 25;
        private const double _coverMm = 70;
        private const int _angleRotate = 3;
        private Document _document;
        private UIDocument _uiDocument;
        private double _r1;
        private double _r2;
        private double _r3;
        private double _r4;
        private double _r5;

        private double _h1;
        private double _h2;
        private double _h3;
        private double _h4;
        private double _h5;

        private FamilyInstance _f;
        private XYZ _vtx;
        private XYZ _vty;
        private XYZ _vtz;
        private XYZ _origin;
        private Element _host;

        private List<RebarBarType> _rebarBarTypes;
        public TestAction(UIDocument uiDocument)
        {
            _uiDocument = uiDocument;
            _document = _uiDocument.Document;
            _f = GetElement();
            if (_f == null) return;
            GetGeometries(_f);
            _rebarBarTypes = new FilteredElementCollector(_document)
                .WhereElementIsElementType()
                .OfClass(typeof(RebarBarType))
                .Cast<RebarBarType>()
                .OrderBy(x => x.get_Parameter(BuiltInParameter.REBAR_BAR_DIAMETER).AsDouble())
                .ToList();
        }
        public void Execute()
        {
            CreateHost();

            using (var ts = new Transaction(_document, "create rebar"))
            {
                ts.SkipAllWarnings();
                ts.Start();
                //InstallR1a();
                //InstallR1b();
                InstallR10();
                InstallR11();
                InstallR12();
                InstallR13();
                InstallR14();
                InstallR15();
                InstallR16();
                ts.Commit();
            }

        }
        public void CreateHost()
        {

            using (var ts = new Transaction(_document, "create new host"))
            {
                ts.Start();
                _host = _document.CreateRebarHost();
                _document.Regenerate();
                ts.Commit();
            }
        }
    }
}
