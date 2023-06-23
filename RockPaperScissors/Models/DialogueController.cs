using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    internal class DialogueController
    {
        public DialogueController()
        {

        }
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
        public void Write(string input)
        {
            Console.Write(input);
        }
        public void ClearConsole()
        {
            Console.Clear();
        }
        public void ClearAndWrite(string input)
        {
            Console.Clear();
            Console.WriteLine(input);
        }
        public void WaitForPlayerContinue()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Beep();
        }
    }
}
