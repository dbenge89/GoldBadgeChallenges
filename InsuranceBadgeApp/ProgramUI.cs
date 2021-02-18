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
            Seed();
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
                        ListAllBadgesAndClearances();
                        break;
                    case "2":
                        CreateNewBadge();
                        break;
                    case "3":
                        UpdateBadgeClearance();
                        break;
                    case "4":
                        DeleteABadge();
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
        private void ListAllBadgesAndClearances()
        {
            List<Badge> badgeList = _badgeRepo.GetBadges();
            foreach (Badge badge in badgeList)
            {
                DisplayBadges(badge);
            }
            Console.ReadKey();
        }
        private void DisplayBadges(Badge badge)
        {
            List<string> doorList = badge.ListOfDoors;
            Console.WriteLine($"\n{badge.BadgeID} has access to:\n");
            DisplayDoors(doorList);
        }
        private void DisplayDoors(List<string> doorList)
        {
            doorList.ForEach(i => Console.Write("{0}\t", i));
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
            DisplayDoors(_listOfDoors);
            string door = Console.ReadLine().ToLower();
            if (_listOfDoors.Contains(door))
            {
                _badgeRepo.AddDoorsToBadge(badge, Console.ReadLine());
                Console.WriteLine($"Door added to {badge.BadgeID} clearance");
            }
            else
            {
                Console.WriteLine("There is no door by that name.");
            }
            Console.ReadKey();
        }
        private void UpdateBadgeClearance()
        {
            Console.WriteLine("Which badge are you updating?");
            string currentBadge = Console.ReadLine();
            Badge badge = _badgeRepo.GetBadgeByBadgeID(currentBadge);
            if (currentBadge == badge.BadgeID)
            {
                Console.WriteLine($"{currentBadge} has access to doors:");
                DisplayDoors(badge.ListOfDoors);
                Console.WriteLine($"\nWhat would you like to do?\n" +
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
                    DisplayDoors(badge.ListOfDoors);
                    string door = Console.ReadLine();
                    _badgeRepo.RemoveDoorsFromBadge(currentBadge, door);
                    Console.WriteLine("\nDoor was deleted.");
                }
                else if (Console.ReadLine().ToLower() == "remove")
                {
                    Console.WriteLine($"Are you sure would you like to remove all doors from {badge.BadgeID}? 'y'/'n'");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        _badgeRepo.RemoveAllDoorsFromBadge(currentBadge);
                        Console.WriteLine($"All doors have been removed from {currentBadge}");
                        Console.ReadKey();
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
                    RunMenu();
                }
                else
                {
                    Console.WriteLine("Please enter a valid menu item.");
                }
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
        private void DeleteABadge()
        {
            Console.WriteLine("Which badge would you like to remove from the system?");
            string currentBadge = Console.ReadLine();
            Badge badge = _badgeRepo.GetBadgeByBadgeID(currentBadge);
            if (currentBadge == badge.BadgeID)
            {
                Console.WriteLine($"{currentBadge} has access to doors:\n");
                DisplayDoors(badge.ListOfDoors);
                Console.WriteLine($"\nWould you like to delete {currentBadge} from the system?\n" +
                    $"Enter 'y' for yes and 'n' for no. Or Enter 'q' to return to the main menu\n\n");
                if (Console.ReadLine().ToLower() == "y")
                {
                    _badgeRepo.DeleteABadge(currentBadge);
                    Console.WriteLine($"You have deleted badge {currentBadge}");
                    Console.ReadKey();
                }
                else if (Console.ReadLine().ToLower() == "n")
                {
                    Console.WriteLine("What would you like to do?\n" +
                        "Enter 'c' to choose another badge.\n" +
                        "Enter 'q' to go to the main menu.\n\n");
                    if (Console.ReadLine().ToLower() == "c")
                    {
                        DeleteABadge();
                    }
                    else if (Console.ReadLine().ToLower() == "q")
                    {
                        RunMenu();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid menu item");
                    }
                }
                else if (Console.ReadLine().ToLower() == "q")
                {
                    RunMenu();
                }
                else
                {
                    Console.WriteLine("Please enter a valid menu item.");
                    Console.ReadKey();
                }
            }
        }
        private void Seed()
        {
            List<string> doorList1 = new List<string>();
            List<string> doorList2 = new List<string>();
            List<string> doorList3 = new List<string>();
            string door1 = "a1";
            string door2 = "a2";
            string door3 = "a3";
            string door4 = "a4";
            string door5 = "a5";
            _listOfDoors.Add(door1);
            _listOfDoors.Add(door2);
            _listOfDoors.Add(door3);
            _listOfDoors.Add(door4);
            _listOfDoors.Add(door5);
            doorList1.Add(door1);
            doorList1.Add(door2);
            doorList1.Add(door3);
            doorList2.Add(door1);
            doorList2.Add(door3);
            doorList2.Add(door5);
            doorList3.Add(door1);
            doorList3.Add(door4);
            doorList3.Add(door5);
            Badge badgeSecurity = new Badge("00000", _listOfDoors);
            Badge badge1 = new Badge("12345", doorList1);
            Badge badge2 = new Badge("23456", doorList2);
            Badge badge3 = new Badge("34567", doorList3);
            _badgeRepo.AddBadgeToBadgeList(badgeSecurity);
            _badgeRepo.AddBadgeToBadgeList(badge1);
            _badgeRepo.AddBadgeToBadgeList(badge2);
            _badgeRepo.AddBadgeToBadgeList(badge3);
        }
    }
}
