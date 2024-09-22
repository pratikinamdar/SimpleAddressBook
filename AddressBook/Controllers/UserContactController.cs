using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace AddressBook.Controllers
{
    public class UserContactController: ControllerBase
    {
        private Database db;

        public UserContactController(IConfiguration config)
        {
            db = new Database(config.GetConnectionString("connstr"));
        }

        [HttpPost("UserContact", Name = "PostUsers")]

        public void PostUsers(UserContact user)
        {
            UserContact u = new UserContact() { Phone = user.Phone, Name = user.Name, Address = user.Address, Email = user.Email };
            db.UserContact.Add(u);
            db.SaveChanges();
        }

        [HttpGet("UserContact", Name = "GetUsers")]

        public IEnumerable<UserContact> GetUsers() 
        {
            return (from u in db.UserContact
                    select u).ToList();
        }


        [HttpGet("UserContact/{Phone}", Name = "GetUsersById")]

        public IEnumerable<UserContact> GetUsersById(int Phone)
        {
            var r = (from u in db.UserContact
                    where u.Phone == Phone
                    select u).ToList();
            return r;
        }

        [HttpDelete("UserContact/{phone}", Name = "DeleteUsersById")]
        public int DeleteUsersById(int phone)
        {
            var d = (from u in db.UserContact
                     where u.Phone == phone
                     select u).First();
            db.UserContact.Remove(d);
            db.SaveChanges();
            return d.Phone;
        }

        [HttpPost("UserContact/{Phone}/{Address}", Name = "UpdateUsersById")]

        public int UpdateUserAddress(string Address, int Phone)
        {
            var r = (from u in db.UserContact
                     where u.Phone == Phone
                     select u).First();
            r.Address = Address;
            db.UserContact.Update(r);
            db.SaveChanges();
            return r.Phone;
        }

    }
}
