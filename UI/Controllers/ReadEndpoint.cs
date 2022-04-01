using Business.Entities;
using Business.Helpers;
using Business.Interfaces;
using System;
using UI.Interfaces;

namespace UI.Controllers
{
    public class ReadEndpoint : IReadEndpoint
    {
        private readonly IReadEndpointBusiness _readEndpointBusiness;
        public ReadEndpoint(IReadEndpointBusiness readEndpointBusiness)
        {
            _readEndpointBusiness = readEndpointBusiness;
        }
        public void Read()
        {
            Console.Clear();
            Console.WriteLine(SystemName.Name.ToUpper());
            Console.WriteLine();
            Console.WriteLine("CONSULT ENDPOINT ");
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
                Console.WriteLine("There is no endpoint created for this serial number");
                Console.WriteLine();
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
            }
        }
    }
}
