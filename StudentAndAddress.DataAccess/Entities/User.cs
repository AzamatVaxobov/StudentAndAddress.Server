using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentAndAddress.DataAccess.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
      
        [EmailAddress]
        public string Email { get; set; }
        
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
