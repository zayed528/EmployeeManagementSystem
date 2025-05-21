document.addEventListener("DOMContentLoaded", () => {
  const form = document.getElementById("update-department-form");

  form.addEventListener("submit", async (e) => {
    e.preventDefault();

    const employeeId = document.getElementById("id").value.trim();
    const newDepartment = document.getElementById("new-department").value.trim();

    if (!employeeId || !newDepartment) {
      alert("Both fields are required.");
      return;
    }

    const payload = {
      employeeId: parseInt(employeeId),
      newDepartment
    };

    try {
      const response = await fetch("http://localhost:5066/api/employee/update-department", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(payload)
      });

      if (response.ok) {
        alert("Department updated successfully.");
        form.reset();
      } else {
        const msg = await response.text();
        alert("Error: " + msg);
      }
    } catch (error) {
      alert("Network error: " + error.message);
    }
  });
});
