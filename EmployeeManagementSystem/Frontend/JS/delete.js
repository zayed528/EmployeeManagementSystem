document.addEventListener("DOMContentLoaded", () => {
  const form = document.getElementById("delete-form");

  form.addEventListener("submit", async (e) => {
    e.preventDefault();

    const id = document.getElementById("delete-id").value.trim();

    if (!id) {
      alert("Please enter a valid employee ID.");
      return;
    }

    try {
      const response = await fetch(`http://localhost:5066/api/employee/${id}`, {
        method: "DELETE"
      });

      if (response.ok) {
        alert("Employee deleted successfully.");
        form.reset();
      } else {
        const errorMessage = await response.text();
        alert("Error: " + errorMessage);
      }
    } catch (err) {
      alert("Network error: " + err.message);
    }
  });
});
