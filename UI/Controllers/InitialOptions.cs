using Business.Helpers;
using System;
using UI.Interfaces;

namespace UI.Controllers
{
    public class InitialOptions : IInitialOptions
    {        
        public int UserInteraction()
        {
            Console.Clear();
            Console.WriteLine(SystemName.Name.ToUpper());
            Console.WriteLine();
            Console.WriteLine("HOME");
            Console.WriteLine("You can choose an option described below:");
            Console.WriteLine();
            Console.WriteLine("To insert a new endpoint, press 1");
            Console.WriteLine("To edit an existing endpoint, press 2");
            Console.WriteLine("To delete an existing endpoint, press 3");
            Console.WriteLine("To list all endpoints, press 4");
            Console.WriteLine("To find an endpoint by \"Endpoint Serial Number\", press 5");
            Console.WriteLine("To exit, press 6");
            int optionSelected;
            Console.WriteLine();
            Console.Write("Enter number option here: ");
            int.TryParse(Console.ReadLine(), out optionSelected);

            while (optionSelected < 1 || optionSelected > 6)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid option, please insert one of the options listed above");
                Console.Write("Enter number option here: ");
                int.TryParse(Console.ReadLine(), out optionSelected);
            }

            return optionSelected;            
        }
    }
}
