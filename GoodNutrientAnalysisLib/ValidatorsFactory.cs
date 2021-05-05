using GoodNutrientAnalysisLib.Analyzers;
using GoodNutrientAnalysisLib.Repository;
using GoodNutrientAnalysisLib.Validators;
using System.Collections.Generic;

namespace GoodNutrientAnalysisLib
{
    public class ValidatorsFactory
    {
        readonly MenuRepository repo;

        public ValidatorsFactory(MenuRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<IValidator> GetValidators(AnalyzableObject selectedAnalyzableObjectId, int selectedMenuOrCyrcleId, AnalysisTypes selectedAnalysisId)
        {
            switch (selectedAnalyzableObjectId, selectedAnalysisId)
            {
                case (AnalyzableObject.Menu, AnalysisTypes.USDA2021Plus):
                    yield return new ValidatorMenuComponentUSDA2021Plus(repo.GetMenuById(selectedMenuOrCyrcleId));
                    yield return new ValidatorMenuNutrientUSDA2021Plus(repo.GetMenuById(selectedMenuOrCyrcleId));
                    break;

                case (AnalyzableObject.Menu, AnalysisTypes.CACFP):
                    yield return new ValidatorMenuComponentCACFP(repo.GetMenuById(selectedMenuOrCyrcleId));
                    break;

                case (AnalyzableObject.MenuCycle, AnalysisTypes.USDA2021Plus):
                    yield return new ValidatorMenuCycleComponentUSDA2021Plus(repo.GetMenuCycleById(selectedMenuOrCyrcleId));
                    yield return new ValidatorMenuCycleNutrientUSDA2021Plus(repo.GetMenuCycleById(selectedMenuOrCyrcleId));
                    break;

                case (AnalyzableObject.MenuCycle, AnalysisTypes.CACFP):
                    break;
            }
        }
    }
}
