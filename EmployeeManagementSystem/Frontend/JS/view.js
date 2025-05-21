
document.addEventListener("DOMContentLoaded", () => {
  
  // Fetch data from the backend and display it in the table
  //  we won't use method GET here because GET is the default value of fetch
  fetch("http://localhost:5066/api/employee")
    .then(response => {
      if (!response.ok) {
        throw new Error("Failed to fetch employees");
      }
      return response.json();
    })
    .then(data => {
      const tableBody = document.querySelector("#employeeTable tbody");

      // Populate the table with employee data
      data.forEach(emp => {
        const row = `
          <tr>
            <td>${emp.employeeId}</td>
            <td>${emp.firstName}</td>
            <td>${emp.lastName}</td>
            <td>${emp.department}</td>
            <td>${emp.salary}</td>
          </tr>
        `;
        tableBody.innerHTML += row;
      });

      // Initialize DataTables with customized language setting
      $('#employeeTable').DataTable({
        language: {
          lengthMenu: "Entries _MENU_" // Only display 'Entries [dropdown]' text instead of 'Show Entries'
        }
      });
    })
    .catch(error => {
      alert("Error loading employees: " + error.message);
    });

});
