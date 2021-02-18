using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBadgeRepo
{
    public class Badge
    {
        public string BadgeID { get; set; }
        public List<string> ListOfDoors{ get; set; }
        public Badge() { }
        public Badge(string badgeID, List<string> doorList)
        {
            BadgeID = badgeID;
            ListOfDoors = doorList;
        }
    }
}
