using Business.Entities;
using UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    internal class Program
    {
        public static List<EndPoint> EndPoints = new List<EndPoint>();
        static void Main(string[] args)
        {            
            StartProcess.UserInteraction();
        }
    }
}
