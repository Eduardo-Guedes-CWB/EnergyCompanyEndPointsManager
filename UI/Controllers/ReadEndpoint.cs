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
            var result = _readEndpointBusiness.Read(serialNumber);
            if (result.Item3 == null)
            { 
                Console.WriteLine(result.Item2);
                Console.WriteLine();
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
            }
        }
    }
}
