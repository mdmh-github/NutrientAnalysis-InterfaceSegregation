using GoodNutrientAnalysisLib.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GoodNutrientAnalysisLib.Analyzers
{
    public class AnalyzerMenuCycleComponentCACFP : IAnalyzer
    {
        public MenuCycle MenuCycle { get; }
        public IEnumerable<AnalyzerMenuComponentCACFP> MenuAnalyzers { get; }

        public AnalyzerMenuCycleComponentCACFP(MenuCycle menuCycle)
        {
            MenuCycle = menuCycle;
            MenuAnalyzers = MenuCycle.Menus.Select(x => new AnalyzerMenuComponentCACFP(x));

        }

        public string Name => "CACFP Menu Cycle component";

        public AnalyzedElement AnalyzedElement => AnalyzedElement.Component;

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
