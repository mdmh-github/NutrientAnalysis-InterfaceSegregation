using GoodNutrientAnalysisLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace GoodNutrientAnalysisLib.Validators
{
    public class ValidatorMenuCycleComponentUSDA2021Plus : IValidator
    {
        public MenuCycle MenuCycle { get; }
        public IEnumerable<ValidatorMenuComponentUSDA2021Plus> MenuValidators { get; }

        public ValidatorMenuCycleComponentUSDA2021Plus(MenuCycle menuCycle)
        {
            MenuCycle = menuCycle;
            MenuValidators = MenuCycle.Menus.Select(x => new ValidatorMenuComponentUSDA2021Plus(x));
        }

        public AnalyzedElement ValidatedElement => AnalyzedElement.Component;

        public string Name => "USDA2021+ Menu Cycle Component";

        public bool Validate()
        {
            return MenuValidators.All(x => x.Validate());
        }
    }
}
