using System.Data;

namespace BadNutrientAnalysisLib.Analyzers
{
    public interface IAnalyzer
    {
        public string Name { get; }
        public string AnalyzedObjectName { get; }
        public DataTable CreateNutrientAnalysis();
        public DataTable CreateComponentAnalysis();
        public bool ValidateNutrients();
        public bool ValidateComponents();
    }
}
