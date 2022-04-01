using Business.Entities;
using Business.Helpers;
using Business.Interfaces;
using System.Collections.Generic;

namespace Business.Controllers
{
    public class IndexEndpointBusiness : IIndexEndpointBusiness
    {
        public List<Endpoint> Index()
        {
            return EndpointsInExecution.Endpoints;
        }
    }
}
