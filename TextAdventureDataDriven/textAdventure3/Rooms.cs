using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace textAdventure3
{
    public class Rooms
    {
        public string filErrorMsg = "File not found.";
        //Defining Adventure Singleton
        private static Rooms rs = new Rooms();
        public static Rooms getInstance()
        {
            return rs;
        }
        public string[] CopyDescriptionsFromFile()
        {
            string textFilePath = @"D:\Visual Studio Projects\textAdventure3\textAdventure3\RoomDescriptions.txt";
            if (!File.Exists(textFilePath))
            {
                string[] temp = { filErrorMsg };
                return temp;
            }
            string text = File.ReadAllText(textFilePath);
            string[] result = text.Split("|".ToCharArray(), StringSplitOptions.None);
            return result;
        }

    }
}
