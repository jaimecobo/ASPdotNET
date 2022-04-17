using L05HandsOnDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace L05HandsOnDB.Controllers
{
    [Route("api/[Controller]")]

    public class EmployeeController : Controller
    {
        [HttpGet]
        public List<Employee> GetData()
        {
            List<Employee> employees = new List<Employee>();
            string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");
            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open(); 

                string sql = $"SELECT * FROM employees WHERE HireDate < '2003-01-01';";

                using (SqliteCommand command = new SqliteCommand(sql, conn))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee newEmployee = new Employee()
                            {
                                EmployeeId = reader.GetInt32(0),
                                LastName = (reader.IsDBNull(1)) ? null : reader.GetString(1),
                                FirstName = (reader.IsDBNull(2)) ? null : reader.GetString(2),
                                Title = (reader.IsDBNull(3)) ? null : reader.GetString(3),
                                ReportsTo = (reader.IsDBNull(4)) ? null : reader.GetInt32(4),
                                BirthDate = reader.GetDateTime(5),
                                HireDate = reader.GetDateTime(6),
                                Address = (reader.IsDBNull(7)) ? null : reader.GetString(7),
                                City = (reader.IsDBNull(8)) ? null : reader.GetString(8),
                                State = (reader.IsDBNull(9)) ? null : reader.GetString(9),
                                Country = (reader.IsDBNull(10)) ? null : reader.GetString(10),
                                PostalCode = (reader.IsDBNull(11)) ? null : reader.GetString(11),
                                Phone = (reader.IsDBNull(12)) ? null : reader.GetString(12),
                                Fax = (reader.IsDBNull(13)) ? null : reader.GetString(13),
                                Email = (reader.IsDBNull(14)) ? null : reader.GetString(14),


                            };
       
                            employees.Add(newEmployee);
                        }
                    }
                    conn.Close();
                }

                return employees;
            }

        }
    }
}