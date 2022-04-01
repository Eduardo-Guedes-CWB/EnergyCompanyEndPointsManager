using Business.Entities;
using Business.Helpers;
using Business.Interfaces;
using System;
using UI.Interfaces;

namespace UI.Controllers
{
    public class UpdateEndpoint : IUpdateEndpoint
    {
        private readonly IReadEndpointBusiness _readEndpointBusiness;
        private readonly IActionConfirmation _actionConfirmation;
        private readonly IUpdateEndpointBusiness _updateEndpointBusiness;

        public UpdateEndpoint(IReadEndpointBusiness readEndpointBusiness, IActionConfirmation actionConfirmation,
                              IUpdateEndpointBusiness updateEndpointBusiness)
        {
            _readEndpointBusiness = readEndpointBusiness;
            _actionConfirmation = actionConfirmation;
            _updateEndpointBusiness = updateEndpointBusiness;
        }

        public string Update()
        {
            Console.Clear();
            Console.WriteLine(SystemName.Name.ToUpper());
            Console.WriteLine();
            Console.WriteLine("EDIT ENDPOINT");
            Console.WriteLine();
            Console.Write("Enter serial number here: ");
            string serialNumber = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(serialNumber))
            {
                Console.WriteLine();
                Console.WriteLine("Invalid value, insert a valid serial number");
                Console.Write("Enter serial number here: ");
                serialNumber = Console.ReadLine();
            }
            Console.WriteLine();
            var result = _readEndpointBusiness.Read(serialNumber);
            if (result.Item3 == null)
            {
                return result.Item2;
            }
            else
            {
                Console.WriteLine("Below the endpoint data:");
                Console.WriteLine();
                Console.WriteLine($"Serial Number: {result.Item3.EndpointSerialNumber};");
                Console.WriteLine($"Meter Model Id: {result.Item3.MeterModelId} ({(ModelIdEnum.ModelId)result.Item3.MeterModelId});");
                Console.WriteLine($"Meter Number: {result.Item3.MeterNumber};");
                Console.WriteLine($"Meter Firmware Version: {result.Item3.MeterFirmwareVersion};");
                Console.WriteLine($"Switch State: {result.Item3.SwitchState} ({(SwitchStateEnum.SwitchState)result.Item3.SwitchState}).");
                Console.WriteLine();
                Console.WriteLine("You can alter just the switch state");
                Console.WriteLine("For Disconnected, enter 0");
                Console.WriteLine("For Connected, enter 1");
                Console.WriteLine("For Armed, enter 2");
                Console.Write("Enter the new switch state here: ");
                int switchState;
                bool switchStateOk = int.TryParse(Console.ReadLine(), out switchState);
                while (!switchStateOk || (switchState < 0 || switchState > 2))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid value, insert a valid switch state");
                    Console.Write("Enter switch state here: ");
                    switchStateOk = int.TryParse(Console.ReadLine(), out switchState);
                }
                result.Item3.SwitchState = switchState;
                Console.WriteLine("Do you want to alter the switch state of this endpoint? (Y / N)");
                if (_actionConfirmation.GetConfirmation())
                {
                    return _updateEndpointBusiness.Update(result.Item3).Item2;
                }
                else
                    return "Operation aborted";
            }
        }
    }
}
