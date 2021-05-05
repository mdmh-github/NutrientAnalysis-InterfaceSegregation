using System.Collections.Generic;

namespace GoodNutrientAnalysisLib.Models
{
    public class MenuCycle
    {
        public MenuCycle(string name, IEnumerable<Menu> menus)
        {
            Name = name;
            Menus = menus;
        }

        public string Name { get; }

        public IEnumerable<Menu> Menus { get; }
    }
}
