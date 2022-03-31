using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class StartProcess
    {
        protected StartProcess()
        { 
        }
        public static void UserInteraction()
        {
            Console.WriteLine("Options");
            Console.WriteLine();
            Console.WriteLine("To insert a new endpoint, press 1");
            Console.WriteLine("To edit an existing endpoint, press 2");
            Console.WriteLine("To delete an existing endpoint, press 3");
            Console.WriteLine("To list all endpoints, press 4");
            Console.WriteLine("To find an endpoint by \"Endpoint Serial Number\", press 5");
            Console.WriteLine("To exit, press 6");
            int optionSelected;
            int.TryParse(Console.ReadLine(), out optionSelected);
            
            while (optionSelected < 1 || optionSelected > 6)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid option, please insert one of the options listed above");
                int.TryParse(Console.ReadLine(), out optionSelected);
            }

            switch (optionSelected)
            {
                case 1:
                    CreateEndPoint.UserInteraction();
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }
    }
}
