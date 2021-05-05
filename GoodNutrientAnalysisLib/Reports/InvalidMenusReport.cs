using GoodNutrientAnalysisLib.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodNutrientAnalysisLib.Reports
{
    public class InvalidMenusReport : IReport<IValidator>
    {
        public string Name { get; set; }

        public InvalidMenusReport(IEnumerable<IValidator> sources, string analyzedObjectName)
        {
            Sources = sources;
            Name = analyzedObjectName;
        }

        public IEnumerable<IValidator> Sources { get; }



        public void GenerateReport()
        {
            Console.WriteLine(Name);

            Console.Write("Nurients: ");
            foreach (var validator in Sources.Where(x => x.ValidatedElement == Models.AnalyzedElement.Nutrient))
            {
                Console.Write(validator.Name);
                Console.Write(": ");
                Console.Write(validator.Validate() ? "Pass" : "Fail");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Components: ");
            foreach (var validator in Sources.Where(x => x.ValidatedElement == Models.AnalyzedElement.Component))
            {
                Console.Write(validator.Name);
                Console.Write(": ");
                Console.Write(validator.Validate() ? "Pass" : "Fail");
            }

        }
    }
}
