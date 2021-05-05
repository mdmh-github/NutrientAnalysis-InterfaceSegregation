using System.Collections.Generic;

namespace GoodNutrientAnalysisLib.Reports
{
    public interface IReport<t>
    {
        IEnumerable<t> Sources { get; }

        void GenerateReport();
    }
}