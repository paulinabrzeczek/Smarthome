namespace backend_smarthome.DTO
{
    public class DeviceDataDto
    {
        public float OccupiedHeatingSetpoint { get; set; }
        public int Battery { get; set; }
        public double LocalTemperature { get; set; }
        public bool HeatAvailable { get; set; }
        public string DeviceId { get; set; }
    }
}
