using BadNutrientAnalysisLib.Analyzers;
using System;

namespace BadNutrientAnalysisLib.Reports
{
    public class InvalidMenusReport : IReport
    {
        public IAnalyzer Analyzer { get; }

        public InvalidMenusReport(IAnalyzer analyzer)
        {
            Analyzer = analyzer;
        }

        public void GenerateReport()
        {
            Console.WriteLine($"Analizer: {Analyzer.Name}");
            Console.WriteLine(Analyzer.AnalyzedObjectName);
            Console.Write("Nurients: ");
            Console.WriteLine(Analyzer.ValidateNutrients() ? "Pass" : "Fail");
            Console.Write("Components: ");
            Console.WriteLine(Analyzer.ValidateComponents() ? "Pass" : "Fail");
        }
    }
}
