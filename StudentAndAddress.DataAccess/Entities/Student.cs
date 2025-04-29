namespace StudentAndAddress.DataAccess.Entities
{
    public class Student
    {
        public long Id { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public Address Address { get; set; }

    }
}
