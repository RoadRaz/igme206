using System;
using System.Collections.Generic;
using System.Text;

namespace textAdventure2
{
    public class Controller
    {
        private static Controller c1 = new Controller();
        public static Controller getInstance()
        {
            return c1;
        }

        public string GetInput()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}
