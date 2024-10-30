namespace backend_smarthome.DAL.Entity
{
    public class ApartmentDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressDb? Address { get; set; }
        public ICollection<RoomDb> Rooms { get; set; }
        public UserDb? User { get; set; }
        public Guid UserId { get; set; }
        public ICollection<GuestDb> Guest { get; set; }
    }
}
