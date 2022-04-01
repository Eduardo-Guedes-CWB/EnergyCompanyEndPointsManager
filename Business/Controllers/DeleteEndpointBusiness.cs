using Business.Entities;
using Business.Helpers;
using Business.Interfaces;
using System;

namespace Business.Controllers
{
    public class DeleteEndpointBusiness : IDeleteEndpointBusiness
    {
        public Tuple<bool, string> Delete(Endpoint endpoint)
        {
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
