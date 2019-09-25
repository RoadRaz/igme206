using System;
using System.Collections.Generic;
using System.Text;

namespace textAdventure2
{
    public class View
    {
        private static View v1 = new View();
        public static View getInstance()
        {
            return v1;
        }

        public void PrintDescription(string strRoom)
        {
            Console.WriteLine(strRoom);
        }

        public void StartGameText()
        {
            Console.WriteLine("Welcome to Demon room! Your friend is trapped in a demon house consisting of 5 rooms.");
            Console.WriteLine("You have entered the Demon's house and trapped inside it.");
            Console.WriteLine("Move through the rooms using look,n,s,e,w commands and collect pickups to rescue your friend.");
            Console.WriteLine("You won't be able to escape unless you kill the Demon.");
            Console.WriteLine("You entered through the main door!");
        }
        public void SameRoomDisclaimer()
        {
            Console.WriteLine("You bumped the wall! You are in the same room");
        }
        public void NextStepPrompt()
        {
            Console.WriteLine("\nWhat next? (Options: look,n,s,e,w)");
        }
        public void GameVerdict(string gameDecider)
        {
            Console.WriteLine(gameDecider);
        }
    }
}
