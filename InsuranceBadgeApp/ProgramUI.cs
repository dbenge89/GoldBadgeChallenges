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
                        NewBadgeMenu();
                        //--Add a new badge
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
        private void NewBadgeMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?\n" +
                "1. Generate random badge ID number\n" +
                "2. Enter new badge ID number\n" +
                "3. Return to Main Menu\n\n\n");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    CreateNewBadge();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Please enter a valid menu item number.");
                    break;
            }
        }

        public void CreateNewBadge()
        {
            //CreateNewBadgeID();
        }
        private void UpdateBadgeClearance()
        {
            Badge badge;

            Console.WriteLine("Which badge are you updating?");
            string currentBadge = Console.ReadLine();
            if (currentBadge == badge.BadgeID)
            {
                Console.WriteLine($"{currentBadge} has access to doors {doors}");
            }
        }

        
        
    }
}
