namespace Business.Entities
{
    public class Endpoint
    {
        public string EndpointSerialNumber { get; set; }
        public int MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string MeterFirmwareVersion { get; set; }
        public int SwitchState { get; set; }
    }
}
