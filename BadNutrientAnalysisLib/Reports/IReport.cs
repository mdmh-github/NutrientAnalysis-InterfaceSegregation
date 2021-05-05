using BadNutrientAnalysisLib.Analyzers;

namespace BadNutrientAnalysisLib.Reports
{
    public interface IReport
    {
        IAnalyzer Analyzer { get; }

        void GenerateReport();
    }
}