document.addEventListener("DOMContentLoaded", () => {
  const form = document.getElementById("update-name-form");

  form.addEventListener("submit", async (e) => {
    e.preventDefault();

    const employeeId = document.getElementById("id").value.trim();
    const firstName = document.getElementById("new-fname").value.trim();
    const lastName = document.getElementById("new-lname").value.trim();

    if (!employeeId || !firstName || !lastName) {
      alert("All fields are required.");
      return;
    }

    const payload = {
      employeeId: parseInt(employeeId),
      firstName,
      lastName
    };

    try {
      const response = await fetch("http://localhost:5066/api/employee/update-name", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(payload)
      });

      if (response.ok) {
        alert("Name updated successfully.");
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
