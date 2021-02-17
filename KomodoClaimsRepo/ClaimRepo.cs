using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsRepo
{
    public class ClaimRepo
    {
        private readonly List<ClaimItems> _claimDirectory = new List<ClaimItems>();
        public int Count
        {
            get
            {
                return _claimDirectory.Count;
            }
        }

        public bool AddClaimToDirectory(ClaimItems claimItems)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Add(claimItems);
            bool claimAdded = _claimDirectory.Count > startingCount;
            return claimAdded;
        }

        public List<ClaimItems> GetClaimItems()
        {
            return _claimDirectory;
        }
        public ClaimItems GetClaimByID(int claimID)
        {
            foreach (ClaimItems claimItem in _claimDirectory)
            {
                if (claimID == claimItem.ClaimID)
                {
                    return claimItem;
                }
            }
            Console.WriteLine("There doesn't appear to be a claim with that ID");
            Console.ReadKey();
            return null;
        }
    }
}
