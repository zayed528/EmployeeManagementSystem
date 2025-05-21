document.addEventListener("DOMContentLoaded", () => {
  const form = document.getElementById("update-salary-form");

  form.addEventListener("submit", async (e) => {
    e.preventDefault();

    const employeeId = document.getElementById("id").value.trim();
    const newSalary = document.getElementById("new-salary").value.trim();

    if (!employeeId || !newSalary) {
      alert("Both fields are required.");
      return;
    }

    const payload = {
      employeeId: parseInt(employeeId),
      newSalary: parseFloat(newSalary)
    };

    try {
      const response = await fetch("http://localhost:5066/api/employee/update-salary", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(payload)
      });

      if (response.ok) {
        alert("Salary updated successfully.");
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
