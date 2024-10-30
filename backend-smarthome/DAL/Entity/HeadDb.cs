using backend_smarthome.DAL.Configuration;

namespace backend_smarthome.DAL.Entity
{
    public class HeadDb : Device
    {
        public int Id { get; set; }
        public double IndoorTemp { get; set; }
        public double OutdoorTemp { get; set; }
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }
    }
}
