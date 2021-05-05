using GoodNutrientAnalysisLib.Models;

namespace GoodNutrientAnalysisLib.Validators
{
    public interface IValidator
    {
        string Name { get; }

        bool Validate();

        AnalyzedElement ValidatedElement { get; }
    }
}
