namespace Business.Interfaces
{
    public interface ICheckEndpoint
    {
        bool AlreadyExists(string serialNumber);
    }
}