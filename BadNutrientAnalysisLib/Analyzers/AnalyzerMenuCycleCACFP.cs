using BadNutrientAnalysisLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BadNutrientAnalysisLib.Analyzers
{
    public class AnalyzerMenuCycleCACFP : IAnalyzer
    {
        public MenuCycle MenuCycle { get; }

        public string Name => "CACFP Menu Cycle";
        public string AnalyzedObjectName => $"Menu Cycle : {MenuCycle.Name}";

        public IEnumerable<AnalyzerMenuCACFP> MenuAnalyzers { get; }

        public AnalyzerMenuCycleCACFP(MenuCycle menuCycle)
        {
            MenuCycle = menuCycle;
            MenuAnalyzers = MenuCycle.Menus.Select(x => new AnalyzerMenuCACFP(x));
        }

        public DataTable CreateComponentAnalysis()
        {
            var datatables = MenuAnalyzers.Select(x => x.CreateComponentAnalysis());
            var mergedDataTable = new DataTable();
            var singleDataTable = datatables.First();

            foreach (DataColumn column in singleDataTable.Columns)
            {
                mergedDataTable.Columns.Add(column);
            }

            var count = 1;

            foreach (var datatable in datatables)
            {
                mergedDataTable.Rows.Add("Day", count);

                foreach (var row in datatable.Rows)
                {
                    mergedDataTable.Rows.Add(row);
                }
            }

            return mergedDataTable;
        }

        public DataTable CreateNutrientAnalysis()
        {
            throw new Exception("CACFP is just focussed on Components");
        }

        public bool ValidateComponents()
        {
            throw new Exception("Non Aplicable");
        }

        public bool ValidateNutrients()
        {
            throw new Exception("CACFP is just focussed on Components");

        }
    }
}
