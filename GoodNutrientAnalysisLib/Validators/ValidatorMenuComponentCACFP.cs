using GoodNutrientAnalysisLib.Models;
using System.Linq;

namespace GoodNutrientAnalysisLib.Validators
{
    public class ValidatorMenuComponentCACFP : IValidator
    {
        public Menu Menu { get; }

        public ValidatorMenuComponentCACFP(Menu menu)
        {
            Menu = menu;
        }

        public AnalyzedElement ValidatedElement =>  AnalyzedElement.Component;

        public string Name => "CACFP Menu Component";

        public bool Validate()
        {
            return Menu.Components.Count() > 2;
        }
    }
}
