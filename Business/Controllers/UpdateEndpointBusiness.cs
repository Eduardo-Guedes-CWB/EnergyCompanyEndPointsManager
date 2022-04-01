using Business.Entities;
using Business.Helpers;
using Business.Interfaces;
using System;
using System.Linq;

namespace Business.Controllers
{
    public class UpdateEndpointBusiness : IUpdateEndpointBusiness
    {
        public Tuple<bool, string> Update(Endpoint endpoint)
        {
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
