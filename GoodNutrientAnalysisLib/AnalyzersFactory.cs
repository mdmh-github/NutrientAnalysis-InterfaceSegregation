using GoodNutrientAnalysisLib.Analyzers;
using GoodNutrientAnalysisLib.Repository;
using System.Collections.Generic;

namespace GoodNutrientAnalysisLib
{
    public class AnalyzersFactory
    {
        readonly MenuRepository repo;

        public AnalyzersFactory(MenuRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<IAnalyzer> GetAnalyzers(AnalyzableObject selectedAnalyzableObjectId, int selectedMenuOrCyrcleId, AnalysisTypes selectedAnalysisId)
        {
            switch (selectedAnalyzableObjectId, selectedAnalysisId)
            {
                case (AnalyzableObject.Menu, AnalysisTypes.USDA2021Plus):
                    yield return new AnalyzerMenuNutrientUSDA2021Plus(repo.GetMenuById(selectedMenuOrCyrcleId));
                    yield return new AnalyzerMenuComponentUSDA2021Plus(repo.GetMenuById(selectedMenuOrCyrcleId));
                    break;

                case (AnalyzableObject.Menu, AnalysisTypes.CACFP):
                    yield return new AnalyzerMenuComponentCACFP(repo.GetMenuById(selectedMenuOrCyrcleId));
                    break;

                case (AnalyzableObject.MenuCycle, AnalysisTypes.USDA2021Plus):
                    yield return new AnalyzerMenuCycleNutrientUSDA2021Plus(repo.GetMenuCycleById(selectedMenuOrCyrcleId));
                    yield return new AnalyzerMenuCycleComponentUSDA2021Plus(repo.GetMenuCycleById(selectedMenuOrCyrcleId));
                    break;

                case (AnalyzableObject.MenuCycle, AnalysisTypes.CACFP):
                    yield return new AnalyzerMenuCycleComponentCACFP(repo.GetMenuCycleById(selectedMenuOrCyrcleId));
                    break;
            }
        }
    }
}
