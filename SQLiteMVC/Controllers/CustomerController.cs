using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using SQLiteMVC.Models;


namespace SQLiteMVC.Controllers
{
    // MVC is handling the routing for you.
    [Route("api/[Controller]")]

    public class CustomerController : Controller
    {
        // api/database
        [HttpGet]
        public List<Customer> GetData()
        {
            List<Customer> customers = new List<Customer>();
            string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");
            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();

                string sql = $"select * from customers limit 20;";

                using (SqliteCommand command = new SqliteCommand(sql, conn))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        CustomerMapper customerMapper = new(reader);
                        while (reader.Read())
                        {
                            //Customer newCustomer = new Customer()
                            //{

                            //    Id = reader.GetInt32(0),
                            //    FirstName = (reader.IsDBNull(1))?null:reader.GetString(1),
                            //    LastName = (reader.IsDBNull(2)) ? null : reader.GetString(2),
                            //    Company = (reader.IsDBNull(3)) ? null : reader.GetString(3),
                            //    Address = (reader.IsDBNull(4)) ? null : reader.GetString(4),
                            //    City = (reader.IsDBNull(5)) ? null : reader.GetString(5),
                            //    State = (reader.IsDBNull(6)) ? null : reader.GetString(6),
                            //    Country = (reader.IsDBNull(7)) ? null : reader.GetString(7),
                            //    PostalCode = (reader.IsDBNull(8)) ? null : reader.GetString(8),
                            //    Phone = (reader.IsDBNull(9)) ? null : reader.GetString(9),
                            //    Fax = (reader.IsDBNull(10)) ? null : reader.GetString(10),
                            //    Email = (reader.IsDBNull(11)) ? null : reader.GetString(11),
                            //    SupportRepId = reader.GetInt32(12),

                            //};
                            Customer newCustomer = customerMapper.ToCustomer(reader);
                            customers.Add(newCustomer);
                        }
                    }
                    conn.Close();
                }

                return customers;
            }

        }

    }
}