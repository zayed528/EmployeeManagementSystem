using MySql.Data.MySqlClient;

namespace EmployeeManagementSystem
{
    public class Connection
    {
        protected MySqlConnection GetConnection()
        {
            string connString = "server=localhost;database=employeemanagement;uid=root;password=password;";
            return new MySqlConnection(connString);
        }
    }
}
