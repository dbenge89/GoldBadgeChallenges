using KomodoMenuRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoMenuTests
{
    [TestClass]
    public class MenuItemTests
    {
        private MenuRepo _entrees = new MenuRepo();
        private MenuRepo _sides = new MenuRepo();
        private MenuRepo _desserts = new MenuRepo();
        private MenuRepo _drinks = new MenuRepo();
        private MenuRepo _menu = new MenuRepo();

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
            MenuItems meal = new MenuItems(3, "Vegan meal", "Enjoy specially created meals with no animal cruelty", entree, side, dessert);


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
        [TestMethod]
        public void GetMealsByNumberAndItemsByName()
        {
            Entree searchEntree = _entrees.GetEntreesByName("Vegan Rice");
            Side searchSide = _sides.GetSidesByName("Vegan Salad");
            Dessert searchDessert = _desserts.GetDessertsByName("Fudge Brownie Sundae");
            Drink searchDrink = _drinks.GetDrinksByName("Chocolate shake");
            MenuItems searchMeal = _menu.GetMenuItemsByNumber(1);

            string expectedEntree = "Vegan Rice";
            string actualEntree = searchEntree.Name;

            string expexectedSide = "Vegan Salad";
            string actualSide = searchSide.Name;

            string expectedDessert = "Fudge Brownie Sundae";
            string actualDessert = searchDessert.Name;

            string expectedDrink = "Chocolate shake";
            string actualDrink = searchDrink.Name;

            int expectedMeal = 1;
            int actualMeal = searchMeal.MealNum;

            Assert.AreEqual(expectedEntree, actualEntree);
            Assert.AreEqual(expexectedSide, actualSide);
            Assert.AreEqual(expectedDessert, actualDessert);
            Assert.AreEqual(expectedDrink, actualDrink);
            Assert.AreEqual(expectedMeal, actualMeal);
        }
        [TestMethod]
        public void UpdateExistingItemsAndMeals()
        {
            Entree newEntree = new Entree("Vegan Rice", "What a dumb meal.", 7.50m, IngredientsType.Tofu, IngredientsType.BrownRice, IngredientsType.Onions, IngredientsType.VeganCheese);
            Side newSide = new Side("Vegan Salad", "Salad but without the good stuff", 4.99m, IngredientsType.Tofu, IngredientsType.Spinach, IngredientsType.Onions, IngredientsType.VeganCheese);
            Dessert newDessert = new Dessert("Fudge Brownie Sundae", "Cold brownie, Warm icecream", 3.99m, DessertIngredientsType.IceCream, DessertIngredientsType.Brownie, DessertIngredientsType.Caramel);
            Drink newDrink = new Drink("Chocolate shake", 2.99m, DrinkType.Regular);
            MenuItems newMeal = new MenuItems(1, "Vegan meal", "No animal cruelty", newEntree, newSide, newDessert);

            bool entreeUpdated = _entrees.UpdateExistingEntree("Vegan Rice", newEntree);
            bool sideUpdated = _sides.UpdateExistingSide("Vegan Salad", newSide);
            bool dessertUpdated = _desserts.UpdateExistingDessert("Fudge Brownie Sundae", newDessert);
            bool drinkUpdated = _drinks.UpdateExistingDrink("Chocolate shake", newDrink);
            bool mealUpdated = _menu.UpdateExistingMeal(1, newMeal);

            Assert.IsTrue(entreeUpdated);
            Assert.IsTrue(sideUpdated);
            Assert.IsTrue(dessertUpdated);
            Assert.IsTrue(drinkUpdated);
            Assert.IsTrue(mealUpdated);
        }
        [TestMethod]
        public void DeleteItemsAndMeals()
        {
            bool removedEntree = _entrees.DeleteEntrees("Vegan Rice");
            bool removedSide = _sides.DeleteSides("Vegan Salad");
            bool removedDessert = _desserts.DeleteDesserts("Fudge Brownie Sundae");
            bool removedDrink = _drinks.DeleteDrinks("Chocolate shake");
            bool removedMeal = _menu.DeleteMenuItems(1);

            Assert.IsTrue(removedEntree);
            Assert.IsTrue(removedSide);
            Assert.IsTrue(removedDessert);
            Assert.IsTrue(removedDrink);
            Assert.IsTrue(removedMeal);
        }
    }
}
