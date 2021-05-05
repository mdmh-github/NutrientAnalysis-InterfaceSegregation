using GoodNutrientAnalysisLib;
using GoodNutrientAnalysisLib.Analyzers;
using GoodNutrientAnalysisLib.Reports;
using GoodNutrientAnalysisLib.Repository;
using System;
using System.Linq;

namespace GoodNutrientAnalysisInterfaceSegregation
{
    partial class Program
    {
        static void Main()
        {
            var repo = new MenuRepository();
            var analyzersFactory = new AnalyzersFactory(repo);
            var validatorsFactory = new ValidatorsFactory(repo);

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
            
            var selectedAnalyzers = analyzersFactory.GetAnalyzers(selectedAnalyzableObjectId, selectedMenuOrCyrcleId, selectedAnalysisId);
            var selectedValidators = validatorsFactory.GetValidators(selectedAnalyzableObjectId, selectedMenuOrCyrcleId, selectedAnalysisId);

            Console.WriteLine("which Report Type:");
            var reportTypes = Enum.GetValues(typeof(ReportType)).Cast<ReportType>();

            foreach (var reportType in reportTypes)
            {
                var reportTypeName = Enum.GetName(typeof(ReportType), reportType);
                Console.WriteLine($"{(int)reportType}) {reportTypeName}");
            }

            var selectedReportId = (ReportType)int.Parse(Console.ReadKey().KeyChar.ToString());

            Console.Clear();
            

            switch (selectedReportId)
            {
                case ReportType.AnalysisReport:
                    new AnalysisReport(selectedAnalyzableObjectName, selectedAnalyzers, selectedValidators)
                        .GenerateReport();

                    break;

                case ReportType.InvalidMenuReport:
                    new InvalidMenusReport(selectedValidators, selectedAnalyzableObjectName)
                        .GenerateReport();

                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }
    }
}
