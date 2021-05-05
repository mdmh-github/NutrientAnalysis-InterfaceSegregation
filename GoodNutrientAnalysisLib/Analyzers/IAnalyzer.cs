using GoodNutrientAnalysisLib.Models;
using System.Data;

namespace GoodNutrientAnalysisLib.Analyzers
{
    public interface IAnalyzer
    {
        DataTable Analyze();
        string Name { get; }

        AnalyzedElement AnalyzedElement { get; }
    }
}
