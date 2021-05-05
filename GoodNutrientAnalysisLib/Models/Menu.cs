using System.Collections.Generic;

namespace GoodNutrientAnalysisLib.Models
{
    public class Menu
    {
        public Menu(string name, IEnumerable<Component> components, IEnumerable<Nutrient> nutrients)
        {
            Name = name;
            Components = components;
            Nutrients = nutrients;
        }

        public string Name { get; }

        public IEnumerable<Component> Components { get; }
        public IEnumerable<Nutrient> Nutrients { get; }
    }
}
