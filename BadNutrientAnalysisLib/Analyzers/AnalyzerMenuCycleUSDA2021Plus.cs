using BadNutrientAnalysisLib.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BadNutrientAnalysisLib.Analyzers
{
    public class AnalyzerMenuCycleUSDA2021Plus : IAnalyzer
    {
        public MenuCycle MenuCycle { get; }

        public string Name => "USDA 2021+ Menu Cycle";

        public string AnalyzedObjectName => $"Menu Cycle: {MenuCycle.Name}";

        public IEnumerable<AnalyzerMenuUSDA2021Plus> MenuAnalyzers { get; }

        public AnalyzerMenuCycleUSDA2021Plus(MenuCycle menuCycle)
        {
            MenuCycle = menuCycle;
            MenuAnalyzers = MenuCycle.Menus.Select(x => new AnalyzerMenuUSDA2021Plus(x));
        }
        public DataTable CreateComponentAnalysis()
        {
            var datatables = MenuAnalyzers.Select(x => x.CreateComponentAnalysis());
            var singleDataTable = datatables.First();
            var mergedDataTable = singleDataTable.Clone();

            var count = 1;

            foreach (var datatable in datatables)
            {
                mergedDataTable.Rows.Add("Day", count);

                foreach (DataRow row in datatable.Rows)
                {
                    var newRow = mergedDataTable.NewRow();

                    foreach (DataColumn column in mergedDataTable.Columns)
                    {
                        newRow[column] = row[column.ColumnName];
                    }

                    mergedDataTable.Rows.Add(newRow);
                }

                count++;
            }

            return mergedDataTable;
        }

        public DataTable CreateNutrientAnalysis()
        {
            var datatables = MenuAnalyzers.Select(x => x.CreateNutrientAnalysis());
            var singleDataTable = datatables.First();
            var mergedDataTable = singleDataTable.Clone();
            var count = 1;

            foreach (var datatable in datatables)
            {
                mergedDataTable.Rows.Add("Day", count);

                foreach (DataRow row in datatable.Rows)
                {
                    var newRow = mergedDataTable.NewRow();

                    foreach (DataColumn column in mergedDataTable.Columns)
                    {
                        newRow[column] = row[column.ColumnName];
                    }

                    mergedDataTable.Rows.Add(newRow);
                }

                count++;
            }

            return mergedDataTable;
        }

        public bool ValidateComponents()
        {
            return MenuAnalyzers.All(x => x.ValidateComponents());
        }

        public bool ValidateNutrients()
        {
            return MenuAnalyzers.All(x => x.ValidateNutrients());
        }
    }
}
