using GoodNutrientAnalysisLib.Analyzers;
using GoodNutrientAnalysisLib.Models;
using GoodNutrientAnalysisLib.Validators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GoodNutrientAnalysisLib.Reports
{
    public class AnalysisReport : IReport<IAnalyzer>
    {
        public string AnalyzedObjectName { get; }
        public IEnumerable<IValidator> Validators { get; }

        public IEnumerable<IAnalyzer> Sources { get; }

        public AnalysisReport(
            string analyzedObjectName,
            IEnumerable<IAnalyzer> analyzers,
            IEnumerable<IValidator> validators

            )
        {
            AnalyzedObjectName = analyzedObjectName;
            Sources = analyzers;
            Validators = validators;
        }

        public void GenerateReport()
        {

            var nutrientValidators = Validators.Where(x => x.ValidatedElement == AnalyzedElement.Nutrient);

            Console.WriteLine($"{AnalyzedObjectName}");
            Console.WriteLine();

            Console.WriteLine("Nutrients: ");

            foreach (var validator in nutrientValidators)
            {
                Console.Write("Validator: ");
                Console.Write(validator.Name);
                Console.Write(": ");
                Console.Write(validator.Validate() ? "Pass" : "Fail");
            }

            var nutrientAnalyzers = Sources.Where(x => x.AnalyzedElement == AnalyzedElement.Nutrient);
            Console.WriteLine();
            foreach (var analyzer in nutrientAnalyzers)
            {
                Console.WriteLine($"Analyzer: {analyzer.Name}");
                var dataTable = analyzer.Analyze();

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

            Console.WriteLine();
            Console.WriteLine();

            // Components
            var componentsValidators = Validators.Where(x => x.ValidatedElement == AnalyzedElement.Component);

            Console.WriteLine("Components: ");

            foreach (var validator in componentsValidators)
            {
                Console.Write(validator.Name);
                Console.Write(": ");
                Console.Write(validator.Validate() ? "Pass" : "Fail");
            }

            var componentAnalyzers = Sources.Where(x => x.AnalyzedElement == AnalyzedElement.Component);
            Console.WriteLine();

            foreach (var analyzer in componentAnalyzers)
            {
                Console.WriteLine($"Analyzer: {analyzer.Name}");
                var dataTable = analyzer.Analyze();

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
}
