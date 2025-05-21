using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    public class SearchByDepartment : Connection
    {
        public FindByDepartmentModel FindingThroughDepartment(string Department)
        {
            var result = new FindByDepartmentModel();

            if (string.IsNullOrWhiteSpace(Department))
            {
                result.Status = "Missing or invalid input";
                return result;
            }

            using MySqlConnection conn = GetConnection();
            conn.Open();

            using MySqlCommand cmd = new MySqlCommand("SELECT * FROM employee WHERE Department = @Department", conn);
            cmd.Parameters.AddWithValue("@Department", Department);

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

            result.Status = result.Data.Count == 0 ? "Department does not exist" : "Success";
            return result;
        }
    }
}
