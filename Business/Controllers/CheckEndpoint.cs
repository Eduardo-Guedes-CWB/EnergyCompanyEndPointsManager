using Business.Helpers;
using Business.Interfaces;
using System.Linq;

namespace Business.Controllers
{
    public class CheckEndpoint : ICheckEndpoint
    {
        public bool AlreadyExists(string serialNumber)
        {
            return EndpointsInExecution.Endpoints.Any(x => x.EndpointSerialNumber == serialNumber);
        }
    }
}
