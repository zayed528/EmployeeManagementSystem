using MySql.Data.MySqlClient;

namespace EmployeeManagementSystem
{
    public class UpdateDepartment : Connection
    {
        public string Execute(int employeeId, string newDepartment)
        {
            if (string.IsNullOrWhiteSpace(newDepartment))
            {
                return "Missing or invalid input";
            }

            using MySqlConnection conn = GetConnection();
            conn.Open();

            using MySqlCommand checkCmd = new MySqlCommand("SELECT EmployeeId FROM employee WHERE EmployeeId = @Id", conn);
            checkCmd.Parameters.AddWithValue("@Id", employeeId);

            using MySqlDataReader reader = checkCmd.ExecuteReader();
            if (!reader.HasRows)
            {
                return "ID does not exist";
            }

            reader.Close();

            using MySqlCommand updateCmd = new MySqlCommand(
                "UPDATE employee SET Department = @Department WHERE EmployeeId = @Id", conn);

            updateCmd.Parameters.AddWithValue("@Department", newDepartment);
            updateCmd.Parameters.AddWithValue("@Id", employeeId);

            int rowsAffected = updateCmd.ExecuteNonQuery();
            return rowsAffected > 0 ? "Department updated successfully." : "Update failed.";
        }
    }
}
