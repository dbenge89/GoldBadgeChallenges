using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoMenuRepo
{
    public class MenuRepo
    {
        private readonly List<Entree> _entrees = new List<Entree>();
        private readonly List<Side> _sides = new List<Side>();
        private readonly List<Dessert> _desserts = new List<Dessert>();
        private readonly List<Drink> _drinks = new List<Drink>();
        private readonly List<MenuItems> _menu = new List<MenuItems>();

        public int Count
        {
            get
            {
                return _menu.Count;
            }
        }
        public bool AddEntreesToDirectory(Entree entrees)
        {
            int initialCount = _entrees.Count;
            _entrees.Add(entrees);
            bool addedItem = _entrees.Count > initialCount;
            return addedItem;
        }
        public bool AddSidesToDirectory(Side side)
        {
            int initialCount = _sides.Count;
            _sides.Add(side);
            bool addedItem = _sides.Count > initialCount;
            return addedItem;
        }
        public bool AddDessertsToDirectory(Dessert dessert)
        {
            int initialCount = _desserts.Count;
            _desserts.Add(dessert);
            bool addedItem = _desserts.Count > initialCount;
            return addedItem;
        }
        public bool AddDrinksToDirectory(Drink drink)
        {
            int initialCount = _drinks.Count;
            _drinks.Add(drink);
            bool addedItem = _drinks.Count > initialCount;
            return addedItem;
        }
        public bool AddMealsToDirectory(MenuItems meals)
        {
            int initialCount = _menu.Count;
            _menu.Add(meals);
            bool addedItem = _menu.Count > initialCount;
            return addedItem;
        }
        public List<Entree> GetEntrees()
        {
            return _entrees;
        }
        public List<Side> GetSides()
        {
            return _sides;
        }
        public List<Dessert> GetDesserts()
        {
            return _desserts;
        }
        public List<Drink> GetDrinks()
        {
            return _drinks;
        }
        public List<MenuItems> GetMenuItems()
        {
            return _menu;
        }
        public Entree GetEntreesByName(string entreeName)
        {
            foreach (Entree entree in _entrees)
            {
                if (entreeName == entree.Name)
                {
                    return entree;
                }
                Console.WriteLine("Please enter a valid entree");
                GetEntrees();
                Console.ReadKey();
            }
            return null;
        }
        public Side GetSidesByName(string sideName)
        {
            foreach (Side side in _sides)
            {
                if (sideName == side.Name)
                {
                    return side;
                }
                Console.WriteLine("Please enter a valid side");
                GetSides();
                Console.ReadKey();
            }
            return null;
        }
        public Dessert GetDessertsByName(string dessertName)
        {
            foreach (Dessert dessert in _desserts)
            {
                if (dessertName == dessert.Name)
                {
                    return dessert;
                }
                Console.WriteLine("Please enter a valid dessert");
                GetDesserts();
                Console.ReadKey();
            }
            return null;
        }
        public Drink GetDrinksByName(string drinkName)
        {
            foreach (Drink drink in _drinks)
            {
                if (drinkName == drink.Name)
                {
                    return drink;
                }
                Console.WriteLine("Please enter a valid drink");
                GetDrinks();
                Console.ReadKey();
            }
            return null;
        }
        public MenuItems GetMenuItemsByNumber(int mealNum)
        {
            foreach (MenuItems items in _menu)
            {
                if (mealNum == Convert.ToInt32(Console.ReadLine()))
                {
                    return items;
                }
                Console.WriteLine("Please enter a valid Menu Item Number");
                GetMenuItems();
                Console.ReadKey();
            }
            return null;
        }
        public bool UpdateExistingEntree(string originalName, Entree newContent)
        {
            Entree oldContent = GetEntreesByName(originalName);

            if (oldContent != null)
            {
                oldContent.Name = newContent.Name;
                oldContent.Description = newContent.Description;
                oldContent.Price = newContent.Price;
                oldContent.Protein = newContent.Protein;
                oldContent.DishBase = newContent.DishBase;
                oldContent.Cheese = newContent.Cheese;
                oldContent.Topping = newContent.Topping;

                return true;
            }
            return false;
        }
        public bool UpdateExistingSide(string originalName, Side newContent)
        {
            Side oldContent = GetSidesByName(originalName);

            if (oldContent != null)
            {
                oldContent.Name = newContent.Name;
                oldContent.Description = newContent.Description;
                oldContent.Price = newContent.Price;
                oldContent.Protein = newContent.Protein;
                oldContent.DishBase = newContent.DishBase;
                oldContent.Cheese = newContent.Cheese;
                oldContent.Topping = newContent.Topping;

                return true;
            }
            return false;
        }
        public bool UpdateExistingDessert(string originalName, Dessert newContent)
        {
            Dessert oldContent = GetDessertsByName(originalName);

            if (oldContent != null)
            {
                oldContent.Name = newContent.Name;
                oldContent.Description = newContent.Description;
                oldContent.Price = newContent.Price;
                oldContent.DessertBase = newContent.DessertBase;
                oldContent.Topping = newContent.Topping;
                oldContent.Topping2 = newContent.Topping2;
         
                return true;
            }
            return false;
        }
        public bool UpdateExistingDrink(string originalName, Drink newContent)
        {
            Drink oldContent = GetDrinksByName(originalName);

            if (oldContent != null)
            {
                oldContent.Name = newContent.Name;
                oldContent.Price = newContent.Price;
                oldContent.Drinks = newContent.Drinks;

                return true;
            }
            return false;
        }
        public bool UpdateExistingMeal(int originalNumber, MenuItems newContent)
        {
            MenuItems oldContent = GetMenuItemsByNumber(originalNumber);

            if (oldContent != null)
            {
                oldContent.MealNum = newContent.MealNum;
                oldContent.MealName = newContent.MealName;
                oldContent.MealDesc = newContent.MealDesc;
                oldContent.Main = newContent.Main;
                oldContent.Sides = newContent.Sides;
                oldContent.Desserts = newContent.Desserts;

                return true;
            }
            return false;
        }
        public bool DeleteEntrees(string entreeName)
        {
            Entree entreeToDelete = GetEntreesByName(entreeName);
            return _entrees.Remove(entreeToDelete);
        }
        public bool DeleteSides(string sideName)
        {
            Side sideToDelete = GetSidesByName(sideName);
            return _sides.Remove(sideToDelete);
        }
        public bool DeleteDesserts(string dessertName)
        {
            Dessert dessertToDelete = GetDessertsByName(dessertName);
            return _desserts.Remove(dessertToDelete);
        }
        public bool DeleteDrinks(string drinkName)
        {
            Drink drinkToDelete = GetDrinksByName(drinkName);
            return _drinks.Remove(drinkToDelete);
        }
        public bool DeleteMenuItems(int mealNum)
        {
            MenuItems mealToDelete = GetMenuItemsByNumber(mealNum);
            return _menu.Remove(mealToDelete);
        }
    }
}
