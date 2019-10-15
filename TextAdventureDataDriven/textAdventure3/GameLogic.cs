using System;
using System.Collections.Generic;
using System.Text;

namespace textAdventure3
{
    public class GameLogic
    {
        public string roomDescErrorMsg = "Room description not found.";
        private static GameLogic g1 = new GameLogic();
        public static GameLogic getInstance()
        {
            return g1;
        }

        //Adjacent Matrix for indexing-----------------------------
        string[,] roomArray = new string[6, 6]
        {
            { "null",  "null",  "null",  "null",  "null",  "null"},
            { "null", "look","w","e","null","n"},
            { "null", "e", "look", "null", "null", "null" },
            { "null", "w", "null", "look", "n", "null" },
            { "null", "null", "null", "s", "look", "w" },
            { "null", "s", "null", "null", "e", "look" }
        };
        //---------------------------------------------------------

        public int MakeMove(string userInput, int currentRoomCopy, Adventure adventObj)
        {
            adventObj.sameRoomCondition = false;
            if (userInput == "q" || userInput == "Q") //Quitting the game
                return -1;
            if (userInput == "look") //Look for room description
                return currentRoomCopy;
            int newRoom = 0;
            for (int i = 0; i < 6; i++)
            {
                if (roomArray[currentRoomCopy, i] == userInput) //Indexes if input command is possible as per current location
                {
                    newRoom = i;
                    break;
                }
            }
            if (newRoom == 0)
            {
                adventObj.sameRoomCondition = true;
                return currentRoomCopy;
            }
            return newRoom;
        }

        public string FetchDescription(int newRoom, string[] roomDescriptions)
        {
            string strRoom = "";
            switch (newRoom)
            {
                case 1:
                    //Fetch Room 1 Description
                    if (!string.IsNullOrWhiteSpace(roomDescriptions[1]))
                        strRoom = roomDescriptions[0];
                    else
                        strRoom = roomDescErrorMsg;
                    break;

                case 2:
                    //Fetch Room 2 Description
                    if (!string.IsNullOrWhiteSpace(roomDescriptions[1]))
                        strRoom = roomDescriptions[1];
                    else
                        strRoom = roomDescErrorMsg;
                    break;

                case 3:
                    //Fetch Room 3 Description
                    if (!string.IsNullOrWhiteSpace(roomDescriptions[1]))
                        strRoom = roomDescriptions[2];
                    else
                        strRoom = roomDescErrorMsg;
                    break;

                case 4:
                    //Fetch Room 4 Description
                    if (!string.IsNullOrWhiteSpace(roomDescriptions[1]))
                        strRoom = roomDescriptions[3];
                    else
                        strRoom = roomDescErrorMsg;
                    break;

                case 5:
                    //Fetch Room 5 Description
                    if (!string.IsNullOrWhiteSpace(roomDescriptions[1]))
                        strRoom = roomDescriptions[4];
                    else
                        strRoom = roomDescErrorMsg;
                    break;
            }
            return strRoom;
        }

        //Check if player collected pickups
        public void CheckPickup(int currentRoomCopy, Adventure adventObj)
        {
            if (currentRoomCopy == 2)
            {
                adventObj.playerSword = true;
            }
            if (currentRoomCopy == 3)
            {
                adventObj.playerShield = true;
            }
            if (currentRoomCopy == 4)
            {
                adventObj.playerEnergy = true;
            }
        }

        //Checking the player's inventory status on entering Demon Room
        public string CheckRoom5Condition(int currentRoomCopy, string[] roomDescriptions, Adventure adventObj)
        {
            if ((currentRoomCopy == 5) && (adventObj.playerSword == false || adventObj.playerShield == false || adventObj.playerEnergy == false))
            {
                return roomDescriptions[4] + "\n" + roomDescriptions[5];
            }
            else if ((currentRoomCopy == 5) && (adventObj.playerSword == true && adventObj.playerShield == true && adventObj.playerEnergy == true))
            {
                return roomDescriptions[4] + "\n" + roomDescriptions[6];
            }
            else
                return "";
        }

        public void CheckPlayAgain(char playAgainInput, Adventure adventObj, Controller controlObj, View viewObj, GameLogic logicObj, Rooms roomObj)
        {
            if (playAgainInput == 'Y' || playAgainInput == 'y')
            {
                adventObj.PlayGame(adventObj, controlObj, viewObj, logicObj, roomObj);
            }
            if (playAgainInput == 'N' || playAgainInput == 'n')
            {
                adventObj.playGameAgain = false;
            }
        }

        //Check if the file consisting of room descriptions exists on the mentioned path
        public bool CheckFileExists(string[] roomDescriptions, Rooms roomObj)
        {
            if (roomDescriptions[0] == roomObj.filErrorMsg)
                return true;
            return false;
        }

        public bool PlayAgainInputEvaluation(char playAgain)
        {
            if (playAgain != 'Y' && playAgain != 'y' && playAgain != 'N' && playAgain != 'n')
                return false;
            return true;
        }
    }
}
