#nullable disable
using Microsoft.EntityFrameworkCore;
using FunctionApp1.Models;

namespace FunctionApp1.Data
{
    public class TestContext : DbContext
    {
        public TestContext (DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
    }
}
