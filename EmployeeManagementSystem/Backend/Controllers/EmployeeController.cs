using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // GET: api/employee
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = new GetAllEmployees().Execute();
            return Ok(result);
        }

        // POST: api/employee
        [HttpPost]
        public IActionResult Add([FromBody] Employee emp)
        {
            var result = new AddEmployee().Execute(emp);

            if (result == "ID already exists")
                return Conflict(result);
            return Ok(result);
        }

        // PUT: api/employee/update-name
        [HttpPut("update-name")]
        public IActionResult UpdateName([FromBody] NameUpdateModel data)
        {
            var result = new UpdateName().Execute(data.EmployeeId, data.FirstName, data.LastName);
            return result == "ID does not exist" ? NotFound(result) : Ok(result);
        }

        // PUT: api/employee/update-salary
        [HttpPut("update-salary")]
        public IActionResult UpdateSalary([FromBody] SalaryUpdateModel data)
        {
            var result = new UpdateSalary().Execute(data.EmployeeId, data.NewSalary);
            return result == "ID does not exist" ? NotFound(result) : Ok(result);
        }

        // PUT: api/employee/update-department
        [HttpPut("update-department")]
        public IActionResult UpdateDepartment([FromBody] DepartmentUpdateModel data)
        {
            var result = new UpdateDepartment().Execute(data.EmployeeId, data.NewDepartment);
            return result == "ID does not exist" ? NotFound(result) : Ok(result);
        }

        // DELETE: api/employee/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = new DeleteEmployee().Execute(id);
            return result == "ID does not exist" ? NotFound(result) : Ok(result);
        }

        // GET: api/employee/search-firstname/{firstName}
        [HttpGet("search-firstname/{firstName}")]
        public IActionResult SearchByFirstName(string firstName)
        {
            var result = new SearchByFirstName().FindingThroughFirstName(firstName);

            if (result.Status == "Missing or invalid input" || result.Status == "Name does not exist")
                return NotFound(result);

            return Ok(result);
        }

        // GET: api/employee/search-department/{department}
        [HttpGet("search-department/{department}")]
        public IActionResult SearchByDepartment(string department)
        {
            var result = new SearchByDepartment().FindingThroughDepartment(department);

            if (result.Status == "Missing or invalid input" || result.Status == "Department does not exist")
                return NotFound(result);

            return Ok(result);
        }

    }
}
