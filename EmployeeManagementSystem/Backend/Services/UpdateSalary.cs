using MySql.Data.MySqlClient;

namespace EmployeeManagementSystem
{
    public class UpdateSalary : Connection
    {
        public string Execute(int employeeId, int newSalary)
        {
            if (newSalary <= 0)
                return "Invalid salary value";

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
                "UPDATE employee SET Salary = @Salary WHERE EmployeeId = @Id", conn);

            updateCmd.Parameters.AddWithValue("@Salary", newSalary);
            updateCmd.Parameters.AddWithValue("@Id", employeeId);

            int rowsAffected = updateCmd.ExecuteNonQuery();
            return rowsAffected > 0 ? "Salary updated successfully." : "Update failed.";
        }
    }
}
