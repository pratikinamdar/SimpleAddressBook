using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class UserContact
    {
        [Key]
        public int Phone { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
