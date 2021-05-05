using GoodNutrientAnalysisLib.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GoodNutrientAnalysisLib.Analyzers
{
    public class AnalyzerMenuCycleNutrientUSDA2021Plus : IAnalyzer
    {
        public MenuCycle MenuCycle { get; }
        public IEnumerable<AnalyzerMenuComponentUSDA2021Plus> MenuAnalyzers { get; }

        public AnalyzerMenuCycleNutrientUSDA2021Plus(MenuCycle menuCycle)
        {
            MenuCycle = menuCycle;
            MenuAnalyzers = MenuCycle.Menus.Select(x => new AnalyzerMenuComponentUSDA2021Plus(x));
        }

        public string Name => "USDA 2021+ Menu Cycle";


        public AnalyzedElement AnalyzedElement => AnalyzedElement.Nutrient;

        public DataTable Analyze()
        {
            var datatables = MenuAnalyzers.Select(x => x.Analyze());
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
    }
}
