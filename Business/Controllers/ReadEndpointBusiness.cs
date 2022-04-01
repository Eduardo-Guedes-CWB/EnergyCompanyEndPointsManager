using Business.Entities;
using Business.Helpers;
using Business.Interfaces;
using System.Linq;

namespace Business.Controllers
{
    public class ReadEndpointBusiness : IReadEndpointBusiness
    {
        public Endpoint Read(string serialNumber)
        {
            var result = from endpoint in EndpointsInExecution.Endpoints where endpoint.EndpointSerialNumber == serialNumber select endpoint;
            return result.FirstOrDefault();
        }
    }
}
