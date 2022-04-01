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
            Endpoint endpoint = _readEndpointBusiness.Read(serialNumber);
            if (endpoint == null)
            {
                return "There is no endpoint created for this serial number";
            }
            else
            {
                Console.WriteLine("Below the endpoint data:");
                Console.WriteLine();
                Console.WriteLine($"Serial Number: {endpoint.EndpointSerialNumber};");
                Console.WriteLine($"Meter Model Id: {endpoint.MeterModelId} ({(ModelIdEnum.ModelId)endpoint.MeterModelId});");
                Console.WriteLine($"Meter Number: {endpoint.MeterNumber};");
                Console.WriteLine($"Meter Firmware Version: {endpoint.MeterFirmwareVersion};");
                Console.WriteLine($"Switch State: {endpoint.SwitchState} ({(SwitchStateEnum.SwitchState)endpoint.SwitchState}).");
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
                endpoint.SwitchState = switchState;
                Console.WriteLine("Do you want to alter the switch state of this endpoint? (Y / N)");
                if (_actionConfirmation.GetConfirmation())
                {
                    return _updateEndpointBusiness.Update(endpoint).Item2;
                }
                else
                    return "Operation aborted";
            }
        }
    }
}
