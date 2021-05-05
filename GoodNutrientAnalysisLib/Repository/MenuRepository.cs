using GoodNutrientAnalysisLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace GoodNutrientAnalysisLib.Repository
{
    public class MenuRepository
    {
        public Menu GetMenuById(int id)
        {
            return GetMenus().ElementAt(id);
        }

        public MenuCycle GetMenuCycleById(int id)
        {
            return GetMenuCycles().ElementAt(id);
        }

        public IEnumerable<Menu> GetMenus()
        {
            return allMenus;
        }

        public IEnumerable<MenuCycle> GetMenuCycles()
        {
            yield return new MenuCycle("Mixed Menus", new Menu[] { BeefAndBeer, GreekSalad, Spaguetti, HamburguerWithFries, Sushi });
            yield return new MenuCycle("Drunk Menus", new Menu[] { BeefAndBeer, BeefAndBeer, BeefAndBeer, BeefAndBeer, BeefAndBeer });
            yield return new MenuCycle("School Menus", new Menu[] { HamburguerWithFries, HamburguerWithFries, HamburguerWithFries, HamburguerWithFries, HamburguerWithFries });
        }

        readonly static Menu GreekSalad = new Menu(
            "Greek Salad Dish",
                new Component[] {
                    new Component
                    {
                        Name = "Vegetables",
                        Value = 1
                    },
                    new Component
                    {
                        Name = "Fruits",
                        Value = 2
                    },
                    new Component
                    {
                        Name = "Milk",
                        Value = 0.5m
                    },
                },
                new Nutrient[] {
                    new Nutrient
                    {
                        Name = "Carbs",
                        Value = 4
                    },
                    new Nutrient
                    {
                        Name = "Sugar",
                        Value = 2
                    },
                    new Nutrient
                    {
                        Name = "Vitamin A",
                        Value = 1
                    },
                    new Nutrient
                    {
                        Name = "Vitamin B",
                        Value = 1
                    },
                    new Nutrient
                    {
                        Name = "Vitamin C",
                        Value = 1

                    },
                }
        );

        readonly static Menu BeefAndBeer = new Menu(
            "Beef and Beer",
                new Component[] {
                    new Component
                    {
                        Name = "Vegetables",
                        Value = 1
                    },
                    new Component
                    {
                        Name = "Meat",
                        Value = 3
                    },
                    new Component
                    {
                        Name = "Grains",
                        Value = 1m
                    },
                },
                new Nutrient[] {
                    new Nutrient
                    {
                        Name = "Carbs",
                        Value = 4
                    },
                    new Nutrient
                    {
                        Name = "salt",
                        Value = 3
                    },
                    new Nutrient
                    {
                        Name = "Fat",
                        Value = 7
                    },
                }
        );

        readonly static Menu Spaguetti = new Menu(
            "Spaguetti with chicken",
                new Component[] {
                    new Component
                    {
                        Name = "Fruits",
                        Value = 1
                    },
                    new Component
                    {
                        Name = "Meat",
                        Value = 2
                    },
                    new Component
                    {
                        Name = "Grains",
                        Value = 1
                    },
                },
                new Nutrient[] {
                    new Nutrient
                    {
                        Name = "Carbs",
                        Value = 10
                    },
                    new Nutrient
                    {
                        Name = "salt",
                        Value = 3
                    },
                    new Nutrient
                    {
                        Name = "Fat",
                        Value = 7
                    },
                }
        );

        readonly static Menu HamburguerWithFries = new Menu(
            "Hamburguer With Fries",
                new Component[] {
                    new Component
                    {
                        Name = "Vegetables",
                        Value = 3
                    },
                    new Component
                    {
                        Name = "Meat",
                        Value = 7
                    },
                    new Component
                    {
                        Name = "Grains",
                        Value = 3
                    },
                    new Component
                    {
                        Name = "Milk",
                        Value = 4
                    },
                },
                new Nutrient[] {
                    new Nutrient
                    {
                        Name = "Carbs",
                        Value = 10
                    },
                    new Nutrient
                    {
                        Name = "salt",
                        Value = 3
                    },
                    new Nutrient
                    {
                        Name = "Fat",
                        Value = 7
                    },
                    new Nutrient
                    {
                        Name = "Vitamin D",
                        Value = 1
                    },
                }
        );

        readonly static Menu Sushi = new Menu(
            "Sushi",
                new Component[] {
                    new Component
                    {
                        Name = "Vegetables",
                        Value = 3
                    },
                    new Component
                    {
                        Name = "Meat",
                        Value = 1
                    },
                    new Component
                    {
                        Name = "Grains",
                        Value = 7
                    },
                },
                new Nutrient[] {
                    new Nutrient
                    {
                        Name = "Carbs",
                        Value = 10
                    },
                    new Nutrient
                    {
                        Name = "salt",
                        Value = 1
                    },
                    new Nutrient
                    {
                        Name = "Fat",
                        Value = 1
                    },
                    new Nutrient
                    {
                        Name = "Vitamin C",
                        Value = 1
                    },
                }
        );

        private static readonly IEnumerable<Menu> allMenus = new Menu[] {
            GreekSalad,
            BeefAndBeer,
            Spaguetti,
            HamburguerWithFries,
            Sushi
        };
    }
}
