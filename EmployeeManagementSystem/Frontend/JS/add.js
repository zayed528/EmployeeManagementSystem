document.addEventListener("DOMContentLoaded", () => {
  const form = document.querySelector("form");

  form.addEventListener("submit", async (e) => {
    e.preventDefault(); 

    const employee = {
      firstName: document.getElementById("fname").value.trim(),
      lastName: document.getElementById("lname").value.trim(),
      employeeId: document.getElementById("id").value.trim(),
      salary: parseFloat(document.getElementById("salary").value.trim()),
      department: document.getElementById("department-select").value
    };

    try {
      const response = await fetch("http://localhost:5066/api/employee", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(employee)
      });

      if (response.ok) {
        alert("Employee added successfully!");
        form.reset();
        $('#department-select').val('').trigger('change'); 
      } else {
        const errMsg = await response.text();
        alert("Error: " + errMsg);
      }
    } catch (error) {
      alert("Network Error: " + error.message);
    }
  });
});
