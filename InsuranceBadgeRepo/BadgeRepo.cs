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
        private readonly List<string> _listOfDoors = new List<string>();

        public bool AddBadgeToBadgeList(Badge badge)
        {
            int startingCount = _listOfBadges.Count;
            _listOfBadges.Add(badge);
            bool wasAdded = _listOfBadges.Count > startingCount;
            return wasAdded;
        }
        public bool AddDoorsToBadge(Badge badge, string newDoor)
        {
            List<string> currentDoors = badge.ListOfDoors;
            int doorCount = currentDoors.Count;
            currentDoors.Add(newDoor);
            bool addedDoor = doorCount < currentDoors.Count;
            return addedDoor;
        }
        public List<Badge> GetBadges()
        {
            return _listOfBadges;
        }
        public List<string> GetDoors()
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
            return null;
        }
        public List<string> GetDoorsByBadgeID(string badgeID)
        {
            Badge badge = GetBadgeByBadgeID(badgeID);
            List<string> currentDoors = badge.ListOfDoors;
            return currentDoors;
        }
        public List<string> GetClearanceForBadge(string badgeID)
        {
            Badge badge = GetBadgeByBadgeID(badgeID);
            List<string> currentDoors = badge.ListOfDoors;
            return currentDoors;
        }
        public bool RemoveDoorsFromBadge(string badgeID, string door)
        {
            Badge currentBadge = GetBadgeByBadgeID(badgeID);
            List<string> currentDoors = currentBadge.ListOfDoors;
            bool doorsDeleted = currentDoors.Remove(door);
            return doorsDeleted;
        }
        public bool RemoveAllDoorsFromBadge(string badgeID)
        {
            Badge badge = GetBadgeByBadgeID(badgeID);
            List<string> doorsToRemove = badge.ListOfDoors;
            int doorCount = doorsToRemove.Count;
            doorsToRemove.RemoveRange(0, doorCount);
            bool doorsRemoved = doorsToRemove.Count == 0;
            return doorsRemoved;
        }
        public bool DeleteABadge(string badgeID)
        {
            Badge badge = GetBadgeByBadgeID(badgeID);
            int startingCount = _listOfBadges.Count;
            _listOfBadges.Remove(badge);
            bool wasDeleted = startingCount > _listOfBadges.Count;
            return wasDeleted;
        }
    }
}
