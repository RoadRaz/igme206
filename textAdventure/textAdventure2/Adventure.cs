using System;

namespace textAdventure2
{
    public class Adventure
    {
        public bool playerSword = false;
        public bool playerShield = false;
        public bool playerEnergy = false;

        private static Adventure a1 = new Adventure();
        public static Adventure getInstance()
        {
            return a1;
        }
        static void Main(string[] args)
        {
            int currentRoom = 1;
            string userInput = "";
            View.getInstance().StartGameText();
            View.getInstance().NextStepPrompt();
            while (true)
            {                 
                userInput = Controller.getInstance().GetInput();
                int newRoom = GameLogic.GetInstance().MakeMove(userInput, currentRoom);
                currentRoom = newRoom;
                string gameDecider = GameLogic.GetInstance().CheckRoom5Condition(currentRoom);
                View.getInstance().GameVerdict(gameDecider);
                if (gameDecider!="")
                    break;
                GameLogic.GetInstance().CheckPickup(currentRoom);
                string strRoom = GameLogic.GetInstance().FetchDescription(newRoom);
                View.getInstance().PrintDescription(strRoom);
                View.getInstance().NextStepPrompt();
            }

        }
    }
}
