using BadNutrientAnalysisLib.Models;
using FastMember;
using System;
using System.Data;
using System.Linq;

namespace BadNutrientAnalysisLib.Analyzers
{
    public class AnalyzerMenuCACFP : IAnalyzer
    {
        public Menu Menu { get; }

        public string Name => "CACFP Menu";

        public string AnalyzedObjectName => $"Menu: {Menu.Name}";

        public AnalyzerMenuCACFP(Menu menu)
        {
            Menu = menu;
        }

        public DataTable CreateComponentAnalysis()
        {
            var table = new DataTable();
            using var reader = ObjectReader.Create(Menu.Components);
            table.Load(reader);
            return table;
        }

        public DataTable CreateNutrientAnalysis()
        {
            throw new Exception("CACFP is just focussed on Components");
        }

        public bool ValidateComponents()
        {
            return Menu.Components.Count() > 2;
        }

        public bool ValidateNutrients()
        {
            throw new Exception("CACFP is just focussed on Components");
        }
    }
}
