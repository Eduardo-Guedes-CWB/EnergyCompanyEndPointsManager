using Business.Entities;
using Business.Helpers;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UI.Interfaces;

namespace UI.Controllers
{
    public class IndexEndpoint : IIndexEndpoint
    {
        private readonly IIndexEndpointBusiness _indexEndpointBusiness;
        public IndexEndpoint(IIndexEndpointBusiness indexEndpointBusiness)
        {
            _indexEndpointBusiness = indexEndpointBusiness;
        }
        public void Index()
        {
            Console.Clear();
            Console.WriteLine(SystemName.Name.ToUpper());
            Console.WriteLine();
            Console.WriteLine("ALL ENDPOINTS");
            Console.WriteLine();
            List<Endpoint> endpoints = _indexEndpointBusiness.Index();
            if (endpoints.Any())
            {
                Console.WriteLine("Below the endpoints data:");
                foreach (var endpoint in endpoints)
                {
                    Console.WriteLine("=========================================");
                    Console.WriteLine($"Serial Number: {endpoint.EndpointSerialNumber};");
                    Console.WriteLine($"Meter Model Id: {endpoint.MeterModelId} ({(ModelIdEnum.ModelId)endpoint.MeterModelId});");
                    Console.WriteLine($"Meter Number: {endpoint.MeterNumber};");
                    Console.WriteLine($"Meter Firmware Version: {endpoint.MeterFirmwareVersion};");
                    Console.WriteLine($"Switch State: {endpoint.SwitchState} ({(SwitchStateEnum.SwitchState)endpoint.SwitchState}).");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There are no endpoints created");
                Console.WriteLine();
            }
        }
    }
}
