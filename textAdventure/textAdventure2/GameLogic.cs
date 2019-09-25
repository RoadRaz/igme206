using System;
using System.Collections.Generic;
using System.Text;

namespace textAdventure2
{
    public class GameLogic
    {
        private static GameLogic g1 = new GameLogic();
        public static GameLogic GetInstance()
        {
            return g1;
        }

        string[,] roomArray = new string[6, 6]
        {
            { "null",  "null",  "null",  "null",  "null",  "null"},
            { "null", "look","w","e","null","n"},
            { "null", "e", "look", "null", "null", "null" },
            { "null", "w", "null", "look", "n", "null" },
            { "null", "null", "null", "s", "look", "w" },
            { "null", "s", "null", "null", "e", "look" }
        };

        public int MakeMove(string userInput, int currentRoomCopy)
        {
            if (userInput == "look")
                return currentRoomCopy;
            int newRoom = 0;
            for (int i = 0; i < 6; i++)
            {
                if (roomArray[currentRoomCopy, i] == userInput)
                {
                    newRoom = i;
                    break;
                }
            }
            if (newRoom == 0)
                return currentRoomCopy;
            return newRoom;
        }

        public string FetchDescription(int newRoom)
        {
            string strRoom = "";
            switch (newRoom)
            {
                case 1:
                    Room1 r1 = new Room1();
                    strRoom = r1.FetchRoomDescription();
                    break;

                case 2:
                    Room2 r2 = new Room2();
                    strRoom = r2.FetchRoomDescription();
                    break;

                case 3:
                    Room3 r3 = new Room3();
                    strRoom = r3.FetchRoomDescription();
                    break;

                case 4:
                    Room4 r4 = new Room4();
                    strRoom = r4.FetchRoomDescription();
                    break;

                case 5:
                    Room5 r5 = new Room5();
                    strRoom = r5.FetchRoomDescription();
                    break;
            }
            return strRoom;
        }

        public void CheckPickup(int currentRoomCopy)
        {
            if (currentRoomCopy == 2)
            {
                Adventure.getInstance().playerSword = true;
            }
            if (currentRoomCopy == 3)
            {
                Adventure.getInstance().playerShield = true;
            }
            if (currentRoomCopy == 4)
            {
                Adventure.getInstance().playerEnergy = true;
            }
        }

        public string CheckRoom5Condition(int currentRoomCopy)
        {
            if ((currentRoomCopy == 5) && (Adventure.getInstance().playerSword == false || Adventure.getInstance().playerShield == false || Adventure.getInstance().playerEnergy == false))
            {
                Room5 rd = new Room5();
                return rd.FetchRoomDescription() + rd.FetchDeadDescription();
            }
            else if ((currentRoomCopy == 5) && (Adventure.getInstance().playerSword == true && Adventure.getInstance().playerShield == true && Adventure.getInstance().playerEnergy == true))
            {
                Room5 rd = new Room5();
                return rd.FetchRoomDescription() + rd.FetchVictoryDescription();
            }
            else
                return "";
        }
    }
}
