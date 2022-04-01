using Business.Entities;
using System;

namespace Business.Interfaces
{
    public interface ICreateEndpointBusiness
    {
        Tuple<bool, string> Create(Endpoint endPoint);
    }
}