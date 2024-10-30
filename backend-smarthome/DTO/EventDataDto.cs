namespace backend_smarthome.DTO
{
    public class EventDataDto
    {
        public double OccupiedHeatingSetpoint { get; set; }
        public int Battery { get; set; }
        public double LocalTemperature { get; set; }
        public bool HeatAvailable { get; set; }
        public string DeviceId { get; set; }
        public int LinkQuality { get; set; }
    }
}
