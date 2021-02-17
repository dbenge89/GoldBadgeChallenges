using KomodoMenuRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoMenuTests
{
    [TestClass]
    public class MenuItemTests
    {
        private MenuRepo _entrees;
        private MenuRepo _sides;
        private MenuRepo _desserts;
        private MenuRepo _drinks;
        private MenuRepo _menu;

        [TestInitialize]
        public void Seed()
        {
            Entree firstEntree = new Entree("Vegan Rice", "Blend of vegan ingredients", 7.50m, IngredientsType.Tofu, IngredientsType.BrownRice, IngredientsType.Onions, IngredientsType.VeganCheese);
            Entree secondEntree = new Entree("Chicken and Bacon Salad", "Salad with fresh ingredients", 7.50m, IngredientsType.Chicken, IngredientsType.Spinach, IngredientsType.Bacon, IngredientsType.Cheese);
            Side firstSide = new Side("Vegan Salad", "Salad with vegan cheese and delicious tofu", 4.99m, IngredientsType.Tofu, IngredientsType.Spinach, IngredientsType.Onions, IngredientsType.VeganCheese);
            Side secondSide = new Side("Fried Rice", "Fried rice with beef", 4.99m, IngredientsType.Beef, IngredientsType.WhiteRice, IngredientsType.Onions, IngredientsType.NA);
            Dessert firstDessert = new Dessert("Fudge Brownie Sundae", "Warm brownie, cold icecream", 3.99m, DessertIngredientsType.IceCream, DessertIngredientsType.Brownie, DessertIngredientsType.Caramel);
            Dessert secondDessert = new Dessert("Cookies and Cream", "Whipped Cream stuff cookie", 3.99m, DessertIngredientsType.Cookie, DessertIngredientsType.WhipCream, DessertIngredientsType.Chocolate);
            Dessert thirdDessert = new Dessert("Vegan dessert", "Animal cruetly free dessert", 3.99m, DessertIngredientsType.RicePudding, DessertIngredientsType.Chocolate, DessertIngredientsType.Caramel);
            Drink firstDrink = new Drink("Chocolate shake", 3.99m, DrinkType.Regular);
            Drink secondDrink = new Drink("Irish Coffee", 5.99m, DrinkType.Regular);
            MenuItems firstMeal = new MenuItems(1, "Vegan meal", "Enjoy specially created meals with no animal cruelty", firstEntree, firstSide, thirdDessert);
            MenuItems secondMeal = new MenuItems(2, "Chicken and Bacon Ranch", "Enjoy our classic CBR", secondEntree, secondSide, firstDessert);
            _entrees.AddEntreesToDirectory(firstEntree);
            _entrees.AddEntreesToDirectory(secondEntree);
            _sides.AddSidesToDirectory(firstSide);
            _sides.AddSidesToDirectory(secondSide);
            _desserts.AddDessertsToDirectory(firstDessert);
            _desserts.AddDessertsToDirectory(secondDessert);
            _desserts.AddDessertsToDirectory(thirdDessert);
            _drinks.AddDrinksToDirectory(firstDrink);
            _drinks.AddDrinksToDirectory(secondDrink);
            _menu.AddMealsToDirectory(firstMeal);
            _menu.AddMealsToDirectory(secondMeal);
        }
        [TestMethod]
        public void AddItemsToDirectory_ShouldAddtoDirectories()
        {
            Entree entree = new Entree("Vegan Rice", "Blend of vegan ingredients", 7.50m, IngredientsType.Tofu, IngredientsType.BrownRice, IngredientsType.Onions, IngredientsType.VeganCheese);
            Side side = new Side("Vegan Salad", "Salad with vegan cheese and delicious tofu", 4.99m, IngredientsType.Tofu, IngredientsType.Spinach, IngredientsType.Onions, IngredientsType.VeganCheese);
            Dessert dessert = new Dessert("Fudge Brownie Sundae", "Warm brownie, cold icecream", 3.99m, DessertIngredientsType.IceCream, DessertIngredientsType.Brownie, DessertIngredientsType.Caramel);
            Drink drink = new Drink("Chocolate shake", 3.99m, DrinkType.Regular);
            MenuItems meal = new MenuItems(1, "Vegan meal", "Enjoy specially created meals with no animal cruelty", entree, side, dessert);


            bool entreeAdded = _entrees.AddEntreesToDirectory(entree);
            bool sideAdded = _sides.AddSidesToDirectory(side);
            bool dessertAdded = _desserts.AddDessertsToDirectory(dessert);
            bool drinkAdded = _drinks.AddDrinksToDirectory(drink);
            bool mealAdded = _menu.AddMealsToDirectory(meal);

            Assert.IsTrue(entreeAdded);
            Assert.IsTrue(sideAdded);
            Assert.IsTrue(dessertAdded);
            Assert.IsTrue(drinkAdded);
            Assert.IsTrue(mealAdded);
        }
    }
}
