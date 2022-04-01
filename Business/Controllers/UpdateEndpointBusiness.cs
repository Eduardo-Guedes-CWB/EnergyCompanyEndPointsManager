using Business.Entities;
using Business.Helpers;
using Business.Interfaces;
using System;
using System.Linq;

namespace Business.Controllers
{
    public class UpdateEndpointBusiness : IUpdateEndpointBusiness
    {
        private readonly ICheckEndpoint _checkEndpoint;
        public UpdateEndpointBusiness(ICheckEndpoint checkEndpoint)
        {
            _checkEndpoint = checkEndpoint;
        }
        public Tuple<bool, string> Update(Endpoint endpoint)
        {
            if (endpoint == null)
                return new Tuple<bool, string>(false, $"Input can not be null");

            if (!_checkEndpoint.AlreadyExists(endpoint.EndpointSerialNumber))
                return new Tuple<bool, string>(false, $"There is no endpoint created for this serial number");

            try
            {
                EndpointsInExecution.Endpoints.First(x => x.EndpointSerialNumber == endpoint.EndpointSerialNumber).SwitchState = endpoint.SwitchState;
                return new Tuple<bool, string>(true, "Endpoint altered");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, $"Operation failed: {ex.Message}");
            }
        }
    }
}
