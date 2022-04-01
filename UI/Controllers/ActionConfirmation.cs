using System;
using UI.Interfaces;

namespace UI.Controllers
{
    public class ActionConfirmation : IActionConfirmation
    {
        public bool GetConfirmation()
        {
            Console.Write("Enter confirmation here: ");
            char confirmation = char.ToUpper(Console.ReadKey().KeyChar);
            while (char.IsWhiteSpace(confirmation) || (!confirmation.Equals('Y') && !confirmation.Equals('N')))
            {
                Console.WriteLine();
                Console.WriteLine("Invalid value, insert a valid confirmation");
                Console.Write("Enter confirmation here: ");
                confirmation = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
            }
            return confirmation.Equals('Y');
        }


    }
}
