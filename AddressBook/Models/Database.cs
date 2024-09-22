using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.InMemory;

namespace AddressBook.Models
{
    public class Database:DbContext
    {
        public string connstr;

        public Database(string connstr)
        {
            this.connstr = connstr;
        }

        public DbSet<UserContact> UserContact {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Database");
        }

    }
}

