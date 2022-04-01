using Business.Entities;
using System;

namespace Business.Interfaces
{
    public interface IDeleteEndpointBusiness
    {
        Tuple<bool, string> Delete(Endpoint endpoint);
    }
}