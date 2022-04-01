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
                Console.WriteLine("Do you confirm the exclusion? (Y / N)");
                if (_actionConfirmation.GetConfirmation())
                {
                    return _deleteEndpointBusiness.Delete(result.Item3).Item2;
                }
                else
                    return "Operation aborted";
            }
        }
    }
}
