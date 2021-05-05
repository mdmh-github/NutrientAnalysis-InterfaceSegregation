using FastMember;
using GoodNutrientAnalysisLib.Models;
using System.Data;

namespace GoodNutrientAnalysisLib.Analyzers
{
    public class AnalyzerMenuComponentUSDA2021Plus : IAnalyzer
    {
        public Menu Menu { get; }

        public AnalyzerMenuComponentUSDA2021Plus(Menu menu)
        {
            Menu = menu;
        }

        public string Name => "USDA 2021+ Menu Component";

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
