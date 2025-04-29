namespace StudentAndAddress.Service.DTOs
{
    public class AddressCreateDto
    {
        public required string City { get; set; }
        public required string Street { get; set; }
        public long StudentId { get; set; }
    }
}
