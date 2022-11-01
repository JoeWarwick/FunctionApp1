using FunctionApp1.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FunctionApp1.Data
{
    public class DataInitialiser
    {
        public static async Task SeedData(TestContext context)
        {
            string employeesJson = File.ReadAllText(".\\Data\\MOCK_DATA.json");
            if (string.IsNullOrEmpty(employeesJson)) return;
            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            List<Employee> employeeList = JsonSerializer.Deserialize<List<Employee>>(employeesJson, options) ?? new List<Employee>();
            await context.Employee.AddRangeAsync(employeeList);
            await context.SaveChangesAsync();
        }
    }
}
