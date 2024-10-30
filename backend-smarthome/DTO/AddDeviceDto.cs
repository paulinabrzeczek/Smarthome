namespace backend_smarthome.DTO
{
    public class AddDeviceDto
    {
        public string Name { get; set; }
        public int DeviceTypeId { get; set; }
        public string SerialNumber { get; set; }
        public Guid UserId { get; set; }
    }
}
