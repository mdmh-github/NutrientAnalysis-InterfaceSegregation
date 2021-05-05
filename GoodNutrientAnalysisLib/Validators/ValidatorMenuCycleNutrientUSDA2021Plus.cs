using GoodNutrientAnalysisLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace GoodNutrientAnalysisLib.Validators
{
    public class ValidatorMenuCycleNutrientUSDA2021Plus : IValidator
    {
        public MenuCycle MenuCycle { get; }

        public ValidatorMenuCycleNutrientUSDA2021Plus(MenuCycle menuCycle)
        {
            MenuCycle = menuCycle;
            MenuValidators = MenuCycle.Menus.Select(x => new ValidatorMenuNutrientUSDA2021Plus(x));
        }

        public IEnumerable<ValidatorMenuNutrientUSDA2021Plus> MenuValidators { get; }

        
        public AnalyzedElement ValidatedElement => AnalyzedElement.Nutrient;

        public string Name => "USDA2021+ Menu Cycle Nutrient";

        public bool Validate()
        {
            return MenuValidators.All(x => x.Validate());

        }
    }
}
