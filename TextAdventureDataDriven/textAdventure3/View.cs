using System;
using System.Collections.Generic;
using System.Text;

namespace textAdventure3
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

        public void ShowMap()
        {
            Console.WriteLine("                 __________________________________");
            Console.WriteLine("                |              ||                 |");
            Console.WriteLine("                |  Demon Room  ::   Laboratory    |");
            Console.WriteLine(" _______________|______::______||_______  ________|");
            Console.WriteLine("|              ||              ||                 |");
            Console.WriteLine("|  Sword Room         Hall          Shield Room   |");
            Console.WriteLine("|______________||______/ ______||_________________|");
            Console.WriteLine("                      |MD|                         ");
            Console.WriteLine("\n");
        }

        public void StartGameText()
        {
            ShowMap();
            Console.WriteLine("Welcome to Demon Escape! Your friend is captured in a Demon's house consisting of 5 rooms.");
            Console.WriteLine("You rush into the house to rescue your friend. However, you end up getting trapped in the house (>_<)");
            Console.WriteLine("Move through the rooms using look,n,s,e,w commands.");
            Console.WriteLine("You won't be able to escape unless you kill the Demon. Try to collect pickups to fight the Demon.");
            Console.WriteLine("You enter the house through the main door(MD)!");
        }
        public void SameRoomDisclaimer()
        {
            Console.WriteLine("You bumped the wall! Either no room in that direction or you entered an Invalid command.");
        }
        public void NextStepPrompt()
        {
            Console.WriteLine("\nWhat next? (Options: look,n,s,e,w) or enter 'q' to quit game");
        }
        public void GameVerdict(string gameDecider)
        {
            Console.WriteLine(gameDecider);
        }
        public void PlayAgain()
        {
            Console.WriteLine("\nDo you want to try again? (Y/N)");
        }

        public void FileNotFound()
        {
            Console.WriteLine("\n'RoomDescriptions.txt' file not found. Game won't be playable.");
            Console.WriteLine(@"Please make sure the file is located inside 'D:\Visual Studio Projects\textAdventure3\textAdventure3' directory.");
        }

        public void InvalidPlayAgainInput()
        {
            Console.WriteLine("Invalid input. Try Again.");
        }
    }
}
