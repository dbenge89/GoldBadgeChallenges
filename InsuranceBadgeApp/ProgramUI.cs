using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InsuranceBadgeRepo;
using System.Threading.Tasks;

namespace InsuranceBadgeApp
{
    public class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();
        private List<string> _listOfDoors = new List<string>();
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool runningProgram = true;
            while (runningProgram)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. List all badges\n" +
                    "2. Add a new badge\n" +
                    "3. Edit a badge's priveledges\n" +
                    "4. Delete an existing badge\n" +
                    "0. Quit Program\n\n\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //--List all current badges and priveledges
                        break;
                    case "2":
                        CreateNewBadge();
                        break;
                    case "3":
                        //--Edit a badge's Doors
                        break;
                    case "4":
                        //--Delete a badge
                        break;
                    case "0":
                        runningProgram = false;
                        break;
                    default:
                        Console.WriteLine("The item you selected does not exist.");
                        Console.WriteLine("Please select a valid menu item number.");
                        break;
                }
            }
        }

        public void CreateNewBadge()
        {
            Console.Clear();

            Badge badge = new Badge();

            Console.WriteLine("Enter a new badge ID:\n");
            badge.BadgeID = Console.ReadLine();

            Console.WriteLine("Would you like to add a door to this badge?\n" +
                "Enter 'y' for yes and 'n' for no\n" +
                "Or enter 'q' to go back to the main menu.\n");
            if (Console.ReadLine().ToLower() == "y")
            {
                AddNewDoorsPrompts(badge);
                Console.WriteLine("Would you like to add another doorto this badge?\n" +
                "Enter 'y' for yes and 'n' for no\n" +
                "Or enter 'q' to go back to the main menu.\n");
                if (Console.ReadLine().ToLower() == "y")
                {
                    AddNewDoorsPrompts(badge);
                }
                else if (Console.ReadLine().ToLower() == "n")
                {
                    Console.WriteLine("You may add new doors at anytime by selecting it from the main menu");
                    Console.ReadKey();
                    RunMenu();
                }
                else if (Console.ReadLine().ToLower() == "q")
                {
                    RunMenu();
                }
                else
                {
                    Console.WriteLine("Please enter a valid menu item.");
                }
            }
            else if (Console.ReadLine().ToLower() == "n")
            {
                Console.WriteLine("You may add new doors at anytime by selecting it from the main menu");
                Console.ReadKey();
                RunMenu();
            }
            else if (Console.ReadLine().ToLower() == "q")
            {
                RunMenu();
            }
            else
            {
                Console.WriteLine("Please enter a valid menu item.");
            }
        }
        public void AddNewDoorsPrompts(Badge badge)
        {
            Console.WriteLine("What door would you like to add?");
            Console.WriteLine($"{_listOfDoors}");
            _badgeRepo.AddDoorsToBadge(badge, Console.ReadLine());
            Console.WriteLine($"Door added to {badge.BadgeID} clearance");
        }
        private void UpdateBadgeClearance()
        {
            Console.WriteLine("Which badge are you updating?");
            string currentBadge = Console.ReadLine();
            Badge badge = _badgeRepo.GetBadgeByBadgeID(currentBadge);
            if (currentBadge == badge.BadgeID)
            {
                Console.WriteLine($"{currentBadge} has access to doors {badge.ListOfDoors}");
                Console.WriteLine($"What would you like to do?\n" +
                    $"To add doors to {currentBadge}, enter 'a':\n\n" +
                    $"To delete a door from {currentBadge}, enter 'd':\n\n" +
                    $"To remove all doors from {currentBadge}, enter 'remove':\n" +
                    $"Remember that you can't undo this.\n");
                if (Console.ReadLine().ToLower() == "a")
                {
                    AddNewDoorsPrompts(badge);
                    Console.ReadKey();
                }
                else if (Console.ReadLine().ToLower() == "d")
                {
                    Console.WriteLine("Which door would you like to delete?");
                    Console.WriteLine($"{badge.ListOfDoors}");
                    string door = Console.ReadLine();
                    _badgeRepo.RemoveDoorsFromBadge(badge, door);
                    Console.WriteLine("Door was deleted.");
                }
                else if (Console.ReadLine().ToLower() == "remove")
                {
                    Console.WriteLine($"Are you sure would you like to remove all doors from {badge.BadgeID}? 'y'/'n'");
                    if (Console.ReadLine().ToLower() == "y")
                    {

                    }
                    else if (Console.ReadLine().ToLower() == "n")
                    {
                        UpdateBadgeClearance();
                    }
                    else
                    {
                        Console.WriteLine("Not a valid response. Returning to Main Menu.");
                        Console.ReadKey();
                        RunMenu();
                    }
                }
                else if (Console.ReadLine().ToLower() == "q")
                {

                }
                else
                {
                    Console.WriteLine("Please enter a valid menu item.");
                }
            }
        }



    }
}
