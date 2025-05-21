using MySql.Data.MySqlClient;

namespace EmployeeManagementSystem
{
    public class AddEmployee : Connection
    {
        public string Execute(Employee emp)
        {
            if (string.IsNullOrWhiteSpace(emp.FirstName) ||
                string.IsNullOrWhiteSpace(emp.LastName) ||
                string.IsNullOrWhiteSpace(emp.Department) ||
                emp.Salary <= 0)
            {
                return "Missing or invalid input";
            }

            using MySqlConnection conn = GetConnection();
            conn.Open();

            using MySqlCommand checkCmd = new MySqlCommand("SELECT EmployeeId FROM employee WHERE EmployeeId = @Id", conn);
            checkCmd.Parameters.AddWithValue("@Id", emp.EmployeeId);

            using MySqlDataReader reader = checkCmd.ExecuteReader();
            if (reader.HasRows)
            {
                return "ID already exists";
            }

            reader.Close();

            using MySqlCommand insertCmd = new MySqlCommand(
                "INSERT INTO employee (EmployeeId, FirstName, LastName, Department, Salary) " +
                "VALUES (@Id, @FirstName, @LastName, @Department, @Salary)", conn);

            insertCmd.Parameters.AddWithValue("@Id", emp.EmployeeId);
            insertCmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            insertCmd.Parameters.AddWithValue("@LastName", emp.LastName);
            insertCmd.Parameters.AddWithValue("@Department", emp.Department);
            insertCmd.Parameters.AddWithValue("@Salary", emp.Salary);

            int rows = insertCmd.ExecuteNonQuery();
            return rows > 0 ? "Employee added successfully." : "Insertion failed.";
        }
    }
}
