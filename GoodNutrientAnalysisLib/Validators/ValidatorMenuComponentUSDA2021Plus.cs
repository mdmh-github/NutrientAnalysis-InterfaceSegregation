using GoodNutrientAnalysisLib.Models;
using System.Linq;

namespace GoodNutrientAnalysisLib.Validators
{
    public class ValidatorMenuComponentUSDA2021Plus : IValidator
    {
        public Menu Menu { get; }

        public ValidatorMenuComponentUSDA2021Plus(Menu menu)
        {
            Menu = menu;
        }

        public AnalyzedElement ValidatedElement => AnalyzedElement.Component;

        public string Name => "USDA2021+ Menu Component";

        public bool Validate()
        {
            return Menu.Components.All(x => x.Value > 0.5m);
        }
    }
}
