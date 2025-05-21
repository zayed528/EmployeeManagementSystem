using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    public class SearchByFirstName : Connection
    {
        public FirstNameSearchModel FindingThroughFirstName(string firstName)
        {
            var result = new FirstNameSearchModel();

            if (string.IsNullOrWhiteSpace(firstName))
            {
                result.Status = "Missing or invalid input";
                return result;
            }

            using MySqlConnection conn = GetConnection();
            conn.Open();

            using MySqlCommand cmd = new MySqlCommand("SELECT * FROM employee WHERE FirstName = @FirstName", conn);
            cmd.Parameters.AddWithValue("@FirstName", firstName);

            using MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Data.Add(new Employee
                {
                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                    FirstName = reader["FirstName"]?.ToString() ?? "",
                    LastName = reader["LastName"]?.ToString() ?? "",
                    Department = reader["Department"]?.ToString() ?? "",
                    Salary = Convert.ToInt32(reader["Salary"] ?? 0)
                });
            }

            result.Status = result.Data.Count == 0 ? "Name does not exist" : "Success";
            return result;
        }
    }
}
