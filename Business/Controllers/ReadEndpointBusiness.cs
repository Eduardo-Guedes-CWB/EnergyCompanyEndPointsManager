using Business.Entities;
using Business.Helpers;
using Business.Interfaces;
using System;
using System.Linq;

namespace Business.Controllers
{
    public class ReadEndpointBusiness : IReadEndpointBusiness
    {
        public Tuple<bool, string, Endpoint> Read(string serialNumber)
        {
            if (serialNumber == null)
                return new Tuple<bool, string, Endpoint>(false, $"Input can not be null", null);

            var result = from endpoint in EndpointsInExecution.Endpoints where endpoint.EndpointSerialNumber == serialNumber select endpoint;
            Endpoint endpointResult = result.FirstOrDefault();
            if (endpointResult == null)
                return new Tuple<bool, string, Endpoint>(false, "There is no endpoint created for this serial number",null );
            else
                return new Tuple<bool, string, Endpoint>(false,null, endpointResult);
        }
    }
}
