namespace backend_smarthome.DAL.Entity
{
    public class GuestDb
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public int? ApartmentId { get; set; }
        public ApartmentDb? Apartment { get; set; }

    }
}
