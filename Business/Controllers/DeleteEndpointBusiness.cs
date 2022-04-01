using Business.Entities;
using Business.Helpers;
using Business.Interfaces;
using System;

namespace Business.Controllers
{
    public class DeleteEndpointBusiness : IDeleteEndpointBusiness
    {
        private readonly ICheckEndpoint _checkEndpoint;
        public DeleteEndpointBusiness(ICheckEndpoint checkEndpoint)
        {
            _checkEndpoint = checkEndpoint;
        }
        public Tuple<bool, string> Delete(Endpoint endpoint)
        {
            if (endpoint == null)
                return new Tuple<bool, string>(false, $"Input can not be null");

            if (!_checkEndpoint.AlreadyExists(endpoint.EndpointSerialNumber))
                return new Tuple<bool, string>(false, $"There is no endpoint created for this serial number");

            try
            {
                EndpointsInExecution.Endpoints.Remove(endpoint);
                return new Tuple<bool, string>(true, "Endpoint excluded");
            }
            catch (Exception ex)
            {

                return new Tuple<bool, string>(false, $"Operation failed: {ex.Message}");
            }
        }
    }
}
