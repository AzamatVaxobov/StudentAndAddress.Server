namespace StudentAndAddress.Service.DTOs
{
    public class StudentDto
    {
        public long Id { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public  AddressDto Address { get; set; }
    }
}
