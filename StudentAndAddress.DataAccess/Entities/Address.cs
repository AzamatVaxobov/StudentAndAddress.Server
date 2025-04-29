namespace StudentAndAddress.DataAccess.Entities
{
    public class Address
    {
        public long Id { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public long StudentId { get; set; }
        public Student Student { get; set; }
    }
}
