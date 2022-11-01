using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FunctionApp1.Data
{
    public class TestContextFactory : IDesignTimeDbContextFactory<TestContext>
    {
        public TestContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data source=.\\Data\\employees.db");

            return new TestContext(optionsBuilder.Options);
        }
    }
}
