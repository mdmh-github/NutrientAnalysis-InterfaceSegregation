using BadNutrientAnalysisLib.Analyzers;
using System;
using System.Data;

namespace BadNutrientAnalysisLib.Reports
{
    public class AnalysisReport : IReport
    {
        public IAnalyzer Analyzer { get; }

        public AnalysisReport(IAnalyzer analyzer)
        {
            Analyzer = analyzer;
        }

        public void GenerateReport()
        {
            var dataTable = Analyzer.CreateNutrientAnalysis();

            Console.WriteLine($"Analizer: {Analyzer.Name}");
            Console.WriteLine($"{Analyzer.AnalyzedObjectName}");
            Console.WriteLine();

            Console.Write("Nurients: ");
            Console.WriteLine(Analyzer.ValidateNutrients() ? "Pass" : "Fail");
            Console.WriteLine();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Console.Write("- "); 
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }

            dataTable = Analyzer.CreateComponentAnalysis();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Components: ");
            Console.WriteLine(Analyzer.ValidateComponents() ? "Pass" : "Fail");
            Console.WriteLine();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Console.Write("- ");

                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}
