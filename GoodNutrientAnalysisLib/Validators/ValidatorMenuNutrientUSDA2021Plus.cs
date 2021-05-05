using GoodNutrientAnalysisLib.Models;
using System.Linq;

namespace GoodNutrientAnalysisLib.Validators
{
    public class ValidatorMenuNutrientUSDA2021Plus : IValidator
    {
        public ValidatorMenuNutrientUSDA2021Plus(Menu menu)
        {
            Menu = menu;
        }

        public Menu Menu { get; }


        public AnalyzedElement ValidatedElement => AnalyzedElement.Nutrient;

        public string Name => "USDA2021+ Menu Nutrient";

        public bool Validate()
        {
            return Menu.Nutrients.All(x => x.Value > 0.25m);
        }
    }
}
