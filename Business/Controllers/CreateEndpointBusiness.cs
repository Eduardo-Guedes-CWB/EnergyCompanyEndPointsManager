using Business.Entities;
using Business.Helpers;
using Business.Interfaces;
using System;

namespace Business.Controllers
{
    public class CreateEndpointBusiness : ICreateEndpointBusiness
    {
        private readonly ICheckEndpoint _checkEndpoint;
        public CreateEndpointBusiness(ICheckEndpoint checkEndpoint)
        {
            _checkEndpoint = checkEndpoint;
        }
        public Tuple<bool, string>  Create(Endpoint endpoint)
        {
            if (endpoint == null)
                return new Tuple<bool, string>(false, $"Input can not be null");

            if (string.IsNullOrWhiteSpace(endpoint.EndpointSerialNumber))
                return new Tuple<bool, string>(false, $"Invalid serial number");
            
            if (endpoint.MeterModelId < 16 || endpoint.MeterModelId > 19)
                return new Tuple<bool, string>(false, $"Invalid meter model id");
            
            if(string.IsNullOrWhiteSpace(endpoint.MeterFirmwareVersion))
                return new Tuple<bool, string>(false, $"Invalid meter firmware version");

            if(endpoint.SwitchState < 0 || endpoint.SwitchState > 2)
                return new Tuple<bool, string>(false, $"Invalid switch state");
            

            try
            {
                if (_checkEndpoint.AlreadyExists(endpoint.EndpointSerialNumber))
                {
                    return new Tuple<bool, string> (false, "There is an endpoint to this serial number. Please review the information and execute the register again." );
                }

                EndpointsInExecution.Endpoints.Add(endpoint);

                return new Tuple<bool, string>(true, "Endpoint registered.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, $"Operation failed: {ex.Message}");
            }
        }
    }
}
