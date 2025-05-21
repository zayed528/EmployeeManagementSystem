using MySql.Data.MySqlClient;

namespace EmployeeManagementSystem
{
    public class DeleteEmployee : Connection
    {
        public string Execute(int employeeId)
        {
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

            using MySqlCommand deleteCmd = new MySqlCommand(
                "DELETE FROM employee WHERE EmployeeId = @Id", conn);

            deleteCmd.Parameters.AddWithValue("@Id", employeeId);

            int rowsAffected = deleteCmd.ExecuteNonQuery();
            return rowsAffected > 0 ? "Employee deleted successfully." : "Deletion failed.";
        }
    }
}
