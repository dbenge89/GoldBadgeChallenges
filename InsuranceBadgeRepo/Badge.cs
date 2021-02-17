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
        public List<Door> ListOfDoors{ get; set; }
        public Badge() { }
        public Badge(string badgeID, List<Door> doorList)
        {
            BadgeID = badgeID;
            ListOfDoors = doorList;
        }
    }
    public class Door
    {
        public string Doors { get; set; }
        public Door() { }
        public Door(string doors)
        {
            Doors = doors;
        }
    }
}
