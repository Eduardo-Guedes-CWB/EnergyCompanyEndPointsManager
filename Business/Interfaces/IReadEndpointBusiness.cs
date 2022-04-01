using Business.Entities;
using System;

namespace Business.Interfaces
{
    public interface IReadEndpointBusiness
    {
        Tuple<bool, string, Endpoint> Read(string serialNumber);
    }
}