namespace EmployeeManagementSystem{
    public class FindByDepartmentModel
    {
        public string Status { get; set; } = string.Empty;
        public List<Employee> Data { get; set; } = new();
    }
}
