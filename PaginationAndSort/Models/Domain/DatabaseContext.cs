using Microsoft.EntityFrameworkCore;
namespace PaginationAndSort.Models.Domain
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options):base(options) { }
        public DbSet<Person> Persons {  get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
