using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    public class GetAllEmployees : Connection
    {
        public List<Employee> Execute()
        {
            List<Employee> employees = new List<Employee>();
            MySqlConnection conn = GetConnection();
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM employee", conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                employees.Add(new Employee
                {
                    EmployeeId = reader.GetInt32("EmployeeId"),

                    FirstName = reader.IsDBNull(reader.GetOrdinal("FirstName"))
                        ? string.Empty
                        : reader.GetString("FirstName"),

                    LastName = reader.IsDBNull(reader.GetOrdinal("LastName"))
                        ? string.Empty
                        : reader.GetString("LastName"),

                    Department = reader.IsDBNull(reader.GetOrdinal("Department"))
                        ? string.Empty
                        : reader.GetString("Department"),

                    Salary = reader.IsDBNull(reader.GetOrdinal("Salary"))
                        ? 0
                        : reader.GetInt32("Salary")
                });
            }

            if (reader != null && !reader.IsClosed) reader.Close();
            if (cmd != null) cmd.Dispose();
            if (conn != null && conn.State == System.Data.ConnectionState.Open) conn.Close();

            return employees;
        }
    }
}
