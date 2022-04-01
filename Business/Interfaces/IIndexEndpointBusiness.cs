using Business.Entities;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IIndexEndpointBusiness
    {
        List<Endpoint> Index();
    }
}