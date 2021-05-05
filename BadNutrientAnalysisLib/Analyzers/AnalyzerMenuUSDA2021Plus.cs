using BadNutrientAnalysisLib.Models;
using FastMember;
using System.Data;
using System.Linq;

namespace BadNutrientAnalysisLib.Analyzers
{
    public class AnalyzerMenuUSDA2021Plus : IAnalyzer
    {
        public Menu Menu { get; }

        public AnalyzerMenuUSDA2021Plus(Menu menu)
        {
            Menu = menu;
        }

        public string Name => "USDA 2021+ Menu";

        public string AnalyzedObjectName => $"Menu: {Menu.Name}";

        public DataTable CreateComponentAnalysis()
        {
            var table = new DataTable();
            using var reader = ObjectReader.Create(Menu.Components);
            table.Load(reader);
            return table;
        }

        public DataTable CreateNutrientAnalysis()
        {
            var table = new DataTable();
            using var reader = ObjectReader.Create(Menu.Nutrients);
            table.Load(reader);
            return table;
        }

        public bool ValidateComponents()
        {
            return Menu.Components.All(x => x.Value > 0.5m);
        }

        public bool ValidateNutrients()
        {
            return Menu.Nutrients.All(x => x.Value > 0.25m);
        }
    }
}
