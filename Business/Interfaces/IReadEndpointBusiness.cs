using Business.Entities;

namespace Business.Interfaces
{
    public interface IReadEndpointBusiness
    {
        Endpoint Read(string serialNumber);
    }
}