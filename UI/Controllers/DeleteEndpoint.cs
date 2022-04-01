using Business.Entities;
using Business.Helpers;
using Business.Interfaces;
using System;
using UI.Interfaces;

namespace UI.Controllers
{
    public class DeleteEndpoint : IDeleteEndpoint
    {
        private readonly IReadEndpointBusiness _readEndpointBusiness;
        private readonly IActionConfirmation _actionConfirmation;
        private readonly IDeleteEndpointBusiness _deleteEndpointBusiness;
        public DeleteEndpoint(IReadEndpointBusiness readEndpointBusiness, IActionConfirmation actionConfirmation,
                              IDeleteEndpointBusiness deleteEndpointBusiness)
        {
            _readEndpointBusiness = readEndpointBusiness;
            _actionConfirmation = actionConfirmation;
            _deleteEndpointBusiness = deleteEndpointBusiness;
        }
        public string Delete()
        {
            Console.Clear();
            Console.WriteLine(SystemName.Name.ToUpper());
            Console.WriteLine();
            Console.WriteLine("DELETE ENDPOINT");
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
                Console.WriteLine("Do you confirm the exclusion? (Y / N)");
                if (_actionConfirmation.GetConfirmation())
                {
                    return _deleteEndpointBusiness.Delete(endpoint).Item2;
                }
                else
                    return "Operation aborted";
            }
        }
    }
}
