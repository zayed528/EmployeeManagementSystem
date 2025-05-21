document.addEventListener("DOMContentLoaded", () => {
  const form = document.getElementById("search-form");
  const resultsSection = document.getElementById("results");
  const resultsTableBody = document.querySelector("#results-table tbody");

  form.addEventListener("submit", async (e) => {
    e.preventDefault();

    const dept = document.getElementById("department-select").value.trim();

    if (!dept) {
      alert("Please select a valid department.");
      return;
    }

    try {
      const response = await fetch(`http://localhost:5066/api/employee/search-department/${dept}`);
      const data = await response.json();

      if (data.status !== "Success") {
        alert("No matching employee(s) found.");
        resultsSection.style.display = "none";
        return;
      }

      resultsTableBody.innerHTML = "";

      data.data.forEach(emp => {
        const row = `
          <tr>
            <td>${emp.employeeId}</td>
            <td>${emp.firstName}</td>
            <td>${emp.lastName}</td>
            <td>${emp.department}</td>
            <td>${emp.salary}</td>
          </tr>
        `;
        resultsTableBody.innerHTML += row;
      });

      resultsSection.style.display = "block";
    } catch (err) {
      alert("Error: " + err.message);
      resultsSection.style.display = "none";
    }
  });
});
