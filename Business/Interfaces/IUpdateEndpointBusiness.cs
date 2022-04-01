using Business.Entities;
using System;

namespace Business.Interfaces
{
    public interface IUpdateEndpointBusiness
    {
        Tuple<bool, string> Update(Endpoint endpoint);
    }
}