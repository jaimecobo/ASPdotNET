using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using SQLiteFromScratch.Models;

namespace SQLiteFromScratch.Controllers
{
    [Route("api/[EmployeesCtrl]")]
    public class EmployeesController : Controller
    {
        [HttpGet]
        public List<Employee> GetData()
        {
            List<Employee> employees = new List<Employee>();

            string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");
            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();
                string sql = $"select * from employees;";
                using (SqliteCommand command = new SqliteCommand(sql, conn))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee newEmployee = new Employee()
                            {
                                Id = reader.GetInt32(0),
                                LastName = reader.GetString(1),
                                FirstName = reader.GetString(2),
                                Title = reader.GetString(3),
                                ReportsTo = reader.GetInt32(4),
                                BirthDate = reader.GetDateTime(5),
                                HireDate = reader.GetDateTime(6),
                                Address = reader.GetString(7),
                                City = reader.GetString(8),
                                State = reader.GetString(9),
                                Country = reader.GetString(10),
                                PostalCode = reader.GetString(11),
                                Phone = reader.GetString(12),
                                Fax = reader.GetString(13),
                                Email = reader.GetString(14),
                               

                            };
                            employees.Add(newEmployee);
                        }
                    }
                }

                conn.Close();
                return employees;
            }

        }
    }
}

