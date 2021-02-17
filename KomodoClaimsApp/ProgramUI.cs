using KomodoClaimsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsApp
{
    public class ProgramUI
    {
        private readonly ClaimRepo _claimRepo = new ClaimRepo();
        public void Run()
        {
            SeedClaimList();
            RunMenu();
        }
        private void RunMenu()
        {
            bool runProgram = true;
            int claimID = SetIDOfCurrentClaim();
            while (runProgram)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the Menu item that you would like to select:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "0. Exit\n\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        GetAllClaimItems();
                        break;
                    case "2":
                        GetNextClaimItem();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "0":
                        runProgram = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu item number.");
                        break;
                }
            }
        }
        private void DisplayClaimsHeader()
        {
            Console.WriteLine($"{" ",-5}ClaimID{" ",-2}Type{" ",-3}Description{ " ",-5}Amount{" ",-5}DateOfAccident{" ",-5}DateOfClaim{" ",-5}IsValid");
            Console.WriteLine($"{" ",-5}{(" ").PadRight(90, '-')}");
        }
        private void DisplayClaims(ClaimItems claim)
        {
            Console.WriteLine($"{" ",-5}{(" ").PadRight(90, '-')}");
            Console.WriteLine($"{" ",-5}{claim.ClaimID} {claim.ClaimType,-8} {claim.Description} {claim.ClaimAmount,10:c} {claim.DateOfIncident.ToShortDateString()} {claim.DateOfClaim.ToShortDateString()} {claim.IsValidClaim()}");
            Console.WriteLine($"{" ",-5}{(" ").PadRight(90, '-')}");

        }
        private void GetAllClaimItems()
        {
            Console.Clear();

            List<ClaimItems> listOfClaims = _claimRepo.GetClaimItems();
            DisplayClaimsHeader();
            foreach (ClaimItems claim in listOfClaims)
            {
                DisplayClaims(claim);
            }
            Console.ReadKey();
        }
        private void GetNextClaimItem()
        {
            int currentClaimID = SetIDOfCurrentClaim();
            int nextClaimID = currentClaimID + 1;
            ClaimItems nextClaim = _claimRepo.GetClaimByID(nextClaimID);


            if (nextClaim.ClaimID < (nextClaimID + 1))
            {
                DisplayClaimsHeader();
                DisplayClaims(nextClaim);
                Console.WriteLine("Do you want to deal with this claim now('y'/'n')");
                if (Console.ReadLine() == "y")
                {
                    Console.Clear();
                    DisplayClaimsHeader();
                    DisplayClaims(nextClaim);
                }
                else if (Console.ReadLine() == "n")
                {
                    Console.Clear();
                    RunMenu();
                }
                else
                {
                    Console.WriteLine("Please enter a valid response.");
                }

            }
            else
            {
                Console.WriteLine("There are no more claims");
                Console.ReadKey();
                RunMenu();
            }
            Console.ReadKey();
        }
        private void CreateNewClaim()
        {
            Console.Clear();

            ClaimItems claim = new ClaimItems();

            Console.WriteLine("Enter an ID number for the Claim");
            claim.ClaimID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select a claim type:\n" +
                "1.  Car\n" +
                "2. Home\n" +
                "3. Theft\n");

            double claimItem = Convert.ToInt32(Console.ReadLine());

            claim.ClaimType = (ClaimType)claimItem;

            Console.WriteLine("Enter a claim description:\n");
            claim.Description = Console.ReadLine();

            Console.WriteLine("Enter the amount of the claim:\n" +
                "$ ");
            claim.ClaimAmount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter the date of the incident:" +
                "please use the format 'YYYY, MM, DD'\n");
            claim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter the date the claim was filed:" +
                "please use the format 'YYYY, MM, DD'\n");
            claim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            _claimRepo.AddClaimToDirectory(claim);
        }
        private void SeedClaimList()
        {
            ClaimItems carWreck = new ClaimItems(1, ClaimType.Car, "Backed car into garage door.", 1214.53m, new DateTime(2020, 04, 12), new DateTime(2020, 05, 01));
            ClaimItems theft = new ClaimItems(2, ClaimType.Theft, "Stole tools from garage", 2236.71m, new DateTime(2021, 01, 01), new DateTime(2021, 02, 08));
            ClaimItems hailDamage = new ClaimItems(3, ClaimType.Home, "Hail storm", 13503.53m, new DateTime(2020, 07, 12), new DateTime(2020, 08, 01));
            ClaimItems truckHailDamage = new ClaimItems(4, ClaimType.Car, "Hail damage to body of truck", 3017.25m, new DateTime(2020, 07, 12), new DateTime(2020, 08, 01));
            ClaimItems floodDamage = new ClaimItems(5, ClaimType.Home, "Flood damage to first two floors", 20500.53m, new DateTime(2020, 06, 12), new DateTime(2020, 08, 01));
            _claimRepo.AddClaimToDirectory(carWreck);
            _claimRepo.AddClaimToDirectory(theft);
            _claimRepo.AddClaimToDirectory(hailDamage);
            _claimRepo.AddClaimToDirectory(truckHailDamage);
            _claimRepo.AddClaimToDirectory(floodDamage);
        }
        private int SetIDOfCurrentClaim()
        {
            int total = _claimRepo.Count;
            int currentClaim = (total - (total - 1));
            if (currentClaim > 0)
            {
                return currentClaim;
            }
            else
            {
                currentClaim = 0;
                return currentClaim;
            }
        }
    }
}
