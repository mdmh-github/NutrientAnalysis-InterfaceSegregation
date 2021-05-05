using FastMember;
using GoodNutrientAnalysisLib.Models;
using System.Data;

namespace GoodNutrientAnalysisLib.Analyzers
{
    public class AnalyzerMenuComponentCACFP : IAnalyzer
    {
        public AnalyzerMenuComponentCACFP(Menu menu)
        {
            Menu = menu;
        }

        public Menu Menu { get; }

        public string Name => "CACFP Menu Component";

        public AnalyzedElement AnalyzedElement => AnalyzedElement.Component;

        public DataTable Analyze()
        {
            var table = new DataTable();
            using var reader = ObjectReader.Create(Menu.Components);
            table.Load(reader);
            return table;
        }
    }
}
