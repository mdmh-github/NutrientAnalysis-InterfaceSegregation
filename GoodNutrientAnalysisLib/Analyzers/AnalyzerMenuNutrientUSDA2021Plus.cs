using FastMember;
using GoodNutrientAnalysisLib.Models;
using System.Data;

namespace GoodNutrientAnalysisLib.Analyzers
{
    public class AnalyzerMenuNutrientUSDA2021Plus : IAnalyzer
    {
        public Menu Menu { get; }

        public AnalyzerMenuNutrientUSDA2021Plus(Menu menu)
        {
            Menu = menu;
        }

        public string Name => "USDA 2021+ Menu Nutrient";

        public AnalyzedElement AnalyzedElement => AnalyzedElement.Nutrient;

        public DataTable Analyze()
        {
            var table = new DataTable();
            using var reader = ObjectReader.Create(Menu.Nutrients);
            table.Load(reader);
            return table;
        }
    }
}
