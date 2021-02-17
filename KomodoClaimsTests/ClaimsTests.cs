using KomodoClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoClaimsTests
{
    [TestClass]
    public class ClaimsTests
    {
        private ClaimRepo _claimRepo;
        private ClaimItems _claimItems;

        [TestInitialize]
        public void Seed()
        {
            _claimRepo = new ClaimRepo();
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

            _claimItems = new ClaimItems(6, ClaimType.Car, "Hit by deer", 3233.23m, new DateTime(2020, 07, 07), new DateTime(2020, 08, 01));
            _claimRepo.AddClaimToDirectory(_claimItems);
        }
        [TestMethod]
        public void AddClaims_ShouldAddNewClaimsToDirectory()
        {
            ClaimItems claimExample = new ClaimItems(7, ClaimType.Home, "Claim example", 123.45m, new DateTime(2020, 01, 01), new DateTime(2020, 02, 01));

            bool addedClaim = _claimRepo.AddClaimToDirectory(claimExample);

            Console.WriteLine(_claimRepo.Count);
            Console.WriteLine(addedClaim);
            Console.WriteLine(claimExample.Description);

            Assert.IsTrue(addedClaim);
        }
        [TestMethod]
        public void GetClaimByID_ShouldGetCorrectClaim()
        {
            ClaimItems searchResult = _claimRepo.GetClaimByID(6);

            Assert.AreEqual(searchResult, _claimItems);

        }
    }
}
