using MySql.Data.MySqlClient;

namespace EmployeeManagementSystem
{
    public class UpdateName : Connection
    {
        public string Execute(int employeeId, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                return "Missing or invalid input";

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
                "UPDATE employee SET FirstName = @FirstName, LastName = @LastName WHERE EmployeeId = @Id", conn);

            updateCmd.Parameters.AddWithValue("@FirstName", firstName);
            updateCmd.Parameters.AddWithValue("@LastName", lastName);
            updateCmd.Parameters.AddWithValue("@Id", employeeId);

            int rows = updateCmd.ExecuteNonQuery();
            return rows > 0 ? "Name updated successfully." : "Update failed.";
        }
    }
}
