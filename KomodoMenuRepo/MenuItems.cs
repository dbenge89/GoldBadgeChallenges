using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoMenuRepo
{
    public class MenuItems
    {
        public int MealNum { get; set; }
        public string MealName { get; set; }
        public string MealDesc { get; set; }
        public Entree Main { get; set; }
        public Side Sides { get; set; }
        public Dessert Desserts { get; set; }
        public Drink Beverage { get; set; }
        public decimal MealPrice(Entree entree, Side side, Dessert dessert)
        {
            return entree.Price + side.Price + dessert.Price;
        }
        public MenuItems() { }
        public MenuItems(int mealNum, string mealName, string mealDesc, Entree main, Side sides, Dessert desserts)
        {
            MealNum = mealNum;
            MealName = mealName;
            MealDesc = mealDesc;
            Main = main;
            Sides = sides;
            Desserts = desserts;
        }
    }
    public class Entree
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IngredientsType Protein { get; set; }
        public IngredientsType DishBase { get; set; }
        public IngredientsType Topping { get; set; }
        public IngredientsType Cheese { get; set; }
        public Entree() { }
        public Entree(string name, string description, decimal price, IngredientsType protein, IngredientsType dishBase, IngredientsType topping, IngredientsType cheese)
        {
            Name = name;
            Description = description;
            Price = price;
            Protein = protein;
            DishBase = dishBase;
            Topping = topping;
            Cheese = cheese;

        }

    }
    public class Side : Entree
    {
        public Side() { }
        public Side(string name, string description, decimal price, IngredientsType protein, IngredientsType dishBase, IngredientsType topping, IngredientsType cheese) : base(name, description, price, protein, dishBase, topping, cheese) { }
    }
    public class Dessert
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DessertIngredientsType DessertBase { get; set; }
        public DessertIngredientsType Topping { get; set; }
        public DessertIngredientsType Topping2 { get; set; }
        public Dessert() { }
        public Dessert(string name, string description, decimal price, DessertIngredientsType dessertBase, DessertIngredientsType topping, DessertIngredientsType topping2)
        {
            Name = name;
            Description = description;
            Price = price;
            DessertBase = dessertBase;
            Topping = topping;
            Topping2 = topping2;
        }

    }
    public class Drink
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DrinkType Drinks { get; set; }
        public Drink() { }
        public Drink(string name, decimal price, DrinkType drinks)
        {
            Name = name;
            Price = price;
            Drinks = drinks;
        }
    }
    public enum IngredientsType { Beef = 1, Chicken, Bacon, Fish, Tofu, Lettuce, Spinach, Tomato, Onions, Cheese, VeganCheese, BrownRice, WhiteRice, CauliflowerRice, NA }
    public enum DessertIngredientsType { Brownie = 1, Cookie, IceCream, RicePudding, Caramel, Chocolate, WhipCream, BrownSugar, Cherry, NA }
    public enum DrinkType { KidsDrink = 1, SmallDrink, MediumDrink, LargeDrink, XLDrink, Regular }
}
