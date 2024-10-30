namespace backend_smarthome.DTO
{
    public class HeadDto
    {
        public string Name { get; set; }
        public double IndoorTemp { get; set; }
        public double OutdoorTemp { get; set; }
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }
        public int RoomId { get; set; }
        public bool Active { get; set; }
        public string Symbol { get; set; }
        public double Value { get; set; }
        public int DeviceTypeId { get; set; }
    }
}
