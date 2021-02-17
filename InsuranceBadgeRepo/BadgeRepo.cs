using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBadgeRepo
{
    public class BadgeRepo
    {
        private readonly List<Badge> _listOfBadges = new List<Badge>();
        private readonly List<Door> _listOfDoors = new List<Door>();

        public int Count
        {
            get
            {
                return _listOfBadges.Count;
            }
        }
        public bool AddBadgeToBadgeList(Badge badge)
        {
            int startingCount = _listOfBadges.Count;
            _listOfBadges.Add(badge);
            bool wasAdded = _listOfBadges.Count > startingCount;
            return wasAdded;
        }
        public List<Badge> GetBadges()
        {
            return _listOfBadges;
        }
        public List<Door> GetDoors()
        {
            return _listOfDoors;
        }
        public Badge GetBadgeByBadgeID(string badgeID)
        {
            foreach(Badge badge in _listOfBadges)
            {
                if (badgeID == badge.BadgeID)
                {
                    return badge;
                }
            }
            Console.WriteLine("No badge with that ID number exists");
            Console.ReadKey();
            return null;
        }

    }
}
