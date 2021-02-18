using KomodoMenuRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoMenuApp
{
    public class ProgramUI
    {
        private readonly MenuRepo _menuRepo = new MenuRepo();
        public void Run()
        {
            SeedMenu();
            RunMenu();
        }
        private void RunMenu()
        {
            bool runningMenu = true;
            while (runningMenu)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the menu item that you would like to select:\n" +
                    "1. Show all meals\n" +
                    "2. Entrees, Sides, Desserts, and Drinks Menu\n" +
                    "3. Find a Meal by Meal Number\n" +
                    "4. Add a new Meal to the menu\n" +
                    "5. Update a Meal\n" +
                    "6. Delete a Meal\n" +
                    "0. Exit Menu\n\n\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllMeals();
                        break;
                    case "2":
                        ItemsMenu();
                        break;
                    case "3":
                        GetAllMealsByMealNumber();
                        break;
                    case "4":
                        CreateNewMeal();
                        break;
                    case "5":
                        UpdateAMeal();
                        break;
                    case "6":
                        DeleteAMeal();
                        break;
                    case "0":
                        runningMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu item number.");
                        break;
                }
            }
        }
        private void ItemsMenu()
        {
            Console.Clear();
            bool itemsMenuRunning = true;
            while (itemsMenuRunning)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the menu item you would like to select:\n" +
                    "1. Show all items by type (entrees, sides, desserts, or drinks)\n" +
                    "2. Add new items\n" +
                    "3. Update items\n" +
                    "4. Delete items\n" +
                    "0. Exit Menu\n\n\n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllItemsByType();
                        break;
                    case "2":
                        AddNewItems();
                        break;
                    case "3":
                        UpdateAnItem();
                        break;
                    case "4":
                        DeleteAnItem();
                        break;
                    case "0":
                        itemsMenuRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu item number or enter '0' to go back to the main menu.");
                        break;

                }
            }
        }
        private void ShowAllMeals()
        {
            Console.Clear();

            List<MenuItems> listOfMenuItems = _menuRepo.GetMenuItems();

            foreach (MenuItems menuItems in listOfMenuItems)
            {
                DisplayMeals(menuItems);
            }
            Console.ReadKey();
            RunMenu();
        }
        private void GetAllMealsByMealNumber()
        {
            Console.WriteLine("Please enter the meal number you would like to see:");
            int mealNumber = Convert.ToInt32(Console.ReadLine());

            MenuItems meal = _menuRepo.GetMenuItemsByNumber(mealNumber);

            if (meal != null)
            {
                DisplayMeals(meal);
                Console.ReadKey();
                RunMenu();
            }
            else
            {
                Console.WriteLine("Invalid meal number. Could not find any results.");
            }
            Console.ReadKey();
        }
        private void ItemsMenuPrompt()
        {
            Console.Clear();
            Console.WriteLine("Enter 'entree' 'side' 'dessert' or 'drink' \n" +
                "Or enter 'q' to go back to the Items Menu\n\n");
        }
        private void ShowAllItemsByType()
        {
            ItemsMenuPrompt();
            string itemMenuChoice = Console.ReadLine().ToLower();
            if (itemMenuChoice.ToLower() == "entree")
            {
                List<Entree> listOfEntrees = _menuRepo.GetEntrees();

                foreach (Entree entree in listOfEntrees)
                {
                    DisplayEntrees(entree);
                }
                Console.ReadKey();
            }
            else if (itemMenuChoice.ToLower() == "side")
            {
                List<Side> listOfSides = _menuRepo.GetSides();

                foreach (Side side in listOfSides)
                {
                    DisplaySides(side);
                }
                Console.ReadKey();
            }
            else if (itemMenuChoice.ToLower() == "dessert")
            {
                List<Dessert> listOfDesserts = _menuRepo.GetDesserts();

                foreach (Dessert dessert in listOfDesserts)
                {
                    DisplayDesserts(dessert);
                }
                Console.ReadKey();
            }
            else if (itemMenuChoice.ToLower() == "drink")
            {
                List<Drink> listOfDrinks = _menuRepo.GetDrinks();

                foreach (Drink drink in listOfDrinks)
                {
                    DisplayDrinks(drink);
                }
                Console.ReadKey();
            }
            else if (itemMenuChoice.ToLower() == "q")
            {
                ItemsMenu();
            }
            else
            {
                Console.WriteLine("Please enter an actual menu item type");
            }
        }
        private void AddNewItems()
        {
            ItemsMenuPrompt();
            string itemMenuChoice = Console.ReadLine().ToLower();
            if (itemMenuChoice.ToLower() == "entree")
            {
                CreateNewEntree();
            }
            else if (itemMenuChoice.ToLower() == "side")
            {
                CreateNewSide();
            }
            else if (itemMenuChoice.ToLower() == "dessert")
            {
                CreateNewDesserts();
            }
            else if (itemMenuChoice.ToLower() == "drink")
            {
                CreateNewDrinks();
            }
            else if (itemMenuChoice.ToLower() == "q")
            {
                ItemsMenu();
            }
            else
            {
                Console.WriteLine("Please enter an actual menu item type");
            }
        }
        private void CreateNewEntree()
        {
            Console.Clear();

            Entree entree = new Entree();

            Console.WriteLine("Please enter an entree name");
            entree.Name = Console.ReadLine();

            Console.WriteLine("Please enter a description for the entree");
            entree.Description = Console.ReadLine();

            Console.WriteLine("Please enter a price for this item");
            entree.Price = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Please select the protein:\n" +
                            "1. Beef\n" +
                            "2. Chicken\n" +
                            "3. Bacon\n" +
                            "4. Fish\n" +
                            "5. Tofu\n" +
                            "14. NA\n");
            string entreeProtein = Console.ReadLine();

            int proteinID = int.Parse(entreeProtein);

            entree.Protein = (IngredientsType)proteinID;

            Console.WriteLine("Select a base:\n" +
                            "4. Tofu\n" +
                            "5. Lettuce\n" +
                            "6. Spinach\n" +
                            "11. Brown Rice\n" +
                            "12. White Rice\n" +
                            "13. Cauliflower Rice\n" +
                            "14. NA\n");
            string entreeBase = Console.ReadLine();

            int baseID = int.Parse(entreeBase);

            entree.DishBase = (IngredientsType)baseID;

            Console.WriteLine("Select a topping:\n" +
                           "2. Bacon\n" +
                           "5. Lettuce\n" +
                           "6. Spinach\n" +
                           "7. Tomato\n" +
                           "8. Onions\n" +
                           "14. NA\n");
            string entreeTopping = Console.ReadLine();

            int toppingID = int.Parse(entreeTopping);

            entree.Topping = (IngredientsType)toppingID;

            Console.WriteLine("Select a cheese:\n" +
                          "9. Cheese\n" +
                          "10. Vegan Cheese\n" +
                          "14. NA\n");
            string entreeCheese = Console.ReadLine();

            int cheeseID = int.Parse(entreeCheese);

            entree.Cheese = (IngredientsType)cheeseID;

            _menuRepo.AddEntreesToDirectory(entree);
        }
        private void CreateNewSide()
        {
            Console.Clear();

            Side side = new Side();

            Console.WriteLine("Please enter a side name");
            side.Name = Console.ReadLine();

            Console.WriteLine("Please enter a description for the side");
            side.Description = Console.ReadLine();

            Console.WriteLine("Please enter a price for this item");
            side.Price = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Select a protein:\n" +
                            "1. Beef\n" +
                            "2. Chicken\n" +
                            "3. Bacon\n" +
                            "4. Fish\n" +
                            "5. Tofu\n" +
                            "14. NA\n");
            string sideProtein = Console.ReadLine();

            int proteinID = int.Parse(sideProtein);

            side.Protein = (IngredientsType)proteinID;

            Console.WriteLine("Select a base:\n" +
                            "4. Tofu\n" +
                            "5. Lettuce\n" +
                            "6. Spinach\n" +
                            "11. Brown Rice\n" +
                            "12. White Rice\n" +
                            "13. Cauliflower Rice\n" +
                            "14. NA\n");
            string sideBase = Console.ReadLine();

            int baseID = int.Parse(sideBase);

            side.DishBase = (IngredientsType)baseID;

            Console.WriteLine("Select a topping:\n" +
                           "2. Bacon\n" +
                           "5. Lettuce\n" +
                           "6. Spinach\n" +
                           "7. Tomato\n" +
                           "8. Onions\n" +
                           "14. NA\n");
            string sideTopping = Console.ReadLine();

            int toppingID = int.Parse(sideTopping);

            side.Topping = (IngredientsType)toppingID;

            Console.WriteLine("Select a cheese:\n" +
                                     "9. Cheese\n" +
                                     "10. Vegan Cheese\n" +
                                     "14. NA\n");
            string sideCheese = Console.ReadLine();

            int cheeseID = int.Parse(sideCheese);

            side.Cheese = (IngredientsType)cheeseID;

            _menuRepo.AddSidesToDirectory(side);
        }
        private void CreateNewDesserts()
        {
            Console.Clear();

            Dessert dessert = new Dessert();

            Console.WriteLine("Please enter a dessert name");
            dessert.Name = Console.ReadLine();

            Console.WriteLine("Please enter a description for the dessert");
            dessert.Description = Console.ReadLine();

            Console.WriteLine("Please enter a price for this item");
            dessert.Price = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Select a base:\n" +
                            "1. Brownie\n" +
                            "2. Cookie\n" +
                            "3. IceCream\n" +
                            "4. Rice Pudding\n" +
                            "10. NA\n");
            string dessertBase = Console.ReadLine();

            int baseID = int.Parse(dessertBase);

            dessert.DessertBase = (DessertIngredientsType)baseID;

            Console.WriteLine("Select a topping:\n" +
                           "1. Brownie\n" +
                           "2. Cookie\n" +
                           "3. IceCream\n" +
                           "5. Caramel\n" +
                           "6. Chocolate\n" +
                           "7. Whip Cream\n" +
                           "8. Brown Sugar\n" +
                           "9. Cherry\n" +
                           "10. NA\n");
            string dessertTopping = Console.ReadLine();

            int toppingID = int.Parse(dessertTopping);

            dessert.Topping = (DessertIngredientsType)toppingID;

            Console.WriteLine("Select another topping:\n" +
                            "1. Brownie\n" +
                            "2. Cookie\n" +
                            "3. IceCream\n" +
                            "5. Caramel\n" +
                            "6. Chocolate\n" +
                            "7. Whip Cream\n" +
                            "8. Brown Sugar\n" +
                            "9. Cherry\n" +
                            "10. NA\n");
            string dessertTopping2 = Console.ReadLine();

            int topping2ID = int.Parse(dessertTopping2);

            dessert.Topping = (DessertIngredientsType)topping2ID;

            _menuRepo.AddDessertsToDirectory(dessert);
        }
        private void CreateNewDrinks()
        {
            Console.Clear();

            Drink drink = new Drink();

            Console.WriteLine("Please enter a drink name");
            drink.Name = Console.ReadLine();

            Console.WriteLine("Please enter a price for this item");
            drink.Price = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Select a size for this dessert");
            string drinkSize = Console.ReadLine();

            int drinkID = int.Parse(drinkSize);

            drink.Drinks = (DrinkType)drinkID;

            _menuRepo.AddDrinksToDirectory(drink);
        }
        private void CreateNewMeal()
        {
            Console.Clear();

            MenuItems meal = new MenuItems();

            Console.WriteLine("Please enter a meal number");
            meal.MealNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter a meal name");
            meal.MealName = Console.ReadLine();

            Console.WriteLine("Please enter short meal description");
            meal.MealDesc = Console.ReadLine();

            Console.WriteLine("Please enter an entree");
            string entreeName = Console.ReadLine();
            meal.Main = _menuRepo.GetEntreesByName(entreeName);

            Console.WriteLine("Please enter a side");
            string sideName = Console.ReadLine();
            meal.Sides = _menuRepo.GetSidesByName(sideName);

            Console.WriteLine("Please enter a dessert");
            string dessertName = Console.ReadLine();
            meal.Desserts = _menuRepo.GetDessertsByName(dessertName);

            _menuRepo.AddMealsToDirectory(meal);
        }
        private void UpdateAnItem()
        {
            ItemsMenuPrompt();
            string itemMenuChoice = Console.ReadLine().ToLower();
            if (itemMenuChoice.ToLower() == "entree")
            {
                UpdateAnEntree();
            }
            else if (itemMenuChoice.ToLower() == "side")
            {
                UpdateASide();
            }
            else if (itemMenuChoice.ToLower() == "dessert")
            {
                UpdateADessert();
            }
            else if (itemMenuChoice.ToLower() == "drink")
            {
                UpdateADrink();
            }
            else if (itemMenuChoice.ToLower() == "q")
            {
                ItemsMenu();
            }
            else
            {
                Console.WriteLine("Please enter an actual menu item type");
            }
        }
        private void UpdateAnEntree()
        {
            Entree entree;

            do
            {
                Console.Clear();
                _menuRepo.GetEntrees();
                Console.WriteLine("Enter an entree name or enter 'cancel' to quit: \n");
                string entreeName = Console.ReadLine();
                entree = _menuRepo.GetEntreesByName(entreeName);
                if (entreeName == "cancel")
                {
                    return;
                }
            } while (entree == null);
            {
                Console.Clear();
                Console.WriteLine("What would you like to update?\n" +
                    "1. Entree name\n" +
                    "2. Entree description\n" +
                    "3. Entree price\n" +
                    "4. Protein included\n" +
                    "5. Base included\n" +
                    "6. Topping included\n" +
                    "7. Cheese included\n" +
                    "0. Go back to items menu");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter a new entree name:\n");
                        string newEntreeName = Console.ReadLine();
                        entree.Name = newEntreeName;
                        break;
                    case "2":
                        Console.WriteLine("Enter a new entree description:\n");
                        string newDescription = Console.ReadLine();
                        entree.Description = newDescription;
                        break;
                    case "3":
                        Console.WriteLine("Update the price:\n");
                        decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                        entree.Price = newPrice;
                        break;
                    case "4":
                        Console.WriteLine("Update the protein:\n" +
                            "1. Beef\n" +
                            "2. Chicken\n" +
                            "3. Bacon\n" +
                            "4. Fish\n" +
                            "5. Tofu\n" +
                            "14. NA\n");

                        string newProtein = Console.ReadLine();
                        switch (newProtein)
                        {
                            case "1":
                            case "2":
                            case "3":
                            case "4":
                            case "5":
                            case "14":
                                int proteinNumber = Convert.ToInt32(newProtein);
                                entree.Protein = (IngredientsType)proteinNumber;
                                break;
                            default:
                                Console.WriteLine("Please select a valid protein number");
                                break;
                        }
                        break;
                    case "5":
                        Console.WriteLine("Update the base:\n" +
                           "4. Tofu\n" +
                           "5. Lettuce\n" +
                           "6. Spinach\n" +
                           "11. Brown Rice\n" +
                           "12. White Rice\n" +
                           "13. Cauliflower Rice\n" +
                           "14. NA\n");

                        string newBase = Console.ReadLine();
                        switch (newBase)
                        {
                            case "4":
                            case "5":
                            case "6":
                            case "11":
                            case "12":
                            case "13":
                            case "14":
                                int baseNumber = Convert.ToInt32(newBase);
                                entree.DishBase = (IngredientsType)baseNumber;
                                break;
                            default:
                                Console.WriteLine("Please select a valid base number");
                                break;
                        }
                        break;
                    case "6":
                        Console.WriteLine("Update the topping:\n" +
                           "2. Bacon\n" +
                           "5. Lettuce\n" +
                           "6. Spinach\n" +
                           "7. Tomato\n" +
                           "8. Onions\n" +
                           "14. NA\n");

                        string newTopping = Console.ReadLine();
                        switch (newTopping)
                        {
                            case "2":
                            case "5":
                            case "6":
                            case "7":
                            case "8":
                            case "14":
                                int toppingNumber = Convert.ToInt32(newTopping);
                                entree.Topping = (IngredientsType)toppingNumber;
                                break;
                            default:
                                Console.WriteLine("Please select a valid topping number");
                                break;
                        }
                        break;
                    case "7":
                        Console.WriteLine("Update the cheese:\n" +
                           "9. Cheese\n" +
                           "10. Vegan Cheese\n" +
                           "14. NA\n");

                        string newCheese = Console.ReadLine();
                        switch (newCheese)
                        {
                            case "9":
                            case "10":
                            case "14":
                                int cheeseNumber = Convert.ToInt32(newCheese);
                                entree.Cheese = (IngredientsType)cheeseNumber;
                                break;
                            default:
                                Console.WriteLine("Please select a valid cheese number");
                                break;
                        }
                        break;
                    case "0":
                        RunMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a correct menu item");
                        break;
                }
            }
        }
        private void UpdateASide()
        {
            Side side;

            do
            {
                Console.Clear();
                _menuRepo.GetSides();
                Console.WriteLine("Enter a side name or enter 'cancel' to quit: \n");
                string sideName = Console.ReadLine();
                side = _menuRepo.GetSidesByName(sideName);
                if (sideName == "cancel")
                {
                    return;
                }
            } while (side == null);
            {
                Console.Clear();
                Console.WriteLine("What would you like to update?\n" +
                    "1. Side name\n" +
                    "2. Side description\n" +
                    "3. Side price\n" +
                    "4. Protein included\n" +
                    "5. Base included\n" +
                    "6. Topping included\n" +
                    "7. Cheese included\n" +
                    "0. Go back to items menu");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter a new side name:\n");
                        string newSideName = Console.ReadLine();
                        side.Name = newSideName;
                        break;
                    case "2":
                        Console.WriteLine("Enter a new side description:\n");
                        string newDescription = Console.ReadLine();
                        side.Description = newDescription;
                        break;
                    case "3":
                        Console.WriteLine("Update the price:\n");
                        decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                        side.Price = newPrice;
                        break;
                    case "4":
                        Console.WriteLine("Update the protein:\n" +
                            "1. Beef\n" +
                            "2. Chicken\n" +
                            "3. Bacon\n" +
                            "4. Fish\n" +
                            "5. Tofu\n" +
                            "14. NA\n");

                        string newProtein = Console.ReadLine();
                        switch (newProtein)
                        {
                            case "1":
                            case "2":
                            case "3":
                            case "4":
                            case "5":
                            case "14":
                                int proteinNumber = Convert.ToInt32(newProtein);
                                side.Protein = (IngredientsType)proteinNumber;
                                break;
                            default:
                                Console.WriteLine("Please select a valid protein number");
                                break;
                        }
                        break;
                    case "5":
                        Console.WriteLine("Update the base:\n" +
                           "4. Tofu\n" +
                           "5. Lettuce\n" +
                           "6. Spinach\n" +
                           "11. Brown Rice\n" +
                           "12. White Rice\n" +
                           "13. Cauliflower Rice\n" +
                           "14. NA\n");

                        string newBase = Console.ReadLine();
                        switch (newBase)
                        {
                            case "4":
                            case "5":
                            case "6":
                            case "11":
                            case "12":
                            case "13":
                            case "14":
                                int baseNumber = Convert.ToInt32(newBase);
                                side.DishBase = (IngredientsType)baseNumber;
                                break;
                            default:
                                Console.WriteLine("Please select a valid base number");
                                break;
                        }
                        break;
                    case "6":
                        Console.WriteLine("Update the topping:\n" +
                           "2. Bacon\n" +
                           "5. Lettuce\n" +
                           "6. Spinach\n" +
                           "7. Tomato\n" +
                           "8. Onions\n" +
                           "14. NA\n");

                        string newTopping = Console.ReadLine();
                        switch (newTopping)
                        {
                            case "2":
                            case "5":
                            case "6":
                            case "7":
                            case "8":
                            case "14":
                                int toppingNumber = Convert.ToInt32(newTopping);
                                side.Topping = (IngredientsType)toppingNumber;
                                break;
                            default:
                                Console.WriteLine("Please select a valid topping number");
                                break;
                        }
                        break;
                    case "7":
                        Console.WriteLine("Update the cheese:\n" +
                           "9. Cheese\n" +
                           "10. Vegan Cheese\n" +
                           "14. NA\n");

                        string newCheese = Console.ReadLine();
                        switch (newCheese)
                        {
                            case "9":
                            case "10":
                            case "14":
                                int cheeseNumber = Convert.ToInt32(newCheese);
                                side.Cheese = (IngredientsType)cheeseNumber;
                                break;
                            default:
                                Console.WriteLine("Please select a valid cheese number");
                                break;
                        }
                        break;
                    case "0":
                        RunMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a correct menu item");
                        break;
                }
            }
        }
        private void UpdateADessert()
        {
            Dessert dessert;

            do
            {
                Console.Clear();
                _menuRepo.GetDesserts();
                Console.WriteLine("Enter a dessert name or enter 'cancel' to quit: \n");
                string dessertName = Console.ReadLine();
                dessert = _menuRepo.GetDessertsByName(dessertName);
                if (dessertName == "cancel")
                {
                    return;
                }
            } while (dessert == null);
            {
                Console.Clear();
                Console.WriteLine("What would you like to update?\n" +
                    "1. Dessert name\n" +
                    "2. Dessert description\n" +
                    "3. Dessert price\n" +
                    "4. Base included\n" +
                    "5. First topping included\n" +
                    "6. Second topping included\n" +
                    "0. Go back to items menu");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter a new dessert name:\n");
                        string newDessertName = Console.ReadLine();
                        dessert.Name = newDessertName;
                        break;
                    case "2":
                        Console.WriteLine("Enter a new dessert description:\n");
                        string newDescription = Console.ReadLine();
                        dessert.Description = newDescription;
                        break;
                    case "3":
                        Console.WriteLine("Update the price:\n");
                        decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                        dessert.Price = newPrice;
                        break;
                    case "4":
                        Console.WriteLine("Update the base:\n" +
                            "1. Brownie\n" +
                            "2. Cookie\n" +
                            "3. IceCream\n" +
                            "4. Rice Pudding\n" +
                            "10. NA\n");

                        string newBase = Console.ReadLine();
                        switch (newBase)
                        {
                            case "1":
                            case "2":
                            case "3":
                            case "4":
                            case "10":
                                int baseNumber = Convert.ToInt32(newBase);
                                dessert.DessertBase = (DessertIngredientsType)baseNumber;
                                break;
                            default:
                                Console.WriteLine("Please select a valid base number");
                                break;
                        }
                        break;
                    case "5":
                        Console.WriteLine("Update the first toppings:\n" +
                           "1. Brownie\n" +
                           "2. Cookie\n" +
                           "3. IceCream\n" +
                           "5. Caramel\n" +
                           "6. Chocolate\n" +
                           "7. Whip Cream\n" +
                           "8. Brown Sugar\n" +
                           "9. Cherry\n" +
                           "10. NA\n");

                        string newTopping = Console.ReadLine();
                        switch (newTopping)
                        {
                            case "1":
                            case "2":
                            case "3":
                            case "5":
                            case "6":
                            case "7":
                            case "8":
                            case "9":
                            case "10":
                                int toppingNumber = Convert.ToInt32(newTopping);
                                dessert.Topping = (DessertIngredientsType)toppingNumber;
                                break;
                            default:
                                Console.WriteLine("Please select a valid topping number");
                                break;
                        }
                        break;
                    case "6":
                        Console.WriteLine("Update the second toppings:\n" +
                           "1. Brownie\n" +
                           "2. Cookie\n" +
                           "3. IceCream\n" +
                           "5. Caramel\n" +
                           "6. Chocolate\n" +
                           "7. Whip Cream\n" +
                           "8. Brown Sugar\n" +
                           "9. Cherry\n" +
                           "10. NA\n");

                        string newTopping2 = Console.ReadLine();
                        switch (newTopping2)
                        {
                            case "1":
                            case "2":
                            case "3":
                            case "5":
                            case "6":
                            case "7":
                            case "8":
                            case "9":
                            case "10":
                                int toppingNumber2 = Convert.ToInt32(newTopping2);
                                dessert.Topping2 = (DessertIngredientsType)toppingNumber2;
                                break;
                            default:
                                Console.WriteLine("Please select a valid topping number");
                                break;
                        }
                        break;
                    case "0":
                        RunMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a correct menu item");
                        break;
                }
            }
        }
        private void UpdateADrink()
        {
            Drink drink;

            do
            {
                Console.Clear();
                _menuRepo.GetDrinks();
                Console.WriteLine("Enter a drink name or enter 'cancel' to quit: \n");
                string drinkName = Console.ReadLine();
                drink = _menuRepo.GetDrinksByName(drinkName);
                if (drinkName == "cancel")
                {
                    return;
                }
            } while (drink == null);
            {
                Console.Clear();
                Console.WriteLine("What would you like to update?\n" +
                    "1. Drink name\n" +
                    "2. Drink price\n" +
                    "3. Drink size\n" +
                    "0. Go back to items menu");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter a new drink name:\n");
                        string newDrinkName = Console.ReadLine();
                        drink.Name = newDrinkName;
                        break;
                    case "2":
                        Console.WriteLine("Update the price:\n");
                        decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                        drink.Price = newPrice;
                        break;
                    case "3":
                        Console.WriteLine("Update the size:\n" +
                            "1. Kids size\n" +
                            "2. Small\n" +
                            "3. Medium\n" +
                            "4. Large\n" +
                            "5. XL\n" +
                            "6. Regular");

                        string newSize = Console.ReadLine();
                        switch (newSize)
                        {
                            case "1":
                            case "2":
                            case "3":
                            case "4":
                            case "5":
                            case "6":
                                int sizeNumber = Convert.ToInt32(newSize);
                                drink.Drinks = (DrinkType)sizeNumber;
                                break;
                            default:
                                Console.WriteLine("Please select a valid size number");
                                break;
                        }
                        break;
                    case "0":
                        RunMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a correct menu item");
                        break;
                }
            }
        }
        private void UpdateAMeal()
        {
            MenuItems meal;

            do
            {
                Console.Clear();
                _menuRepo.GetMenuItems();
                Console.WriteLine("Enter a meal number, or enter '0' to quit: \n");
                int mealNum = Convert.ToInt32(Console.ReadLine());
                meal = _menuRepo.GetMenuItemsByNumber(mealNum);
                if (mealNum == 0)
                {
                    return;
                }
            } while (meal == null);
            {
                Console.Clear();
                Console.WriteLine("What would you like to update?\n" +
                    "1. Meal number\n" +
                    "2. Meal name\n" +
                    "3. Meal description\n" +
                    "4. Main included\n" +
                    "5. Side included\n" +
                    "6. Dessert included\n" +
                    "0. Go back to main menu");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter a new meal number:\n");
                        int newMealNum = Convert.ToInt32(Console.ReadLine());
                        meal.MealNum = newMealNum;
                        break;
                    case "2":
                        Console.WriteLine("Enter a new meal name:\n");
                        string newName = Console.ReadLine();
                        meal.MealName = newName;
                        break;
                    case "3":
                        Console.WriteLine("Enter a new description:\n");
                        string newDescription = Console.ReadLine();
                        meal.MealDesc = newDescription;
                        break;
                    case "4":
                        Console.WriteLine("Update the entree:\n");
                        string newEntree = Console.ReadLine();
                        Entree entree = _menuRepo.GetEntreesByName(newEntree);
                        meal.Main = entree;
                        break;
                    case "5":
                        Console.WriteLine("Update the side:\n");
                        string newSide = Console.ReadLine();
                        Side side = _menuRepo.GetSidesByName(newSide);
                        meal.Sides = side;
                        break;
                    case "6":
                        Console.WriteLine("Update the dessert:\n");
                        string newDessert = Console.ReadLine();
                        Dessert dessert = _menuRepo.GetDessertsByName(newDessert);
                        meal.Desserts = dessert;
                        break;
                    case "0":
                        RunMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a correct menu item");
                        break;
                }
            }
        }
        private void DeleteAnItem()
        {
            ItemsMenuPrompt();
            string itemMenuChoice = Console.ReadLine().ToLower();
            if (itemMenuChoice.ToLower() == "entree")
            {
                DeleteAnEntree();
            }
            else if (itemMenuChoice.ToLower() == "side")
            {
                DeleteASide();
            }
            else if (itemMenuChoice.ToLower() == "dessert")
            {
                DeleteADessert();
            }
            else if (itemMenuChoice.ToLower() == "drink")
            {
                DeleteADrink();
            }
            else if (itemMenuChoice.ToLower() == "q")
            {
                ItemsMenu();
            }
            else
            {
                Console.WriteLine("Please enter an actual menu item type");
            }
        }
        private void DeleteAnEntree()
        {
            Console.Clear();

            Console.WriteLine("What entree would you like to delete?\n");

            List<Entree> entreeList = _menuRepo.GetEntrees();

            int count = 1;

            foreach (Entree entree in entreeList)
            {
                count++;
                Console.WriteLine($"{count}. {entree.Name}");
            }

            int targetContentId = int.Parse(Console.ReadLine());

            if (targetContentId >= 0 && targetContentId < entreeList.Count)
            {
                Entree desiredEntree = entreeList[targetContentId];
                if (_menuRepo.DeleteEntrees(desiredEntree.Name))
                {
                    Console.WriteLine($"{desiredEntree.Name} sucessfully removed.");
                }
                else
                {
                    Console.WriteLine("Entree has not been removed.");
                }
            }
            else
            {
                Console.WriteLine("No entree has that name.");
            }
            Console.ReadKey();
        }
        private void DeleteASide()
        {
            Console.Clear();

            Console.WriteLine("What side would you like to delete?\n");

            List<Side> sideList = _menuRepo.GetSides();

            int count = 1;

            foreach (Side side in sideList)
            {
                count++;
                Console.WriteLine($"{count}. {side.Name}");
            }

            int targetContentId = int.Parse(Console.ReadLine());

            if (targetContentId >= 0 && targetContentId < sideList.Count)
            {
                Entree desiredSide = sideList[targetContentId];
                if (_menuRepo.DeleteSides(desiredSide.Name))
                {
                    Console.WriteLine($"{desiredSide.Name} sucessfully removed.");
                }
                else
                {
                    Console.WriteLine("Side has not been removed.");
                }
            }
            else
            {
                Console.WriteLine("No side has that name.");
            }
            Console.ReadKey();
        }
        private void DeleteADessert()
        {
            Console.Clear();

            Console.WriteLine("What dessert would you like to delete?\n");

            List<Dessert> dessertList = _menuRepo.GetDesserts();

            int count = 1;

            foreach (Dessert dessert in dessertList)
            {
                count++;
                Console.WriteLine($"{count}. {dessert.Name}");
            }

            int targetContentId = int.Parse(Console.ReadLine());

            if (targetContentId >= 0 && targetContentId < dessertList.Count)
            {
                Dessert desiredDessert = dessertList[targetContentId];
                if (_menuRepo.DeleteDesserts(desiredDessert.Name))
                {
                    Console.WriteLine($"{desiredDessert.Name} sucessfully removed.");
                }
                else
                {
                    Console.WriteLine("Entree has not been removed.");
                }
            }
            else
            {
                Console.WriteLine("No entree has that name.");
            }
            Console.ReadKey();
        }
        private void DeleteADrink()
        {
            Console.Clear();

            Console.WriteLine("What drink would you like to delete?\n");

            List<Drink> drinkList = _menuRepo.GetDrinks();

            int count = 1;

            foreach (Drink drink in drinkList)
            {
                count++;
                Console.WriteLine($"{count}. {drink.Name}");
            }

            int targetContentId = int.Parse(Console.ReadLine());

            if (targetContentId >= 0 && targetContentId < drinkList.Count)
            {
                Drink desiredDrink = drinkList[targetContentId];
                if (_menuRepo.DeleteDrinks(desiredDrink.Name))
                {
                    Console.WriteLine($"{desiredDrink.Name} sucessfully removed.");
                }
                else
                {
                    Console.WriteLine("Drink has not been removed.");
                }
            }
            else
            {
                Console.WriteLine("No drink has that name.");
            }
            Console.ReadKey();
        }
        private void DeleteAMeal()
        {
            Console.Clear();

            Console.WriteLine("What meal would you like to delete?\n");

            List<MenuItems> mealList = _menuRepo.GetMenuItems();

            foreach (MenuItems meal in mealList)
            {
                DisplayMeals(meal);
            }


            int mealNum = Convert.ToInt32(Console.ReadLine());


            if (mealNum >= 0 && mealNum < mealList.Count)
            {
                MenuItems desiredMeal = mealList[mealNum];
                if (_menuRepo.DeleteMenuItems(desiredMeal.MealNum))
                {
                    Console.WriteLine($"{desiredMeal.MealName} sucessfully removed.");
                }
                else
                {
                    Console.WriteLine("Meal has not been removed.");
                }
            }
            else
            {
                Console.WriteLine("No meal has that menu number.");
            }
            Console.ReadKey();
        }
        private void DisplayEntrees(Entree entree)
        {
            Console.WriteLine($"Entree: {entree.Name}\n" +
                $"Description: {entree.Description}\n" +
                $"Base: {entree.DishBase}\n" +
                $"Protein: {entree.Protein}\n" +
                $"Toppings: {entree.Topping}\n" +
                $"Cheese: {entree.Cheese}\n\n\n");
        }
        private void DisplaySides(Side side)
        {
            Console.WriteLine($"Side: {side.Name}\n" +
                $"Description: {side.Description}\n" +
                $"Base: {side.DishBase}\n" +
                $"Protein: {side.Protein}\n" +
                $"Toppings: {side.Topping}\n" +
                $"Cheese: {side.Cheese}\n" +
                $"Price: {side.Price}\n\n\n");
        }
        private void DisplayDesserts(Dessert dessert)
        {
            Console.WriteLine($"Dessert: {dessert.Name}\n" +
                $"Description: {dessert.Description}\n" +
                $"Base: {dessert.DessertBase}\n" +
                $"Topping: {dessert.Topping}\n" +
                $"2nd Topping: {dessert.Topping2}\n" +
                $"Price: {dessert.Price}\n\n\n");
        }
        private void DisplayDrinks(Drink drink)
        {
            Console.WriteLine($"Drink: {drink.Name}\n" +
                $"Size: {drink.Drinks}\n" +
                $"Price: {drink.Price}\n\n\n");
        }
        private void DisplayMeals(MenuItems menuItems)
        {
            Console.WriteLine($"Menu Number: {menuItems.MealNum}\n" +
                $"Meal Name: {menuItems.MealName}\n" +
                $"Meal Description: {menuItems.MealName}\n" +
                $"Meal Entree: {menuItems.Main.Name}\n" +
                $"Meal Side: {menuItems.Sides.Name}\n" +
                $"Meal Dessert: {menuItems.Desserts.Name}\n" +
                $"Meal Price: {menuItems.MealPrice(menuItems.Main, menuItems.Sides, menuItems.Desserts)}\n\n\n");
        }
        private void SeedMenu()
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
            _menuRepo.AddEntreesToDirectory(firstEntree);
            _menuRepo.AddEntreesToDirectory(secondEntree);
            _menuRepo.AddSidesToDirectory(firstSide);
            _menuRepo.AddSidesToDirectory(secondSide);
            _menuRepo.AddDessertsToDirectory(firstDessert);
            _menuRepo.AddDessertsToDirectory(secondDessert);
            _menuRepo.AddDessertsToDirectory(thirdDessert);
            _menuRepo.AddDrinksToDirectory(firstDrink);
            _menuRepo.AddDrinksToDirectory(secondDrink);
            _menuRepo.AddMealsToDirectory(firstMeal);
            _menuRepo.AddMealsToDirectory(secondMeal);
        }
    }
}
