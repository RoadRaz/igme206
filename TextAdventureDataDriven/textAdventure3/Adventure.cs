using System;

namespace textAdventure3
{
    public class Adventure
    {
        public bool playerSword = false;
        public bool playerShield = false;
        public bool playerEnergy = false;
        public bool sameRoomCondition = false;
        public bool gameEnd = false;
        public bool playGameAgain = true;

        //Defining Adventure Singleton
        private static Adventure a1 = new Adventure();
        public static Adventure getInstance()
        {
            return a1;
        }

        static void Main(string[] args)
        {
            Adventure adventObj = Adventure.getInstance();
            Controller controlObj = Controller.getInstance();
            View viewObj = View.getInstance();
            GameLogic logicObj = GameLogic.getInstance();
            Rooms roomObj = Rooms.getInstance();

            //Main game loop
            adventObj.PlayGame(adventObj, controlObj, viewObj, logicObj, roomObj);
            while (adventObj.playGameAgain)
            {
                viewObj.PlayAgain();
                char playAgain = controlObj.GetPlayAgainInput();
                while (logicObj.PlayAgainInputEvaluation(playAgain) == false)
                {
                    viewObj.InvalidPlayAgainInput();
                    playAgain = controlObj.GetPlayAgainInput();
                }
                logicObj.CheckPlayAgain(playAgain, adventObj, controlObj, viewObj, logicObj, roomObj);
            }
        }
        //Called when there is no room in the direction entered
        public void callViewSameRoom()
        {
            View.getInstance().SameRoomDisclaimer();
        }
        //Reset all flags when a new game begins
        public void Reset()
        {
            playerSword = false;
            playerShield = false;
            playerEnergy = false;
            sameRoomCondition = false;
            gameEnd = false;
            playGameAgain = true;
        }
        public void PlayGame(Adventure adventObj, Controller controlObj, View viewObj, GameLogic logicObj, Rooms roomObj)
        {
            Reset();
            string[] roomDescriptions = roomObj.CopyDescriptionsFromFile();
            if (logicObj.CheckFileExists(roomDescriptions, roomObj))
            {
                viewObj.FileNotFound();
                return;
            }
            int currentRoom = 1; //Starting at Room 1 in the game
            viewObj.StartGameText();
            viewObj.NextStepPrompt();
            //Inner Game Loop
            while (true)
            {
                string userInput = "";
                userInput = controlObj.GetInput();
                int newRoom = logicObj.MakeMove(userInput, currentRoom, adventObj);
                if (newRoom == -1) //Quit game
                    return;
                currentRoom = newRoom;

                //If Room 5 Visited-----------------------------------------------------------
                string gameDecider = logicObj.CheckRoom5Condition(currentRoom, roomDescriptions, adventObj);
                viewObj.GameVerdict(gameDecider);
                if (gameDecider != "")
                    break;
                //----------------------------------------------------------------------------

                logicObj.CheckPickup(currentRoom, adventObj);
                string strRoom = logicObj.FetchDescription(currentRoom, roomDescriptions);
                if (adventObj.sameRoomCondition == true)
                {
                    viewObj.ShowMap();
                    viewObj.SameRoomDisclaimer();
                }
                else
                    viewObj.PrintDescription(strRoom);
                viewObj.NextStepPrompt();
            }
        }
    }
}
