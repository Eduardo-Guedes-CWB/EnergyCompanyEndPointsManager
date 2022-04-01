using Business.Entities;
using Business.Helpers;
using Business.Interfaces;
using System;

namespace Business.Controllers
{
    public class CreateEndpointBusiness : ICreateEndpointBusiness
    {
        private readonly ICheckEndpoint checkEndpoint;
        public CreateEndpointBusiness(ICheckEndpoint _checkEndpoint)
        {
            checkEndpoint = _checkEndpoint;
        }
        public Tuple<bool, string>  Create(Endpoint endPoint)
        {
            try
            {
                if (checkEndpoint.AlreadyExists(endPoint.EndpointSerialNumber))
                {
                    return new Tuple<bool, string> (false, "There is an endpoint to this serial number. Please review the information and execute the register again." );
                }

                EndpointsInExecution.Endpoints.Add(endPoint);

                return new Tuple<bool, string>(true, "Endpoint registered.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, $"Operation failed: {ex.Message}");
            }
        }
    }
}
