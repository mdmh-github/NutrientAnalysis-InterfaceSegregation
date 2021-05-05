using BadNutrientAnalysisLib.Analyzers;
using BadNutrientAnalysisLib.Reports;
using BadNutrientAnalysisLib.Repository;
using System;
using System.Linq;

namespace NutrientAnalysisInterfaceSegregation
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("What are you going to Analyze?");
            var values = Enum.GetValues(typeof(AnalyzableObject)).Cast<AnalyzableObject>();


            foreach (var analyzableObject in values)
            {
                var analyzableObjectName = Enum.GetName(typeof(AnalyzableObject), analyzableObject);
                Console.WriteLine($"{(int)analyzableObject}) {analyzableObjectName}");
            }

            var selectedAnalyzableObjectId = (AnalyzableObject)int.Parse(Console.ReadKey().KeyChar.ToString());
            var selectedAnalyzableObjectName = Enum.GetName(typeof(AnalyzableObject), selectedAnalyzableObjectId);
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Which {selectedAnalyzableObjectName}");

            var repo = new MenuRepository();

            switch (selectedAnalyzableObjectId)
            {
                case AnalyzableObject.Menu:
                    var menuIndex = 0;
                    foreach (var menu in repo.GetMenus())
                    {
                        Console.WriteLine($"{menuIndex}) {menu.Name}");
                        menuIndex++;

                    }
                    break;
                case AnalyzableObject.MenuCycle:
                    var menuCycleIndex = 0;
                    foreach (var menuCycle in repo.GetMenuCycles())
                    {
                        Console.WriteLine($"{menuCycleIndex}) {menuCycle.Name}");
                        menuCycleIndex++;

                    }
                    break;
            }

            var selectedMenuOrCyrcleId = int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("which Analysis Type:");
            var analysisTypes = Enum.GetValues(typeof(AnalysisTypes)).Cast<AnalysisTypes>();


            foreach (var analysisType in analysisTypes)
            {
                var analysisTypeName = Enum.GetName(typeof(AnalysisTypes), analysisType);
                Console.WriteLine($"{(int)analysisType}) {analysisTypeName}");
            }

            var selectedAnalysisId = (AnalysisTypes)int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();
            Console.WriteLine();

            IAnalyzer selectedAnalyzer = null;
            switch (selectedAnalyzableObjectId, selectedAnalysisId)
            {
                case (AnalyzableObject.Menu, AnalysisTypes.USDA2021Plus):
                    selectedAnalyzer = new AnalyzerMenuUSDA2021Plus(repo.GetMenuById(selectedMenuOrCyrcleId));
                    break;

                case (AnalyzableObject.Menu, AnalysisTypes.CACFP):
                    selectedAnalyzer = new AnalyzerMenuCACFP(repo.GetMenuById(selectedMenuOrCyrcleId));
                    break;

                case (AnalyzableObject.MenuCycle, AnalysisTypes.USDA2021Plus):
                    selectedAnalyzer = new AnalyzerMenuCycleUSDA2021Plus(repo.GetMenuCycleById(selectedMenuOrCyrcleId));
                    break;
                case (AnalyzableObject.MenuCycle, AnalysisTypes.CACFP):
                    selectedAnalyzer = new AnalyzerMenuCycleCACFP(repo.GetMenuCycleById(selectedMenuOrCyrcleId));
                    break;
            }

            Console.WriteLine("which Report Type:");
            var reportTypes = Enum.GetValues(typeof(ReportType)).Cast<ReportType>();

            foreach (var reportType in reportTypes)
            {
                var reportTypeName = Enum.GetName(typeof(ReportType), reportType);
                Console.WriteLine($"{(int)reportType}) {reportTypeName}");
            }

            var selectedReportId = (ReportType)int.Parse(Console.ReadKey().KeyChar.ToString());

            IReport report = null;
            switch (selectedReportId)
            {
                case ReportType.AnalysisReport:
                    report = new AnalysisReport(selectedAnalyzer);
                    break;

                case ReportType.InvalidMenuReport:
                    report = new InvalidMenusReport(selectedAnalyzer);
                    break;
                default:
                    break;
            }

            Console.Clear();
            report.GenerateReport();

            Console.ReadKey();
        }
    }
}
