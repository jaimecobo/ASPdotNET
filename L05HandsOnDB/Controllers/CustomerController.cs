using L05HandsOnDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace L05HandsOnDB.Controllers
{
    [Route("api/[Controller]")]

    public class CustomerController : Controller
    {
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