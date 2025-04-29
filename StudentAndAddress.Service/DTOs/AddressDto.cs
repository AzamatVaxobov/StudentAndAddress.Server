namespace StudentAndAddress.Service.DTOs
{
    public class AddressDto
    {
        public long Id { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public long StudentId { get; set; }
    }
}
