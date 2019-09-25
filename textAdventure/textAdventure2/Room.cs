using System;
using System.Collections.Generic;
using System.Text;

namespace textAdventure2
{
    public abstract class Room
    {
        public abstract string FetchRoomDescription();
    }

    public class Room1 : Room
    {
        private string roomDescription1 = "Currently you are inside a dark and creepy hall past the main door. Try to search weapons and energy to fight the Demon.";
        public override string FetchRoomDescription()
        {

            return roomDescription1;
        }
    }

    public class Room2 : Room
    {
        private string roomDescription2 = "It's a room full of swords. You pick one sword!";
        public override string FetchRoomDescription()
        {
            return roomDescription2;
        }
    }

    public class Room3 : Room
    {
        private string roomDescription3 = "It's a room full of shields. You pick one shield!";
        public override string FetchRoomDescription()
        {
            return roomDescription3;
        }
    }

    public class Room4 : Room
    {
        private string roomDescription4 = "It's a laboratory room. You found some energy syrup. You re-energise yourself!";
        public override string FetchRoomDescription()
        {
            return roomDescription4;
        }
    }

    public class Room5 : Room
    {
        private string roomDescription5 = "It's the Demon Room. The Demon and your friend are in the room.";
        private string deadDescription5 = " But you do not have enough resources to fight against the Demon. You die! :(";
        private string victoryDescription5 = " Hooray! You successfully defeated the Demon and saved your friend. :)";
        public override string FetchRoomDescription()
        {
            return roomDescription5;
        }
        public string FetchDeadDescription()
        {
            return deadDescription5;
        }
        public string FetchVictoryDescription()
        {
            return victoryDescription5;
        }
    }
}
